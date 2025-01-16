﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Alor.OpenAPI.Enums;
using SpanJson;

namespace Alor.OpenAPI.Models
{
    [DataContract]
    internal sealed class RequestOrdersActionsMarketTv : IEquatable<RequestOrdersActionsMarketTv>, IValidatableObject
    {
        public RequestOrdersActionsMarketTv() { }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsMarketTV"]/Member[@name="OrdersActionsMarketTV"]/*' />
        public RequestOrdersActionsMarketTv(Side side = default,
            int? quantity = default, Instrument? instrument = default, string? comment = default,
            User? user = default, TimeInForce? timeInForce = default)
        {
            Side = side;
            Quantity = quantity;
            Instrument = instrument;
            Comment = comment;
            User = user;
            TimeInForce = timeInForce;
        }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsMarketTV"]/Member[@name="side"]/*' />
        [DataMember(Name = "side", EmitDefaultValue = false)]
        public Side Side { get; private set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsMarketTV"]/Member[@name="quantity"]/*' />
        [DataMember(Name = "quantity", EmitDefaultValue = false)]
        public int? Quantity { get; private set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsMarketTV"]/Member[@name="instrument"]/*' />
        [DataMember(Name = "instrument", EmitDefaultValue = false)]
        public Instrument? Instrument { get; private set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsMarketTV"]/Member[@name="comment"]/*' />
        [DataMember(Name = "comment", EmitDefaultValue = false)]
        public string? Comment { get; private set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsMarketTV"]/Member[@name="user"]/*' />
        [DataMember(Name = "user", EmitDefaultValue = false)]
        public User? User { get; private set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsMarketTV"]/Member[@name="timeInForce"]/*' />
        [DataMember(Name = "timeInForce", EmitDefaultValue = false)]
        public TimeInForce? TimeInForce { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrdersActionsMarketTv {").Append(Environment.NewLine);
            sb.Append("  Side: ").Append(Side).Append(Environment.NewLine);
            sb.Append("  Quantity: ").Append(Quantity).Append(Environment.NewLine);
            sb.Append("  Instrument: ").Append(Instrument).Append(Environment.NewLine);
            sb.Append("  Comment: ").Append(Comment).Append(Environment.NewLine);
            sb.Append("  User: ").Append(User).Append(Environment.NewLine);
            sb.Append("  TimeInForce: ").Append(TimeInForce).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode() => Utilities.Utilities.GetHashCodeHelper(
            [
                Side.GetHashCode(),
                Quantity?.GetHashCode() ?? 0,
                Instrument?.GetHashCode() ?? 0,
                Comment?.GetHashCode() ?? 0,
                User?.GetHashCode() ?? 0,
                TimeInForce?.GetHashCode() ?? 0,
            ]
        );

        private static bool EqualsHelper(RequestOrdersActionsMarketTv? first, RequestOrdersActionsMarketTv? second) =>
            first?.Side == second?.Side &&
            first?.Quantity == second?.Quantity &&
            first?.Instrument == second?.Instrument &&
            first?.Comment == second?.Comment &&
            first?.User == second?.User &&
            first?.TimeInForce == second?.TimeInForce;

        public bool Equals(RequestOrdersActionsMarketTv? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            if (GetType() != other.GetType())
                return false;

            return EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as RequestOrdersActionsMarketTv);

        private static bool Equals(RequestOrdersActionsMarketTv? first, RequestOrdersActionsMarketTv? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(RequestOrdersActionsMarketTv? first, RequestOrdersActionsMarketTv? second) => Equals(first, second);

        public static bool operator !=(RequestOrdersActionsMarketTv? first, RequestOrdersActionsMarketTv? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
