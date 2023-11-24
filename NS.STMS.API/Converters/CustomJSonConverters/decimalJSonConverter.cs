using System.Buffers.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NS.STMS.API.Converters.CustomJSonConverters
{
    public class decimalJSonConverter : JsonConverter<decimal>
    {

        public override decimal Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
        {
            decimal defaultValue = 0;

            if (reader.TokenType == JsonTokenType.String)
            {
                ReadOnlySpan<byte> sentBytes = reader.GetSentBytes();

                bool isEmptyString = sentBytes.Length == 0;

                if (isEmptyString)
                    return defaultValue;

                if (Utf8Parser.TryParse(sentBytes, out decimal sentValue, out int bytesConsumed) && sentBytes.Length == bytesConsumed)
                    return sentValue;

                // try to parse from a string if the above failed, this covers cases with other escaped/UTF characters
                if (decimal.TryParse(reader.GetString(), out sentValue))
                    return sentValue;
                else
                    return defaultValue;
            }
            else if (reader.TokenType == JsonTokenType.Null)
            {
                return defaultValue;
            }

            // default handling
            return reader.GetDecimal();
        }

        public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value);
        }

    }
}
