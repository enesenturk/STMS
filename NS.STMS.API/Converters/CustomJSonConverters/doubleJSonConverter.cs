using System.Buffers.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NS.STMS.API.Converters.CustomJSonConverters
{
    public class doubleJSonConverter : JsonConverter<double>
    {

        public override double Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
        {
            double defaultValue = 0;

            if (reader.TokenType == JsonTokenType.String)
            {
                ReadOnlySpan<byte> sentBytes = reader.GetSentBytes();

                bool isEmptyString = sentBytes.Length == 0;

                if (isEmptyString)
                    return defaultValue;

                if (Utf8Parser.TryParse(sentBytes, out double sentValue, out int bytesConsumed) && sentBytes.Length == bytesConsumed)
                    return sentValue;

                // try to parse from a string if the above failed, this covers cases with other escaped/UTF characters
                if (double.TryParse(reader.GetString(), out sentValue))
                    return sentValue;
                else
                    return defaultValue;
            }
            else if (reader.TokenType == JsonTokenType.Null)
            {
                return defaultValue;
            }

            // default handling
            return reader.GetDouble();
        }

        public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value);
        }

    }
}
