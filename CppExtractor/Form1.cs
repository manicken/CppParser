using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CppAst;

using System.Text.RegularExpressions;

namespace CppExtractor
{
    public partial class Form1 : Form
    {
        string folder = @"G:\arduino-1.8.13-td1.55\hardware\teensy\avr\libraries\Audio";

        string classRegex = @"(?!enum).*class\b\s\b[A-Za-z_][A-Za-z_0-9]*\b\s*($)?(|:\s*($)?(public|private|protected)\s*($)?\b[^{]*\s*)\s*($)?";
        string fieldVisibilityRegex = @"\s*(public:|private:)";
        string functionRegex = @"\s*(unsigned|signed)?\s*(void|int|byte|char|short|long|float|double|bool)\s+(\w+)\s*(\([^)]*\))\s*";

        public Form1()
        {
            InitializeComponent();
            rtxtRegex.Clear();
            rtxtRegex.AppendText(classRegex + "\n");
            rtxtRegex.AppendText(fieldVisibilityRegex + "\n");
            rtxtRegex.AppendText(functionRegex);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rtxt.Clear();
            string[] files = Directory.GetFiles(folder, "*.h");
            string regex = "";
            for (int i = 0; i < rtxtRegex.Lines.Length; i++) {
                regex += rtxtRegex.Lines[i];
                if (i < rtxtRegex.Lines.Length - 1)
                    regex += "|";
            }
            Regex rxFunctions = new Regex(regex);

            for (int i=0; i < files.Length; i++)
            {
                rtxt.AppendText("********************\n");
                rtxt.AppendText(files[i] + "\n");
                string contents = File.ReadAllText(files[i]);
                MatchCollection func_matches = rxFunctions.Matches(contents);

                if (func_matches.Count > 0)
                {
                    foreach (Match match in func_matches) {
                        string groups = "";
                        /*if (match.Groups.Count > 1)
                        {
                            for (int gi = 1; gi < match.Groups.Count; gi++) {
                                
                                groups += "["+match.Groups[gi].Value+"]";
                            }
                        }*/
                        //rtxt.AppendText("@ " + match.Index + " " + match.Value.Trim() + groups +"\n");
                        rtxt.AppendText(match.Value.Trim() + groups + "\n");
                    }
                }
                rtxt.AppendText("********************\n");
            }
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {



            string[] files = Directory.GetFiles(folder, "*.h");
            CppParserOptions cpo = new CppParserOptions();
            cpo.TargetCpu = CppTargetCpu.ARM;
            cpo.AdditionalArguments.Add("-DLAYOUT_US_ENGLISH");
            cpo.TargetSystem = "mfloat-abi=soft";
            cpo.IncludeFolders.Add(@"G:\arduino-1.8.13-td1.55\hardware\teensy\avr\cores\teensy4");
            cpo.IncludeFolders.Add(@"G:\arduino-1.8.13-td1.55\hardware\tools\arm\arm-none-eabi\include");
            cpo.IncludeFolders.Add(@"G:\arduino-1.8.13-td1.55\hardware\tools\arm\lib\gcc\arm-none-eabi\5.4.1\include");
            cpo.IncludeFolders.Add(@"G:\arduino-1.8.13-td1.55\hardware\tools\arm\arm-none-eabi\include\c++\5.4.1");
            cpo.IncludeFolders.Add(@"G:\arduino-1.8.13-td1.55\hardware\tools\arm\arm-none-eabi\include\c++\5.4.1\arm-none-eabi");

            for (int i = 0; i < files.Length; i++)
            {
                rtxt.AppendText("********************\n");
                var compilation = CppParser.ParseFile(files[i], cpo);
                if (compilation.HasErrors)
                    rtxt.AppendText(files[i] + " have errors\n" + compilation.Diagnostics);
                else
                    rtxt.AppendText(files[i] + "\n");

                foreach (var cppClass in compilation.Classes)
                {
                    if (!cppClass.Name.StartsWith("Audio")) continue;

                    rtxt.AppendText("ClassName: " + cppClass.Name + "\n");

                    foreach (var func in cppClass.Functions)
                    {
                        if (func.Visibility.ToString() != "Public") continue;
                        string parameters = "";
                        foreach (var parameter in func.Parameters)
                            parameters += parameter;

                        rtxt.AppendText(func.Name + " " + parameters + " " + func.Visibility + "\n"); //Console.WriteLine(cppClass);
                    }
                }
                //foreach (var cppFunction in compilation.Functions)
                //rtxt.AppendText(cppFunction + "\n"); //Console.WriteLine(cppClass);
                rtxt.AppendText("********************\n");
            }

        }

        class ClassObj
        {
            public string Name = "";
            public List<string> functions = new List<string>();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            string[] lines = rtxtInput.Lines;
            //List<ClassObj> classes = new List<ClassObj>();

            //ClassObj co = new ClassObj();

            List<string> result = new List<string>();

            for (int li = 0; li < lines.Length; li++)
            {
                string line = lines[li].Trim();
                if (line.StartsWith("class"))
                {
                    line = line.Substring(line.IndexOf(" : public ")+ " : public ".Length);
                    line = line.Substring(0, line.IndexOf(","));
                    result.Add("<br>");
                    result.Add(line +"<br>");
                }
                else if (line.StartsWith("if (isTarget"))
                {
                    line = line.Replace("if (isTarget(msg,addressOffset,\"/", "");
                    line = line.Replace(line.Substring(line.IndexOf("))"), line.IndexOf("//") - line.IndexOf("))") - 1), "").Replace("\"", "");
                    result.Add(line + "<br>");
                }
                else if (line.StartsWith("else if (isTarget"))
                {
                    line = line.Replace("else if (isTarget(msg,addressOffset,\"/", "");
                    line = line.Replace(line.Substring(line.IndexOf("))"), line.IndexOf("//") - line.IndexOf("))") - 1), "").Replace("\"", "");
                    result.Add(line + "<br>");
                }
            }

            rtxt.Lines = result.ToArray();
        }
    }
}
