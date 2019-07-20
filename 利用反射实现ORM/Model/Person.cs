using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using 利用反射实现ORM.ORM_Attributes;

namespace 利用反射实现ORM.Model
{
    [Table("person")]
    class Person
    {
        [DataField("id",20,SqlDbType.Int)]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
    }
}
