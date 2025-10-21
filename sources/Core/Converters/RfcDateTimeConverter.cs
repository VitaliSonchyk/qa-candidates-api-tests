using System.Globalization;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Core.Converters
{
    public class Rfc1123DateTimeConverter : JsonConverter<DateTime>
    {
        private static readonly string[] Formats =
         {
            "r",                   // Standard RFC1123 format: "Mon, 07 Feb 2022 00:01:24 GMT"
            "ddd, d MMM yyyy HH:mm:ss 'GMT'" // Allows single-digit day: "Mon, 7 Feb 2022 00:01:24 GMT"
        };

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            if (value == null)
                throw new JsonException("Date string is null.");

            return DateTime.ParseExact(
                value,
                Formats,
                CultureInfo.InvariantCulture,
                DateTimeStyles.AdjustToUniversal | DateTimeStyles.AllowWhiteSpaces
            );
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            // Always write in proper RFC1123 format with leading zero
            writer.WriteStringValue(value.ToUniversalTime().ToString("r", CultureInfo.InvariantCulture));
        }
    }
}
