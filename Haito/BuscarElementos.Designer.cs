namespace Haito
{
    partial class BuscarElementos
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
            this.dgvBusqueda = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bAceptar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscarProducto = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusqueda)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvBusqueda
            // 
            this.dgvBusqueda.AllowUserToAddRows = false;
            this.dgvBusqueda.AllowUserToDeleteRows = false;
            this.dgvBusqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBusqueda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBusqueda.Location = new System.Drawing.Point(0, 0);
            this.dgvBusqueda.MultiSelect = false;
            this.dgvBusqueda.Name = "dgvBusqueda";
            this.dgvBusqueda.ReadOnly = true;
            this.dgvBusqueda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBusqueda.Size = new System.Drawing.Size(690, 282);
            this.dgvBusqueda.TabIndex = 0;
            this.dgvBusqueda.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBusqueda_CellContentDoubleClick);
            this.dgvBusqueda.DoubleClick += new System.EventHandler(this.dgvBusqueda_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bAceptar);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtBuscar);
            this.panel1.Controls.Add(this.btnBuscarProducto);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 32);
            this.panel1.TabIndex = 1;
            // 
            // bAceptar
            // 
            this.bAceptar.Location = new System.Drawing.Point(556, 3);
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.Size = new System.Drawing.Size(122, 23);
            this.bAceptar.TabIndex = 39;
            this.bAceptar.Text = "Aceptar";
            this.bAceptar.UseVisualStyleBackColor = true;
            this.bAceptar.Click += new System.EventHandler(this.bAceptar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Ingrese Busqueda:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.AcceptsReturn = true;
            this.txtBuscar.Location = new System.Drawing.Point(122, 3);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(215, 20);
            this.txtBuscar.TabIndex = 37;
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.Location = new System.Drawing.Point(341, 2);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarProducto.TabIndex = 38;
            this.btnBuscarProducto.Text = "Buscar";
            this.btnBuscarProducto.UseVisualStyleBackColor = true;
            this.btnBuscarProducto.Click += new System.EventHandler(this.btnBuscarProducto_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(690, 314);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvBusqueda);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 32);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(690, 282);
            this.panel3.TabIndex = 2;
            // 
            // BuscarElementos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 314);
            this.Controls.Add(this.panel2);
            this.Name = "BuscarElementos";
            this.Text = "Buscar Elementos";
            this.Load += new System.EventHandler(this.BuscarElementos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusqueda)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBusqueda;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscarProducto;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button bAceptar;
    }
}