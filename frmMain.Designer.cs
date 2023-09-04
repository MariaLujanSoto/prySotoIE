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
            this.btnNavegar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNavegar
            // 
            this.btnNavegar.Location = new System.Drawing.Point(119, 191);
            this.btnNavegar.Name = "btnNavegar";
            this.btnNavegar.Size = new System.Drawing.Size(154, 39);
            this.btnNavegar.TabIndex = 0;
            this.btnNavegar.Text = "NAVEGAR";
            this.btnNavegar.UseVisualStyleBackColor = true;
            this.btnNavegar.Click += new System.EventHandler(this.btnAbrirCarpetas_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(115)))), ((int)(((byte)(159)))));
            this.ClientSize = new System.Drawing.Size(380, 450);
            this.Controls.Add(this.btnNavegar);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNavegar;
    }
}