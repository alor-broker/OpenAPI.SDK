﻿using Alor.OpenAPI.Enums;
using SpanJson;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models
{
    [DataContract]
    internal sealed class CwsRequestOrderMarket : IEquatable<CwsRequestOrderMarket>, IValidatableObject
    {
        public CwsRequestOrderMarket() { }

        /// <include file='../XmlDocs/CoreModels.xml'
        ///     path='
        ///             Docs/Members[@name="wsCmdCreateOrderMarket"]/Member[@name="wsCmdCreateOrderMarket"]/*
        ///           | Docs/Members[@name="wsCmdDeleteOrderMarket"]/Member[@name="wsCmdDeleteOrderMarket"]/param[@name="exchange"]
        ///           | Docs/Members[@name="wsCmdUpdateOrderMarket"]/Member[@name="wsCmdUpdateOrderMarket"]/param[@name="orderId"]
        ///          ' />
        public CwsRequestOrderMarket(string? opcode = null, string? guid = null, string? orderId = null, Side? side = null,
            int? quantity = null, Instrument? instrument = null, Exchange? exchange = null, string? comment = null,
            User? user = null, TimeInForce? timeInForce = null, bool? checkDuplicates = null, bool? allowMargin = null)
        {
            Opcode = opcode;
            Guid = guid;
            OrderId = orderId;
            Side = side;
            Quantity = quantity;
            Instrument = instrument;
            Exchange = exchange;
            Comment = comment;
            User = user;
            TimeInForce = timeInForce;
            CheckDuplicates = checkDuplicates;
            AllowMargin = allowMargin;
        }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdCreateOrderMarket"]/Member[@name="opcode"]/*' />
        [DataMember(Name = "opcode", EmitDefaultValue = false)]
        public string? Opcode { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdCreateOrderMarket"]/Member[@name="guid"]/*' />
        [DataMember(Name = "guid", EmitDefaultValue = false)]
        public string? Guid { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderMarket"]/Member[@name="orderId"]/*' />
        [DataMember(Name = "orderId", EmitDefaultValue = false)]
        public string? OrderId { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdCreateOrderMarket"]/Member[@name="side"]/*' />
        [DataMember(Name = "side", EmitDefaultValue = false)]
        public Side? Side { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdCreateOrderMarket"]/Member[@name="quantity"]/*' />
        [DataMember(Name = "quantity", EmitDefaultValue = false)]
        public int? Quantity { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdCreateOrderMarket"]/Member[@name="instrument"]/*' />
        [DataMember(Name = "instrument", EmitDefaultValue = false)]
        public Instrument? Instrument { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdDeleteOrderMarket"]/Member[@name="exchange"]/*' />
        [DataMember(Name = "exchange", EmitDefaultValue = false)]
        public Exchange? Exchange { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdCreateOrderMarket"]/Member[@name="comment"]/*' />
        [DataMember(Name = "comment", EmitDefaultValue = false)]
        public string? Comment { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdCreateOrderMarket"]/Member[@name="user"]/*' />
        [DataMember(Name = "user", EmitDefaultValue = false)]
        public User? User { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdCreateOrderMarket"]/Member[@name="timeInForce"]/*' />
        [DataMember(Name = "timeInForce", EmitDefaultValue = false)]
        public TimeInForce? TimeInForce { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdCreateOrderMarket"]/Member[@name="checkDuplicates"]/*' />
        [DataMember(Name = "checkDuplicates", EmitDefaultValue = false)]
        public bool? CheckDuplicates { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdCreateOrderMarket"]/Member[@name="allowMargin"]/*' />
        [DataMember(Name = "allowMargin", EmitDefaultValue = false)]
        public bool? AllowMargin { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CwsRequestOrderMarket {").Append(Environment.NewLine);
            sb.Append("  Opcode: ").Append(Opcode).Append(Environment.NewLine);
            sb.Append("  Guid: ").Append(Guid).Append(Environment.NewLine);
            sb.Append("  OrderId: ").Append(OrderId).Append(Environment.NewLine);
            sb.Append("  Side: ").Append(Side).Append(Environment.NewLine);
            sb.Append("  Quantity: ").Append(Quantity).Append(Environment.NewLine);
            sb.Append("  Instrument: ").Append(Instrument).Append(Environment.NewLine);
            sb.Append("  Exchange: ").Append(Exchange).Append(Environment.NewLine);
            sb.Append("  Comment: ").Append(Comment).Append(Environment.NewLine);
            sb.Append("  User: ").Append(User).Append(Environment.NewLine);
            sb.Append("  TimeInForce: ").Append(TimeInForce).Append(Environment.NewLine);
            sb.Append("  CheckDuplicates: ").Append(CheckDuplicates).Append(Environment.NewLine);
            sb.Append("  AllowMargin: ").Append(AllowMargin).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Opcode);
            hash.Add(Guid);
            hash.Add(OrderId);
            hash.Add(Side);
            hash.Add(Quantity);
            hash.Add(Instrument);
            hash.Add(Exchange);
            hash.Add(Comment);
            hash.Add(User);
            hash.Add(TimeInForce);
            hash.Add(CheckDuplicates);
            hash.Add(AllowMargin);
            return hash.ToHashCode();
        }

        private static bool EqualsHelper(CwsRequestOrderMarket? first, CwsRequestOrderMarket? second) =>
            first?.Opcode == second?.Opcode &&
            first?.Guid == second?.Guid &&
            first?.OrderId == second?.OrderId &&
            first?.Side == second?.Side &&
            first?.Quantity == second?.Quantity &&
            first?.Instrument == second?.Instrument &&
            first?.Exchange == second?.Exchange &&
            first?.Comment == second?.Comment &&
            first?.User == second?.User &&
            first?.TimeInForce == second?.TimeInForce &&
            first?.CheckDuplicates == second?.CheckDuplicates &&
            first?.AllowMargin == second?.AllowMargin;

        public bool Equals(CwsRequestOrderMarket? other)
        {
            if (this == (object?)other)
                return true;

            if (other is null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as CwsRequestOrderMarket);

        private static bool Equals(CwsRequestOrderMarket? first, CwsRequestOrderMarket? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(CwsRequestOrderMarket? first, CwsRequestOrderMarket? second) => Equals(first, second);

        public static bool operator !=(CwsRequestOrderMarket? first, CwsRequestOrderMarket? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
