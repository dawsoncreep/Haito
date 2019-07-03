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
