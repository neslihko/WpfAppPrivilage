using System.Windows;

using System.Windows.Media;



namespace WpfAppPrivilage
{
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Circle))]

    class Circle : Shape
    {

        public Point Center { get; set; }
        public float Radius { get; set; }


        public override void Draw(DrawingContext drawingContext)
        {

             
            Pen borderPen = new Pen(new SolidColorBrush(Color), 1.0);
            double innerRadius = Radius - borderPen.Thickness / 2.0;
            double outerRadius = Radius + borderPen.Thickness / 2.0;

            if (base.Filled)
            {
                SolidColorBrush fillBrush = new SolidColorBrush(base.Color);
                drawingContext.DrawEllipse(fillBrush, borderPen, Center, innerRadius  , innerRadius  );
            }
            else
            {
                drawingContext.DrawEllipse(null, borderPen, Center, outerRadius, outerRadius);
            }

        }
    }
}