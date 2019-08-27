using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform_MaskedTextBox控件实现输入验证
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /*
        掩码元素 	说明 	                                                                                正则表达式元素
            0 	    0 到 9 之间的任何一个数字。必选项。 	                                                        /d
            9 	    数字或空格。可选项。 	                                                                        [ /d]?
            # 	    数字或空格。可选项。如果此位置在掩码中保留为空，它将显示为空格。允许使用加号 (+) 和减号 (-)。 	    [ /d+-]?
            L 	    ASCII 字母。必选项。 	                                                                        [a-zA-Z]
            ? 	    ASCII 字母。可选项。 	                                                                        [a-zA-Z]?
            & 	    字符。必选项。 	                                                                            [/p{Ll}/p{Lu}/p{Lt}/p{Lm}/p{Lo}]
            C 	    字符。可选项。 	                                                                            [/p{Ll}/p{Lu}/p{Lt}/p{Lm}/p{Lo}]?
            A 	    字母数字。可选项。 	                                                                        /W
            . 	    相应于区域性的小数点占位符。 	                                                                不可用。
            , 	    相应于区域性的千分位占位符。 	                                                                不可用。
            : 	    相应于区域性的时间分隔符。 	                                                                不可用。
            / 	    相应于区域性的日期分隔符。 	                                                                不可用。
            $ 	    相应于区域性的货币符号。 	                                                                    不可用。
            <  	    将后面的所有字符转换为小写。 	                                                                不可用。
            > 	    将后面的所有字符转换为大写。 	                                                                不可用。
            | 	    停止前面的大写转换或小写转换。 	                                                            不可用。
            / 	    对掩码字符进行转义，将它转换为原义字符。“//”是反斜杠的转义序列。 	                                /
            所有其他字符。 	原义字符。所有非掩码元素将在 MaskedTextBox 中以原样显示。 	所有其他字符。


        */
        private void Form1_Load(object sender, EventArgs e)
        {
            this.maskedTextBox1.Mask = "000000-00000000-000A";//身份证号码18位
            this.maskedTextBox2.Mask = "000000-000000-000";//身份证号码15位
            this.maskedTextBox3.Mask = "000000";//邮政编码
            this.maskedTextBox4.Mask = "0000年90月90日";//出生日期
        }
    }
}
