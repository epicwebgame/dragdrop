namespace SchoolManagementSystem.WinForms
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.lstSchool1 = new System.Windows.Forms.ListBox();
            this.lstSchool2 = new System.Windows.Forms.ListBox();
            this.lstSchool3 = new System.Windows.Forms.ListBox();
            this.lstResults = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 38);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lstSchool1
            // 
            this.lstSchool1.FormattingEnabled = true;
            this.lstSchool1.Location = new System.Drawing.Point(12, 67);
            this.lstSchool1.Name = "lstSchool1";
            this.lstSchool1.Size = new System.Drawing.Size(203, 368);
            this.lstSchool1.TabIndex = 1;
            // 
            // lstSchool2
            // 
            this.lstSchool2.FormattingEnabled = true;
            this.lstSchool2.Location = new System.Drawing.Point(221, 67);
            this.lstSchool2.Name = "lstSchool2";
            this.lstSchool2.Size = new System.Drawing.Size(203, 368);
            this.lstSchool2.TabIndex = 2;
            // 
            // lstSchool3
            // 
            this.lstSchool3.FormattingEnabled = true;
            this.lstSchool3.Location = new System.Drawing.Point(428, 67);
            this.lstSchool3.Name = "lstSchool3";
            this.lstSchool3.Size = new System.Drawing.Size(203, 368);
            this.lstSchool3.TabIndex = 3;
            // 
            // lstResults
            // 
            this.lstResults.FormattingEnabled = true;
            this.lstResults.Location = new System.Drawing.Point(637, 67);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(572, 368);
            this.lstResults.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 450);
            this.Controls.Add(this.lstResults);
            this.Controls.Add(this.lstSchool3);
            this.Controls.Add(this.lstSchool2);
            this.Controls.Add(this.lstSchool1);
            this.Controls.Add(this.btnAdd);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lstSchool1;
        private System.Windows.Forms.ListBox lstSchool2;
        private System.Windows.Forms.ListBox lstSchool3;
        private System.Windows.Forms.ListBox lstResults;
    }
}

