using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyNotepadInterface;

namespace MyNotepadAddonToUpper
{
    public class ToUpper : IEditor
    {
        public string Name { get; private set; } = "ToUpper";

        public void Run(System.Windows.Forms.TextBox textbox)
        {
            textbox.Text = textbox.Text.ToUpper();
        }
    }
}
