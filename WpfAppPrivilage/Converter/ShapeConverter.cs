using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using NPOI.SS.Formula.Functions;
using WpfAppPrivilage;

namespace WpfAppPrivilage
{
    public class ShapeConverter : JsonConverter<Shape>
    {
     

      

        public override Shape? ReadJson(JsonReader reader, Type objectType, Shape? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {

            JObject jsonObject = JObject.Load(reader);

            // Determine the concrete type based on the "type" property in JSON
            string shapeType = jsonObject["type"].ToString();

            // Create an instance of the concrete type
            Shape shape;
            switch (shapeType)
            {
                case "line":
                    shape = new Line();
                    break;
                case "circle":
                    shape = new Circle();
                    break;
                case "triangle":
                    shape = new Triangle();
                    break;

                default:
                    throw new NotSupportedException($"Shape type '{shapeType}' is not supported.");
            }

            // Populate the properties of the shape object
            serializer.Populate(jsonObject.CreateReader(), shape);

            return shape;
        }

        public override void WriteJson(JsonWriter writer, Shape? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
