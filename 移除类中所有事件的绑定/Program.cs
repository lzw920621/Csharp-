using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 移除类中所有事件的绑定
{
    class Program
    {
        static void Main(string[] args)
        {
        }


        /// <summary>
        /// 移除所有注册事件
        /// </summary>
        public void RemoveAllEvent()
        {
            var newType = this.GetType();//通过反射获取当前类的信息
            foreach (var item in newType.GetEvents())
            {
                FieldInfo _Field = newType.GetField(item.Name, BindingFlags.Instance | BindingFlags.NonPublic);
                if (_Field != null)
                {
                    object _FieldValue = _Field.GetValue(this);
                    if (_FieldValue != null && _FieldValue is Delegate)
                    {
                        Delegate _ObjectDelegate = (Delegate)_FieldValue;
                        Delegate[] invokeList = _ObjectDelegate.GetInvocationList();
                        if (invokeList != null)
                        {
                            foreach (Delegate del in invokeList)
                            {
                                item.RemoveEventHandler(this, del);
                            }
                        }
                    }
                }
            }
        }
    }


}
