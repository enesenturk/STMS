using System.Buffers.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NS.STMS.API.Converters.CustomJSonConverters
{
    public class intJSonConverter : JsonConverter<int>
    {

        public override int Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
        {
            int defaultValue = 0;

            if (reader.TokenType == JsonTokenType.String)
            {
                ReadOnlySpan<byte> sentBytes = reader.GetSentBytes();

                bool isEmptyString = sentBytes.Length == 0;

                if (isEmptyString)
                    return defaultValue;

                if (Utf8Parser.TryParse(sentBytes, out int sentValue, out int bytesConsumed) && sentBytes.Length == bytesConsumed)
                    return sentValue;

                // try to parse from a string if the above failed, this covers cases with other escaped/UTF characters
                if (int.TryParse(reader.GetString(), out sentValue))
                    return sentValue;
                else
                    return defaultValue;
            }
            else if (reader.TokenType == JsonTokenType.Null)
            {
                return defaultValue;
            }

            // default handling
            return reader.GetInt32();
        }

        public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value);
        }

    }
}
