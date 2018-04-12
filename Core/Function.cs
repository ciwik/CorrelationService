using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class Function
    {
        private SortedDictionary<double, Point> _points;

        public Point this[int index] => _points.Values.ElementAt(index);
        public Point this[double parameter]
        {
            get
            {
                if (_points.ContainsKey(parameter))
                    return _points[parameter];

                double t = (parameter - this[0].X) / (this[Count - 1].X - this[0].X);
                int m = (int)(t * Count);
                if (m == Count - 1)
                    return this[m];
                t = (parameter - this[m].X) / (this[m + 1].X - this[m].X);
                return new Point(parameter, this[m].Y + t * (this[m + 1].Y - this[m].Y));
            }
        }

        public int Count => _points.Count;
        public double Average => _points.Values.Average(p => p.Y);

        public Function()
        {
            _points = new SortedDictionary<double, Point>();
        }

        public Function(Function func)
        {
            _points = func._points;
        }

        public void Add(Point point)
        {
            _points.Add(point.X, point);
        }

        public void Scale(int count)
        {
            var points = new SortedDictionary<double, Point>();

            double leftBorder = _points.First().Key;
            double rightBorder = _points.Last().Key;
            double step = (rightBorder - leftBorder) / count;

            for (double x = leftBorder; x < rightBorder; x += step)
            {
                points.Add(x, this[x]);
            }

            _points = points;
        }

        public static Function Create(Func<double, double> f, double leftBorder, double rightBorder, double step)
        {
            var result = new Function();

            result._points = new SortedDictionary<double, Point>();
            for (double x = leftBorder; x <= rightBorder - step; x += step)
            {
                result._points.Add(x, new Point(x, f(x)));
            }
            result._points.Add(rightBorder, new Point(rightBorder, f(rightBorder)));

            return result;
        }

        public static Function Create(Func<double, double> f, double leftBorder, double rightBorder, int pointsCount)
        {
            double step = (rightBorder - leftBorder) / (pointsCount - 1);
            return Create(f, leftBorder, rightBorder, step);
        }
    }
}
