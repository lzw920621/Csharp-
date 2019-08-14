using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform窗体单例
{
    public partial class Form1 : Form
    {
        private Form1()
        {
            InitializeComponent();
        }

        #region 单例
        private static Form1 form;

        private static object lockObject = new object();

        public static Form1 SingletonForm
        {
            get
            {
                if (form == null || form.IsDisposed == true)
                {
                    lock (lockObject)
                    {
                        if (form == null || form.IsDisposed == true)
                        {
                            return form = new Form1();
                        }
                    }
                }
                return form;
            }
        }
        #endregion
    }
}
