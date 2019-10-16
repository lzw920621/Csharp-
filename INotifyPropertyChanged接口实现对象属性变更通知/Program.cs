using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotifyPropertyChanged接口实现对象属性变更通知
{
    public class User : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private uint _userId;
        private string _name;

        public uint UserId
        {
            get => _userId;
            set
            {
                if (_userId == value)
                    return;

                _userId = value;
                this.OnPropertyChanged("UserId"); // 传统写法
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (_name == value)
                    return;

                _name = value;
                this.OnPropertyChanged(nameof(Name)); // nameof 为 C# 7.0 新增操作符
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            // 注意 ?. 为 C# 7.0 新增操作符
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
