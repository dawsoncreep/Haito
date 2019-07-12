using Microsoft.Reporting.WinForms;
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
    public partial class reporte : Form
    {
        string report;
        int id;
        int idEncabezado;
        public reporte(string _reporte, int _id, int _idEncabezado)
        {
            InitializeComponent();
            report = _reporte;
            id = _id;
            idEncabezado = _idEncabezado;
        }

        private void reporte_Load(object sender, EventArgs e)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;

            LocalReport localReport = reportViewer1.LocalReport;

            
            reportViewer1.LocalReport.Refresh();

            if (report == "ordenCompra")
            {
                localReport.ReportPath = "ordenCompra.rdl";

                dsHaitoTableAdapters.obtenerDatosOrdenCompraTableAdapter dcta = new dsHaitoTableAdapters.obtenerDatosOrdenCompraTableAdapter();
                dsHaito.obtenerDatosOrdenCompraDataTable dt = new dsHaito.obtenerDatosOrdenCompraDataTable();
                dcta.Fill(dt, id, idEncabezado );
                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource datasource = new ReportDataSource("DataSet1", (DataTable)dt);
                reportViewer1.LocalReport.DataSources.Add(datasource);
                reportViewer1.ShowParameterPrompts = false;

                ReportParameter parametro = new ReportParameter("idOrdenCompra", id.ToString());
                reportViewer1.LocalReport.SetParameters(parametro);
               
              
            }


            if (report == "cotizacion")
            {
                localReport.ReportPath = "cotizacione.rdl";
                dsHaitoTableAdapters.obtenerDatosCotizacionTableAdapter dcta = new dsHaitoTableAdapters.obtenerDatosCotizacionTableAdapter();
                dsHaito.obtenerDatosCotizacionDataTable dt = new dsHaito.obtenerDatosCotizacionDataTable();
                dcta.Fill(dt, id, idEncabezado);
                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource datasource = new ReportDataSource("DataSet1", (DataTable)dt);
                reportViewer1.LocalReport.DataSources.Add(datasource);
                reportViewer1.ShowParameterPrompts = false;

                ReportParameter parametro = new ReportParameter("idCotizacion", id.ToString());
                reportViewer1.LocalReport.SetParameters(parametro);
            }
            this.reportViewer1.RefreshReport();
        }
    }
}
