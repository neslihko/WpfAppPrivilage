namespace WpfAppPrivilage
{
    using System.Windows;
    using System.Windows.Media;
    using System.Xml.Serialization;

    [XmlInclude(typeof(Line))]
    internal class Line : Shape
    {
        public Point A { get; set; }

        public Point B { get; set; }

        public override void Draw(DrawingContext context)
        {
            var pen = new Pen(new SolidColorBrush(Color), 4);
            var start = new Point(A.X, -A.Y);
            var end = new Point(B.X, -B.Y);

            context.DrawLine(pen, start, end);
        }
    }
}
