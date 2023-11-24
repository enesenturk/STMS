using System.Buffers;
using System.Text.Json;

namespace NS.STMS.API.Converters.CustomJSonConverters
{
    public static class JSonConverterHelper
    {

        public static ReadOnlySpan<byte> GetSentBytes(this Utf8JsonReader reader)
        {
            return reader.HasValueSequence ? reader.ValueSequence.ToArray() : reader.ValueSpan;
        }

    }
}
