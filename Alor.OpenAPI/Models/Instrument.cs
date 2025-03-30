using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Alor.OpenAPI.Enums;
using SpanJson;

namespace Alor.OpenAPI.Models
{
    [DataContract]
    public sealed class Instrument : IEquatable<Instrument>, IValidatableObject
    {
        public Instrument() { }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="objectInstrumentFieldsSymbolExchangeGroup"]/Member[@name="objectInstrumentFieldsSymbolExchangeGroup"]/*' />
        [JsonConstructor]
        public Instrument(string? symbol = default, Exchange exchange = default, string? instrumentGroup = default)
        {
            Symbol = symbol;
            Exchange = exchange;
            InstrumentGroup = instrumentGroup;
        }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="objectInstrumentFieldsSymbolExchangeGroup"]/Member[@name="symbol"]/*' />
        [DataMember(Name = "symbol", EmitDefaultValue = false)]
        public string? Symbol { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="objectInstrumentFieldsSymbolExchangeGroup"]/Member[@name="exchange"]/*' />
        [DataMember(Name = "exchange", EmitDefaultValue = false)]
        public Exchange Exchange { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="objectInstrumentFieldsSymbolExchangeGroup"]/Member[@name="instrumentGroup"]/*' />
        [DataMember(Name = "instrumentGroup", EmitDefaultValue = false)]
        public string? InstrumentGroup { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Instrument {").Append(Environment.NewLine);
            sb.Append("  Symbol: ").Append(Symbol).Append(Environment.NewLine);
            sb.Append("  Exchange: ").Append(Exchange).Append(Environment.NewLine);
            sb.Append("  InstrumentGroup: ").Append(InstrumentGroup).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode() => HashCode.Combine(Symbol, Exchange, InstrumentGroup);

        private static bool EqualsHelper(Instrument? first, Instrument? second) =>
            first?.Symbol == second?.Symbol &&
            first?.Exchange == second?.Exchange &&
            first?.InstrumentGroup == second?.InstrumentGroup;


        public bool Equals(Instrument? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as Instrument);

        private static bool Equals(Instrument? first, Instrument? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(Instrument? first, Instrument? second) => Equals(first, second);

        public static bool operator !=(Instrument? first, Instrument? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}