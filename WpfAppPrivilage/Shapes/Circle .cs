namespace WpfAppPrivilage
{
    using System.Windows;

    using System.Windows.Media;
    using System.Xml.Serialization;

    [XmlInclude(typeof(Circle))]
    internal class Circle : Shape
    {
        public Point Center { get; set; }

        public double Radius { get; set; }

        public override void Draw(DrawingContext context)
        {
            var borderPen = new Pen(new SolidColorBrush(Color), 4.0);
            var innerRadius = Radius - borderPen.Thickness / 2.0;
            var outerRadius = Radius + borderPen.Thickness / 2.0;

            if (base.Filled)
            {
                var fillBrush = new SolidColorBrush(base.Color);
                context.DrawEllipse(fillBrush, borderPen, Center, innerRadius, innerRadius);
            }
            else
            {
                context.DrawEllipse(null, borderPen, Center, outerRadius, outerRadius);
            }
        }
    }
}