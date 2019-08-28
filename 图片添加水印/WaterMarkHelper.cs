using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace 图片添加水印
{
    class WaterMarkHelper
    {
        /// <summary>
        /// 添加水印
        /// </summary>
        /// <param name="imgPath">原图片地址</param>
        /// <param name="sImgPath">水印图片地址</param>
        /// <returns>resMsg[0] 成功,失败 </returns>
        public static string[] AddWaterMark(string imgPath, string sImgPath)
        {
            string[] resMsg = new[] { "成功", sImgPath };
            using (Image image = Image.FromFile(imgPath))
            {
                try
                {
                    Bitmap bitmap = new Bitmap(image);

                    int width = bitmap.Width, height = bitmap.Height;
                    //水印文字
                    string text = "版权保密";

                    Graphics g = Graphics.FromImage(bitmap);

                    g.DrawImage(bitmap, 0, 0);

                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                    g.DrawImage(image, new Rectangle(0, 0, width, height), 0, 0, width, height, GraphicsUnit.Pixel);

                    Font crFont = new Font("微软雅黑", 120, FontStyle.Bold);
                    SizeF crSize = new SizeF();
                    crSize = g.MeasureString(text, crFont);

                    //背景位置(去掉了. 如果想用可以自己调一调 位置.)
                    //graphics.FillRectangle(new SolidBrush(Color.FromArgb(200, 255, 255, 255)), (width - crSize.Width) / 2, (height - crSize.Height) / 2, crSize.Width, crSize.Height);

                    SolidBrush semiTransBrush = new SolidBrush(Color.FromArgb(120, 177, 171, 171));

                    //将原点移动 到图片中点
                    g.TranslateTransform(width / 2, height / 2);
                    //以原点为中心 转 -45度
                    g.RotateTransform(-45);

                    g.DrawString(text, crFont, semiTransBrush, new PointF(0, 0));

                    //保存文件
                    bitmap.Save(sImgPath, System.Drawing.Imaging.ImageFormat.Jpeg);

                }
                catch (Exception e)
                {

                    resMsg[0] = "失败";
                    resMsg[1] = e.Message;
                }
            }

            return resMsg;
        }

    }
}
