//Autor: Dominik Bonna
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Geometric_figures
{
    public partial class MainWindow : Window
    {
        public bool itIsDrawn = false;
        public bool itIsCircle = false;
        public bool itIsTriangle = false;
        public bool itIsRectangle = false;
        public bool itIsPentagon = false;
        List<Point> points = new List<Point>();
        public void GetMousePosition()
        {
            Point pointToWindow = Mouse.GetPosition(canvas);
            points.Add(pointToWindow);
        }
        public MainWindow()
        {
            InitializeComponent();
            info.Text = "Aby utworzyć figurę, wybierz ją z panelu obok";
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
            points.Clear();
            info.Text = "Aby utworzyć figurę, wybierz ją z panelu obok";
            area.Content = null;
            perimeter.Content = null;
            pentagon.IsChecked = false;
            rectangle.IsChecked = false;
            triangle.IsChecked = false;
            circle.IsChecked = false;
            itIsDrawn = false;
            itIsCircle = false;
            itIsTriangle = false;
            itIsRectangle = false;
            itIsPentagon = false;
    }

        private void Pentagon_Click(object sender, RoutedEventArgs e)
        {
            itIsPentagon = true;
            points.Clear();
            info.Text = "Wybierz 1 punkt pięciokąta";
        }

        private void Triangle_Click(object sender, RoutedEventArgs e)
        {
            itIsTriangle = true;
            points.Clear();
            info.Text = "Wybierz 1 punkt trójkąta";
        }

        private void Rectangle_Click(object sender, RoutedEventArgs e)
        {
            itIsRectangle = true;
            points.Clear();
            info.Text = "Wybierz 1 punkt czworokąta";
        }

        private void Circle_Click(object sender, RoutedEventArgs e)
        {
            itIsCircle = true;
            points.Clear();
            info.Text = "Wybierz środek okręgu";
        }

        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GetMousePosition();
            info.Text = $"Wybierz {points.Count + 1} punkt figury";
            if (itIsDrawn == false)
            {
                if (points.Count == 2 && itIsCircle == true)
                {
                    double r = Math.Sqrt(Math.Pow(points[0].X - points[1].X, 2) + Math.Pow(points[0].Y - points[1].Y, 2));
                    Circle circle = new Circle(points[0], r);
                    itIsDrawn = true;
                    info.Text = "Utworzono okrąg. Wciśnij przycisk \"wyczyść\", jeśli chcesz narysować inną figurę";
                }
                else if (points.Count == 3 && itIsTriangle == true)
                {
                    Triangle triangle = new Triangle(points[0], points[1], points[2]);
                    itIsDrawn = true;
                    info.Text = "Utworzono trójkąt. Wciśnij przycisk \"wyczyść\", jeśli chcesz narysować inną figurę";
                }
                else if (points.Count == 4 && itIsRectangle == true)
                {
                    Rectangle rectangle = new Rectangle(points[0], points[1], points[2], points[3]);
                    itIsDrawn = true;
                    info.Text = "Utworzono czworokąt. Wciśnij przycisk \"wyczyść\", jeśli chcesz narysować inną figurę";
                }
                if (points.Count == 5 && itIsPentagon ==true)
                {
                    Pentagon pentagon = new Pentagon(points[0], points[1], points[2], points[3], points[4]);
                    itIsDrawn = true;
                    info.Text = "Utworzono pięciokąt. Wciśnij przycisk \"wyczyść\", jeśli chcesz narysować inną figurę";
                }
            }
            else
                info.Text="Przed utworzeniem kolejnej figury wciśnij przycisk \"wyczyść\"";   
        }
    }
}
    