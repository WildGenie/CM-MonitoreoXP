namespace SucursalAudio.admin
{
    partial class administrador
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(administrador));
            this.iconoAdmin = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuTrayIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.configMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFtp = new System.Windows.Forms.Button();
            this.menuTrayIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // iconoAdmin
            // 
            this.iconoAdmin.ContextMenuStrip = this.menuTrayIcon;
            this.iconoAdmin.Icon = ((System.Drawing.Icon)(resources.GetObject("iconoAdmin.Icon")));
            this.iconoAdmin.Text = "iconoAdmin";
            this.iconoAdmin.Visible = true;
            // 
            // menuTrayIcon
            // 
            this.menuTrayIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configMenu});
            this.menuTrayIcon.Name = "menuTrayIcon";
            this.menuTrayIcon.ShowImageMargin = false;
            this.menuTrayIcon.Size = new System.Drawing.Size(127, 26);
            // 
            // configMenu
            // 
            this.configMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.configMenu.Name = "configMenu";
            this.configMenu.Size = new System.Drawing.Size(127, 22);
            this.configMenu.Text = "Configuración";
            this.configMenu.Click += new System.EventHandler(this.configMenu_Click);
            // 
            // btnFtp
            // 
            this.btnFtp.Location = new System.Drawing.Point(139, 23);
            this.btnFtp.Name = "btnFtp";
            this.btnFtp.Size = new System.Drawing.Size(75, 42);
            this.btnFtp.TabIndex = 1;
            this.btnFtp.Text = "Probar FTP";
            this.btnFtp.UseVisualStyleBackColor = true;
            this.btnFtp.Click += new System.EventHandler(this.button1_Click);
            // 
            // administrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 112);
            this.Controls.Add(this.btnFtp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "administrador";
            this.ShowInTaskbar = false;
            this.Text = "Configuración de Audio Bluetooth";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.administrador_FormClosing);
            this.Resize += new System.EventHandler(this.administrador_Resize);
            this.menuTrayIcon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon iconoAdmin;
        private System.Windows.Forms.ContextMenuStrip menuTrayIcon;
        private System.Windows.Forms.ToolStripMenuItem configMenu;
        private System.Windows.Forms.Button btnFtp;
    }
}