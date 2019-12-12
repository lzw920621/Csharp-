using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 实现哈夫曼编码
{
    public class HuffmanDicItem
    {
        /// <summary>
        /// 字符
        /// </summary>
        public char Character { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="charactor"></param>
        /// <param name="code"></param>
        public HuffmanDicItem(char charactor, string code)
        {
            Character = charactor;
            Code = code;
        }
    }
}
