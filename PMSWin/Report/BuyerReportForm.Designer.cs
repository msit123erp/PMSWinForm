namespace PMSWin.Report
{
    partial class BuyerReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.TenSourceListchart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.PurchasingECountchart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.PurchusingPCVAchart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.MonthSumchart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TenSourceListchart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchasingECountchart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchusingPCVAchart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthSumchart)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.TenSourceListchart);
            this.pnlContent.Controls.Add(this.PurchusingPCVAchart);
            this.pnlContent.Controls.Add(this.PurchasingECountchart);
            this.pnlContent.Controls.Add(this.MonthSumchart);
            this.pnlContent.Size = new System.Drawing.Size(1672, 1050);
            // 
            // TenSourceListchart
            // 
            this.TenSourceListchart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.TenSourceListchart.BorderlineWidth = 5;
            chartArea1.AxisX.Title = "項目";
            chartArea1.AxisY.Title = "價格";
            chartArea1.Name = "ChartArea1";
            this.TenSourceListchart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.TenSourceListchart.Legends.Add(legend1);
            this.TenSourceListchart.Location = new System.Drawing.Point(764, 574);
            this.TenSourceListchart.Name = "TenSourceListchart";
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(177)))), ((int)(((byte)(181)))));
            series1.IsValueShownAsLabel = true;
            series1.LabelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.TenSourceListchart.Series.Add(series1);
            this.TenSourceListchart.Size = new System.Drawing.Size(785, 464);
            this.TenSourceListchart.TabIndex = 7;
            this.TenSourceListchart.Text = "chart3";
            title1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Tit";
            title1.Text = "最近九筆新增的貨源清單";
            this.TenSourceListchart.Titles.Add(title1);
            // 
            // PurchasingECountchart
            // 
            this.PurchasingECountchart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.PurchasingECountchart.BorderlineWidth = 5;
            chartArea3.AxisX.Title = "年/月";
            chartArea3.AxisY.Title = "數量";
            chartArea3.Name = "ChartArea1";
            this.PurchasingECountchart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.PurchasingECountchart.Legends.Add(legend3);
            this.PurchasingECountchart.Location = new System.Drawing.Point(53, 574);
            this.PurchasingECountchart.Name = "PurchasingECountchart";
            series3.ChartArea = "ChartArea1";
            series3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(177)))), ((int)(((byte)(181)))));
            series3.IsValueShownAsLabel = true;
            series3.LabelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.PurchasingECountchart.Series.Add(series3);
            this.PurchasingECountchart.Size = new System.Drawing.Size(638, 464);
            this.PurchasingECountchart.TabIndex = 6;
            this.PurchasingECountchart.Text = "chart4";
            title3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title3.Name = "Title1";
            title3.Text = "已產生採購單但尚完全答交之採購單";
            this.PurchasingECountchart.Titles.Add(title3);
            // 
            // PurchusingPCVAchart
            // 
            this.PurchusingPCVAchart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.PurchusingPCVAchart.BorderlineWidth = 5;
            chartArea2.AxisX.Title = "年/月";
            chartArea2.AxisY.Title = "數量";
            chartArea2.Name = "ChartArea1";
            this.PurchusingPCVAchart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.PurchusingPCVAchart.Legends.Add(legend2);
            this.PurchusingPCVAchart.Location = new System.Drawing.Point(764, 51);
            this.PurchusingPCVAchart.Name = "PurchusingPCVAchart";
            this.PurchusingPCVAchart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(177)))), ((int)(((byte)(181)))));
            series2.IsValueShownAsLabel = true;
            series2.LabelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.PurchusingPCVAchart.Series.Add(series2);
            this.PurchusingPCVAchart.Size = new System.Drawing.Size(785, 464);
            this.PurchusingPCVAchart.TabIndex = 5;
            this.PurchusingPCVAchart.Text = "chart2";
            title2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title1";
            title2.Text = "已採購但未進貨表單";
            this.PurchusingPCVAchart.Titles.Add(title2);
            // 
            // MonthSumchart
            // 
            this.MonthSumchart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.MonthSumchart.BorderlineWidth = 5;
            chartArea4.AxisX.Title = "年 / 月";
            chartArea4.AxisY.Title = "當月銷售總金額";
            chartArea4.Name = "ChartArea1";
            this.MonthSumchart.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.MonthSumchart.Legends.Add(legend4);
            this.MonthSumchart.Location = new System.Drawing.Point(53, 51);
            this.MonthSumchart.Name = "MonthSumchart";
            series4.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            series4.ChartArea = "ChartArea1";
            series4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(177)))), ((int)(((byte)(181)))));
            series4.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series4.IsValueShownAsLabel = true;
            series4.LabelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            series4.LabelForeColor = System.Drawing.Color.Red;
            series4.LabelFormat = "C";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.MonthSumchart.Series.Add(series4);
            this.MonthSumchart.Size = new System.Drawing.Size(638, 464);
            this.MonthSumchart.TabIndex = 4;
            this.MonthSumchart.Text = "chart1";
            title4.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title4.Name = "Title1";
            title4.Text = "每月採購金額圖表";
            this.MonthSumchart.Titles.Add(title4);
            // 
            // BuyerReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1672, 1050);
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "BuyerReportForm";
            this.Text = "BuyerReportForm";
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TenSourceListchart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchasingECountchart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchusingPCVAchart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthSumchart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart TenSourceListchart;
        private System.Windows.Forms.DataVisualization.Charting.Chart PurchusingPCVAchart;
        private System.Windows.Forms.DataVisualization.Charting.Chart PurchasingECountchart;
        private System.Windows.Forms.DataVisualization.Charting.Chart MonthSumchart;
    }
}