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
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarUsuarios();
            
        }

        private void cargarUsuarios()
        {
            usuarioDataGridView.DataSource = null;
            usuarioDataGridView.Refresh();
            dsHaitoTableAdapters.obtenerUsuariosActivosTableAdapter pta = new dsHaitoTableAdapters.obtenerUsuariosActivosTableAdapter();
            // DataTable dt = new DataTable();
            usuarioDataGridView.DataSource = pta.GetData(0);
            //ocultar las columnas que no se deben de ver
            usuarioDataGridView.Columns[3].Visible = false;
            usuarioDataGridView.Columns[4].Visible = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            UsuarioEditar nuevo = new UsuarioEditar(0);
            nuevo.ShowDialog();
            nuevo.Close();
            cargarUsuarios();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (usuarioDataGridView.SelectedRows.Count == 0)
                return;
            int idUsuarioEditar = (int)usuarioDataGridView.SelectedRows[0].Cells["idUsuario"].Value;
            UsuarioEditar nuevo = new UsuarioEditar(idUsuarioEditar);
            nuevo.ShowDialog();
            nuevo.Close();
            cargarUsuarios();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (usuarioDataGridView.SelectedRows.Count == 0)
                return;
            int idUsuarioEliminar = (int)usuarioDataGridView.SelectedRows[0].Cells["idUsuario"].Value;
            string nombre = usuarioDataGridView.SelectedRows[0].Cells["nombre"].Value.ToString();
            DialogResult response = MessageBox.Show(string.Format("¿Está seguro de eliminar el usuario {0} ?", nombre), "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (response == DialogResult.Yes)
            {
                dsHaitoTableAdapters.QueriesTableAdapter qta = new dsHaitoTableAdapters.QueriesTableAdapter();
                qta.InsertarCambiarUsuario(idUsuarioEliminar, null, "","", true);
                AutoClosingMessageBox.Show("Eliminado con éxito", "Éxito", 3000);
                cargarUsuarios();
            }
        }

        private void bSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


       
    }
}
