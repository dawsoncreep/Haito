using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Haito
{
    public partial class BuscarElementos : Form
    {
        string tablaBD;
        public int resultado = 0;
        public int idEncabezado = 0;
        public BuscarElementos(string tabla)
        {
            InitializeComponent();
            tablaBD = tabla;
        }

        private void BuscarElementos_Load(object sender, EventArgs e)
        {           
            realizarBusqueda();            
        }

        private void cargarProductos()
        {
            dsHaitoTableAdapters.busquedaProductosTableAdapter bpta = new dsHaitoTableAdapters.busquedaProductosTableAdapter();
            dgvBusqueda.DataSource = bpta.GetData(txtBuscar.Text);
            dgvBusqueda.Columns[2].Visible = false;
            dgvBusqueda.Columns[3].Visible = false;
            dgvBusqueda.Columns[4].Visible = false;
            dgvBusqueda.Columns[6].Visible = false;

        }

        private void cargarCotizacion()
        {
            dsHaitoTableAdapters.busquedaCotizacionesTableAdapter bcta = new dsHaitoTableAdapters.busquedaCotizacionesTableAdapter();
            dgvBusqueda.DataSource = bcta.GetData(txtBuscar.Text);
            dgvBusqueda.Columns[5].Visible = false;
            dgvBusqueda.Refresh();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            realizarBusqueda();
        }

        private void realizarBusqueda()
        {
            switch (tablaBD)
            {
                case "ordenCompra":
                    cargarOrdenCompra();
                    break;

                case "productos":
                    cargarProductos();
                    break;
                case "cotizacion":
                    cargarCotizacion();
                    break;
                case "remision":
                    cargarRemision();
                    break;


                default:
                    break;
            }
        }

        private void cargarRemision()
        {
            dsHaitoTableAdapters.busquedaRemisionTableAdapter bcta = new dsHaitoTableAdapters.busquedaRemisionTableAdapter();
            dgvBusqueda.DataSource = bcta.GetData(txtBuscar.Text);
            dgvBusqueda.Columns[4].Visible = false;
            dgvBusqueda.Refresh();
        }



        private void cargarOrdenCompra()
        {
            dsHaitoTableAdapters.busquedaOrdenCompraTableAdapter bcta = new dsHaitoTableAdapters.busquedaOrdenCompraTableAdapter();
            dgvBusqueda.DataSource = bcta.GetData(txtBuscar.Text);
            dgvBusqueda.Columns[4].Visible = false;
            dgvBusqueda.Refresh();

        }

        private void cargarEmpresa()
        {
            return;
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                realizarBusqueda();

        }

        private void dgvBusqueda_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            aceptar();
        }

        private void aceptar()
        {
            if (dgvBusqueda.SelectedRows.Count == 0)
                return;

            resultado = (int)dgvBusqueda.SelectedRows[0].Cells[0].Value;
            if (tablaBD == "cotizacion")
                idEncabezado = (int)dgvBusqueda.SelectedRows[0].Cells["idEncabezado"].Value;
            this.Hide();
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            aceptar();

        }

        private void dgvBusqueda_DoubleClick(object sender, EventArgs e)
        {
            aceptar();
        }

        private void bSalir_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}
