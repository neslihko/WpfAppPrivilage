namespace WpfAppPrivilage
{
    using System.Windows.Media;

    public abstract class Shape
    {
        public Color Color { get; set; }

        public bool Filled { get; set; }

        public abstract void Draw(DrawingContext context);
    }
}
