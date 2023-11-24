using System.Buffers.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NS.STMS.API.Converters.CustomJSonConverters
{
	public class booleanJSonConverter : JsonConverter<bool>
	{

		public override bool Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
		{
			bool defaultValue = false;

			if (reader.TokenType == JsonTokenType.String)
			{
				ReadOnlySpan<byte> sentBytes = reader.GetSentBytes();

				bool isEmptyString = sentBytes.Length == 0;

				if (isEmptyString)
					return defaultValue;

				if (Utf8Parser.TryParse(sentBytes, out bool sentValue, out int bytesConsumed) && sentBytes.Length == bytesConsumed)
					return sentValue;

				string sentString = reader.GetString();

				if (sentString is "1")
					return true;

				if (bool.TryParse(sentString, out sentValue))
					return sentValue;
				else
					return defaultValue;
			}
			else if (reader.TokenType == JsonTokenType.Null)
			{
				return defaultValue;
			}
			else if (reader.TokenType == JsonTokenType.Number)
			{
				int sentInt = reader.GetInt32();

				if (sentInt is 1)
					return true;
				else
					return defaultValue;
			}

			return reader.GetBoolean();
		}

		public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
		{
			writer.WriteBooleanValue(value);
		}

	}
}
