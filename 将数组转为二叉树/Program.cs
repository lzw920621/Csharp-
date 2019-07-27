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

            TreeNode tree = ArrayToBinaryTree(array,0,array.Length-1);
            Console.WriteLine("------------------先序遍历-------------------");
            PreOrder(tree);
            Console.WriteLine("-------------------中序遍历------------------");
            InOrder(tree);
            Console.WriteLine("--------------------后序遍历------------------");
            PostOrder(tree);
            Console.WriteLine("--------------------层序遍历------------------");
            LevelOrder(tree);
            Console.WriteLine("--------------------------------------");
            Console.Write("Height : "+GetTreeHeight(tree));
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

        public static TreeNode ArrayToBinaryTree_2(int[] array)//按层序的方式
        {
            if (array == null || array.Length < 1) return null;
            
            Queue<TreeNode> queue = new Queue<TreeNode>();

            TreeNode root = new TreeNode(array[0]);
            int index = 0;
            queue.Enqueue(root);
            while(queue.Count>0)
            {
                TreeNode current = queue.Dequeue();
                if(2*index+1<array.Length)
                {
                    current.left = new TreeNode(array[2 * index + 1]);
                    queue.Enqueue(current.left);
                }
                if(2*index+2<array.Length)
                {
                    current.right = new TreeNode(array[2 * index] + 2);
                    queue.Enqueue(current.right);
                }
                index++;
            }

            return root;
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

            PostOrder(treeNode.left);
            PostOrder(treeNode.right);
            Console.WriteLine(treeNode.val);
        }

        public static void InOrder(TreeNode treeNode)//中序遍历
        {
            if (treeNode == null) return;

            InOrder(treeNode.left);
            Console.WriteLine(treeNode.val);
            InOrder(treeNode.right);
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
        
        public static int GetTreeHeight(TreeNode node)//树的高度
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                int leftHeight = GetTreeHeight(node.left);
                int rightHeight = GetTreeHeight(node.right);
                return leftHeight > rightHeight ? leftHeight + 1 : rightHeight + 1;
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
