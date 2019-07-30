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
    public partial class fMenu : Form
    {
        public int idUsuario;
        
        public fMenu(int _idUsuario)
        {
            InitializeComponent();
            idUsuario = _idUsuario;
        }

        private void fMenu_Load(object sender, EventArgs e)
        {

        }

        private void clientesProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Clientes().Show();

        }

        private void empresasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Empresas().Show();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Productos().Show();

        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Usuarios().Show();
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cerrar();
        }

        private void cerrar()
        {
            this.Dispose();
        }

        private void fMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            cerrar();
        }

        private void ordenDeCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new OrdenCompra(0, idUsuario).Show();       
        }

        private void cotizaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Cotizacion(0, idUsuario).Show();
        }

        
    }
}
