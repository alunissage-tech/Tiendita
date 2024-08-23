namespace View.UserControls
{
    partial class Header
    {
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnThemeSwitch;
        public System.Windows.Forms.ToolStripButton btnSettings;
        public System.Windows.Forms.ToolStripButton btnProducts;
        public System.Windows.Forms.ToolStripButton btnSales;
        public System.Windows.Forms.ToolStripButton btnInvoices;

        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnThemeSwitch = new System.Windows.Forms.ToolStripButton();
            this.btnSettings = new System.Windows.Forms.ToolStripButton();
            this.btnProducts = new System.Windows.Forms.ToolStripButton();
            this.btnSales = new System.Windows.Forms.ToolStripButton();
            this.btnInvoices = new System.Windows.Forms.ToolStripButton();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnThemeSwitch,
            this.btnProducts,
            this.btnSales,
            this.btnInvoices,
            this.btnSettings});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(526, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip";
            // 
            // btnThemeSwitch
            // 
            this.btnThemeSwitch.Name = "btnThemeSwitch";
            this.btnThemeSwitch.Size = new System.Drawing.Size(86, 22);
            this.btnThemeSwitch.Text = "Cambiar tema";
            // 
            // btnSettings
            // 
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(87, 22);
            this.btnSettings.Text = "Configuración";
            // 
            // btnProducts
            // 
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(65, 22);
            this.btnProducts.Text = "Productos";
            // 
            // btnSales
            // 
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new System.Drawing.Size(45, 22);
            this.btnSales.Text = "Ventas";
            // 
            // btnInvoices
            // 
            this.btnInvoices.Name = "btnInvoices";
            this.btnInvoices.Size = new System.Drawing.Size(55, 22);
            this.btnInvoices.Text = "Facturas";
            // 
            // Header
            // 
            this.Controls.Add(this.toolStrip);
            this.Name = "Header";
            this.Size = new System.Drawing.Size(526, 50);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
