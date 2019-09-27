using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMSWin.Report
{
    public partial class BuyerReportForm : BaseForm
    {
        public BuyerReportForm()
        {
            InitializeComponent();

            this.MonthSum();
            this.TenSourceList();
            this.PurchaseECount();
            this.PurchasePCVA();
            pnlContent.BackColor = Color.FromArgb(250, 236, 209);
     
            MonthSumchart.BorderlineColor = Color.FromArgb(42, 73, 93);
           PurchusingPCVAchart.BorderlineColor = Color.FromArgb(42, 73, 93);
            PurchasingECountchart.BorderlineColor = Color.FromArgb(42, 73, 93);
            TenSourceListchart.BorderlineColor = Color.FromArgb(42, 73, 93);
        }

        //假的資料
        string emid = Common.ContainerForm.BuyerLoginAccount.EmployeeID;

        Dao.BuyerReportDao brd = new Dao.BuyerReportDao();

        void MonthSum()
        {
            DataTable mon = brd.EveryMonthSum(emid);

            this.MonthSumchart.DataSource = mon;
            this.MonthSumchart.Series[0].Name = "";
            this.MonthSumchart.Series[0].XValueMember = Convert.ToString(mon.Columns[1]);
            this.MonthSumchart.Series[0].YValueMembers = Convert.ToString(mon.Columns[0]);
            this.MonthSumchart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            //3D
            this.MonthSumchart.ChartAreas[0].Area3DStyle.Enable3D = true;
            this.MonthSumchart.ChartAreas[0].Area3DStyle.Rotation = 10;
            this.MonthSumchart.ChartAreas[0].Area3DStyle.Inclination = 30;
            this.MonthSumchart.ChartAreas[0].Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Simplistic;
            this.MonthSumchart.ChartAreas[0].Area3DStyle.PointGapDepth = 20;
        }

        void TenSourceList()
        {
            DataTable slist = brd.TopTenSourceList();

            this.TenSourceListchart.DataSource = slist;
            this.TenSourceListchart.Series[0].Name = "";
            this.TenSourceListchart.Series[0].XValueMember = Convert.ToString(slist.Columns[0]);
            this.TenSourceListchart.ChartAreas[0].AxisX.LabelStyle.Angle = 90;
            this.TenSourceListchart.Series[0].YValueMembers = Convert.ToString(slist.Columns[1]);
            this.TenSourceListchart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            //3D
            this.TenSourceListchart.ChartAreas[0].Area3DStyle.Enable3D = true;
            this.TenSourceListchart.ChartAreas[0].Area3DStyle.Rotation = 10; //起始角度
            this.TenSourceListchart.ChartAreas[0].Area3DStyle.Inclination = 30; //傾斜角度
            //表面光澤
            this.TenSourceListchart.ChartAreas[0].Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Simplistic;
            this.TenSourceListchart.ChartAreas[0].Area3DStyle.PointGapDepth = 20;
        }

        void PurchaseECount()
        {
            DataTable pec = brd.PurchasingECount(emid);

            this.PurchasingECountchart.DataSource = pec;
            this.PurchasingECountchart.Series[0].Name = "";
            this.PurchasingECountchart.Series[0].XValueMember = Convert.ToString(pec.Columns[0]);
            this.PurchasingECountchart.Series[0].YValueMembers = Convert.ToString(pec.Columns[1]);
            this.PurchasingECountchart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            //3D
            this.PurchasingECountchart.ChartAreas[0].Area3DStyle.Enable3D = true;
            this.PurchasingECountchart.ChartAreas[0].Area3DStyle.Rotation = 10; //起始角度
            this.PurchasingECountchart.ChartAreas[0].Area3DStyle.Inclination = 30; //傾斜角度
            //表面光澤
            this.PurchasingECountchart.ChartAreas[0].Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Simplistic;
            this.PurchasingECountchart.ChartAreas[0].Area3DStyle.PointGapDepth = 20;
        }

        void PurchasePCVA()
        {
            DataTable pcva = brd.PurchasingPCAV(emid);

            this.PurchusingPCVAchart.DataSource = pcva;
            this.PurchusingPCVAchart.Series[0].Name = "";
            this.PurchusingPCVAchart.Series[0].XValueMember = Convert.ToString(pcva.Columns[0]);
            this.PurchusingPCVAchart.Series[0].YValueMembers = Convert.ToString(pcva.Columns[1]);
            this.PurchusingPCVAchart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            //3D
            this.PurchusingPCVAchart.ChartAreas[0].Area3DStyle.Enable3D = true;
            this.PurchusingPCVAchart.ChartAreas[0].Area3DStyle.Rotation = 10;
            this.PurchusingPCVAchart.ChartAreas[0].Area3DStyle.Inclination = 30;
            this.PurchusingPCVAchart.ChartAreas[0].Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Simplistic;
            this.PurchusingPCVAchart.ChartAreas[0].Area3DStyle.PointGapDepth = 20;
        }
    }
}
