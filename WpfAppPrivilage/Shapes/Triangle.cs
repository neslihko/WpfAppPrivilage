namespace WpfAppPrivilage
{
    using System.Windows.Media;

    using System.Windows;
    using System.Xml.Serialization;

    [XmlInclude(typeof(Triangle))]
    internal class Triangle : Shape
    {
        public Point A { get; set; }

        public Point B { get; set; }

        public Point C { get; set; }

        public override void Draw(DrawingContext context)
        {
            var pen = new Pen(new SolidColorBrush(Color), 4);

            context.DrawGeometry(Filled ? new SolidColorBrush(Color) : null, pen, CreateTriangleGeometry());
        }

        private Geometry CreateTriangleGeometry()
        {
            var geometry = new StreamGeometry();

            using (StreamGeometryContext context = geometry.Open())
            {
                context.BeginFigure(A, base.Filled, true);
                context.LineTo(B, true, false);
                context.LineTo(C, true, false);
                context.Close();
            }

            geometry.Freeze();
            return geometry;
        }
    }
}
