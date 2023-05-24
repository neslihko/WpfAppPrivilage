using System.Collections.Generic;
using System.Windows.Media;
using System.Windows;
using WpfAppPrivilage;
namespace WpfAppPrivilage
{
      class VectorGraphicViewer : FrameworkElement
    {
        public  List<Shape>? Shapes { get; set; }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
           

            // Draw each shape in the collection
            foreach (var shape in Shapes)
            {
                shape.Draw(drawingContext);
            }
        }
    }
}
