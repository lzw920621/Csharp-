using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通过文件头判断文件的类型
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isTrue = IsAllowedExtension(@"C:\Users\lzw92\Desktop\Sonos.pptx");
        }


        public static bool IsAllowedExtension(string filePath)
        {
            FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);
            string fileclass = "";

            try
            {                
                for (int i = 0; i < 2; i++)//获取前三个字节所对应的字符串
                {
                    fileclass += reader.ReadByte().ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                reader.Close();
                stream.Close();                
            }

            if (fileclass == "255216")
            {
                return true;
            }
            else
            {
                return false;
            }

            
            /*文件扩展名说明
            * 255216 jpg
            * 208207 doc xls ppt wps
            * 8075 docx pptx xlsx zip           
            * 8297 rar
            * 7790 exe
            * 3780 pdf
            *
            * 4946/104116 txt
            * 7173 gif
            * 255216 jpg
            * 13780 png
            * 6677 bmp
            * 239187 txt,aspx,asp,sql
            * 208207 xls.doc.ppt
            * 6063 xml
            * 6033 htm,html
            * 4742 js
            * 8075 xlsx,zip,pptx,mmap,zip
            * 8297 rar
            * 01 accdb,mdb
            * 7790 exe,dll
            * 5666 psd
            * 255254 rdp
            * 10056 bt种子
            * 64101 bat
            * 4059 sgf
            */

        }
    }
}
