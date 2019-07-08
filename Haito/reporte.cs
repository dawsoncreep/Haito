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
        public reporte(string _reporte, int _id)
        {
            InitializeComponent();
            report = _reporte;
            id = _id;
        }

        private void reporte_Load(object sender, EventArgs e)
        {

            reportViewer1.ProcessingMode = ProcessingMode.Remote;

            ServerReport serverReport = reportViewer1.ServerReport;

            // Get a reference to the default credentials  
            System.Net.ICredentials credentials =
                System.Net.CredentialCache.DefaultCredentials;

            // Get a reference to the report server credentials  
            ReportServerCredentials rsCredentials =
                serverReport.ReportServerCredentials;

            // Set the credentials for the server report  
            rsCredentials.NetworkCredentials = credentials;

            // Set the report server URL and report path  
            serverReport.ReportServerUrl =
                new Uri("http://localhost/reportserver");
           

            if (report == "ordenCompra")
            {
               
                reportViewer1.ServerReport.ReportPath = "/ordenCompra";
                ReportParameter parametro = new ReportParameter("idOrdenCompra", id.ToString());
                reportViewer1.ServerReport.SetParameters(parametro);
            }


            if (report == "cotizacion")
            {
                reportViewer1.ServerReport.ReportPath = "/cotizacione";
                ReportParameter parametro = new ReportParameter("idCotizacion", id.ToString());
                reportViewer1.ServerReport.SetParameters(parametro);
            }
            this.reportViewer1.RefreshReport();
        }
    }
}
