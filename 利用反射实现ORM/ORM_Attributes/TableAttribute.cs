using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 利用反射实现ORM.ORM_Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    class TableAttribute:Attribute
    {
        public string TableName { get; private set; }
        public TableAttribute(string name)
        {
            this.TableName = name;
        }
    }
}
