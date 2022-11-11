using System;

using System.Globalization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace api.modelo
{


    public partial class transactionsResponse
    {
        [JsonProperty("data")]
        public DataResponse Data { get; set; }
    }

    public partial class DataResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("amount_in_cents")]
        public long AmountInCents { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("customer_email")]
        public string CustomerEmail { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("payment_method_type")]
        public string PaymentMethodType { get; set; }

        [JsonProperty("payment_method")]
        public PaymentMethod PaymentMethod { get; set; }

        [JsonProperty("shipping_address")]
        public ShippingAddress ShippingAddress { get; set; }

        [JsonProperty("redirect_url")]
        public Uri RedirectUrl { get; set; }

        [JsonProperty("payment_link_id")]
        public object PaymentLinkId { get; set; }
    }

    public partial class PaymentMethodResponse : PaymentMethod
    {
        
        [JsonProperty("phone_number")]
        public long PhoneNumber { get; set; }
    }

    public partial class ShippingAddressResponse : ShippingAddress
    {
        
    }

    public partial class MerchantsDataResponse
    {
        public static MerchantsDataResponse FromJson(string json) => JsonConvert.DeserializeObject<MerchantsDataResponse>(json, api.modelo.Converter.Settings);
    }

    public static class SerializeResponse
    {
        public static string ToJson(this MerchantsDataResponse self) => JsonConvert.SerializeObject(self, api.modelo.ConverterResponse.Settings);
    }

    internal static class ConverterResponse
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
}
