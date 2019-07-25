using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 简单记事本接口
{
    public class Class1
    {
    }

    public interface IEditor//编辑接口
    {
        string Name { get; }
        void Run(TextBox textbox);
    }
}
