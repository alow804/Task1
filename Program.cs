using System;
using System.Collections;

namespace Task1
{
    class Program
    {
        //Abstract Class for the Figure methods(Move and Rotate)
        public abstract class Figure
        {
            public abstract void Move(double offsetX, double offsetY);
            public abstract void Rotate(double angleInDegrees);
        }

        //----Point class---------
        public class Point : Figure
        {
            private double x;
            private double y;

            public Point()
            {

            }

            public Point(double x, double y)
            {
                this.x = x;
                this.y = y;
            }

            public void setX(double x)
            {
                this.x = x;
            }

            public void setY(double y)
            {
                this.y = y;
            }

            public double getX()
            {
                return x;
            }

            public double getY()
            {
                return y;
            }

            public override void Move(double offsetX, double offsetY)
            {
                x += offsetX;
                y += offsetY;
            }

            public override void Rotate(double angleInDegrees)
            {
                double angleInRadians = angleInDegrees * (Math.PI / 180);
                double cosTheta = Math.Cos(angleInRadians);
                double sinTheta = Math.Sin(angleInRadians);

                double newX = (x * cosTheta) - (y * sinTheta);
                double newY = (x * sinTheta) + (y * cosTheta);

                x = newX;
                y = newY;
            }

            public override string ToString()
            {
                return "Point: (" + x + "," + y + ") ";
            }
        }
        //----Point class---------

        //----Line class--------
        public class Line : Figure
        {
            private Point start;
            private Point end;

            public Line()
            {

            }

            public Line(Point start, Point end)
            {
                this.start = start;
                this.end = end;
            }

            public void setStart(Point start)
            {
                this.start = start;
            }

            public void setEnd(Point end)
            {
                this.end = end;
            }

            public Point getStart()
            {
                return start;
            }

            public Point getEnd()
            {
                return end;
            }

            public double getDistance()
            {
                double dx = end.getX() - start.getX();
                double dy = end.getY() - start.getY();
                return Math.Sqrt((dx * dx) + (dy * dy));
            }

            public override void Move(double offsetX, double offsetY)
            {
                start.Move(offsetX, offsetY);
                end.Move(offsetX, offsetY);
            }

            public void moveStart(double offsetX, double offsetY)
            {
                start.Move(offsetX, offsetY);
            }

            public void moveEnd(double offsetX, double offsetY)
            {
                end.Move(offsetX, offsetY);
            }

            public override void Rotate(double angle)
            {
                start.Rotate(angle);
                end.Rotate(angle);
            }

            public string toStringStart()
            {
                return "(" + start.getX() + "," + start.getY() + ")";
            }

            public string toStringEnd()
            {
                return "(" + end.getX() + "," + end.getY() + ")";
            }

            public override string ToString()
            {
                return "Line Start: " + "(" + start.getX() + "," + start.getY() + ")" + " End: " + "(" + end.getX() + "," + end.getY() + ") ";
            }
        }
        //----Line class--------

        //----Circle class--------
        public class Circle : Figure
        {
            private Point center;
            private double radius;

            public Circle()
            {
            }

            public Circle(Point center, double radius)
            {
                this.center = center;
                this.radius = radius;
            }
            public string getCenter()
            {
                return "(" + center.getX() + "," + center.getY() + ")";
            }

            public double getArea()
            {
                return Math.PI * radius * radius;
            }

            public double getCircumference()
            {
                return 2 * Math.PI * radius;
            }

            public override void Move(double offsetX, double offsetY)
            {
                center.Move(offsetX, offsetY);
            }

            public override void Rotate(double angle)
            {
                center.Rotate(angle);
            }

            public override string ToString() {

                return "Center: " + "(" + center.getX() + "," + center.getY() + ") ";
            }


        }
        //----Circle class--------

        //----Aggregation class--------
        public class Aggregation : Figure
        {
            ArrayList figureList = new ArrayList();

            public Aggregation()
            {
                figureList = new ArrayList();
            }

            public void addFigure(Figure figure)
            {
                figureList.Add(figure);
            }

            public override void Move(double offsetX, double offsetY)
            {
                foreach (Figure figure in figureList) {
                    figure.Move(offsetX, offsetY);
                }
            }

            public override void Rotate(double angleInDegrees)
            {
                foreach (Figure figure in figureList)
                {
                    figure.Rotate(angleInDegrees);
                }
            }

            public override string ToString(){
                string output ="";

                foreach (Figure figure in figureList)
                {
                    output+= figure.ToString();
                }

                return output;
            }
}
        //----Aggregation class--------

        static void Main(string[] args)
        {
            Aggregation list = new Aggregation();
            Point point1 = new Point(1,2);
            Point point2 = new Point(2,1);
            Circle circle1 = new Circle(new Point(3, 1), 5);
            list.addFigure(point1);
            list.addFigure(point2);
            list.addFigure(circle1);

            Console.WriteLine("Original: "+list.ToString());
            list.Move(2, 1);
            Console.WriteLine("After Move: " + list.ToString());
            list.Rotate(50);
            Console.WriteLine("After Rotate: " + list.ToString());

        }

        }

}




