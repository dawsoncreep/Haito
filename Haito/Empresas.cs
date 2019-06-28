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
    public partial class Empresas : Form
    {
        public Empresas()
        {
            InitializeComponent();
        }

        private void Empresas_Load(object sender, EventArgs e)
        {
            cargarEmpresas();
        }

        private void cargarEmpresas()
        {
            empresasDataGridView.DataSource = null;
            empresasDataGridView.Refresh();
            dsHaitoTableAdapters.obtenerEmpresasActivasTableAdapter eta = new dsHaitoTableAdapters.obtenerEmpresasActivasTableAdapter();
            empresasDataGridView.DataSource = eta.GetData(0);
            empresasDataGridView.Columns[2].Visible = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            EmpresasEditar nuevo = new EmpresasEditar(0);
            nuevo.ShowDialog();
            cargarEmpresas();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (empresasDataGridView.SelectedRows.Count == 0)
                return;
            int idProductoEditar = (int)empresasDataGridView.SelectedRows[0].Cells["idEmpresa"].Value;
            EmpresasEditar nuevo = new EmpresasEditar(idProductoEditar);
            nuevo.ShowDialog();
            cargarEmpresas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (empresasDataGridView.SelectedRows.Count == 0)
                return;
            int idEmpresaEliminar = (int)empresasDataGridView.SelectedRows[0].Cells["idEmpresa"].Value;
            string nombre = empresasDataGridView.SelectedRows[0].Cells["nombre"].Value.ToString();
            DialogResult response = MessageBox.Show(string.Format("¿Está seguro de eliminar la empresa {0} ?", nombre), "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (response == DialogResult.Yes)
            {
                dsHaitoTableAdapters.QueriesTableAdapter qta = new dsHaitoTableAdapters.QueriesTableAdapter();
                qta.InsertarCambiarEmpresa(idEmpresaEliminar, "", true);
                AutoClosingMessageBox.Show("Eliminado con éxito", "Éxito", 3000);
                cargarEmpresas();
            }
        }


    }
}
