namespace Testing
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
            this.ptbxSource = new System.Windows.Forms.PictureBox();
            this.rtxbString = new System.Windows.Forms.RichTextBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnTraining = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ptbxSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ptbxSource
            // 
            this.ptbxSource.Location = new System.Drawing.Point(12, 12);
            this.ptbxSource.Name = "ptbxSource";
            this.ptbxSource.Size = new System.Drawing.Size(281, 315);
            this.ptbxSource.TabIndex = 0;
            this.ptbxSource.TabStop = false;
            // 
            // rtxbString
            // 
            this.rtxbString.Location = new System.Drawing.Point(299, 12);
            this.rtxbString.Name = "rtxbString";
            this.rtxbString.Size = new System.Drawing.Size(297, 286);
            this.rtxbString.TabIndex = 1;
            this.rtxbString.Text = "";
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(521, 304);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 2;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(440, 304);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnTraining
            // 
            this.btnTraining.Location = new System.Drawing.Point(359, 304);
            this.btnTraining.Name = "btnTraining";
            this.btnTraining.Size = new System.Drawing.Size(75, 23);
            this.btnTraining.TabIndex = 3;
            this.btnTraining.Text = "Training";
            this.btnTraining.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 339);
            this.Controls.Add(this.btnTraining);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.rtxbString);
            this.Controls.Add(this.ptbxSource);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ptbxSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbxSource;
        private System.Windows.Forms.RichTextBox rtxbString;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnTraining;
    }
}

