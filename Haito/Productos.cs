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
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarProductos();
        }

        private void cargarProductos()
        {
            productoDataGridView.DataSource = null;
            productoDataGridView.Refresh();
            dsHaitoTableAdapters.obtenerProductosActivosTableAdapter pta = new dsHaitoTableAdapters.obtenerProductosActivosTableAdapter();
            // DataTable dt = new DataTable();
            productoDataGridView.DataSource = pta.GetData(0);
            //ocultar las columnas que no se deben de ver
            productoDataGridView.Columns[2].Visible = false;
            productoDataGridView.Columns[3].Visible = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ProductoEditar nuevo = new ProductoEditar(0);
            nuevo.ShowDialog();
            nuevo.Close();
            cargarProductos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (productoDataGridView.SelectedRows.Count == 0)
                return;
            int idProductoEditar = (int)productoDataGridView.SelectedRows[0].Cells["idProducto"].Value;
            ProductoEditar nuevo = new ProductoEditar(idProductoEditar);
            nuevo.ShowDialog();
            nuevo.Close();
            cargarProductos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (productoDataGridView.SelectedRows.Count == 0)
                return;
            int idProductoEliminar = (int)productoDataGridView.SelectedRows[0].Cells["idProducto"].Value;
            string nombre = productoDataGridView.SelectedRows[0].Cells["nombre"].Value.ToString();
            DialogResult response = MessageBox.Show(string.Format("¿Está seguro de eliminar el producto {0} ?", nombre), "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (response == DialogResult.Yes)
            {
                dsHaitoTableAdapters.QueriesTableAdapter qta = new dsHaitoTableAdapters.QueriesTableAdapter();
                qta.InsertarCambiarProducto(idProductoEliminar, null, "", true);
                AutoClosingMessageBox.Show("Eliminado con éxito", "Éxito", 3000);
                cargarProductos();
            }
        }


       
    }
}
