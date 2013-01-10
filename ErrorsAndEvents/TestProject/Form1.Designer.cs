namespace TestProject
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
            this.btnErrorLog = new System.Windows.Forms.Button();
            this.btnEventLog = new System.Windows.Forms.Button();
            this.Button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnErrorLog
            // 
            this.btnErrorLog.Location = new System.Drawing.Point(21, 26);
            this.btnErrorLog.Name = "btnErrorLog";
            this.btnErrorLog.Size = new System.Drawing.Size(243, 23);
            this.btnErrorLog.TabIndex = 0;
            this.btnErrorLog.Text = "Create Error Log Entry";
            this.btnErrorLog.UseVisualStyleBackColor = true;
            this.btnErrorLog.Click += new System.EventHandler(this.btnErrorLog_Click);
            // 
            // btnEventLog
            // 
            this.btnEventLog.Location = new System.Drawing.Point(21, 65);
            this.btnEventLog.Name = "btnEventLog";
            this.btnEventLog.Size = new System.Drawing.Size(243, 23);
            this.btnEventLog.TabIndex = 1;
            this.btnEventLog.Text = "Create Event Log Entry";
            this.btnEventLog.UseVisualStyleBackColor = true;
            this.btnEventLog.Click += new System.EventHandler(this.btnEventLog_Click);
            // 
            // Button3
            // 
            this.Button3.Location = new System.Drawing.Point(189, 116);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(75, 23);
            this.Button3.TabIndex = 2;
            this.Button3.Text = "Exit";
            this.Button3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 165);
            this.Controls.Add(this.Button3);
            this.Controls.Add(this.btnEventLog);
            this.Controls.Add(this.btnErrorLog);
            this.Name = "Form1";
            this.Text = "Errors and Events";
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Button btnErrorLog;
        internal System.Windows.Forms.Button btnEventLog;
        internal System.Windows.Forms.Button Button3;
    }
}

