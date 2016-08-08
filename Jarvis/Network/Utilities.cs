using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Network
{
    public class Utilities
    {
        public float x;
        public float y;
        public PointF[] points;
        public float phi = 1.61803398874989484820458683436F;
        public Int16 spiralInterval = 100;
        public Int16 levelLimit = 3;
        public Int16 levelCount = 0;
        List<PointF> AllPoints = new List<PointF>();


        public List<PointF> getInputPoints(Int16 x, Int16 y, Int16 spInt)
        {

            points = new PointF[2];
            points[0].X = x;
            points[0].Y = y;
            points[1].X = (x / 2);
            points[1].Y = (y / 3);
            spiralInterval = spInt;
            loadPoints();
            return AllPoints;
        }


        private void loadPoints()
        {
            // Draw the true spiral.
            PointF start = points[0];
            PointF origin = points[points.Count() - 1];
            float dx = start.X - origin.X;
            float dy = start.Y - origin.Y;
            double radius = Math.Sqrt(dx * dx + dy * dy);
            double theta = Math.Atan2(dy, dx);
            const Int16 num_slices = 1000;
            double dtheta = Math.PI / 2 / num_slices;
            double factor = 1 - (1 / phi) / num_slices * 0.78; //@
            List<PointF> new_points = new List<PointF>();
            // Repeat until dist is too small to see.
            Int16 count = 0;

            while (radius > 2)
            {
                count++;
                PointF new_point = new PointF(
                (float)(origin.X + radius * Math.Cos(theta)),
                (float)(origin.Y + radius * Math.Sin(theta)));
                PointF startPoint = new PointF();
                try
                {
                    new_points.Add(new_point);

                    if (count == spiralInterval)
                    {

                        startPoint.X = ((new_point.X + origin.X) / 2);
                        startPoint.Y = ((new_point.Y + origin.Y) / 2);
                        if (Math.Abs(startPoint.X - new_point.X) > 2 && Math.Abs(startPoint.Y - new_point.Y) > 2)
                        {
                            drawNewSpiral( new_point, startPoint, theta + (dtheta), 1, true);
                        }
                        count = 0;
                    }
                    theta += dtheta;
                    radius *= factor;
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                }
            }

            theta = Math.Atan2(dy, dx);
            theta = theta + 90;
            radius = Math.Sqrt(dx * dx + dy * dy);
            count = 0;

            while (radius > 2)
            {
                count++;
                PointF new_point = new PointF(
                (float)(origin.X + radius * Math.Cos(theta)),
                (float)(origin.Y + radius * Math.Sin(theta)));
                PointF startPoint = new PointF();
                try
                {
                    new_points.Add(new_point);

                    if (count == spiralInterval)
                    {

                        startPoint.X = ((new_point.X + origin.X) / 2);
                        startPoint.Y = ((new_point.Y + origin.Y) / 2);
                        if (Math.Abs(startPoint.X - new_point.X) > 2 && Math.Abs(startPoint.Y - new_point.Y) > 2)
                        {
                            drawNewSpiral( new_point, startPoint, theta + (dtheta), 1, false);
                        }
                        count = 0;
                    }
                    theta += dtheta;
                    radius *= factor;
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                }
            }
          

            AllPoints.AddRange(new_points);

        }



        private void drawNewSpiral(PointF start, PointF origin, double theta, Int16 level, bool reverse )
        {
            if (level >= levelLimit)
            {
                return;
            }
            levelCount++;
            float dx = start.X - origin.X;
            float dy = start.Y - origin.Y;
            double radius = Math.Sqrt(dx * dx + dy * dy);
            const Int16 num_slices = 1000;
            double dtheta = Math.PI / 2 / num_slices;
            double factor = 1 - (1 / phi) / num_slices * 0.78; //@
            List<PointF> new_points = new List<PointF>();
            // Repeat until dist is too small to see.
            Int16 count = 0;
            while (radius > 2)
            {

                count++;
                PointF new_point = new PointF(
                (float)(origin.X + radius * Math.Cos(theta)),
                (float)(origin.Y + radius * Math.Sin(theta)));
                PointF startPoint = new PointF();
                try
                {
                    new_points.Add(new_point);

                    if (count >= (spiralInterval / level))
                    {

                        startPoint.X = ((new_point.X + origin.X) / 2);
                        startPoint.Y = ((new_point.Y + origin.Y) / 2);
                        if (Math.Abs(startPoint.X - new_point.X) > 2 && Math.Abs(startPoint.Y - new_point.Y) > 2)
                        {
<<<<<<< HEAD
                            drawNewSpiral( new_point, startPoint, theta + (dtheta), level + 1, !reverse);
=======
                            drawNewSpiral(new_point, startPoint, theta + (dtheta), (Int16)(level + 1), !reverse);
>>>>>>> origin/Input_Classes
                        }
                        count = 0;
                    }
                    if (reverse)
                    {
                        theta -= dtheta;

                    }
                    else
                    {
                        theta += dtheta;
                    }

                    radius *= factor;
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                }

            }
            AllPoints.AddRange(new_points);
        }
    }
}
