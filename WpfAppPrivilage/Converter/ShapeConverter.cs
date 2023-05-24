namespace WpfAppPrivilage
{
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;
    using System;

    public class ShapeConverter : JsonConverter<Shape>
    {
        public override Shape? ReadJson(JsonReader reader, Type objectType, Shape? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);

            if (jsonObject == null)
            {
                return null;
            }

            // Determine the concrete type based on the "type" property in JSON
            var shapeType = jsonObject["type"]?.ToString();

            // Create an instance of the concrete type
            Shape shape = shapeType switch
            {
                "line" => new Line(),
                "circle" => new Circle(),
                "triangle" => new Triangle(),
                _ => throw new NotSupportedException($"Shape type '{shapeType}' is not supported."),
            };

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
