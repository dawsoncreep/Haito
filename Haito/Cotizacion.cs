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
    public partial class Cotizacion : Form
    {
        int idEmpresa = 0;
        int idContacto = 0;
        DateTime fecha = DateTime.Now;
        int idUsuario = 1;
        int idCotizacion = 0;
        int idEncabezado = 0;

        public Cotizacion(int _idCotizacion, int _idUsuario)
        {
            InitializeComponent();
            if (_idCotizacion != 0)
            {
                idCotizacion = _idCotizacion;
                txtIDFolio.Text = idCotizacion.ToString();
            }
            idUsuario=_idUsuario;
        }

   

        private void cargarDatosCotizacion()
        {
            try
            {
                dsHaitoTableAdapters.obtenerDatosCotizacionTableAdapter dcta = new dsHaitoTableAdapters.obtenerDatosCotizacionTableAdapter();
                DataTable dtCotizacion = dcta.GetData(idCotizacion, idEncabezado);

                //agregar todo al datagrid y ocultar las columnas que no se ocupan solo mostrar las que se ocupan
                dgvProductos.DataSource = null;

                if (dtCotizacion.Rows.Count == 0)
                    return;
                try
                {
                    cbEmpresa.SelectedValue = (int)dtCotizacion.Rows[0]["idEmpresa"];
                }
                catch { }

                cbEncabezado.SelectedIndex = (int)dtCotizacion.Rows[0]["idEncabezado"];

                cbAtencion.SelectedValue = (int)dtCotizacion.Rows[0]["idCliente"];
                dateFecha.Text = dtCotizacion.Rows[0]["fecha"].ToString();
                tbObservaciones.Text = dtCotizacion.Rows[0]["observaciones"].ToString();

                //totales
                tbSubtotal.Text = dtCotizacion.Rows[0]["subtotal"].ToString();
                tbIVA.Text = dtCotizacion.Rows[0]["iva"].ToString();
                tbTotal.Text = dtCotizacion.Rows[0]["total"].ToString();

                dgvProductos.DataSource = dtCotizacion;

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cotizacion_Load(object sender, EventArgs e)
        {
            //Carga las empresas los contactos y las unidades de medida

            cargarEmpresas();
            cargarContactos(idEmpresa);
            cargarUM();
            cargarEncabezados();
            if (idCotizacion != 0)
            {
                cargarDatosCotizacion();
               
            }else
            cargarSiguienteFolio((int)cbEncabezado.SelectedValue);
        }

        private void cargarEncabezados()
        {
            cbEncabezado.DataSource = Enum.GetValues(typeof(encabezado));
            cbEncabezado.SelectedIndex = 0;
        }

        private void cargarSiguienteFolio(int idEncabezado)
        {
            //cargar el siguiente folio 
            dsHaitoTableAdapters.QueriesTableAdapter qta = new dsHaitoTableAdapters.QueriesTableAdapter();
            txtIDFolio.Text = qta.obtenerSigIDCotizacion(idEncabezado).ToString();

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
            dsHaitoTableAdapters.obtenerClientesActivosTableAdapter cata = new dsHaitoTableAdapters.obtenerClientesActivosTableAdapter();
            cbAtencion.DisplayMember = "atencion";
            cbAtencion.ValueMember = "idClienteProveedor";
            cbAtencion.DataSource = cata.GetData(null, idEmpresa);
        }

        private void cargarEmpresas()
        {
            dsHaitoTableAdapters.obtenerEmpresasActivasTableAdapter eata = new dsHaitoTableAdapters.obtenerEmpresasActivasTableAdapter();
            cbEmpresa.DisplayMember = "nombre";
            cbEmpresa.ValueMember = "idEmpresa";
            cbEmpresa.DataSource = eata.GetData(0, false);
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
            //se van a guardar con el numero de cotizacion que se haya mostrado en el folio superior

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
                    qta.InsertarCambiarCotizacion(int.Parse(txtIDFolio.Text), idContacto, DateTime.Parse(dateFecha.Text), idUsuario, tbObservaciones.Text.ToUpper(), cbEncabezado.SelectedIndex);
                    int idProducto = int.Parse(dtProd.Rows[0]["idProducto"].ToString());
                    idCotizacion = int.Parse(txtIDFolio.Text);
                    qta.InsertarCambiarCotizacionDetalle(int.Parse(txtIDFolio.Text), idProducto, cantidad, precio, cbUnidadMedida.Text 
                        , cbEncabezado.SelectedIndex, false);
                    cargarDatosCotizacion();
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

            if (cbAtencion.SelectedIndex < 0)
            {
                valida = "Debe seleccionar un cliente";
                return valida;
            }

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

        private void eliminar()
        {
            if (dgvProductos.SelectedRows.Count == 0)
                return;
            int idcotizacionDetalle = (int)dgvProductos.SelectedRows[0].Cells["idCotizacionDetalle"].Value;
            string nombre = dgvProductos.SelectedRows[0].Cells["nombre"].Value.ToString();
            DialogResult response = MessageBox.Show(string.Format("¿Está seguro de eliminar el producto {0} ?", nombre), "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (response == DialogResult.Yes)
            {
                dsHaitoTableAdapters.QueriesTableAdapter qta = new dsHaitoTableAdapters.QueriesTableAdapter();
                qta.InsertarCambiarCotizacionDetalle(idcotizacionDetalle, null, null,null,null,null, true);
                AutoClosingMessageBox.Show("Eliminado con éxito", "Éxito", 3000);
                cargarDatosCotizacion();
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
            BuscarElementos buscar = new BuscarElementos("cotizacion");
            buscar.ShowDialog();
            if (buscar.resultado > 0)
            {
                txtIDFolio.Text = buscar.resultado.ToString();
                idCotizacion = buscar.resultado;
                idEncabezado = buscar.idEncabezado;
                cargarDatosCotizacion();
            }
            buscar.Close();
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ( idCotizacion != 0){
                reporte report = new reporte("cotizacion", idCotizacion, (int) cbEncabezado.SelectedValue);
                report.Show();

            }
        }

        private void bBuscarEmpresa_Click(object sender, EventArgs e)
        {
            BuscarElementos buscar = new BuscarElementos("empresa");
            buscar.ShowDialog();
            if (buscar.resultado != 0)
            {
                cbEmpresa.SelectedValue = buscar.resultado;
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbAtencion.SelectedIndex < 0)
                {
                    AutoClosingMessageBox.Show("Debe seleccionar un cliente", "Valida", 2000);
                    return;
                }

                else
                {
                    //ingresar en bd o hacer la actualizacion dependiendo si se habia guardado anteriormente
                    dsHaitoTableAdapters.QueriesTableAdapter qta = new dsHaitoTableAdapters.QueriesTableAdapter();
                    qta.InsertarCambiarCotizacion(int.Parse(txtIDFolio.Text), idContacto, DateTime.Parse(dateFecha.Text), idUsuario, tbObservaciones.Text.ToUpper(), (int) cbEncabezado.SelectedValue);

                    AutoClosingMessageBox.Show("Ingreso correcto", "Cotización", 2000);
                }
            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
        }

        private void tbObservaciones_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbEncabezado_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cambia el folio por encabezado solo si es nuevo 
            if (idCotizacion == 0)
            {
                dsHaitoTableAdapters.QueriesTableAdapter qta = new dsHaitoTableAdapters.QueriesTableAdapter();
                txtIDFolio.Text = qta.obtenerSigIDCotizacion((int)cbEncabezado.SelectedValue).ToString();
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
        
    }
}
