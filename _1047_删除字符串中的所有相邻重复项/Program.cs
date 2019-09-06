using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1047_删除字符串中的所有相邻重复项
{
    /*
    给出由小写字母组成的字符串 S，重复项删除操作会选择两个相邻且相同的字母，并删除它们。

    在 S 上反复执行重复项删除操作，直到无法继续删除。

    在完成所有重复项删除操作后返回最终的字符串。答案保证唯一。

 
    示例：

    输入："abbaca"
    输出："ca"
    解释：
    例如，在 "abbaca" 中，我们可以删除 "bb" 由于两字母相邻且相同，这是此时唯一可以执行删除操作的重复项。之后我们得到字符串 "aaca"，其中又只有 "aa" 可以执行重复项删除操作，所以最后的字符串为 "ca"。


    提示：

        1 <= S.length <= 20000
        S 仅由小写英文字母组成。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/remove-all-adjacent-duplicates-in-string
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            string str = RemoveDuplicates("abbaca");
        }

        public static string RemoveDuplicates(string S)
        {
            Stack<char> stack = new Stack<char>();
            stack.Push(S[0]);
            for (int i = 1; i < S.Length; i++)
            {

                if (stack.Count > 0 && S[i] == stack.Peek())
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(S[i]);
                }
            }
            return new string(stack.Reverse().ToArray());
        }

        public static string RemoveDuplicates2(string S)
        {            
            StringBuilder sb = new StringBuilder();
            sb.Append(S[0]);
            for (int i = 1; i < S.Length; i++)
            {
                if(sb.Length>0 && S[i]==sb[sb.Length-1])
                {
                    sb.Remove(sb.Length - 1, 1);
                }
                else
                {
                    sb.Append(S[i]);
                }
            }

            return sb.ToString();
        }
    }
}
