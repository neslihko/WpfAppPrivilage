using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfAppPrivilage
{
    [JsonDerivedType(typeof(Circle), typeDiscriminator: "Circle")]
    [JsonDerivedType(typeof(Line), typeDiscriminator: "Line")]
    [JsonDerivedType(typeof(Triangle), typeDiscriminator: "Triangle")]
    public abstract class Shape
    {
        
        public System.Windows.Media.Color Color { get; set; }
        public bool Filled { get; set; }
        public abstract void Draw(DrawingContext drawingContext);


    }
}
