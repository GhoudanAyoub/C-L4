using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Point
    {
        private double x;
        private double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }


        public void deplacer(double x2,double y2)
        {
            this.x = x2;
            this.y = y2;
        }

        public string afficher()
        {
            return "(" + this.x + "," + this.y + ")";
        }
        public Point SymParX()
        {
            return new Point(this.x,-this.y);
        }
        public Point SymParY()
        {
            return new Point(-this.x,this.y);
        }
        public Point SymParORIGIN()
        {
            return new Point(-this.x,-this.y);
        }
        public void Permuter()
        {
            this.x = y;
            this.y = x;
        }


    }
}
