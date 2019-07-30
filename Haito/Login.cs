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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            dsHaitoTableAdapters.QueriesTableAdapter qta = new dsHaitoTableAdapters.QueriesTableAdapter();
            try
            {
                int log = (int)qta.tryLogin(txtNombre.Text, txtContrasenia.Text);
                if (log == 0)
                {
                    AutoClosingMessageBox.Show("Ingreso Incorrecto", "Login", 2000);
                    return;
                }
                fMenu home = new fMenu(log);
                home.ShowDialog();
                this.Hide();

            }
            catch { AutoClosingMessageBox.Show("Base de datos no encontrada", "Error", 3000); }

        }

        private void Login_Load(object sender, EventArgs e)
        {
            lVersion.Text = "Versión: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(); 
        
        }

        private void txtContrasenia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dsHaitoTableAdapters.QueriesTableAdapter qta = new dsHaitoTableAdapters.QueriesTableAdapter();
                try
                {
                    int log = (int)qta.tryLogin(txtNombre.Text, txtContrasenia.Text);
                    if (log == 0)
                    {
                        AutoClosingMessageBox.Show("Ingreso Incorrecto", "Login", 2000);
                        return;
                    }
                    fMenu home = new fMenu(log);
                    this.Hide();
                    home.ShowDialog();
                    this.Close();

                }
                catch { }
               
            }
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtContrasenia.Focus();
            }
        }
    }
}
