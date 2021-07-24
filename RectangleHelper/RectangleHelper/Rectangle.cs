using System;

namespace RectangleHelper
{
    public class Rectangle
    {
        private double width { get;  set; }
        private double length { get;  set; }
       
        public Rectangle(double width, double length)
        {
            if (width <= 0d || length <= 0d)
            {
                throw new ArgumentException("invalid width or lenght");
            }
            this.width = width;
            this.length = length;
        }

        public double Perimeter()
        {
            return (length + width) * 2;
        }
        public double Square()
        {
            return length * width;
        }
    }
}
