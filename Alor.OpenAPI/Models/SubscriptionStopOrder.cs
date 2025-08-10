using Alor.OpenAPI.Enums;
using SpanJson;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models
{
    [DataContract]
    internal class SubscriptionStopOrder : IEquatable<SubscriptionStopOrder>, IValidatableObject
    {
        public SubscriptionStopOrder() { }

        /// <include file='../XmlDocs/CoreModels.xml'
        ///          path='Docs/Members[@name="wsSubStopOrdersGetAndSubscribeV2"]
        ///               /Member[@name="wsSubStopOrdersGetAndSubscribeV2"]
        ///               /param[
        ///                      @name="portfolio" or @name="orderStatuses" or @name="skipHistory" or @name="exchange"
        ///                      or @name="format" or @name="frequency" or @name="guid"
        ///                     ]'/>
        internal SubscriptionStopOrder(string? portfolio = null, List<OrderStatus>? orderStatuses = null,
            bool? skipHistory = null, Exchange? exchange = null, Format? format = null, string? guid = null)
        {
            Portfolio = portfolio;
            OrderStatuses = orderStatuses;
            SkipHistory = skipHistory;
            Exchange = exchange;
            Format = format;
            Guid = guid;
        }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubStopOrdersGetAndSubscribeV2"]/Member[@name="opcode"]/*' />
        [DataMember(Name = "opcode", EmitDefaultValue = false)]
        public string? Opcode { get; init; } = "StopOrdersGetAndSubscribeV2";

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubStopOrdersGetAndSubscribeV2"]/Member[@name="portfolio"]/*' />
        [DataMember(Name = "portfolio", EmitDefaultValue = false)]
        public string? Portfolio { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubStopOrdersGetAndSubscribeV2"]/Member[@name="orderStatuses"]/*' />
        [DataMember(Name = "orderStatuses", EmitDefaultValue = false)]
        public List<OrderStatus>? OrderStatuses { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubStopOrdersGetAndSubscribeV2"]/Member[@name="skipHistory"]/*' />
        [DataMember(Name = "skipHistory", EmitDefaultValue = false)]
        public bool? SkipHistory { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubStopOrdersGetAndSubscribeV2"]/Member[@name="exchange"]/*' />
        [DataMember(Name = "exchange", EmitDefaultValue = false)]
        public Exchange? Exchange { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubStopOrdersGetAndSubscribeV2"]/Member[@name="format"]/*' />
        [DataMember(Name = "format", EmitDefaultValue = false)]
        public Format? Format { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubStopOrdersGetAndSubscribeV2"]/Member[@name="guid"]/*' />
        [DataMember(Name = "guid", EmitDefaultValue = false)]
        public string? Guid { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubStopOrdersGetAndSubscribeV2"]/Member[@name="token"]/*' />
        [DataMember(Name = "token", EmitDefaultValue = false)]
        public string? Token { get; init; } = "JwtToken";

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class StopOrdersSubscription {").Append(Environment.NewLine);
            sb.Append("  Opcode: ").Append(Opcode).Append(Environment.NewLine);
            sb.Append("  Portfolio: ").Append(Portfolio).Append(Environment.NewLine);
            sb.Append("  OrderStatuses: ").Append(OrderStatuses == null ? "null" : string.Join(", ", OrderStatuses.Select(x => x.ToString()))).Append(Environment.NewLine);
            sb.Append("  SkipHistory: ").Append(SkipHistory).Append(Environment.NewLine);
            sb.Append("  Exchange: ").Append(Exchange).Append(Environment.NewLine);
            sb.Append("  Format: ").Append(Format).Append(Environment.NewLine);
            sb.Append("  Guid: ").Append(Guid).Append(Environment.NewLine);
            sb.Append("  Token: ").Append(Token).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Opcode);
            hash.Add(Portfolio);

            if (OrderStatuses != null)
                foreach (var item in OrderStatuses)
                {
                    hash.Add(item);
                }
            
            hash.Add(SkipHistory);
            hash.Add(Exchange);
            hash.Add(Format);
            hash.Add(Guid);
            hash.Add(Token);
            return hash.ToHashCode();
        }

        private static bool EqualsHelper(SubscriptionStopOrder? first, SubscriptionStopOrder? second) =>
            first?.Opcode == second?.Opcode &&
            first?.Portfolio == second?.Portfolio &&
            first?.OrderStatuses != null && second?.OrderStatuses != null
                ? first.OrderStatuses.SequenceEqual(second.OrderStatuses)
                : first?.OrderStatuses == null && second?.OrderStatuses == null &&
                  first?.SkipHistory == second?.SkipHistory &&
            first?.Exchange == second?.Exchange &&
            first?.Format == second?.Format &&
            first?.Guid == second?.Guid &&
            first?.Token == second?.Token;

        public bool Equals(SubscriptionStopOrder? other)
        {
            if (this == (object?)other)
                return true;

            if (other is null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as SubscriptionStopOrder);

        private static bool Equals(SubscriptionStopOrder? first, SubscriptionStopOrder? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(SubscriptionStopOrder? first, SubscriptionStopOrder? second) => Equals(first, second);

        public static bool operator !=(SubscriptionStopOrder? first, SubscriptionStopOrder? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
