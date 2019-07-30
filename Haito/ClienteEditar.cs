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
    public partial class ClienteEditar : Form
    {
        int idCliente;
        bool cliente;
        public ClienteEditar(int _idCliente, bool _cliente)
        {
            InitializeComponent();
            idCliente = _idCliente;
            cliente = _cliente;
        }
        
  
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cbEmpresa.SelectedValue == null)
            {
                AutoClosingMessageBox.Show("Debe seleccionar una empresa dada de alta.", "ERROR", 3000);
                return;
            }
            
            dsHaitoTableAdapters.QueriesTableAdapter qta = new dsHaitoTableAdapters.QueriesTableAdapter();
            qta.InsertarCambiarClienteProveedor(idCliente, (int)cbEmpresa.SelectedValue, tbAtencion.Text.ToUpper(), tbCelular.Text.ToUpper(),
                tbTel1.Text.ToUpper(), tbTel2.Text.ToUpper(), tbCorreo.Text.ToUpper(), tbDiasCredito.Text.ToUpper(), tbDomicilio.Text.ToUpper(), tbPuesto.Text.ToUpper(), tbRFC.Text.ToUpper(), cliente
                , tbCodigoPostal.Text, false);
            AutoClosingMessageBox.Show("Insertado con exito", "Éxito", 3000);
            this.Close();
        }

        private void ClienteEditar_Load(object sender, EventArgs e)
        {
            //carga los datos que esten en las empresas
            dsHaitoTableAdapters.obtenerEmpresasActivasTableAdapter eata = new dsHaitoTableAdapters.obtenerEmpresasActivasTableAdapter();

            cbEmpresa.ValueMember = "idEmpresa";
            cbEmpresa.DisplayMember = "nombre";
            cbEmpresa.DataSource = eata.GetData(0,null);
            
            if (idCliente == 0)//nuevo producto carga el id del producto que sigue
            {
                //saca el ultimo ID para asignar el siguiente
                dsHaitoTableAdapters.QueriesTableAdapter qta = new dsHaitoTableAdapters.QueriesTableAdapter();
                idCliente = (int)qta.obtenerSigIDCliente();
                txtID.Text = idCliente.ToString();
            }
            else //carga los datos del producto que se va a modificar
            {
                DataTable dt;
                if (cliente)
                {
                    dsHaitoTableAdapters.obtenerClientesActivosTableAdapter cata = new dsHaitoTableAdapters.obtenerClientesActivosTableAdapter();
                    dt = cata.GetData(idCliente, null);
                }
                else
                {
                    dsHaitoTableAdapters.obtenerProveedoresActivosTableAdapter cata = new dsHaitoTableAdapters.obtenerProveedoresActivosTableAdapter();
                    dt = cata.GetData(idCliente, null);
                }

                txtID.Text = dt.Rows[0]["idClienteProveedor"].ToString();
                cbEmpresa.SelectedValue = dt.Rows[0]["idEmpresa"].ToString();
                tbAtencion.Text = dt.Rows[0]["atencion"].ToString();
                tbCelular.Text = dt.Rows[0]["celular"].ToString();
                tbTel1.Text = dt.Rows[0]["telefono"].ToString();
                tbTel2.Text = dt.Rows[0]["telefono2"].ToString();
                tbCorreo.Text = dt.Rows[0]["correo"].ToString();
                tbDiasCredito.Text = dt.Rows[0]["diasCredito"].ToString();
                tbDomicilio.Text = dt.Rows[0]["domicilio"].ToString();
                tbPuesto.Text = dt.Rows[0]["puestoArea"].ToString();
                tbRFC.Text = dt.Rows[0]["rfc"].ToString();
                tbCodigoPostal.Text = dt.Rows[0]["codigoPostal"].ToString();

                /*
                 * [idClienteProveedor] [int] NOT NULL,
                    [idEmpresa] [int] NOT NULL,
                    [atencion] [nvarchar](500) NOT NULL,
                    [celular] [nvarchar](50) NULL,
                    [telefono] [nvarchar](50) NULL,
                    [telefono2] [nvarchar](50) NULL,
                    [correo] [nvarchar](100) NULL,
                    [diasCredito] [nvarchar](100) NULL,
                    [domicilio] [nvarchar](max) NULL,
                    [puestoArea] [nvarchar](100) NULL,
                    [RFC] [nvarchar](13) NULL,
                    [cliente] [bit] NOT NULL,
                    [codigoPostal] [nvarchar](8) NULL,
                 */
            }
           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

     
    }
}
