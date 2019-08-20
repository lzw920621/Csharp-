using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Textbox数据绑定
{
    class MyData: INotifyPropertyChanged
    {
        private string _theValue = string.Empty;

        public string TheValue
        {
            get { return _theValue; }
            set
            {
                if (string.IsNullOrEmpty(value) && value == _theValue)
                    return;

                _theValue = value;
                this.NotifyPropertyChanged(() => TheValue);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;//事件 通知绑定者 数据源发生变化

        public void NotifyPropertyChanged<T>(Expression<Func<T>> property)
        {
            if (PropertyChanged == null)
                return;

            var memberExpression = property.Body as MemberExpression;
            if (memberExpression == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(memberExpression.Member.Name));
        }
    }
}
