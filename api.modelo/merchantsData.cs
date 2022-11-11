using System;
using System.Collections.Generic;

using System.Globalization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace api.modelo
{
    public partial class MerchantsData
    {
        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("contact_name")]
        public string ContactName { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("logo_url")]
        public object LogoUrl { get; set; }

        [JsonProperty("legal_name")]
        public string LegalName { get; set; }

        [JsonProperty("legal_id_type")]
        public string LegalIdType { get; set; }

        [JsonProperty("legal_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long LegalId { get; set; }

        [JsonProperty("public_key")]
        public string PublicKey { get; set; }

        [JsonProperty("accepted_currencies")]
        public List<string> AcceptedCurrencies { get; set; }

        [JsonProperty("fraud_javascript_key")]
        public object FraudJavascriptKey { get; set; }

        [JsonProperty("fraud_groups")]
        public List<object> FraudGroups { get; set; }

        [JsonProperty("accepted_payment_methods")]
        public List<string> AcceptedPaymentMethods { get; set; }

        [JsonProperty("payment_methods")]
        public List<PaymentMethod> PaymentMethods { get; set; }

        [JsonProperty("presigned_acceptance")]
        public PresignedAcceptance PresignedAcceptance { get; set; }
    }

    public partial class PaymentMethod
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("payment_processors")]
        public List<PaymentProcessor> PaymentProcessors { get; set; }
    }

    public partial class PaymentProcessor
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class PresignedAcceptance
    {
        [JsonProperty("acceptance_token")]
        public string AcceptanceToken { get; set; }

        [JsonProperty("permalink")]
        public Uri Permalink { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class Meta
    {
    }

    public partial class MerchantsData
    {
        public static MerchantsData FromJson(string json) => JsonConvert.DeserializeObject<MerchantsData>(json, api.modelo.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this MerchantsData self) => JsonConvert.SerializeObject(self, api.modelo.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
