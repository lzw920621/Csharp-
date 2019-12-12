using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 实现哈夫曼编码
{
    public class HuffmanTreeNode : BinTreeNode<char>
    {
        /// <summary>
        /// 结点的权值
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// 叶子结点 -- 字符
        /// </summary>
        /// <param name="data"></param>
        /// <param name="weight"></param>
        public HuffmanTreeNode(char data, int weight) : base(data)
        {
            Weight = weight;
        }

        /// <summary>
        /// 非叶子结点
        /// </summary>
        /// <param name="weight"></param>
        public HuffmanTreeNode(int weight) : base('\0')
        {
            Weight = weight;
        }
    }
}
