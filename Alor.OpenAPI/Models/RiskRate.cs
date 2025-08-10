using Alor.OpenAPI.Enums;
using SpanJson;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models
{
    [DataContract]
    public sealed class RiskRate : IEquatable<RiskRate>, IValidatableObject
    {
        public RiskRate() { }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRiskRate"]/Member[@name="responseRiskRate"]/*' />
        public RiskRate(long? id = null, string? instrument = null,
            Exchange? exchange = null, int? riskCategoryId = null,
            decimal? securityRiskCategoryId = null, string? assetType = null,
            string? underlyingAsset = null, string? setName = null,
            string? isin = null, string? currencyCode = null, decimal? rateUp = null,
            decimal? rateDown = null, decimal? rateSymmetric = null,
            bool? isShortSellPossible = null, bool? isMarginal = null,
            decimal? setRate = null, int? sgnR = null)
        {
            Id = id;
            Instrument = instrument;
            Exchange = exchange;
            RiskCategoryId = riskCategoryId;
            SecurityRiskCategoryId = securityRiskCategoryId;
            AssetType = assetType;
            UnderlyingAsset = underlyingAsset;
            SetName = setName;
            Isin = isin;
            CurrencyCode = currencyCode;
            RateUp = rateUp;
            RateDown = rateDown;
            RateSymmetric = rateSymmetric;
            IsShortSellPossible = isShortSellPossible;
            IsMarginal = isMarginal;
            SetRate = setRate;
            SgnR = sgnR;
        }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRiskRate"]/Member[@name="id"]/*' />
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public long? Id { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRiskRate"]/Member[@name="instrument"]/*' />
        [DataMember(Name = "instrument", EmitDefaultValue = false)]
        public string? Instrument { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRiskRate"]/Member[@name="exchange"]/*' />
        [DataMember(Name = "exchange", EmitDefaultValue = false)]
        public Exchange? Exchange { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRiskRate"]/Member[@name="riskCategoryId"]/*' />
        [DataMember(Name = "riskCategoryId", EmitDefaultValue = false)]
        public int? RiskCategoryId { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRiskRate"]/Member[@name="securityRiskCategoryId"]/*' />
        [DataMember(Name = "securityRiskCategoryId", EmitDefaultValue = false)]
        public decimal? SecurityRiskCategoryId { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRiskRate"]/Member[@name="assetType"]/*' />
        [DataMember(Name = "assetType", EmitDefaultValue = false)]
        public string? AssetType { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRiskRate"]/Member[@name="underlyingAsset"]/*' />
        [DataMember(Name = "underlyingAsset", EmitDefaultValue = false)]
        public string? UnderlyingAsset { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRiskRate"]/Member[@name="setName"]/*' />
        [DataMember(Name = "setName", EmitDefaultValue = false)]
        public string? SetName { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRiskRate"]/Member[@name="isin"]/*' />
        [DataMember(Name = "isin", EmitDefaultValue = false)]
        public string? Isin { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRiskRate"]/Member[@name="currencyCode"]/*' />
        [DataMember(Name = "currencyCode", EmitDefaultValue = false)]
        public string? CurrencyCode { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRiskRate"]/Member[@name="rateUp"]/*' />
        [DataMember(Name = "rateUp", EmitDefaultValue = false)]
        public decimal? RateUp { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRiskRate"]/Member[@name="rateDown"]/*' />
        [DataMember(Name = "rateDown", EmitDefaultValue = false)]
        public decimal? RateDown { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRiskRate"]/Member[@name="rateSymmetric"]/*' />
        [DataMember(Name = "rateSymmetric", EmitDefaultValue = false)]
        public decimal? RateSymmetric { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRiskRate"]/Member[@name="isShortSellPossible"]/*' />
        [DataMember(Name = "isShortSellPossible", EmitDefaultValue = false)]
        public bool? IsShortSellPossible { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRiskRate"]/Member[@name="isMarginal"]/*' />
        [DataMember(Name = "isMarginal", EmitDefaultValue = false)]
        public bool? IsMarginal { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRiskRate"]/Member[@name="setRate"]/*' />
        [DataMember(Name = "setRate", EmitDefaultValue = false)]
        public decimal? SetRate { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRiskRate"]/Member[@name="sgnR"]/*' />
        [DataMember(Name = "sgnR", EmitDefaultValue = false)]
        public int? SgnR { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RiskRate {").Append(Environment.NewLine);
            sb.Append("  Id: ").Append(Id).Append(Environment.NewLine);
            sb.Append("  Instrument: ").Append(Instrument).Append(Environment.NewLine);
            sb.Append("  Exchange: ").Append(Exchange).Append(Environment.NewLine);
            sb.Append("  RiskCategoryId: ").Append(RiskCategoryId).Append(Environment.NewLine);
            sb.Append("  SecurityRiskCategoryId: ").Append(SecurityRiskCategoryId).Append(Environment.NewLine);
            sb.Append("  AssetType: ").Append(AssetType).Append(Environment.NewLine);
            sb.Append("  UnderlyingAsset: ").Append(UnderlyingAsset).Append(Environment.NewLine);
            sb.Append("  SetName: ").Append(SetName).Append(Environment.NewLine);
            sb.Append("  Isin: ").Append(Isin).Append(Environment.NewLine);
            sb.Append("  CurrencyCode: ").Append(CurrencyCode).Append(Environment.NewLine);
            sb.Append("  RateUp: ").Append(RateUp).Append(Environment.NewLine);
            sb.Append("  RateDown: ").Append(RateDown).Append(Environment.NewLine);
            sb.Append("  RateSymmetric: ").Append(RateSymmetric).Append(Environment.NewLine);
            sb.Append("  IsShortSellPossible: ").Append(IsShortSellPossible).Append(Environment.NewLine);
            sb.Append("  IsMarginal: ").Append(IsMarginal).Append(Environment.NewLine);
            sb.Append("  SetRate: ").Append(SetRate).Append(Environment.NewLine);
            sb.Append("  SgnR: ").Append(SgnR).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Id);
            hash.Add(Instrument);
            hash.Add(Exchange);
            hash.Add(RiskCategoryId);
            hash.Add(SecurityRiskCategoryId);
            hash.Add(AssetType);
            hash.Add(UnderlyingAsset);
            hash.Add(SetName);
            hash.Add(Isin);
            hash.Add(CurrencyCode);
            hash.Add(RateUp);
            hash.Add(RateDown);
            hash.Add(RateSymmetric);
            hash.Add(IsShortSellPossible);
            hash.Add(IsMarginal);
            hash.Add(SetRate);
            hash.Add(SgnR);
            return hash.ToHashCode();
        }

        private static bool EqualsHelper(RiskRate? first, RiskRate? second) =>
            first?.Id == second?.Id &&
            first?.Instrument == second?.Instrument &&
            first?.Exchange == second?.Exchange &&
            first?.RiskCategoryId == second?.RiskCategoryId &&
            first?.SecurityRiskCategoryId == second?.SecurityRiskCategoryId &&
            first?.AssetType == second?.AssetType &&
            first?.UnderlyingAsset == second?.UnderlyingAsset &&
            first?.SetName == second?.SetName &&
            first?.Isin == second?.Isin &
            first?.CurrencyCode == second?.CurrencyCode &&
            first?.RateUp == second?.RateUp &&
            first?.RateDown == second?.RateDown &&
            first?.RateSymmetric == second?.RateSymmetric &&
            first?.IsShortSellPossible == second?.IsShortSellPossible &&
            first?.IsMarginal == second?.IsMarginal &&
            first?.SetRate == second?.SetRate &&
            first?.SgnR == second?.SgnR;


        public bool Equals(RiskRate? other)
        {
            if (this == (object?)other)
                return true;

            if (other is null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as RiskRate);

        private static bool Equals(RiskRate? first, RiskRate? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(RiskRate? first, RiskRate? second) => Equals(first, second);

        public static bool operator !=(RiskRate? first, RiskRate? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
