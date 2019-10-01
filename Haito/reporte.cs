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
        int idMoneda;
        public reporte(string _reporte, int _id, int _idEncabezado, int _idMoneda)
        {
            InitializeComponent();
            report = _reporte;
            id = _id;
            idEncabezado = _idEncabezado;
            idMoneda = _idMoneda;
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
                dcta.Fill(dt, id, idEncabezado, idMoneda);
                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource datasource = new ReportDataSource("DataSet1", (DataTable)dt);
                reportViewer1.LocalReport.DataSources.Add(datasource);
                reportViewer1.ShowParameterPrompts = false;

                ReportParameter parametro = new ReportParameter("idOrdenCompra", id.ToString());


                ReportParameter parametro2 = new ReportParameter("idEncabezado", idEncabezado.ToString());
                ReportParameter parametro3 = new ReportParameter("idMoneda", idMoneda.ToString());
                reportViewer1.LocalReport.SetParameters(parametro);
                reportViewer1.LocalReport.SetParameters(parametro2);
                reportViewer1.LocalReport.SetParameters(parametro3);


               
              
            }


            if (report == "cotizacion")
            {
                localReport.ReportPath = "cotizacione.rdl";
                dsHaitoTableAdapters.obtenerDatosCotizacionTableAdapter dcta = new dsHaitoTableAdapters.obtenerDatosCotizacionTableAdapter();
                dsHaito.obtenerDatosCotizacionDataTable dt = new dsHaito.obtenerDatosCotizacionDataTable();
                dcta.Fill(dt, id, idEncabezado, idMoneda);
                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource datasource = new ReportDataSource("DataSet1", (DataTable)dt);
                reportViewer1.LocalReport.DataSources.Add(datasource);
                reportViewer1.ShowParameterPrompts = false;

                ReportParameter parametro = new ReportParameter("idCotizacion", id.ToString());
                ReportParameter parametro2 = new ReportParameter("idEncabezado", idEncabezado.ToString());
                ReportParameter parametro3 = new ReportParameter("idMoneda", idMoneda.ToString());
                reportViewer1.LocalReport.SetParameters(parametro);
                reportViewer1.LocalReport.SetParameters(parametro2);
                reportViewer1.LocalReport.SetParameters(parametro3);

            }

            if (report == "remision")
            {
                localReport.ReportPath = "remision.rdl";
                dsHaitoTableAdapters.obtenerDatosRemisionTableAdapter dcta = new dsHaitoTableAdapters.obtenerDatosRemisionTableAdapter();
                dsHaito.obtenerDatosRemisionDataTable dt = new dsHaito.obtenerDatosRemisionDataTable();
                dcta.Fill(dt, id, idEncabezado, idMoneda);
                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource datasource = new ReportDataSource("DataSet1", (DataTable)dt);
                reportViewer1.LocalReport.DataSources.Add(datasource);
                reportViewer1.ShowParameterPrompts = false;

                ReportParameter parametro = new ReportParameter("idRemision", id.ToString());
                ReportParameter parametro2 = new ReportParameter("idEncabezado", idEncabezado.ToString());
                ReportParameter parametro3 = new ReportParameter("idMoneda", idMoneda.ToString());
                reportViewer1.LocalReport.SetParameters(parametro);
                reportViewer1.LocalReport.SetParameters(parametro2);
                reportViewer1.LocalReport.SetParameters(parametro3);

            }


            this.reportViewer1.RefreshReport();
        }
    }
}
