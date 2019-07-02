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
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
                cargarClientes();
            else
                cargarProveedores();
        }

        private void cargarProveedores()
        {
            proveedoresDataGridView.DataSource = null;
            proveedoresDataGridView.Refresh();
            dsHaitoTableAdapters.obtenerProveedoresActivosTableAdapter cta = new dsHaitoTableAdapters.obtenerProveedoresActivosTableAdapter();
            // DataTable dt = new DataTable();
            proveedoresDataGridView.DataSource = cta.GetData(null, null);
            //ocultar las columnas que no se deben de ver
           proveedoresDataGridView.Columns[2].Visible = false;
           proveedoresDataGridView.Columns[12].Visible = false;
           proveedoresDataGridView.Columns[14].Visible = false;
        }

        private void cargarClientes()
        {
            clienteDataGridView.DataSource = null;
            clienteDataGridView.Refresh();
            dsHaitoTableAdapters.obtenerClientesActivosTableAdapter cta = new dsHaitoTableAdapters.obtenerClientesActivosTableAdapter();
            // DataTable dt = new DataTable();
            clienteDataGridView.DataSource = cta.GetData(null,null);
            //ocultar las columnas que no se deben de ver
            clienteDataGridView.Columns[2].Visible = false;
            clienteDataGridView.Columns[12].Visible = false;
            clienteDataGridView.Columns[14].Visible = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                ClienteEditar nuevo = new ClienteEditar(0, true);
                nuevo.ShowDialog();
                cargarClientes();
            }
            else
            {
                ClienteEditar nuevo = new ClienteEditar(0, false);
                nuevo.ShowDialog();
                cargarProveedores();
            }
      
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                if (clienteDataGridView.SelectedRows.Count == 0)
                    return;
                int idClienteEditar = (int)clienteDataGridView.SelectedRows[0].Cells["idClienteProveedor"].Value;
                ClienteEditar nuevo = new ClienteEditar(idClienteEditar, true);
                nuevo.ShowDialog();
                cargarClientes();
            }
            else
            {
                if (proveedoresDataGridView.SelectedRows.Count == 0)
                    return;
                int idProveedorEditar = (int)proveedoresDataGridView.SelectedRows[0].Cells["idClienteProveedor"].Value;
                ClienteEditar nuevo = new ClienteEditar(idProveedorEditar, false);
                nuevo.ShowDialog();
                cargarProveedores();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                if (clienteDataGridView.SelectedRows.Count == 0)
                    return;
                int idClienteEliminar = (int)clienteDataGridView.SelectedRows[0].Cells["idClienteProveedor"].Value;
                string nombre = clienteDataGridView.SelectedRows[0].Cells["atencion"].Value.ToString();
                DialogResult response = MessageBox.Show(string.Format("¿Está seguro de eliminar el cliente {0} ?", nombre), "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (response == DialogResult.Yes)
                {
                    dsHaitoTableAdapters.QueriesTableAdapter qta = new dsHaitoTableAdapters.QueriesTableAdapter();
                    qta.InsertarCambiarClienteProveedor(idClienteEliminar, null, "", "", "", "", "", "", "", "", "", null, "", true);
                    AutoClosingMessageBox.Show("Eliminado con éxito", "Éxito", 3000);
                    cargarClientes();
                }
            }
            else
            {
                if (proveedoresDataGridView.SelectedRows.Count == 0)
                    return;
                int idProveedorEliminar = (int)proveedoresDataGridView.SelectedRows[0].Cells["idClienteProveedor"].Value;
                string nombre = proveedoresDataGridView.SelectedRows[0].Cells["atencion"].Value.ToString();
                DialogResult response = MessageBox.Show(string.Format("¿Está seguro de eliminar el proveedor {0} ?", nombre), "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (response == DialogResult.Yes)
                {
                    dsHaitoTableAdapters.QueriesTableAdapter qta = new dsHaitoTableAdapters.QueriesTableAdapter();
                    qta.InsertarCambiarClienteProveedor(idProveedorEliminar, null, "", "", "", "", "", "", "", "", "", null, "", true);
                    AutoClosingMessageBox.Show("Eliminado con éxito", "Éxito", 3000);
                    cargarProveedores();
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
                cargarClientes();
            else
                cargarProveedores();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
