using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PMSWin.Report
{
    public partial class SupplierReportForm : BaseForm
    {
        public SupplierReportForm()
        {
            InitializeComponent();

            this.ThreeMonBuyersPie();
            this.ThreeMonPartsPie();
            this.ThreeMonBuyers();
            this.ThreeMonParts();
            tabPage1.BackColor = Color.FromArgb(250, 236, 209);
            tabPage2.BackColor = Color.FromArgb(250, 236, 209);
            ThreeMonBuyerschart.BorderlineDashStyle = ChartDashStyle.Solid;
            ThreeMonBuyerschart.BorderlineColor = Color.FromArgb(42,73,93);
            ThreeMonPartschart.BorderlineDashStyle = ChartDashStyle.Solid;
            ThreeMonPartschart.BorderlineColor = Color.FromArgb(42, 73, 93);
            chart1.BorderlineDashStyle = ChartDashStyle.Solid;
            chart1.BorderlineColor = Color.FromArgb(42, 73, 93);
            chart2.BorderlineDashStyle = ChartDashStyle.Solid;
            chart2.BorderlineColor = Color.FromArgb(42, 73, 93);
        }

        string supid = Common.ContainerForm.SupplierLoginAccount.SupplierAccountID;

        Dao.SupplierReportDao srd = new Dao.SupplierReportDao();
        //圓餅圖
        void ThreeMonBuyersPie()
        {
            DataTable dt = this.srd.ThreeMonBuyerUnit(supid);

            this.ThreeMonBuyerschart.DataSource = dt;
            this.ThreeMonBuyerschart.Series[0].XValueMember = Convert.ToString(dt.Columns[0]);
            this.ThreeMonBuyerschart.Series[0].YValueMembers = Convert.ToString(dt.Columns[1]);
            this.ThreeMonBuyerschart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            //3D
            this.ThreeMonBuyerschart.ChartAreas[0].Area3DStyle.Enable3D = true;
            this.ThreeMonBuyerschart.ChartAreas[0].Area3DStyle.Rotation = 10;
            this.ThreeMonBuyerschart.ChartAreas[0].Area3DStyle.Inclination = 50;
            this.ThreeMonBuyerschart.ChartAreas[0].Area3DStyle.LightStyle = LightStyle.Realistic;
        }

        private void ThreeMonPartsPie()
        {
            DataTable dt = srd.ThreeMonPartUnit(supid);

            this.ThreeMonPartschart.DataSource = dt;
            this.ThreeMonPartschart.Series[0].XValueMember = Convert.ToString(dt.Columns[0]);
            this.ThreeMonPartschart.Series[0].YValueMembers = Convert.ToString(dt.Columns[1]);
            this.ThreeMonPartschart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            this.ThreeMonPartschart.ChartAreas[0].Area3DStyle.Enable3D = true;
            this.ThreeMonPartschart.ChartAreas[0].Area3DStyle.Rotation = 10;
            this.ThreeMonPartschart.ChartAreas[0].Area3DStyle.Inclination = 50;
            this.ThreeMonPartschart.ChartAreas[0].Area3DStyle.LightStyle = LightStyle.Realistic;
        }

        private void ThreeMonBuyerschart_PrePaint(object sender, System.Windows.Forms.DataVisualization.Charting.ChartPaintEventArgs e)
        {
            foreach(DataPoint p in this.ThreeMonBuyerschart.Series[0].Points)
            {
                p["Exploded"] = "True";
            }
        }

        private void ThreeMonPartschart_PrePaint(object sender, ChartPaintEventArgs e)
        {
            foreach (DataPoint p in this.ThreeMonPartschart.Series[0].Points)
            {
                p["Exploded"] = "True";
            }
        }

        //條狀圖
        void ThreeMonBuyers()
        {
            DataTable dt = this.srd.ThreeMonBuyerUnit(supid);

            this.chart1.DataSource = dt;
            this.chart1.Series[0].XValueMember = Convert.ToString(dt.Columns[0]);
            this.chart1.Series[0].YValueMembers = Convert.ToString(dt.Columns[1]);
            this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            //3D
            this.chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
            this.chart1.ChartAreas[0].Area3DStyle.Rotation = 10;
            this.chart1.ChartAreas[0].Area3DStyle.Inclination = 50;
            this.chart1.ChartAreas[0].Area3DStyle.LightStyle = LightStyle.Realistic;
        }

        private void ThreeMonParts()
        {
            DataTable dt = srd.ThreeMonPartUnit(supid);

            this.chart2.DataSource = dt;
            this.chart2.Series[0].XValueMember = Convert.ToString(dt.Columns[0]);
            this.chart2.Series[0].YValueMembers = Convert.ToString(dt.Columns[1]);
            this.chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            this.chart2.ChartAreas[0].Area3DStyle.Enable3D = true;
            this.chart2.ChartAreas[0].Area3DStyle.Rotation = 10;
            this.chart2.ChartAreas[0].Area3DStyle.Inclination = 50;
            this.chart2.ChartAreas[0].Area3DStyle.LightStyle = LightStyle.Realistic;
        }
    }
}
