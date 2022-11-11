using System;
using System.Collections.Generic;

using System.Globalization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace api.modelo
{
    
    public partial class TokenCardRequest
    {
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("cvc")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Cvc { get; set; }

        [JsonProperty("exp_month")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ExpMonth { get; set; }

        [JsonProperty("exp_year")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ExpYear { get; set; }

        [JsonProperty("card_holder")]
        public string CardHolder { get; set; }
    }
}
