namespace CppExtractor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.rtxt = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rtxtRegex = new System.Windows.Forms.RichTextBox();
            this.rtxtInput = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(12, 12);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(125, 23);
            this.btnSelectFolder.TabIndex = 0;
            this.btnSelectFolder.Text = "parse using CppAst";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // rtxt
            // 
            this.rtxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxt.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxt.Location = new System.Drawing.Point(605, 108);
            this.rtxt.Name = "rtxt";
            this.rtxt.Size = new System.Drawing.Size(681, 330);
            this.rtxt.TabIndex = 1;
            this.rtxt.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(158, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "parse using regex";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rtxtRegex
            // 
            this.rtxtRegex.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtRegex.Location = new System.Drawing.Point(12, 42);
            this.rtxtRegex.Name = "rtxtRegex";
            this.rtxtRegex.Size = new System.Drawing.Size(984, 60);
            this.rtxtRegex.TabIndex = 4;
            this.rtxtRegex.Text = resources.GetString("rtxtRegex.Text");
            // 
            // rtxtInput
            // 
            this.rtxtInput.Location = new System.Drawing.Point(15, 109);
            this.rtxtInput.Name = "rtxtInput";
            this.rtxtInput.Size = new System.Drawing.Size(576, 328);
            this.rtxtInput.TabIndex = 5;
            this.rtxtInput.Text = resources.GetString("rtxtInput.Text");
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(347, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "single parse";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.rtxtInput);
            this.Controls.Add(this.rtxtRegex);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rtxt);
            this.Controls.Add(this.btnSelectFolder);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.RichTextBox rtxt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox rtxtRegex;
        private System.Windows.Forms.RichTextBox rtxtInput;
        private System.Windows.Forms.Button button2;
    }
}

