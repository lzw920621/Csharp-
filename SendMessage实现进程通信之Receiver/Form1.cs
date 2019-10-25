using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendMessage实现进程通信之Receiver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void frmReceiver_KeyDown(object sender, KeyEventArgs e)
        {
            this.lsvMsgList.Items.Add(e.KeyValue.ToString());
        }

        private void frmReceiver_KeyUp(object sender, KeyEventArgs e)
        {
            this.lsvMsgList.Items.Add(e.KeyValue.ToString());
        }
    }
}
