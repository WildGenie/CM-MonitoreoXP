namespace AdminAudioVideo.CapaPresentacion
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnuPrincipal = new System.Windows.Forms.MenuStrip();
            this.mnuItemArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.spCont = new System.Windows.Forms.SplitContainer();
            this.spCont.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuPrincipal
            // 
            this.mnuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnuPrincipal.Name = "mnuPrincipal";
            this.mnuPrincipal.Size = new System.Drawing.Size(1217, 24);
            this.mnuPrincipal.TabIndex = 1;
            this.mnuPrincipal.Text = "menu";
            // 
            // mnuItemArchivo
            // 
            this.mnuItemArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemSalir});
            this.mnuItemArchivo.Name = "mnuItemArchivo";
            this.mnuItemArchivo.Size = new System.Drawing.Size(60, 20);
            this.mnuItemArchivo.Text = "Archivo";
            // 
            // mnuItemSalir
            // 
            this.mnuItemSalir.Name = "mnuItemSalir";
            this.mnuItemSalir.Size = new System.Drawing.Size(96, 22);
            this.mnuItemSalir.Text = "Salir";
            this.mnuItemSalir.Click += new System.EventHandler(this.mnuItemSalir_Click);
            // 
            // spCont
            // 
            this.spCont.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spCont.IsSplitterFixed = true;
            this.spCont.Location = new System.Drawing.Point(12, 27);
            this.spCont.Name = "spCont";
            this.spCont.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spCont.Panel1
            // 
            this.spCont.Panel1.AutoScroll = true;
            // 
            // spCont.Panel2
            // 
            this.spCont.Panel2.AutoScroll = true;
            this.spCont.Size = new System.Drawing.Size(1193, 876);
            this.spCont.SplitterDistance = 435;
            this.spCont.TabIndex = 2;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 915);
            this.Controls.Add(this.spCont);
            this.Controls.Add(this.mnuPrincipal);
            this.MainMenuStrip = this.mnuPrincipal;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monitor de audio y video en sucursales";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.spCont.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem mnuItemArchivo;
        private System.Windows.Forms.ToolStripMenuItem mnuItemSalir;
        private System.Windows.Forms.SplitContainer spCont;
    }
}

