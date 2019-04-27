namespace RealTimeChart
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer_UpdateData = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.numericUpDown_AxisY_Min = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown_AxisY_Max = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_AxisY_Min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_AxisY_Max)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea7.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.chart1.Legends.Add(legend7);
            this.chart1.Location = new System.Drawing.Point(57, 27);
            this.chart1.Name = "chart1";
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            this.chart1.Series.Add(series7);
            this.chart1.Size = new System.Drawing.Size(714, 460);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // timer_UpdateData
            // 
            this.timer_UpdateData.Interval = 500;
            this.timer_UpdateData.Tick += new System.EventHandler(this.timer_UpdateData_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(777, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "刷新间隔(毫秒)：";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(911, 36);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(81, 25);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(849, 95);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(102, 44);
            this.btn_Start.TabIndex = 5;
            this.btn_Start.Text = "开始";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Location = new System.Drawing.Point(849, 159);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(102, 46);
            this.btn_Stop.TabIndex = 6;
            this.btn_Stop.Text = "停止";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // numericUpDown_AxisY_Min
            // 
            this.numericUpDown_AxisY_Min.DecimalPlaces = 2;
            this.numericUpDown_AxisY_Min.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_AxisY_Min.Location = new System.Drawing.Point(892, 331);
            this.numericUpDown_AxisY_Min.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            -2147418112});
            this.numericUpDown_AxisY_Min.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            -2147483648});
            this.numericUpDown_AxisY_Min.Name = "numericUpDown_AxisY_Min";
            this.numericUpDown_AxisY_Min.Size = new System.Drawing.Size(64, 25);
            this.numericUpDown_AxisY_Min.TabIndex = 7;
            this.numericUpDown_AxisY_Min.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericUpDown_AxisY_Min.ValueChanged += new System.EventHandler(this.numericUpDown_AxisY_Min_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(803, 333);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Y轴下限 ：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(803, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Y轴上限 ：";
            // 
            // numericUpDown_AxisY_Max
            // 
            this.numericUpDown_AxisY_Max.DecimalPlaces = 2;
            this.numericUpDown_AxisY_Max.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_AxisY_Max.Location = new System.Drawing.Point(892, 287);
            this.numericUpDown_AxisY_Max.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown_AxisY_Max.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDown_AxisY_Max.Name = "numericUpDown_AxisY_Max";
            this.numericUpDown_AxisY_Max.Size = new System.Drawing.Size(64, 25);
            this.numericUpDown_AxisY_Max.TabIndex = 9;
            this.numericUpDown_AxisY_Max.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_AxisY_Max.ValueChanged += new System.EventHandler(this.numericUpDown_AxisY_Max_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 514);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown_AxisY_Max);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown_AxisY_Min);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chart1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_AxisY_Min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_AxisY_Max)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer timer_UpdateData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.NumericUpDown numericUpDown_AxisY_Min;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown_AxisY_Max;
    }
}

