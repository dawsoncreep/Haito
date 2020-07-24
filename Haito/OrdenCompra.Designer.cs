namespace Haito
{
    partial class OrdenCompra
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
            this.lAtencion = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbEmpresa = new System.Windows.Forms.ComboBox();
            this.txtIDFolio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbAtencion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateFecha = new System.Windows.Forms.DateTimePicker();
            this.bBuscarEmpresa = new System.Windows.Forms.Button();
            this.bAtencion = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbProducto = new System.Windows.Forms.TextBox();
            this.btnBuscarProducto = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCantidad = new System.Windows.Forms.TextBox();
            this.cbUnidadMedida = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.cbMoneda = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbEncabezado = new System.Windows.Forms.ComboBox();
            this.tbObservaciones = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.tbPrecio = new System.Windows.Forms.TextBox();
            this.bAgregar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.bEliminar = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.tbTotal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbSubtotal = new System.Windows.Forms.TextBox();
            this.tbIVA = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarCotizacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbRetencion = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lAtencion
            // 
            this.lAtencion.AutoSize = true;
            this.lAtencion.Location = new System.Drawing.Point(12, 34);
            this.lAtencion.Name = "lAtencion";
            this.lAtencion.Size = new System.Drawing.Size(49, 13);
            this.lAtencion.TabIndex = 24;
            this.lAtencion.Text = "Atención";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Empresa";
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Location = new System.Drawing.Point(108, 5);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.Size = new System.Drawing.Size(379, 21);
            this.cbEmpresa.TabIndex = 1;
            this.cbEmpresa.SelectedIndexChanged += new System.EventHandler(this.cbEmpresa_SelectedIndexChanged);
            // 
            // txtIDFolio
            // 
            this.txtIDFolio.Location = new System.Drawing.Point(617, 7);
            this.txtIDFolio.Name = "txtIDFolio";
            this.txtIDFolio.ReadOnly = true;
            this.txtIDFolio.Size = new System.Drawing.Size(115, 20);
            this.txtIDFolio.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(582, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Folio";
            // 
            // cbAtencion
            // 
            this.cbAtencion.FormattingEnabled = true;
            this.cbAtencion.Location = new System.Drawing.Point(108, 31);
            this.cbAtencion.Name = "cbAtencion";
            this.cbAtencion.Size = new System.Drawing.Size(379, 21);
            this.cbAtencion.TabIndex = 3;
            this.cbAtencion.SelectedIndexChanged += new System.EventHandler(this.cbAtencion_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(574, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Fecha";
            // 
            // dateFecha
            // 
            this.dateFecha.Location = new System.Drawing.Point(617, 34);
            this.dateFecha.Name = "dateFecha";
            this.dateFecha.Size = new System.Drawing.Size(200, 20);
            this.dateFecha.TabIndex = 5;
            // 
            // bBuscarEmpresa
            // 
            this.bBuscarEmpresa.Location = new System.Drawing.Point(493, 3);
            this.bBuscarEmpresa.Name = "bBuscarEmpresa";
            this.bBuscarEmpresa.Size = new System.Drawing.Size(75, 23);
            this.bBuscarEmpresa.TabIndex = 2;
            this.bBuscarEmpresa.Text = "Buscar";
            this.bBuscarEmpresa.UseVisualStyleBackColor = true;
            this.bBuscarEmpresa.Visible = false;
            this.bBuscarEmpresa.Click += new System.EventHandler(this.bBuscarEmpresa_Click);
            // 
            // bAtencion
            // 
            this.bAtencion.Location = new System.Drawing.Point(493, 29);
            this.bAtencion.Name = "bAtencion";
            this.bAtencion.Size = new System.Drawing.Size(75, 23);
            this.bAtencion.TabIndex = 4;
            this.bAtencion.Text = "Buscar";
            this.bAtencion.UseVisualStyleBackColor = true;
            this.bAtencion.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Agregar Producto";
            // 
            // tbProducto
            // 
            this.tbProducto.AcceptsReturn = true;
            this.tbProducto.Location = new System.Drawing.Point(97, 15);
            this.tbProducto.Name = "tbProducto";
            this.tbProducto.ReadOnly = true;
            this.tbProducto.Size = new System.Drawing.Size(469, 20);
            this.tbProducto.TabIndex = 34;
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.Location = new System.Drawing.Point(572, 13);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarProducto.TabIndex = 7;
            this.btnBuscarProducto.Text = "Buscar";
            this.btnBuscarProducto.UseVisualStyleBackColor = true;
            this.btnBuscarProducto.Click += new System.EventHandler(this.btnBuscarProducto_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(457, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Unidad de Medida";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(97, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Cantidad";
            // 
            // tbCantidad
            // 
            this.tbCantidad.AcceptsReturn = true;
            this.tbCantidad.Location = new System.Drawing.Point(152, 41);
            this.tbCantidad.Name = "tbCantidad";
            this.tbCantidad.Size = new System.Drawing.Size(103, 20);
            this.tbCantidad.TabIndex = 9;
            // 
            // cbUnidadMedida
            // 
            this.cbUnidadMedida.FormattingEnabled = true;
            this.cbUnidadMedida.Location = new System.Drawing.Point(557, 41);
            this.cbUnidadMedida.Name = "cbUnidadMedida";
            this.cbUnidadMedida.Size = new System.Drawing.Size(97, 21);
            this.cbUnidadMedida.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.cmbTipo);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.cbMoneda);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.cbEncabezado);
            this.panel1.Controls.Add(this.tbObservaciones);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbEmpresa);
            this.panel1.Controls.Add(this.lAtencion);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtIDFolio);
            this.panel1.Controls.Add(this.cbAtencion);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dateFecha);
            this.panel1.Controls.Add(this.bAtencion);
            this.panel1.Controls.Add(this.bBuscarEmpresa);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(829, 176);
            this.panel1.TabIndex = 41;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(565, 58);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 13);
            this.label13.TabIndex = 39;
            this.label13.Text = "Moneda";
            // 
            // cbMoneda
            // 
            this.cbMoneda.FormattingEnabled = true;
            this.cbMoneda.Location = new System.Drawing.Point(617, 55);
            this.cbMoneda.Name = "cbMoneda";
            this.cbMoneda.Size = new System.Drawing.Size(200, 21);
            this.cbMoneda.TabIndex = 38;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 58);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 13);
            this.label12.TabIndex = 37;
            this.label12.Text = "Encabezado";
            // 
            // cbEncabezado
            // 
            this.cbEncabezado.FormattingEnabled = true;
            this.cbEncabezado.Location = new System.Drawing.Point(108, 55);
            this.cbEncabezado.Name = "cbEncabezado";
            this.cbEncabezado.Size = new System.Drawing.Size(379, 21);
            this.cbEncabezado.TabIndex = 36;
            this.cbEncabezado.SelectedIndexChanged += new System.EventHandler(this.cbEncabezado_SelectedIndexChanged);
            // 
            // tbObservaciones
            // 
            this.tbObservaciones.AcceptsReturn = true;
            this.tbObservaciones.Location = new System.Drawing.Point(108, 112);
            this.tbObservaciones.Multiline = true;
            this.tbObservaciones.Name = "tbObservaciones";
            this.tbObservaciones.Size = new System.Drawing.Size(709, 58);
            this.tbObservaciones.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Observaciones";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 200);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(829, 317);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Productos";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnNuevo);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.tbPrecio);
            this.panel3.Controls.Add(this.bAgregar);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.tbProducto);
            this.panel3.Controls.Add(this.tbCantidad);
            this.panel3.Controls.Add(this.cbUnidadMedida);
            this.panel3.Controls.Add(this.btnBuscarProducto);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 223);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(823, 91);
            this.panel3.TabIndex = 8;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(653, 13);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 8;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(261, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 42;
            this.label8.Text = "Precio Unitario";
            // 
            // tbPrecio
            // 
            this.tbPrecio.AcceptsReturn = true;
            this.tbPrecio.Location = new System.Drawing.Point(348, 41);
            this.tbPrecio.Name = "tbPrecio";
            this.tbPrecio.Size = new System.Drawing.Size(103, 20);
            this.tbPrecio.TabIndex = 10;
            // 
            // bAgregar
            // 
            this.bAgregar.Location = new System.Drawing.Point(739, 12);
            this.bAgregar.Name = "bAgregar";
            this.bAgregar.Size = new System.Drawing.Size(75, 58);
            this.bAgregar.TabIndex = 12;
            this.bAgregar.Text = "Agregar";
            this.bAgregar.UseVisualStyleBackColor = true;
            this.bAgregar.Click += new System.EventHandler(this.bAgregar_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.dgvProductos);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(823, 298);
            this.panel2.TabIndex = 41;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.tbRetencion);
            this.panel4.Controls.Add(this.bEliminar);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.tbTotal);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.tbSubtotal);
            this.panel4.Controls.Add(this.tbIVA);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 178);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(823, 120);
            this.panel4.TabIndex = 20;
            // 
            // bEliminar
            // 
            this.bEliminar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bEliminar.Location = new System.Drawing.Point(740, 3);
            this.bEliminar.Name = "bEliminar";
            this.bEliminar.Size = new System.Drawing.Size(75, 23);
            this.bEliminar.TabIndex = 50;
            this.bEliminar.Text = "Eliminar";
            this.bEliminar.UseVisualStyleBackColor = false;
            this.bEliminar.Click += new System.EventHandler(this.bEliminar_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(532, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 48;
            this.label11.Text = "Total";
            // 
            // tbTotal
            // 
            this.tbTotal.AcceptsReturn = true;
            this.tbTotal.Location = new System.Drawing.Point(572, 6);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.ReadOnly = true;
            this.tbTotal.Size = new System.Drawing.Size(103, 20);
            this.tbTotal.TabIndex = 49;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(197, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 13);
            this.label9.TabIndex = 46;
            this.label9.Text = "IVA";
            // 
            // tbSubtotal
            // 
            this.tbSubtotal.AcceptsReturn = true;
            this.tbSubtotal.Location = new System.Drawing.Point(83, 6);
            this.tbSubtotal.Name = "tbSubtotal";
            this.tbSubtotal.ReadOnly = true;
            this.tbSubtotal.Size = new System.Drawing.Size(103, 20);
            this.tbSubtotal.TabIndex = 45;
            // 
            // tbIVA
            // 
            this.tbIVA.AcceptsReturn = true;
            this.tbIVA.Location = new System.Drawing.Point(228, 6);
            this.tbIVA.Name = "tbIVA";
            this.tbIVA.ReadOnly = true;
            this.tbIVA.Size = new System.Drawing.Size(103, 20);
            this.tbIVA.TabIndex = 47;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 44;
            this.label10.Text = "Subtotal";
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowDrop = true;
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvProductos.Location = new System.Drawing.Point(0, 0);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(823, 171);
            this.dgvProductos.TabIndex = 0;
            this.dgvProductos.DoubleClick += new System.EventHandler(this.dgvProductos_DoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.cargarCotizacionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(829, 24);
            this.menuStrip1.TabIndex = 43;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guardarToolStripMenuItem,
            this.imprimirToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // imprimirToolStripMenuItem
            // 
            this.imprimirToolStripMenuItem.Name = "imprimirToolStripMenuItem";
            this.imprimirToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.imprimirToolStripMenuItem.Text = "Imprimir";
            this.imprimirToolStripMenuItem.Click += new System.EventHandler(this.imprimirToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // cargarCotizacionToolStripMenuItem
            // 
            this.cargarCotizacionToolStripMenuItem.Name = "cargarCotizacionToolStripMenuItem";
            this.cargarCotizacionToolStripMenuItem.Size = new System.Drawing.Size(161, 20);
            this.cargarCotizacionToolStripMenuItem.Text = "Cargar Orden de Compra...";
            this.cargarCotizacionToolStripMenuItem.Click += new System.EventHandler(this.cargarCotizacionToolStripMenuItem_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(532, 85);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 13);
            this.label14.TabIndex = 41;
            this.label14.Text = "Tipo Cotizacion";
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(618, 82);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(200, 21);
            this.cmbTipo.TabIndex = 40;
            this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.cmbTipo_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(346, 10);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 13);
            this.label15.TabIndex = 52;
            this.label15.Text = "Retención";
            // 
            // tbRetencion
            // 
            this.tbRetencion.AcceptsReturn = true;
            this.tbRetencion.Location = new System.Drawing.Point(408, 6);
            this.tbRetencion.Name = "tbRetencion";
            this.tbRetencion.ReadOnly = true;
            this.tbRetencion.Size = new System.Drawing.Size(103, 20);
            this.tbRetencion.TabIndex = 53;
            // 
            // OrdenCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 517);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "OrdenCompra";
            this.Text = "Orden de Compra";
            this.Load += new System.EventHandler(this.OrdenCompra_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lAtencion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbEmpresa;
        private System.Windows.Forms.TextBox txtIDFolio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbAtencion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateFecha;
        private System.Windows.Forms.Button bBuscarEmpresa;
        private System.Windows.Forms.Button bAtencion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbProducto;
        private System.Windows.Forms.Button btnBuscarProducto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbCantidad;
        private System.Windows.Forms.ComboBox cbUnidadMedida;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbObservaciones;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button bAgregar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imprimirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbPrecio;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbSubtotal;
        private System.Windows.Forms.TextBox tbIVA;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.ToolStripMenuItem cargarCotizacionToolStripMenuItem;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbEncabezado;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbMoneda;
        private System.Windows.Forms.Button bEliminar;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbRetencion;
    }
}