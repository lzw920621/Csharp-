﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNotepadInterface
{
    public interface IEditor
    {
        string Name { get; }
        void Run(TextBox textbox);
    }
}
