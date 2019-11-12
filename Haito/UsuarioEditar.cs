using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Haito
{
    public partial class UsuarioEditar : Form
    {
        public int idUsuario;
        public UsuarioEditar(int _idUsuario)
        {
            InitializeComponent();
            idUsuario = _idUsuario;
        }


        private Image convertirByteImagen(byte[] imageSQL)
        {
            Image newImage = null;
            // Obtiene los resultados de la búsqueda

            byte[] imgData = imageSQL;

            // Trata la información de la imagen para poder trasladarla al picturebox
            using (MemoryStream ms = new MemoryStream(imgData, 0, imgData.Length))
            {
                ms.Write(imgData, 0, imgData.Length);
                newImage = Image.FromStream(ms, true);
            }

            pbFirma.Image = newImage;
            newImage = null;

            return newImage;
        }

        private void ProductoEditar_Load(object sender, EventArgs e)
        {
            //carga los datos que esten en las empresas
            dsHaitoTableAdapters.obtenerEmpresasActivasTableAdapter eata = new dsHaitoTableAdapters.obtenerEmpresasActivasTableAdapter();
            cargarRol();
            if (idUsuario == 0)//nuevo usuario carga el id del producto que sigue
            {
                //saca el ultimo ID para asignar el siguiente
                dsHaitoTableAdapters.QueriesTableAdapter qta = new dsHaitoTableAdapters.QueriesTableAdapter();
                idUsuario = (int)qta.obtenerSigIDUsuario();
                txtID.Text = idUsuario.ToString();
               
            }
            else //carga los datos del producto que se va a modificar
            {
                dsHaitoTableAdapters.obtenerUsuariosActivosTableAdapter pata = new dsHaitoTableAdapters.obtenerUsuariosActivosTableAdapter();
                DataTable dt = pata.GetData(idUsuario);
                txtID.Text = dt.Rows[0]["idUsuario"].ToString();
                txtNombre.Text = dt.Rows[0]["nombre"].ToString();
                txtContrasenia.Text = dt.Rows[0]["pass"].ToString();
                cbRol.SelectedItem = int.Parse(dt.Rows[0]["idRol"].ToString());
                try{
                    convertirByteImagen((Byte[]) dt.Rows[0]["imagenFirma"]);
                }catch{}
                txtFirma.Text = dt.Rows[0]["firma"].ToString();
            }
        }
        private void cargarRol()
        {
            cbRol.DataSource = Enum.GetValues(typeof(rol));

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() == "")
            {
                return;
            }
            if (txtContrasenia.Text.Trim() == "")
            {
                return;
            }
            if (txtFirma.Text.Trim() == "")
            {
                return;
            }

            dsHaitoTableAdapters.QueriesTableAdapter qta = new dsHaitoTableAdapters.QueriesTableAdapter();
           
            qta.InsertarCambiarUsuario(idUsuario, (int)cbRol.SelectedValue, txtNombre.Text, txtContrasenia.Text, false, txtFirma.Text, imagen);
            AutoClosingMessageBox.Show("Insertado con exito", "Éxito", 3000);
            this.Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.idUsuario = 0;
            this.Close();
        }

        byte[] imagen;

        private void btnCargar_Click(object sender, EventArgs e)
        {
            //carga la imagen de la firma para el usuario y agregarlo a la bd
            OpenFileDialog BuscarImagen = new OpenFileDialog();
            BuscarImagen.Filter = "Archivo PNG|*.png";

            if (BuscarImagen.ShowDialog() == DialogResult.OK)
            {
                pbFirma.Image = Image.FromFile(BuscarImagen.FileName);
                
            }
            imagen = System.IO.File.ReadAllBytes(BuscarImagen.FileName);
            //txtUrl.Text = BuscarImagen.FileName;

        }

        
    }
}
