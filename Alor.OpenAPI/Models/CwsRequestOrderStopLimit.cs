﻿using Alor.OpenAPI.Enums;
using SpanJson;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models
{
    [DataContract]
    internal class CwsRequestOrderStopLimit : IEquatable<CwsRequestOrderStopLimit>, IValidatableObject
    {
        public CwsRequestOrderStopLimit() { }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderStopLimit"]/Member[@name="wsCmdUpdateOrderStopLimit"]/*' />
        public CwsRequestOrderStopLimit(string? opcode = default, string? guid = default, string? orderId = default,
            Side side = default, Condition condition = default, decimal? triggerPrice = default,
            long? stopEndUnixTime = default, decimal? price = default, int? quantity = default,
            Instrument? instrument = default, Exchange? exchange = default, string? board = default,
            User? user = default, TimeInForce timeInForce = default, int? icebergFixed = default,
            decimal? icebergVariance = default, bool? checkDuplicates = default, int? protectingSeconds = default,
            bool? activate = true, bool? allowMargin = default)
        {
            Opcode = opcode;
            Guid = guid;
            OrderId = orderId;
            Side = side;
            Condition = condition;
            TriggerPrice = triggerPrice;
            StopEndUnixTime = stopEndUnixTime;
            Price = price;
            Quantity = quantity;
            Instrument = instrument;
            Exchange = exchange;
            Board = board;
            User = user;
            TimeInForce = timeInForce;
            IcebergFixed = icebergFixed;
            IcebergVariance = icebergVariance;
            CheckDuplicates = checkDuplicates;
            ProtectingSeconds = protectingSeconds;
            Activate = activate ?? true;
            AllowMargin = allowMargin;
        }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderStopLimit"]/Member[@name="opcode"]/*' />
        [DataMember(Name = "opcode", EmitDefaultValue = false)]
        public string? Opcode { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderStopLimit"]/Member[@name="guid"]/*' />
        [DataMember(Name = "guid", EmitDefaultValue = false)]
        public string? Guid { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderStopLimit"]/Member[@name="orderId"]/*' />
        [DataMember(Name = "orderId", EmitDefaultValue = false)]
        public string? OrderId { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderStopLimit"]/Member[@name="side"]/*' />
        [DataMember(Name = "side", EmitDefaultValue = false)]
        public Side Side { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderStopLimit"]/Member[@name="condition"]/*' />
        [DataMember(Name = "condition", EmitDefaultValue = false)]
        public Condition Condition { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderStopLimit"]/Member[@name="triggerPrice"]/*' />
        [DataMember(Name = "triggerPrice", EmitDefaultValue = false)]
        public decimal? TriggerPrice { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderStopLimit"]/Member[@name="stopEndUnixTime"]/*' />
        [DataMember(Name = "stopEndUnixTime", EmitDefaultValue = false)]
        public long? StopEndUnixTime { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderStopLimit"]/Member[@name="price"]/*' />
        [DataMember(Name = "price", EmitDefaultValue = false)]
        public decimal? Price { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderStopLimit"]/Member[@name="quantity"]/*' />
        [DataMember(Name = "quantity", EmitDefaultValue = false)]
        public int? Quantity { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderStopLimit"]/Member[@name="instrument"]/*' />
        [DataMember(Name = "instrument", EmitDefaultValue = false)]
        public Instrument? Instrument { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdDeleteOrderStopLimit"]/Member[@name="exchange"]/*' />
        [DataMember(Name = "exchange", EmitDefaultValue = false)]
        public Exchange? Exchange { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderStopLimit"]/Member[@name="board"]/*' />
        [DataMember(Name = "board", EmitDefaultValue = false)]
        public string? Board { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderStopLimit"]/Member[@name="user"]/*' />
        [DataMember(Name = "user", EmitDefaultValue = false)]
        public User? User { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderStopLimit"]/Member[@name="timeInForce"]/*' />
        [DataMember(Name = "timeInForce", EmitDefaultValue = false)]
        public TimeInForce TimeInForce { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderStopLimit"]/Member[@name="icebergFixed"]/*' />
        [DataMember(Name = "icebergFixed", EmitDefaultValue = false)]
        public int? IcebergFixed { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderStopLimit"]/Member[@name="icebergVariance"]/*' />
        [DataMember(Name = "icebergVariance", EmitDefaultValue = false)]
        public decimal? IcebergVariance { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderStopLimit"]/Member[@name="checkDuplicates"]/*' />
        [DataMember(Name = "checkDuplicates", EmitDefaultValue = false)]
        public bool? CheckDuplicates { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderStopLimit"]/Member[@name="protectingSeconds"]/*' />
        [DataMember(Name = "protectingSeconds", EmitDefaultValue = false)]
        public int? ProtectingSeconds { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderStopLimit"]/Member[@name="activate"]/*' />
        [DataMember(Name = "activate", EmitDefaultValue = false)]
        public bool? Activate { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderStopLimit"]/Member[@name="allowMargin"]/*' />
        [DataMember(Name = "allowMargin", EmitDefaultValue = false)]
        public bool? AllowMargin { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CwsRequestOrderStopLimit {").Append(Environment.NewLine);
            sb.Append("  Opcode: ").Append(Opcode).Append(Environment.NewLine);
            sb.Append("  Guid: ").Append(Guid).Append(Environment.NewLine);
            sb.Append("  OrderId: ").Append(OrderId).Append(Environment.NewLine);
            sb.Append("  Side: ").Append(Side).Append(Environment.NewLine);
            sb.Append("  Condition: ").Append(Condition).Append(Environment.NewLine);
            sb.Append("  TriggerPrice: ").Append(TriggerPrice).Append(Environment.NewLine);
            sb.Append("  StopEndUnixTime: ").Append(StopEndUnixTime).Append(Environment.NewLine);
            sb.Append("  Price: ").Append(Price).Append(Environment.NewLine);
            sb.Append("  Quantity: ").Append(Quantity).Append(Environment.NewLine);
            sb.Append("  Instrument: ").Append(Instrument).Append(Environment.NewLine);
            sb.Append("  Exchange: ").Append(Exchange).Append(Environment.NewLine);
            sb.Append("  Board: ").Append(Board).Append(Environment.NewLine);
            sb.Append("  User: ").Append(User).Append(Environment.NewLine);
            sb.Append("  TimeInForce: ").Append(TimeInForce).Append(Environment.NewLine);
            sb.Append("  IcebergFixed: ").Append(IcebergFixed).Append(Environment.NewLine);
            sb.Append("  IcebergVariance: ").Append(IcebergVariance).Append(Environment.NewLine);
            sb.Append("  CheckDuplicates: ").Append(CheckDuplicates).Append(Environment.NewLine);
            sb.Append("  ProtectingSeconds: ").Append(ProtectingSeconds).Append(Environment.NewLine);
            sb.Append("  Activate: ").Append(Activate).Append(Environment.NewLine);
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
            hash.Add(Condition);
            hash.Add(TriggerPrice);
            hash.Add(StopEndUnixTime);
            hash.Add(Price);
            hash.Add(Quantity);
            hash.Add(Instrument);
            hash.Add(Exchange);
            hash.Add(Board);
            hash.Add(User);
            hash.Add(TimeInForce);
            hash.Add(IcebergFixed);
            hash.Add(IcebergVariance);
            hash.Add(CheckDuplicates);
            hash.Add(ProtectingSeconds);
            hash.Add(Activate);
            hash.Add(AllowMargin);
            return hash.ToHashCode();
        }

        private static bool EqualsHelper(CwsRequestOrderStopLimit? first, CwsRequestOrderStopLimit? second) =>
            first?.Opcode == second?.Opcode &&
            first?.Guid == second?.Guid &&
            first?.OrderId == second?.OrderId &&
            first?.Side == second?.Side &&
            first?.Condition == second?.Condition &&
            first?.TriggerPrice == second?.TriggerPrice &&
            first?.StopEndUnixTime == second?.StopEndUnixTime &&
            first?.Price == second?.Price &&
            first?.Quantity == second?.Quantity &&
            first?.Instrument == second?.Instrument &&
            first?.Exchange == second?.Exchange &&
            first?.Board == second?.Board &&
            first?.User == second?.User &&
            first?.TimeInForce == second?.TimeInForce &&
            first?.IcebergFixed == second?.IcebergFixed &&
            first?.IcebergVariance == second?.IcebergVariance &&
            first?.CheckDuplicates == second?.CheckDuplicates &&
            first?.ProtectingSeconds == second?.ProtectingSeconds &&
            first?.Activate == second?.Activate &&
            first?.AllowMargin == second?.AllowMargin;

        public bool Equals(CwsRequestOrderStopLimit? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as CwsRequestOrderStopLimit);

        private static bool Equals(CwsRequestOrderStopLimit? first, CwsRequestOrderStopLimit? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(CwsRequestOrderStopLimit? first, CwsRequestOrderStopLimit? second) =>
            Equals(first, second);

        public static bool operator !=(CwsRequestOrderStopLimit? first, CwsRequestOrderStopLimit? second) =>
            !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
