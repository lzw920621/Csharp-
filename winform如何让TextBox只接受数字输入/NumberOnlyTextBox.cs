using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform如何让TextBox只接受数字输入
{
    class NumberOnlyTextBox:TextBox
    {
        protected override void OnKeyPress(KeyPressEventArgs e)
        {

            base.OnKeyPress(e);

            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))

                e.Handled = true;
        }
    }
}
