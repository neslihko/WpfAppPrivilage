using System.Collections.Generic;
using System.Windows.Media;
using System.Windows;
using Newtonsoft.Json;
using System.IO;

namespace WpfAppPrivilage
{
    internal class VectorGraphicViewer : FrameworkElement
    {
        private List<Shape>? Shapes { get; set; }

        public void ReadShapes(string shapesPath)
        {
            var text = File.ReadAllText(shapesPath);

            var settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new ShapeConverter(), new PointConverter(), new ColorConverter() }
            };

            Shapes = JsonConvert.DeserializeObject<List<Shape>>(text, settings) ?? new List<Shape>();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            Shapes?.ForEach(shape => shape.Draw(drawingContext));
        }
    }
}
