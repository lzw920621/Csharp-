using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace 利用反射实现ORM.ORM_Attributes
{
    class DataFieldAttribute:Attribute//字段特性
    {
        public string FieldName { get; private set; }
        public int Length { get; private set; }
        public SqlDbType FieldType { get; private set; }

        public DataFieldAttribute(string fieldName,int length,SqlDbType fieldType)
        {
            this.FieldName = fieldName;
            this.Length = length;
            this.FieldType = fieldType;
        }
    }
}
