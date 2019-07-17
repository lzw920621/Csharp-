using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 将数组转为二叉树
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Enumerable.Range(0, 20).ToArray();

            TreeNode tree = ArrayToBinaryTree(array, 0, array.Length - 1);
            PreOrder(tree);
            Console.WriteLine("-------------------------------------");
            InOrder(tree);
            Console.WriteLine("--------------------------------------");
            PostOrder(tree);
            Console.WriteLine("--------------------------------------");
            LevelOrder(tree);

            Console.ReadKey();
        }

        public static TreeNode ArrayToBinaryTree(int[] array,int low,int high)//将数组转为二叉树
        {
            if (low > high) return null;
            int mid = (low + high) / 2;
            TreeNode treeNode = new TreeNode(array[mid]);
            treeNode.left = ArrayToBinaryTree(array, low, mid - 1);
            treeNode.right = ArrayToBinaryTree(array, mid + 1, high);
            return treeNode;
        }

        public static void PreOrder(TreeNode treeNode)//先序遍历
        {
            if (treeNode == null) return;

            Console.WriteLine(treeNode.val);
            PreOrder(treeNode.left);
            PreOrder(treeNode.right);
        }

        public static void PostOrder(TreeNode treeNode)//后序遍历
        {
            if (treeNode == null) return;
            
            PreOrder(treeNode.left);
            PreOrder(treeNode.right);
            Console.WriteLine(treeNode.val);
        }

        public static void InOrder(TreeNode treeNode)//中序遍历
        {
            if (treeNode == null) return;
            
            PreOrder(treeNode.left);
            Console.WriteLine(treeNode.val);
            PreOrder(treeNode.right);
        }

        public static void LevelOrder(TreeNode treeNode)//层序遍历
        {
            if (treeNode == null) return;

            Queue<TreeNode> queue = new Queue<TreeNode>();

            queue.Enqueue(treeNode);
            while(queue.Count>0)
            {
                TreeNode current = queue.Dequeue();
                Console.WriteLine(current.val);
                if(current.left!=null)
                {
                    queue.Enqueue(current.left);
                }
                if(current.right!=null)
                {
                    queue.Enqueue(current.right);
                }
            }
        }
    }

    class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val)
        {
            this.val = val;
        }
    }
}
