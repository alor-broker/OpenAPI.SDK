using Alor.OpenAPI.Enums;
using SpanJson;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models
{
    [DataContract]
    public sealed class RequestEstimateOrder : IEquatable<RequestEstimateOrder>, IValidatableObject
    {
        public RequestEstimateOrder() { }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="objectEstimateOrder"]/Member[@name="objectEstimateOrder"]/*' />
        public RequestEstimateOrder(string? portfolio = null, string? ticker = null, Exchange? exchange = null,
            decimal? price = null, int? lotQuantity = null, decimal? budget = null, string? board = null,
            bool? includeLimitOrders = false)
        {
            Portfolio = portfolio;
            Ticker = ticker;
            Exchange = exchange;
            Price = price;
            LotQuantity = lotQuantity;
            Budget = budget;
            Board = board;
            IncludeLimitOrders = includeLimitOrders ?? false;
        }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="objectEstimateOrder"]/Member[@name="portfolio"]/*' />
        [DataMember(Name = "portfolio", EmitDefaultValue = false)]
        public string? Portfolio { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="objectEstimateOrder"]/Member[@name="ticker"]/*' />
        [DataMember(Name = "ticker", EmitDefaultValue = false)]
        public string? Ticker { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="objectEstimateOrder"]/Member[@name="exchange"]/*' />
        [DataMember(Name = "exchange", EmitDefaultValue = false)]
        public Exchange? Exchange { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="objectEstimateOrder"]/Member[@name="price"]/*' />
        [DataMember(Name = "price", EmitDefaultValue = false)]
        public decimal? Price { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="objectEstimateOrder"]/Member[@name="lotQuantity"]/*' />
        [DataMember(Name = "lotQuantity", EmitDefaultValue = false)]
        public int? LotQuantity { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="objectEstimateOrder"]/Member[@name="budget"]/*' />
        [DataMember(Name = "budget", EmitDefaultValue = false)]
        public decimal? Budget { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="objectEstimateOrder"]/Member[@name="board"]/*' />
        [DataMember(Name = "board", EmitDefaultValue = false)]
        public string? Board { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="objectEstimateOrder"]/Member[@name="includeLimitOrders"]/*' />
        [DataMember(Name = "includeLimitOrders", EmitDefaultValue = false)]
        public bool? IncludeLimitOrders { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RequestEstimateOrder {").Append(Environment.NewLine);
            sb.Append("  Portfolio: ").Append(Portfolio).Append(Environment.NewLine);
            sb.Append("  Ticker: ").Append(Ticker).Append(Environment.NewLine);
            sb.Append("  Exchange: ").Append(Exchange).Append(Environment.NewLine);
            sb.Append("  Price: ").Append(Price).Append(Environment.NewLine);
            sb.Append("  LotQuantity: ").Append(LotQuantity).Append(Environment.NewLine);
            sb.Append("  Budget: ").Append(Budget).Append(Environment.NewLine);
            sb.Append("  Board: ").Append(Board).Append(Environment.NewLine);
            sb.Append("  IncludeLimitOrders: ").Append(IncludeLimitOrders).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode() => HashCode.Combine(Portfolio, Ticker, Exchange, Price, LotQuantity, Budget,
            Board, IncludeLimitOrders);

        private static bool EqualsHelper(RequestEstimateOrder? first, RequestEstimateOrder? second) =>
            first?.Portfolio == second?.Portfolio &&
            first?.Ticker == second?.Ticker &&
            first?.Exchange == second?.Exchange &&
            first?.Price == second?.Price &&
            first?.LotQuantity == second?.LotQuantity &&
            first?.Budget == second?.Budget &&
            first?.Board == second?.Board &&
            first?.IncludeLimitOrders == second?.IncludeLimitOrders;

        public bool Equals(RequestEstimateOrder? other)
        {
            if (this == (object?)other)
                return true;

            if (other is null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as RequestEstimateOrder);

        private static bool Equals(RequestEstimateOrder? first, RequestEstimateOrder? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(RequestEstimateOrder? first, RequestEstimateOrder? second) => Equals(first, second);

        public static bool operator !=(RequestEstimateOrder? first, RequestEstimateOrder? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
