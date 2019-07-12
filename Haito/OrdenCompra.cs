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
    public partial class OrdenCompra : Form
    {
        int idEmpresa = 0;
        int idContacto = 0;
        DateTime fecha = DateTime.Now;
        int idUsuario = 1;
        int idOrdenCompra = 0;
        int idEncabezado = 0;
        public OrdenCompra(int _idOrdenCompra, int _idusuario)
        {
            InitializeComponent();
            if (_idOrdenCompra != 0)
            {
                idOrdenCompra = _idOrdenCompra;
                txtIDFolio.Text = idOrdenCompra.ToString();
            }
            idUsuario = _idusuario;
        }

   

        private void cargarDatosOrdenCompra()
        {
            dsHaitoTableAdapters.obtenerDatosOrdenCompraTableAdapter dcta = new dsHaitoTableAdapters.obtenerDatosOrdenCompraTableAdapter();
            DataTable dtOrdenCompra = dcta.GetData(idOrdenCompra, cbEncabezado.SelectedIndex);

            //agregar todo al datagrid y ocultar las columnas que no se ocupan solo mostrar las que se ocupan
            dgvProductos.DataSource = null;

            if (dtOrdenCompra.Rows.Count == 0)
                return;


            cbEncabezado.SelectedIndex = (int)dtOrdenCompra.Rows[0]["idEncabezado"];
            //encabezado
            cbEmpresa.SelectedValue = (int)dtOrdenCompra.Rows[0]["idEmpresa"];
            cbAtencion.SelectedValue = (int) dtOrdenCompra.Rows[0]["idProveedor"];
            dateFecha.Text = dtOrdenCompra.Rows[0]["fecha"].ToString();
            tbObservaciones.Text = dtOrdenCompra.Rows[0]["observaciones"].ToString();

            //totales
            tbSubtotal.Text = dtOrdenCompra.Rows[0]["subtotal"].ToString();
            tbIVA.Text = dtOrdenCompra.Rows[0]["iva"].ToString();
            tbTotal.Text = dtOrdenCompra.Rows[0]["total"].ToString();

            dgvProductos.DataSource = dtOrdenCompra;

            //oculta las columnas que no nos interesan
            dgvProductos.Columns[0].Visible = false;
            dgvProductos.Columns[1].Visible = false;
            dgvProductos.Columns[2].Visible = false;
            dgvProductos.Columns[3].Visible = false;
            dgvProductos.Columns[4].Visible = false;

            dgvProductos.Columns[5].Visible = false;
            dgvProductos.Columns[10].Visible = false;

            dgvProductos.Columns[12].Visible = false;
            dgvProductos.Columns[13].Visible = false;
            dgvProductos.Columns[14].Visible = false;
            dgvProductos.Columns[15].Visible = false;
            dgvProductos.Columns[16].Visible = false;
            dgvProductos.Columns[17].Visible = false;
            dgvProductos.Columns[18].Visible = false;

            dgvProductos.Columns[19].Visible = false;
            dgvProductos.Refresh();

        }

        private void OrdenCompra_Load(object sender, EventArgs e)
        {
            //Carga las empresas los contactos y las unidades de medida
            cargarEmpresas();
            cargarContactos(idEmpresa);
            cargarUM();
            cargarEncabezado();
            if (idOrdenCompra != 0)
            {
                cargarDatosOrdenCompra();
               
            }else
            cargarSiguienteFolio();
        }

        private void cargarEncabezado()
        {
            cbEncabezado.DataSource = Enum.GetValues(typeof(encabezado));
            cbEncabezado.SelectedIndex = 0;
        }

        private void cargarSiguienteFolio()
        {
            //cargar el siguiente folio 
            dsHaitoTableAdapters.QueriesTableAdapter qta = new dsHaitoTableAdapters.QueriesTableAdapter();
            txtIDFolio.Text = qta.obtenerSigIDOrdenCompra(cbEncabezado.SelectedIndex).ToString();

        }

        private void cargarUM()
        {
            cbUnidadMedida.DataSource = Enum.GetValues(typeof(unidadMedida));

        }

        private void cargarContactos(int idEmpresa)
        {
            if (idEmpresa == 0)
                return;
            cbAtencion.DataSource = null;
            dsHaitoTableAdapters.obtenerProveedoresActivosTableAdapter cata = new dsHaitoTableAdapters.obtenerProveedoresActivosTableAdapter();
            cbAtencion.DisplayMember = "atencion";
            cbAtencion.ValueMember = "idClienteProveedor";
            cbAtencion.DataSource = cata.GetData(null, idEmpresa);
        }

        private void cargarEmpresas()
        {
            dsHaitoTableAdapters.obtenerEmpresasActivasTableAdapter eata = new dsHaitoTableAdapters.obtenerEmpresasActivasTableAdapter();
            cbEmpresa.DisplayMember = "nombre";
            cbEmpresa.ValueMember = "idEmpresa";
            cbEmpresa.DataSource = eata.GetData(0, true);
        }

       

        private void cbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarContactos((int)cbEmpresa.SelectedValue);
        }

        private void cbAtencion_SelectedIndexChanged(object sender, EventArgs e)
        {
            //poner en la variable el dato del contacto 
            if (cbAtencion.SelectedIndex < 0)
                idContacto = 0;
            else idContacto = (int)cbAtencion.SelectedValue;
        }

        DataTable dtProd;
        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            BuscarElementos busqueda = new BuscarElementos("productos");
            busqueda.ShowDialog();
            int idProducto = busqueda.resultado;
            if (idProducto != 0)
            {
                dsHaitoTableAdapters.obtenerProductosActivosTableAdapter ta = new dsHaitoTableAdapters.obtenerProductosActivosTableAdapter();
                dtProd = ta.GetData(idProducto);
                tbProducto.Text = dtProd.Rows[0]["nombre"].ToString();                    
            }
        }

        private void dgvProductos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //eliminar elemento seleccionado

        }

       

        private void bAgregar_Click(object sender, EventArgs e)
        {
            //al momento de agregar valida que haya un producto, 
            //que las cantidades sean decimales validos
            //que el precio sea valido y que se haya seleccionado una unidad de medida.
            //se van a guardar con el numero de orden de compra que se haya mostrado en el folio superior

            try
            {
                if (valida() != "OK")
                {
                    AutoClosingMessageBox.Show(valida(), "Error", 3000);
                    return;
                }
                else
                {
                    //ingresar en bd o hacer la actualizacion dependiendo si se habia guardado anteriormente
                    dsHaitoTableAdapters.QueriesTableAdapter qta = new dsHaitoTableAdapters.QueriesTableAdapter();
                    qta.InsertarCambiarOrdenCompra(int.Parse(txtIDFolio.Text), idContacto, DateTime.Parse(dateFecha.Text), idUsuario, tbObservaciones.Text.ToUpper(), cbEncabezado.SelectedIndex);
                    int idProducto = int.Parse(dtProd.Rows[0]["idProducto"].ToString());
                    idOrdenCompra = int.Parse(txtIDFolio.Text);
                    qta.InsertarCambiarOrdenCompraDetalle(int.Parse(txtIDFolio.Text), idProducto, cantidad, precio, cbUnidadMedida.Text, false, cbEncabezado.SelectedIndex);
                    cargarDatosOrdenCompra();
                    btnBuscarProducto.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");

            }

        }

        decimal cantidad = 0.00M;
        decimal precio = 0.00M;

        private string valida()
        {
            string valida = "OK";

            //if (cbAtencion.SelectedIndex < 0)
            //{
            //    valida = "Debe seleccionar un cliente";
            //    return valida;
            //}

            if (tbProducto.Text.Trim() == "")
            {
                valida = "Debe seleccionar un producto";
                return valida;
            }

            decimal.TryParse(tbCantidad.Text, out cantidad);
            if(cantidad== 0)
            {
                valida = "Ingrese una cantidad valida";
                return valida;
            }
            decimal.TryParse(tbPrecio.Text, out precio);
            if (precio == 0)
            {
                valida = "Ingrese un precio valido";
                    return valida;
            }
            if (cbUnidadMedida.SelectedIndex < 0)
            {
                valida = "Seleccione una unidad de medida";
                return valida;
            }
            return valida;
        }

       
        int idProducto;
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //crear un nuevo producto y agregarlo
            ProductoEditar nuevo = new ProductoEditar(0);
            nuevo.ShowDialog();
            idProducto = nuevo.idProducto;
            nuevo.Close();
            if (idProducto != 0)
            {
                try
                {
                    dsHaitoTableAdapters.obtenerProductosActivosTableAdapter ta = new dsHaitoTableAdapters.obtenerProductosActivosTableAdapter();
                    dtProd = ta.GetData(idProducto);
                    tbProducto.Text = dtProd.Rows[0]["nombre"].ToString();
                }
                catch
                {
                    AutoClosingMessageBox.Show("No encontrado", "Error", 3000);
                }
            }            
        }

        private void cbUnidadMedida_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtIDFolio_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void eliminar()
        {
            if (dgvProductos.SelectedRows.Count == 0)
                return;
            int idOrdenCompraDetalle = (int)dgvProductos.SelectedRows[0].Cells["idOrdenCompraDetalle"].Value;
            string nombre = dgvProductos.SelectedRows[0].Cells["nombre"].Value.ToString();
            DialogResult response = MessageBox.Show(string.Format("¿Está seguro de eliminar el producto {0} ?", nombre), "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (response == DialogResult.Yes)
            {
                dsHaitoTableAdapters.QueriesTableAdapter qta = new dsHaitoTableAdapters.QueriesTableAdapter();
                qta.InsertarCambiarOrdenCompraDetalle(idOrdenCompraDetalle, null, null,null,null, true, null);
                AutoClosingMessageBox.Show("Eliminado con éxito", "Éxito", 3000);
                cargarDatosOrdenCompra();
            }
        }

        private void dgvProductos_DoubleClick(object sender, EventArgs e)
        {
            eliminar();


        }

        private void cargarCotizacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //muestra la pantall de busqueda para cargar una cotización anterior
            //esta ya no se modifica solo se puede imprimir
            BuscarElementos buscar = new BuscarElementos("ordenCompra");
            buscar.ShowDialog();
            if (buscar.resultado > 0)
            {
                txtIDFolio.Text = buscar.resultado.ToString();
                idOrdenCompra = buscar.resultado;
                cargarDatosOrdenCompra();
            }
            buscar.Close();
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (idOrdenCompra != 0)
            {
                reporte report = new reporte("ordenCompra", idOrdenCompra, 0);
                report.Show();

            }
        }

        private void bBuscarEmpresa_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbEncabezado_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cambia el folio por encabezado solo si es nuevo 
            if (idOrdenCompra == 0)
            {
                dsHaitoTableAdapters.QueriesTableAdapter qta = new dsHaitoTableAdapters.QueriesTableAdapter();
                txtIDFolio.Text = qta.obtenerSigIDOrdenCompra((int)cbEncabezado.SelectedValue).ToString();
            }
        }

        
    }
}
