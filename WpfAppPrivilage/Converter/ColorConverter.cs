using Newtonsoft.Json;
using System;

using System.Windows;
using System.Windows.Media;

namespace WpfAppPrivilage
{
    public class ColorConverter : JsonConverter<Color>
    {
        public override Color ReadJson(JsonReader reader, Type objectType, Color existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var colorString = reader.Value.ToString();
            string[] colorValues = colorString.Split(';');

            if (colorValues.Length != 4 ||
                !byte.TryParse(colorValues[0], out byte a) ||
                !byte.TryParse(colorValues[1], out byte r) ||
                !byte.TryParse(colorValues[2], out byte g) ||
                !byte.TryParse(colorValues[3], out byte b))
            {
                throw new JsonSerializationException($"Invalid color format: {colorString}");
            }

            return Color.FromArgb(a, r, g, b);
        }





        public override void WriteJson(JsonWriter writer, Color value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }


}