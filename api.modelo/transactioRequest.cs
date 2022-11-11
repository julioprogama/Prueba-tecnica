using System;
using System.Collections.Generic;

using System.Globalization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace api.modelo
{
   

    public partial class TransactionsRequest
    {
        [JsonProperty("acceptance_token")]
        public string AcceptanceToken { get; set; }

        [JsonProperty("amount_in_cents")]
        public long AmountInCents { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("customer_email")]
        public string CustomerEmail { get; set; }

        [JsonProperty("payment_method")]
        public PaymentMethod PaymentMethod { get; set; }

        [JsonProperty("payment_source_id")]
        public long PaymentSourceId { get; set; }

        [JsonProperty("redirect_url")]
        public Uri RedirectUrl { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("customer_data")]
        public CustomerData CustomerData { get; set; }

        [JsonProperty("shipping_address")]
        public ShippingAddress ShippingAddress { get; set; }
    }

    public partial class CustomerData
    {
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("legal_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long LegalId { get; set; }

        [JsonProperty("legal_id_type")]
        public string LegalIdType { get; set; }
    }

    public partial class PaymentMethod
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("installments")]
        public long Installments { get; set; }
    }

    public partial class ShippingAddress
    {
        [JsonProperty("address_line_1")]
        public string AddressLine1 { get; set; }

        [JsonProperty("address_line_2")]
        public string AddressLine2 { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("postal_code")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long PostalCode { get; set; }
    }


    public partial class TransactionsRequest
    {
        public static TransactionsRequest FromJson(string json) => JsonConvert.DeserializeObject<TransactionsRequest>(json, api.modelo.Converter.Settings);
    }

    //public static class Serialize
    //{
    //    public static string ToJson(this TransactionsRequest self) => JsonConvert.SerializeObject(self, api.modelo.Converter.Settings);
    //}

    //internal static class Converter
    //{
    //    public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
    //    {
    //        MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
    //        DateParseHandling = DateParseHandling.None,
    //        Converters =
    //        {
    //            new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
    //        },
    //    };
    //}

    //internal class ParseStringConverter : JsonConverter
    //{
    //    public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

    //    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    //    {
    //        if (reader.TokenType == JsonToken.Null) return null;
    //        var value = serializer.Deserialize<string>(reader);
    //        long l;
    //        if (Int64.TryParse(value, out l))
    //        {
    //            return l;
    //        }
    //        throw new Exception("Cannot unmarshal type long");
    //    }

    //    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    //    {
    //        if (untypedValue == null)
    //        {
    //            serializer.Serialize(writer, null);
    //            return;
    //        }
    //        var value = (long)untypedValue;
    //        serializer.Serialize(writer, value.ToString());
    //        return;
    //    }

    //    public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    //}
}

