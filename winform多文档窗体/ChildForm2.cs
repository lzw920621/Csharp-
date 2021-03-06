﻿using System;
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
    public partial class ChildForm2 : Form
    {
        private ChildForm2()
        {
            InitializeComponent();
        }
        #region 单例
        private static ChildForm2 childForm;

        private static object lockObject = new object();

        public static ChildForm2 SingletonForm
        {
            get
            {
                if (childForm == null || childForm.IsDisposed == true)
                {
                    lock (lockObject)
                    {
                        if (childForm == null || childForm.IsDisposed == true)
                        {
                            return childForm = new ChildForm2();
                        }
                    }
                }
                return childForm;
            }
        }
        #endregion
    }
}
