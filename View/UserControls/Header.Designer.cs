namespace View.UserControls
{
    partial class Header
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private MaterialSkin.Controls.MaterialButton btnThemeSwitch;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnThemeSwitch = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // btnThemeSwitch
            // 
            this.btnThemeSwitch.AutoSize = true;
            this.btnThemeSwitch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnThemeSwitch.Depth = 0;
            this.btnThemeSwitch.Icon = null; // Puedes asignar un icono si lo deseas
            this.btnThemeSwitch.Location = new System.Drawing.Point(10, 10);
            this.btnThemeSwitch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnThemeSwitch.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnThemeSwitch.Name = "btnThemeSwitch";
            this.btnThemeSwitch.Size = new System.Drawing.Size(36, 36);
            this.btnThemeSwitch.TabIndex = 0;
            this.btnThemeSwitch.Text = "Switch Theme";
            this.btnThemeSwitch.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained; // Estilo de botón
            this.btnThemeSwitch.UseAccentColor = false; // Estilo de color
            this.btnThemeSwitch.UseVisualStyleBackColor = true;
            this.btnThemeSwitch.Click += new System.EventHandler(this.btnThemeSwitch_Click);
            // 
            // Header
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnThemeSwitch);
            this.Name = "Header";
            this.Size = new System.Drawing.Size(200, 50);
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        #endregion
    }
}
