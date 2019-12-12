using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 实现哈夫曼编码
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "state,seat,act,tea,cat,set,a,eat";
            Console.WriteLine("原始字符串:"+str);

            HuffmanTree huffmanTree = new HuffmanTree();
            List<HuffmanDicItem> dic;
            string code = huffmanTree.StringToHuffmanCode(out dic, str);
            Console.WriteLine("字符与其对应的编码:");
            for (int i = 0; i < dic.Count; i++)
            {
                Console.WriteLine(dic[i].Character + ":" + dic[i].Code);
            }
            //Console.WriteLine("编码后的字符串:");
            Console.WriteLine("编码后:"+code);

            string decode = huffmanTree.HuffmanCodeToString(dic, code);
            //Console.WriteLine("解码后的字符串:");
            Console.WriteLine("解码后:"+decode);

            Console.ReadLine();            
        }

        

    }

    
}
