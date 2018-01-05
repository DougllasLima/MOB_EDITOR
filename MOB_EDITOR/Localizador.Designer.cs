namespace MOB_EDITOR
{
    partial class Localizador
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
            this.txtLocaliza = new System.Windows.Forms.TextBox();
            this.btLocalizar = new System.Windows.Forms.Button();
            this.lbMobsLocalizados = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtLocaliza
            // 
            this.txtLocaliza.Location = new System.Drawing.Point(28, 31);
            this.txtLocaliza.Name = "txtLocaliza";
            this.txtLocaliza.Size = new System.Drawing.Size(188, 20);
            this.txtLocaliza.TabIndex = 0;
            // 
            // btLocalizar
            // 
            this.btLocalizar.Location = new System.Drawing.Point(222, 29);
            this.btLocalizar.Name = "btLocalizar";
            this.btLocalizar.Size = new System.Drawing.Size(75, 23);
            this.btLocalizar.TabIndex = 1;
            this.btLocalizar.Text = "Localizar";
            this.btLocalizar.UseVisualStyleBackColor = true;
            this.btLocalizar.Click += new System.EventHandler(this.btLocalizar_Click);
            // 
            // lbMobsLocalizados
            // 
            this.lbMobsLocalizados.FormattingEnabled = true;
            this.lbMobsLocalizados.Location = new System.Drawing.Point(28, 78);
            this.lbMobsLocalizados.Name = "lbMobsLocalizados";
            this.lbMobsLocalizados.Size = new System.Drawing.Size(269, 251);
            this.lbMobsLocalizados.TabIndex = 2;
            // 
            // Localizador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 340);
            this.Controls.Add(this.lbMobsLocalizados);
            this.Controls.Add(this.btLocalizar);
            this.Controls.Add(this.txtLocaliza);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Localizador";
            this.Text = "Localizador";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLocaliza;
        private System.Windows.Forms.Button btLocalizar;
        private System.Windows.Forms.ListBox lbMobsLocalizados;
    }
}