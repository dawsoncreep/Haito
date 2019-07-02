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
    public partial class ProductoEditar : Form
    {
        public int idProducto;
        public ProductoEditar(int _idProducto)
        {
            InitializeComponent();
            idProducto = _idProducto;
        }

        private void ProductoEditar_Load(object sender, EventArgs e)
        {
            //carga los datos que esten en las empresas
            dsHaitoTableAdapters.obtenerEmpresasActivasTableAdapter eata = new dsHaitoTableAdapters.obtenerEmpresasActivasTableAdapter();
            
            cbEmpresa.ValueMember = "idEmpresa";
            cbEmpresa.DisplayMember = "nombre";
            cbEmpresa.DataSource = eata.GetData(0);
           

            if (idProducto == 0)//nuevo producto carga el id del producto que sigue
            {
                //saca el ultimo ID para asignar el siguiente
                dsHaitoTableAdapters.QueriesTableAdapter qta = new dsHaitoTableAdapters.QueriesTableAdapter();
                idProducto = (int)qta.obtenerSigIDProducto();
                txtID.Text = idProducto.ToString();
            }
            else //carga los datos del producto que se va a modificar
            {
                dsHaitoTableAdapters.obtenerProductosActivosTableAdapter pata = new dsHaitoTableAdapters.obtenerProductosActivosTableAdapter();
                DataTable dt = pata.GetData(idProducto);
                txtID.Text = dt.Rows[0]["idProducto"].ToString();
                txtNombre.Text = dt.Rows[0]["nombre"].ToString();
                cbEmpresa.SelectedValue = dt.Rows[0]["idEmpresa"].ToString();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() == "")
            {
                return;
            }

            dsHaitoTableAdapters.QueriesTableAdapter qta = new dsHaitoTableAdapters.QueriesTableAdapter();
            qta.InsertarCambiarProducto(idProducto, (int)cbEmpresa.SelectedValue, txtNombre.Text, false);
            AutoClosingMessageBox.Show("Insertado con exito", "Éxito", 3000);
            this.Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
