using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 实现哈夫曼编码
{
    class HuffmanTree
    {
        private List<HuffmanTreeNode> CreateInitForest(string str)
        {
            if (string.IsNullOrEmpty(str))
                throw new ArgumentNullException();

            List<HuffmanTreeNode> result = new List<HuffmanTreeNode>();
            char[] charArray = str.ToCharArray();
            List<IGrouping<char, char>> lst = charArray.GroupBy(a => a).ToList();

            foreach (IGrouping<char, char> g in lst)
            {
                char data = g.Key;
                int weight = g.ToList().Count;
                HuffmanTreeNode node = new HuffmanTreeNode(data, weight);
                result.Add(node);
            }
            return result;
        }

        private HuffmanTreeNode CreateHuffmanTree(List<HuffmanTreeNode> sources)
        {
            if (sources == null)
                throw new ArgumentNullException();
            if (sources.Count < 2)
                throw new ArgumentException("构造Huffman树，最少为2个结点。");

            HuffmanTreeNode root = default(HuffmanTreeNode);
            bool isNext = true;

            while (isNext)
            {
                List<HuffmanTreeNode> lst = sources.OrderBy(a => a.Weight).ToList();
                HuffmanTreeNode n1 = lst[0];
                HuffmanTreeNode n2 = lst[1];
                int weight = n1.Weight + n2.Weight;

                HuffmanTreeNode node = new HuffmanTreeNode(weight);
                node.LeftChild = n1;
                node.RightChild = n2;

                if (lst.Count == 2)
                {
                    root = node;
                    isNext = false;
                }
                else
                {
                    sources = lst.GetRange(2, lst.Count - 2);
                    sources.Add(node);
                }
            }
            return root;
        }

        private List<HuffmanDicItem> CreateHuffmanDict(string code, HuffmanTreeNode current)
        {
            if (current == null)
                throw new ArgumentNullException();

            List<HuffmanDicItem> result = new List<HuffmanDicItem>();
            if (current.LeftChild == null && current.RightChild == null)
            {
                result.Add(new HuffmanDicItem(current.Data, code));
            }
            else
            {
                List<HuffmanDicItem> dictL = CreateHuffmanDict(code + "0",
                    (HuffmanTreeNode)current.LeftChild);
                List<HuffmanDicItem> dictR = CreateHuffmanDict(code + "1",
                    (HuffmanTreeNode)current.RightChild);

                result.AddRange(dictL);
                result.AddRange(dictR);
            }
            return result;
        }

        private List<HuffmanDicItem> CreateHuffmanDict(HuffmanTreeNode root)
        {
            if (root == null)
                throw new ArgumentNullException();

            return CreateHuffmanDict(string.Empty, root);
        }

        private string ToHuffmanCode(string source, List<HuffmanDicItem> lst)
        {
            if (string.IsNullOrEmpty(source))
                throw new ArgumentNullException();
            if (lst == null)
                throw new ArgumentNullException();

            string result = string.Empty;
            for (int i = 0; i < source.Length; i++)
            {
                result += lst.Single(a => a.Character == source[i]).Code;
            }
            return result;
        }

        // 被外界调用的函数，对字符串进行huffman编码。
        public string StringToHuffmanCode(out List<HuffmanDicItem> dict, string str)
        {
            List<HuffmanTreeNode> forest = CreateInitForest(str);
            HuffmanTreeNode root = CreateHuffmanTree(forest);
            dict = CreateHuffmanDict(root);
            string result = ToHuffmanCode(str, dict);
            return result;
        }
        
        // 解码
        public string HuffmanCodeToString(List<HuffmanDicItem> dict, string code)
        {
            string result = string.Empty;
            for (int i = 0; i < code.Length;)
            {
                foreach (HuffmanDicItem item in dict)
                {
                    if (code[i] == item.Code[0] && item.Code.Length + i <= code.Length)
                    {
                        string temp = code.Substring(i, item.Code.Length);
                        if (temp == item.Code)
                        {
                            result += item.Character;
                            i += item.Code.Length;
                            break;
                        }
                    }
                }
            }
            return result;
        }
    }
}
