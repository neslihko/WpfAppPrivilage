using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
 

namespace WpfAppPrivilage
{
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Line))]
    class Line : Shape
    {
        public Point a { get; set; }
        public Point b { get; set; }

        public override void Draw(DrawingContext drawingContext)
        {
            Pen pen = new Pen(new SolidColorBrush(Color),100.0);
            Point startPoint = new Point(a.X, -a.Y);
            Point endPoint = new Point(b.X, -b.Y);
            drawingContext.DrawLine(pen, startPoint, endPoint);
        }
 
    }
}
