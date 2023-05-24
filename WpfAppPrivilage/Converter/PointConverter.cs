using Newtonsoft.Json;
using System;

using System.Windows;

namespace WpfAppPrivilage
{
    public class PointConverter :  JsonConverter<Point>
    {
        public override Point ReadJson(JsonReader reader, Type objectType, Point existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string pointString = reader.Value.ToString();
            string[] coordinates = pointString.Split(';');

            if (coordinates.Length != 2 || !double.TryParse(coordinates[0], out double x) || !double.TryParse(coordinates[1], out double y))
            {
                throw new JsonSerializationException($"Invalid point format: {pointString}");
            }

            return new Point(x, y);
        }

        public override void WriteJson(JsonWriter writer, Point value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }


    }


}