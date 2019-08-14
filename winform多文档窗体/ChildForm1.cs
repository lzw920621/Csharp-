using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform多文档窗体
{
    public partial class ChildForm1 : Form
    {
        private ChildForm1()
        {
            InitializeComponent();
        }

        #region 单例
        private static ChildForm1 childForm;

        private static object lockObject = new object();

        public static ChildForm1 SingletonForm
        {
            get
            {
                if (childForm == null || childForm.IsDisposed == true)
                {
                    lock (lockObject)
                    {
                        if (childForm == null || childForm.IsDisposed == true)
                        {
                            return childForm = new ChildForm1();
                        }
                    }
                }
                return childForm;
            }
        }
        #endregion
    }
}
