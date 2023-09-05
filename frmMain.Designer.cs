namespace prySotoIE
{
    partial class frmMain
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
            this.btnAbrirCarpeta = new System.Windows.Forms.Button();
            this.btnGrabarArchivo = new System.Windows.Forms.Button();
            this.lblRuta = new System.Windows.Forms.Label();
            this.ventanaCarpetas = new System.Windows.Forms.FolderBrowserDialog();
            this.uikl = new System.Windows.Forms.TreeView();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.txtNombreArchivo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAbrirCarpeta
            // 
            this.btnAbrirCarpeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirCarpeta.Location = new System.Drawing.Point(13, 27);
            this.btnAbrirCarpeta.Name = "btnAbrirCarpeta";
            this.btnAbrirCarpeta.Size = new System.Drawing.Size(173, 35);
            this.btnAbrirCarpeta.TabIndex = 0;
            this.btnAbrirCarpeta.Text = "Abrir Navegador Carpeta";
            this.btnAbrirCarpeta.UseVisualStyleBackColor = true;
            this.btnAbrirCarpeta.Click += new System.EventHandler(this.btnAbrirCarpeta_Click);
            // 
            // btnGrabarArchivo
            // 
            this.btnGrabarArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabarArchivo.Location = new System.Drawing.Point(13, 265);
            this.btnGrabarArchivo.Name = "btnGrabarArchivo";
            this.btnGrabarArchivo.Size = new System.Drawing.Size(187, 37);
            this.btnGrabarArchivo.TabIndex = 1;
            this.btnGrabarArchivo.Text = "Grabar Archivo";
            this.btnGrabarArchivo.UseVisualStyleBackColor = true;
            this.btnGrabarArchivo.Click += new System.EventHandler(this.btnGrabarArchivo_Click);
            // 
            // lblRuta
            // 
            this.lblRuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRuta.Location = new System.Drawing.Point(12, 116);
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Size = new System.Drawing.Size(100, 23);
            this.lblRuta.TabIndex = 2;
            this.lblRuta.Text = "Ruta...";
            // 
            // uikl
            // 
            this.uikl.Location = new System.Drawing.Point(248, 27);
            this.uikl.Name = "uikl";
            this.uikl.Size = new System.Drawing.Size(161, 210);
            this.uikl.TabIndex = 3;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(436, 27);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(181, 369);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // txtNombreArchivo
            // 
            this.txtNombreArchivo.Location = new System.Drawing.Point(13, 227);
            this.txtNombreArchivo.Name = "txtNombreArchivo";
            this.txtNombreArchivo.Size = new System.Drawing.Size(136, 20);
            this.txtNombreArchivo.TabIndex = 6;
            // 
            // frmNavegar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(115)))), ((int)(((byte)(159)))));
            this.ClientSize = new System.Drawing.Size(640, 450);
            this.Controls.Add(this.txtNombreArchivo);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.uikl);
            this.Controls.Add(this.lblRuta);
            this.Controls.Add(this.btnGrabarArchivo);
            this.Controls.Add(this.btnAbrirCarpeta);
            this.Name = "frmNavegar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNavegar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAbrirCarpeta;
        private System.Windows.Forms.Button btnGrabarArchivo;
        private System.Windows.Forms.Label lblRuta;
        private System.Windows.Forms.FolderBrowserDialog ventanaCarpetas;
        private System.Windows.Forms.TreeView uikl;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox txtNombreArchivo;
    }
}