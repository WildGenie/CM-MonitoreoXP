namespace AdminAudioVideo.CapaPresentacion
{
    partial class PanelDetalles
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
            this.btnCerrar = new System.Windows.Forms.Button();
            this.ctrlVideo = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnright = new System.Windows.Forms.Button();
            this.ctrlAudio = new System.Windows.Forms.Panel();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.lblVideo = new System.Windows.Forms.Label();
            this.lblAudio = new System.Windows.Forms.Label();
            this.videoSourcePlayer1 = new AForge.Controls.VideoSourcePlayer();
            this.ctrlVideo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(297, 326);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 24);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // ctrlVideo
            // 
            this.ctrlVideo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlVideo.Controls.Add(this.videoSourcePlayer1);
            this.ctrlVideo.Controls.Add(this.btnUp);
            this.ctrlVideo.Controls.Add(this.btnHome);
            this.ctrlVideo.Controls.Add(this.btnLeft);
            this.ctrlVideo.Controls.Add(this.btnright);
            this.ctrlVideo.Controls.Add(this.btnDown);
            this.ctrlVideo.Location = new System.Drawing.Point(19, 17);
            this.ctrlVideo.Name = "ctrlVideo";
            this.ctrlVideo.Size = new System.Drawing.Size(353, 211);
            this.ctrlVideo.TabIndex = 6;
            // 
            // btnHome
            // 
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.Image = global::AdminAudioVideo.Properties.Resources.home;
            this.btnHome.Location = new System.Drawing.Point(280, 140);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(27, 27);
            this.btnHome.TabIndex = 10;
            this.btnHome.UseVisualStyleBackColor = true;
            // 
            // btnright
            // 
            this.btnright.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnright.Image = global::AdminAudioVideo.Properties.Resources.right;
            this.btnright.Location = new System.Drawing.Point(313, 140);
            this.btnright.Name = "btnright";
            this.btnright.Size = new System.Drawing.Size(27, 27);
            this.btnright.TabIndex = 8;
            this.btnright.UseVisualStyleBackColor = true;
            // 
            // ctrlAudio
            // 
            this.ctrlAudio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlAudio.Location = new System.Drawing.Point(19, 246);
            this.ctrlAudio.Name = "ctrlAudio";
            this.ctrlAudio.Size = new System.Drawing.Size(353, 74);
            this.ctrlAudio.TabIndex = 7;
            // 
            // btnUp
            // 
            this.btnUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUp.Image = global::AdminAudioVideo.Properties.Resources.up;
            this.btnUp.Location = new System.Drawing.Point(280, 107);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(27, 27);
            this.btnUp.TabIndex = 6;
            this.btnUp.UseVisualStyleBackColor = true;
            // 
            // btnLeft
            // 
            this.btnLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLeft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLeft.Image = global::AdminAudioVideo.Properties.Resources.left;
            this.btnLeft.Location = new System.Drawing.Point(247, 140);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnLeft.Size = new System.Drawing.Size(27, 27);
            this.btnLeft.TabIndex = 9;
            this.btnLeft.UseVisualStyleBackColor = true;
            // 
            // btnDown
            // 
            this.btnDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDown.Image = global::AdminAudioVideo.Properties.Resources.down;
            this.btnDown.Location = new System.Drawing.Point(280, 173);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(27, 27);
            this.btnDown.TabIndex = 7;
            this.btnDown.UseVisualStyleBackColor = true;
            // 
            // lblVideo
            // 
            this.lblVideo.AutoSize = true;
            this.lblVideo.Location = new System.Drawing.Point(26, 6);
            this.lblVideo.Name = "lblVideo";
            this.lblVideo.Size = new System.Drawing.Size(74, 13);
            this.lblVideo.TabIndex = 11;
            this.lblVideo.Text = "Video en linea";
            // 
            // lblAudio
            // 
            this.lblAudio.AutoSize = true;
            this.lblAudio.Location = new System.Drawing.Point(26, 236);
            this.lblAudio.Name = "lblAudio";
            this.lblAudio.Size = new System.Drawing.Size(74, 13);
            this.lblAudio.TabIndex = 12;
            this.lblAudio.Text = "Audio en linea";
            // 
            // videoSourcePlayer1
            // 
            this.videoSourcePlayer1.Location = new System.Drawing.Point(8, 5);
            this.videoSourcePlayer1.Name = "videoSourcePlayer1";
            this.videoSourcePlayer1.Size = new System.Drawing.Size(232, 195);
            this.videoSourcePlayer1.TabIndex = 11;
            this.videoSourcePlayer1.Text = "videoSourcePlayer1";
            this.videoSourcePlayer1.VideoSource = null;
            // 
            // PanelDetalles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 362);
            this.Controls.Add(this.lblAudio);
            this.Controls.Add(this.lblVideo);
            this.Controls.Add(this.ctrlAudio);
            this.Controls.Add(this.ctrlVideo);
            this.Controls.Add(this.btnCerrar);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "PanelDetalles";
            this.Text = "Sucursal en linea";
            this.ctrlVideo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel ctrlVideo;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnright;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Panel ctrlAudio;
        private System.Windows.Forms.Label lblVideo;
        private System.Windows.Forms.Label lblAudio;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer1;
    }
}