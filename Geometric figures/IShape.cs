//Autor: Dominik Bonna
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Geometric_figures
{
    public interface IShape
    {
        double Area();
        double Perimeter();
    }

    public class Circle : IShape
    {
        private double radius;
        private const double PI = Math.PI;
        public double Area()
        {
            return PI * Math.Pow(radius, 2);
        }
        public double Perimeter()
        {
            return 2 * PI * radius;
        }
        MainWindow window = (MainWindow)System.Windows.Application.Current.MainWindow;
        public Circle(Point pointOne, double radius)
        {
            this.radius = radius;
            window.area.Content = $"Pole wynosi: {Area()}";
            window.perimeter.Content = $"Obwód wynosi: {Perimeter()}";
            Ellipse circle = new Ellipse();
            circle.Width = 2*radius;
            circle.Height = 2*radius;
            circle.SetValue(Canvas.LeftProperty, pointOne.X);
            circle.SetValue(Canvas.TopProperty, pointOne.Y);
            Canvas.SetLeft(circle, pointOne.X - (circle.Width / 2));
            Canvas.SetTop(circle, pointOne.Y - (circle.Height / 2));
            circle.Fill = Brushes.DarkCyan;
            circle.Stroke = Brushes.Black;
            circle.StrokeThickness = 3;
            window.canvas.Children.Add(circle);
        }
    }

    public class Triangle : IShape
    {
        private double a, b, c;
        public double Area()
        {
            double s = (a + b + c) / 2;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }
        public double Perimeter()
        {
            return a + b + c;
        }
        MainWindow window = (MainWindow)System.Windows.Application.Current.MainWindow;
        public Triangle(Point pointOne, Point pointTwo, Point pointThree)
        {
            a = Math.Sqrt(Math.Pow(pointTwo.X - pointOne.X, 2) + Math.Pow(pointTwo.Y - pointOne.Y, 2));
            b = Math.Sqrt(Math.Pow(pointTwo.X - pointThree.X, 2) + Math.Pow(pointTwo.Y - pointThree.Y, 2));
            c = Math.Sqrt(Math.Pow(pointOne.X - pointThree.X, 2) + Math.Pow(pointOne.Y - pointThree.Y, 2));
            window.area.Content = $"Pole wynosi: {Area()}";
            window.perimeter.Content = $"Obwód wynosi: {Perimeter()}";
            Polygon triangle = new Polygon();
            window.canvas.Children.Add(triangle);
            PointCollection points = new PointCollection();
            points.Add(pointOne);
            points.Add(pointTwo);
            points.Add(pointThree);
            triangle.Points = points;
            triangle.Fill = Brushes.DarkMagenta;
            triangle.Stroke = Brushes.Black;
            triangle.StrokeThickness = 3;
        }
    }

    public class Rectangle : IShape
    {
        private double a, b, c, d;
        public double Area() { return 0; }
        public double Area(PointCollection points)
        {
            return Math.Abs(points.Take(points.Count - 1).Select((p, i) => (points[i + 1].X - p.X) * (points[i + 1].Y + p.Y)).Sum() / 2);
        }
        public double Perimeter()
        {
            return a + b + c + d;
        }
        MainWindow window = (MainWindow)System.Windows.Application.Current.MainWindow;
        public Rectangle(Point pointOne, Point pointTwo, Point pointThree, Point pointFour)
        {
            a = Math.Sqrt(Math.Pow(pointTwo.X - pointOne.X, 2) + Math.Pow(pointTwo.Y - pointOne.Y, 2));
            b = Math.Sqrt(Math.Pow(pointThree.X - pointTwo.X, 2) + Math.Pow(pointThree.Y - pointTwo.Y, 2));
            c = Math.Sqrt(Math.Pow(pointFour.X - pointThree.X, 2) + Math.Pow(pointFour.Y - pointThree.Y, 2));
            d = Math.Sqrt(Math.Pow(pointOne.X - pointFour.X, 2) + Math.Pow(pointOne.Y - pointFour.Y, 2));
            Polygon rectangle = new Polygon();
            window.canvas.Children.Add(rectangle);
            PointCollection points = new PointCollection();
            points.Add(pointOne);
            points.Add(pointTwo);
            points.Add(pointThree);
            points.Add(pointFour);
            rectangle.Points = points;
            window.area.Content = $"Pole wynosi: {Area(points)}";
            window.perimeter.Content = $"Obwód wynosi: {Perimeter()}";
            rectangle.Fill = Brushes.Cyan;
            rectangle.Stroke = Brushes.Black;
            rectangle.StrokeThickness = 3;
        }
    }

        public class Pentagon : IShape
        {
            private double a, b, c, d, e;
            public double Area() {return 0;}
            public double Area(PointCollection points)
            {
            return Math.Abs(points.Take(points.Count - 1).Select((p, i) => (points[i + 1].X - p.X) * (points[i + 1].Y + p.Y)).Sum() / 2);
            }
            public double Perimeter()
            {
                return a + b + c + d + e;
            }
            MainWindow window = (MainWindow)System.Windows.Application.Current.MainWindow;
            public Pentagon(Point pointOne, Point pointTwo, Point pointThree, Point pointFour, Point pointFive)
            {
                a = Math.Sqrt(Math.Pow(pointTwo.X - pointOne.X, 2) + Math.Pow(pointTwo.Y - pointOne.Y, 2));
                b = Math.Sqrt(Math.Pow(pointThree.X - pointTwo.X, 2) + Math.Pow(pointThree.Y - pointTwo.Y, 2));
                c = Math.Sqrt(Math.Pow(pointFour.X - pointThree.X, 2) + Math.Pow(pointFour.Y - pointThree.Y, 2));
                d = Math.Sqrt(Math.Pow(pointFive.X - pointFour.X, 2) + Math.Pow(pointFive.Y - pointFour.Y, 2));
                e = Math.Sqrt(Math.Pow(pointOne.X - pointFive.X, 2) + Math.Pow(pointOne.Y - pointFive.Y, 2));
                Polygon pentagon = new Polygon();
                window.canvas.Children.Add(pentagon);
                PointCollection points = new PointCollection();
                points.Add(pointOne);
                points.Add(pointTwo);
                points.Add(pointThree);
                points.Add(pointFour);
                points.Add(pointFive);
                pentagon.Points = points;
                window.area.Content = $"Pole wynosi: {Area(points)}";
                window.perimeter.Content = $"Obwód wynosi: {Perimeter()}";
                pentagon.Fill = Brushes.Yellow;
                pentagon.Stroke = Brushes.Black;
                pentagon.StrokeThickness = 3;
            }
        }
}