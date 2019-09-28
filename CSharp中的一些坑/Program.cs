using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp中的一些坑
{
    class Program
    {
        struct Point
        {
            public int x;
            public int y;
        }
        class PointBox
        {
            public int Number { get; set; }
            public Point Point { get; set; }
        }
        static void Main(string[] args)
        {
            var ps1 = new Point[] { new Point { x = 1, y = 2 } };
            ps1[0].x = 3;

            var ps2 = new List<Point> { new Point { x = 1, y = 2 } };
            ps2[0].x = 3;

            var box = new PointBox() { Number = 1, Point = new Point { x = 1, y = 2 } };
            box.Number += 3;
            box.Point.x = 5;
        }
    }
}
