using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ant_colony
{
    public class Path
    {
        PointF start;
        PointF end;
        float distance;
        float pheromoneLvl;

        public Path()
        {
            start = new PointF(0, 0);
            end = new PointF(0, 0);
            distance = 0;
            pheromoneLvl = 0;
        }

        public Path(PointF startPoint, PointF endPoint)
        {
            start = startPoint;
            end = endPoint;
            distance = (float)Math.Pow((Math.Pow(start.X - end.X, 2F) + Math.Pow(start.Y - end.Y, 2F)), .5F);
            pheromoneLvl = 0;
        }

        public float getPheroLvl()
        {
            return pheromoneLvl;
        }

        public float getDistance()
        {
            return distance;
        }
    }
}
