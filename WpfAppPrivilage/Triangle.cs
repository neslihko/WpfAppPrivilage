using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;
 
using System.Windows;

namespace WpfAppPrivilage
{
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Triangle))]
    class Triangle : Shape
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }


        public override void Draw(DrawingContext drawingContext)
        {
          
            Pen pen = new Pen(new SolidColorBrush(Color), 100);

            if (base.Filled)
            {
                SolidColorBrush fillBrush = new SolidColorBrush(base.Color);
                drawingContext.DrawGeometry(fillBrush, pen, CreateTriangleGeometry());
            }
            else
            {
                drawingContext.DrawGeometry(null, pen, CreateTriangleGeometry());
            }
        }

        private Geometry CreateTriangleGeometry()
        {
            StreamGeometry geometry = new StreamGeometry();

            using (StreamGeometryContext context = geometry.Open())
            {
                context.BeginFigure(A, false, false);
                context.LineTo(B, true, false);
                context.LineTo(C, true, false);
                context.Close();
            }

            geometry.Freeze();
            return geometry;
        }
    }
}
