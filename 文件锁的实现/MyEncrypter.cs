using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace 文件锁的实现
{
    class MyEncrypter : IEncrypter
    {
        private bool Decode(string str)
        {
            if (Directory.Exists(str))
            {
                if (HasEncrypt(str))
                {
                    DirectoryInfo d = new DirectoryInfo(str);
                    int index = str.LastIndexOf('.');
                    d.MoveTo(str.Substring(0, index));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else return false;
        }


        private bool HasEncrypt(string str)//判断是否已加密
        {
            if (str.LastIndexOf(".{") == -1)
                return false;
            else return true;
        }

        private bool Encrypt(string str)//加密
        {
            if (Directory.Exists(str))
            {
                DirectoryInfo d = new DirectoryInfo(str);
                d.MoveTo(d.Parent.FullName + "\\" + d.Name + ".{2559a1f2-21d7-11d4-bdaf-00c04f60b9f0}");
                return true;
            }
            else return false;
        }


        void IEncrypter.MultiEncrypt(string path)
        {
            DirectoryInfo d = new DirectoryInfo(path);
            var ds = d.GetDirectories();
            var fs = d.GetFiles();
            if (d.GetDirectories().Count() == 0 && d.GetFiles().Count() == 0)
            {
                MessageBox.Show("文件夹为空");
                return;
            }
            foreach (DirectoryInfo item in ds)
            {
                item.MoveTo(item.Parent.FullName + "\\" + item.Name + ".{2559a1f2-21d7-11d4-bdaf-00c04f60b9f0}");
            }
            foreach (FileInfo item in fs)
            {
                DirectoryInfo directoryInfo = d.CreateSubdirectory(item.Name + "_MYLOCKER");
                string basePath = directoryInfo.Parent.FullName + "\\";
                item.MoveTo(directoryInfo.FullName + "\\" + item.Name);
                directoryInfo.MoveTo(basePath + directoryInfo.Name + ".{2559a1f2-21d7-11d4-bdaf-00c04f60b9f0}");
            }
            MessageBox.Show("全局加密成功!");
        }

        void IEncrypter.SingleEncrypt(string path)
        {
            try
            {
                if (!HasEncrypt(path))
                {
                    if (Encrypt(path))
                    {
                        MessageBox.Show("文件夹加密成功!");
                    }
                    else
                    {
                        FileInfo fileInfo = new FileInfo(path);
                        string fullName = fileInfo.FullName;
                        string basePath = fileInfo.FullName.Substring(0, fullName.LastIndexOf("."));
                        DirectoryInfo directoryInfo = Directory.CreateDirectory(basePath);
                        fileInfo.MoveTo(basePath + "\\" + fileInfo.Name);
                        directoryInfo.MoveTo(directoryInfo.FullName + "_MYLOCKER.{2559a1f2-21d7-11d4-bdaf-00c04f60b9f0}");
                    }
                }
                else
                {
                    if (Decode(path))
                    {
                        MessageBox.Show("文件夹解密成功!");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("操作出了点小问题,请检查是否存在同名文件或文件夹");
            }
        }
    }
}
