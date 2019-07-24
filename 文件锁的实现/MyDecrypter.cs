using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace 文件锁的实现
{
    class MyDecrypter: IDecrypter
    {
        private bool Decode(string str)
        {
            if (Directory.Exists(str))
            {
                DirectoryInfo d = new DirectoryInfo(str);
                int index = str.LastIndexOf('.');
                d.MoveTo(str.Substring(0, index));
                return true;
            }
            else return false;
        }


        private bool HasEncrypt(string str, ref int index)
        {
            if ((index = str.LastIndexOf(".{")) == -1)
                return false;
            else return true;
        }

        void IDecrypter.MultiDecrypt(string path)
        {
            int temp = 0;
            if (!HasEncrypt(path, ref temp))
            {
                DirectoryInfo d = new DirectoryInfo(path);
                if (d.GetDirectories().Count() == 0 && d.GetFiles().Count() == 0) { MessageBox.Show("文件夹为空!"); return; }
                foreach (DirectoryInfo item in d.GetDirectories())
                {
                    int index = 0;
                    if (HasEncrypt(item.Name, ref index))
                    {
                        item.MoveTo(item.Parent.FullName + "\\" + item.Name.Substring(0, index));
                        if (item.Name.Contains("_MYLOCKER"))
                        {
                            var parentPath = item.Parent.FullName;
                            FileInfo[] fileInfo = item.GetFiles();
                            foreach (var file in fileInfo)
                            {
                                file.MoveTo(parentPath + "\\" + file.Name);
                            }
                            item.Delete();
                        }
                    }
                }
                MessageBox.Show("全局解密成功!");
            }
            else
            {
                Decode(path); MessageBox.Show("全局解密成功!");
            }
        }

        void IDecrypter.SingleDecrypt(string path)
        {
            //空实现
        }
    }
}
