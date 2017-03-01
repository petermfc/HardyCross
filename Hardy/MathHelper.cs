using System;
using System.Drawing;

namespace Hardy
{
    public class MathHelper
    {
        public static float P3A(Point A, Point B, Point C)
        {
            float angle = 0;
            int v1x = B.X - C.X;
            int v1y = B.Y - C.Y;
            int v2x = A.X - C.X;
            int v2y = A.Y - C.Y;
            angle =(float)(Math.Atan2(v1x, v1y) - Math.Atan2(v2x, v2y) * 180 / Math.PI) ;
            return angle;
        }
        public static double P3A(PointF A, PointF B, PointF C)
        {
            double angle = 0;
            double v1x = B.X - C.X;
            double v1y = B.Y - C.Y;
            double v2x = A.X - C.X;
            double v2y = A.Y - C.Y;
            angle = Math.Atan2(v1x, v1y) - Math.Atan2(v2x, v2y) * 180 / Math.PI;
            return angle;
        }

        public static Point MiddlePoint2(Point a, Point b)
        {
            Point p = new Point((a.X + b.X) / 2, (a.Y + b.Y) / 2);
            return p;
        }

        public static PointF MiddlePoint2F(PointF a, PointF b)
        {
            PointF p = new PointF((a.X + b.X) / 2, (a.Y + b.Y) / 2);
            return p;
        }
    }
}
