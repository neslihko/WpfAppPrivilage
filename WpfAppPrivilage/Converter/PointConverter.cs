namespace WpfAppPrivilage
{
    using Newtonsoft.Json;

    using System;

    using System.Windows;

    public class PointConverter : JsonConverter<Point>
    {
        public override Point ReadJson(JsonReader reader, Type objectType, Point existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var pointString = reader.Value?.ToString();
            var coordinates = pointString?.Split(';');

            if (coordinates == null ||
                coordinates.Length != 2 ||
                !double.TryParse(coordinates[0].Trim(), out double x) ||
                !double.TryParse(coordinates[1].Trim(), out double y))
            {
                throw new JsonSerializationException($"Invalid point format: {pointString}. Try using ; as a separator.");
            }

            return new Point(x, y);
        }

        public override void WriteJson(JsonWriter writer, Point value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}