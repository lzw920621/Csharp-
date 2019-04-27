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

namespace RealTimeChart
{
    public partial class Form1 : Form
    {
        List<string> seriesList = new List<string> { "实时数据1","实时数据2" };

        DateTime startTime;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Initial();
        }

        void Initial()
        {
            timer_UpdateData.Interval = (int)numericUpDown1.Value;
            ChartInitial(chart1, seriesList);
        }

        void ChartInitial(Chart chart,List<string> seriesList)
        {
            chart.Series.Clear();//清除图例

            for (int i = 0; i < seriesList.Count; i++)
            {
                chart.Series.Add(seriesList[i]);//添加图列
                chart.Series[i].ChartType = SeriesChartType.Line;//设置为折线图 

                //chart.Series[i].XValueType = ChartValueType.DateTime;
            }

            chart.ChartAreas[0].AxisY.Minimum = -1.2;//设置Y轴最小值
            chart.ChartAreas[0].AxisY.Maximum = 1.2;//Y轴最大范围

            chart.ChartAreas[0].AxisX.LabelStyle.Format = "0.00";
            
            //chart.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
            //chart.ChartAreas[0].AxisX.LabelStyle.Format = "T";

            chart.ChartAreas[0].AxisX.Title = "时间";//X轴标题
            chart.ChartAreas[0].AxisY.Title = "值";//Y轴标题
        }

        private void timer_UpdateData_Tick(object sender, EventArgs e)
        {
            //DateTime t1 = DateTime.Now;
            //double seconds= (DateTime.Now - startTime).TotalSeconds; 
            //double y1 = Math.Sin(seconds);
            //double y2 = Math.Cos(seconds);
            //chart1.Series[0].Points.AddXY(t1, y1);
            //chart1.Series[1].Points.AddXY(t1, y2);


            double x1 = (DateTime.Now - startTime).TotalSeconds;
            double y1 = Math.Sin(x1);

            double x2 = x1;
            double y2 = Math.Cos(x2);

            chart1.Series[0].Points.AddXY(x1, y1);
            chart1.Series[1].Points.AddXY(x2, y2);

            if (chart1.Series[0].Points.Count>50)
            {
                chart1.Series[0].Points.RemoveAt(0);                
            }
            if(chart1.Series[1].Points.Count>50)
            {
                chart1.Series[1].Points.RemoveAt(0);
            }

            chart1.ChartAreas[0].AxisX.Minimum = chart1.Series[0].Points.First().XValue;
            chart1.ChartAreas[0].AxisX.Maximum = chart1.Series[0].Points.Last().XValue;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            timer_UpdateData.Interval = (int)numericUpDown1.Value;
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            if(timer_UpdateData.Enabled==false)
            {
                startTime = DateTime.Now;
                for (int i = 0; i < seriesList.Count; i++)
                {
                    chart1.Series[i].Points.Clear();
                }

                timer_UpdateData.Start();
            }
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            timer_UpdateData.Stop();
        }

        private void numericUpDown_AxisY_Max_ValueChanged(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisY.Maximum = (double)numericUpDown_AxisY_Max.Value;
        }

        private void numericUpDown_AxisY_Min_ValueChanged(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisY.Minimum = (double)numericUpDown_AxisY_Min.Value;
        }
    }
}
