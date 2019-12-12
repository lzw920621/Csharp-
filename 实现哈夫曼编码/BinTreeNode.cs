using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 实现哈夫曼编码
{
    public class BinTreeNode<T>  where T : IComparable<T>
    {
        private T _data;

        /// <summary>
        /// 获取或设置该结点的左孩子
        /// </summary>
        public BinTreeNode<T> LeftChild { get; set; }

        /// <summary>
        /// 获取或设置该结点的右孩子
        /// </summary>
        public BinTreeNode<T> RightChild { get; set; }

        /// <summary>
        /// 获取或设置该结点的数据元素
        /// </summary>
        public T Data
        {
            get { return _data; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                _data = value;
            }
        }

        /// <summary>
        /// 初始化BinTreeNode类的新实例
        /// </summary>
        /// <param name="data">该结点的数据元素 </param>
        /// <param name="lChild">该结点的左孩子</param>
        /// <param name="rChild">该结点的右孩子</param>
        public BinTreeNode(T data, BinTreeNode<T> lChild = null,
            BinTreeNode<T> rChild = null)
        {
            if (data == null)
                throw new ArgumentNullException();

            LeftChild = lChild;
            _data = data;
            RightChild = rChild;
        }
    }
}
