using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 子窗体控制父窗体显示和隐藏
{
    public delegate void ClosingHandler();
    public partial class ChildForm : Form
    {
        public ChildForm()
        {
            InitializeComponent();
        }

        
        public ClosingHandler MyHandler;
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (MyHandler != null)
            {
                MyHandler();
            }
            base.OnFormClosing(e);
        }
    }
}
