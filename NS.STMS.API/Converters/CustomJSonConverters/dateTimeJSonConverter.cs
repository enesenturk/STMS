using System.Buffers.Text;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NS.STMS.API.Converters.CustomJSonConverters
{
    public class dateTimeJSonConverter : JsonConverter<DateTime>
    {

        public override DateTime Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
        {
            DateTime defaultValue = DateTime.MinValue;

            if (reader.TokenType == JsonTokenType.String)
            {
                ReadOnlySpan<byte> sentBytes = reader.GetSentBytes();

                bool isEmptyString = sentBytes.Length == 0;

                if (isEmptyString)
                    return defaultValue;

                if (Utf8Parser.TryParse(sentBytes, out DateTime sentValue, out int bytesConsumed) && sentBytes.Length == bytesConsumed)
                    return sentValue;

                // try to parse from a string if the above failed, this covers cases with other escaped/UTF characters
                if (DateTime.TryParse(reader.GetString(), out sentValue))
                    return sentValue;
                else
                    return defaultValue;
            }
            else if (reader.TokenType == JsonTokenType.Null)
            {
                return defaultValue;
            }

            // default handling
            return reader.GetDateTime();
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture));
        }

    }
}
