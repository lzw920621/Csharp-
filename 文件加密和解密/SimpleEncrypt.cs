using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace 文件加密和解密
{
    //一种超简单的加密方式:将要加

    class SimpleEncrypt
    {
        public void EncryptOrDecryptFile(string filePath)
        {
            //先判断文件是否存在
            if(File.Exists(filePath))
            {
                try
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite))
                    {
                        byte[] byteArray = new byte[(int)fs.Length];
                        fs.Read(byteArray, 0, byteArray.Length);
                        for (int i = 0; i < byteArray.Length; i++)
                        {
                            byteArray[i] = (byte)(0xff - byteArray[i]);
                        }
                        fs.Seek(0, SeekOrigin.Begin);//设定流的位置为起始字节位置
                        fs.Write(byteArray, 0, byteArray.Length);
                        fs.Flush();
                        SendMessage("OK");
                    }
                }
                catch (Exception e)
                {
                    SendMessage(e.Message+'\n'+"Failed");
                }                          
            }
            else
            {
                //throw new FileNotFoundException("文件不存在");
                SendMessage("文件不存在");
            }
        }
        public event Action<string> SendMessage;
    } 
}
