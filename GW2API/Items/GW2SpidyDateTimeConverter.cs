using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Utilities;


namespace GW2API.Items
{
    class GW2SpidyDateTimeConverter : DateTimeConverterBase
    {
        private static string datePropertyName = "price_last_changed";
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is DateTime)
            {
                DateTime dateTime = ((DateTime)value).ToUniversalTime();
                writer.WriteValue(String.Format("{0} UTC" , dateTime.ToString("YYYY-MM-dd HH:mm:ss")));
            }
            else
            {
                throw new Exception("Expected System.DateTime object.");
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.String)
                throw new Exception(String.Format("Unexpected token parsing date. Expected String, got {0}.", reader.TokenType));

            return DateTime.Parse(((string)reader.Value).Replace("UTC", string.Empty)).ToUniversalTime();
        }
    }
}
