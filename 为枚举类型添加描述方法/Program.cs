using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 为枚举类型添加描述方法
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum val)
        {
            var type = val.GetType();
            var memberInfo = type.GetMember(val.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            if(attributes==null || attributes.Length==0)
            {
                return val.ToString();
            }

            return (attributes.Single() as DescriptionAttribute).Description;
        }
    }

    public enum Level
    {
        [Description("Bad")]
        B,
        [Description("Normal")]
        N,
        [Description("Good")]
        G,
        [Description("Very Good")]
        VG
    }
    class Program
    {
        static void Main(string[] args)
        {
            Level level = Level.B;
            string description=level.GetDescription();
        }
    }
}
