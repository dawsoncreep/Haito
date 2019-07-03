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
    public partial class EmpresasEditar : Form
    {
        int idEmpresa;
        public EmpresasEditar(int _idEmpresa)
        {
            InitializeComponent();
            idEmpresa = _idEmpresa;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            dsHaitoTableAdapters.QueriesTableAdapter qta = new dsHaitoTableAdapters.QueriesTableAdapter();
            qta.InsertarCambiarEmpresa(idEmpresa, txtNombre.Text.ToUpper(), false);
            AutoClosingMessageBox.Show("Insertado con exito", "Éxito", 3000);
            this.Close();
        }

        private void EmpresasEditar_Load(object sender, EventArgs e)
        {

            if (idEmpresa == 0)//nuevo producto carga el id del producto que sigue
            {
                //saca el ultimo ID para asignar el siguiente
                dsHaitoTableAdapters.QueriesTableAdapter qta = new dsHaitoTableAdapters.QueriesTableAdapter();
                idEmpresa = (int)qta.obtenerSigIDEmpresa();
                txtID.Text = idEmpresa.ToString();
            }
            else //carga los datos del producto que se va a modificar
            {
                dsHaitoTableAdapters.obtenerEmpresasActivasTableAdapter pata = new dsHaitoTableAdapters.obtenerEmpresasActivasTableAdapter();
                DataTable dt = pata.GetData(idEmpresa,null);
                txtID.Text = dt.Rows[0]["idEmpresa"].ToString();
                txtNombre.Text = dt.Rows[0]["nombre"].ToString();
               
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
