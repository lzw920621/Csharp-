using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 简单记事本接口;

namespace MyNotepadAddons
{
    public class ToUpper : IEditor
    {
        public string Name { get; private set; } = "ToUpper";

        public void Run(TextBox textbox)
        {
            textbox.Text.ToUpper();
        }
    }
}
