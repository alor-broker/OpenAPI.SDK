﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Alor.OpenAPI.Enums;
using SpanJson;

namespace Alor.OpenAPI.Models.Slim
{
    [DataContract]
    public sealed class PositionSlim : IEquatable<PositionSlim>, IValidatableObject
    {
        public PositionSlim() { }

        /// <include file='../../XmlDocs/CoreModels.xml'
        ///          path='Docs/Members[@name="responsePosition"]
        ///               /Member[@name="responsePosition"]
        ///               /param[
        ///                      @name="volume" or @name="currentVolume" or @name="symbol" or @name="brokerSymbol" or @name="portfolio"
        ///                      or @name="exchange" or @name="avgPrice" or @name="qtyUnits" or @name="openUnits" or @name="lotSize"
        ///                      or @name="shortName" or @name="qtyT0" or @name="qtyT1" or @name="qtyT2" or @name="qtyTFuture"
        ///                      or @name="dailyUnrealisedPl" or @name="unrealisedPl" or @name="isCurrency" or @name="existing"
        ///                     ]'/>
        public PositionSlim(decimal? volume = null, decimal? currentVolume = null,
            string? symbol = null, string? brokerSymbol = null, string? portfolio = null,
            Exchange? exchange = null, decimal? avgPrice = null,
            decimal? qtyUnits = null, decimal? openUnits = null,
            decimal? lotSize = null, string? shortName = null,
            decimal? qtyT0 = null, decimal? qtyT1 = null, decimal? qtyT2 = null,
            decimal? qtyTFuture = null,  decimal? dailyUnrealisedPl = null,
            decimal? unrealisedPl = null, bool? isCurrency = null, bool? existing = null)
        {
            Volume = volume;
            CurrentVolume = currentVolume;
            Symbol = symbol;
            BrokerSymbol = brokerSymbol;
            Portfolio = portfolio;
            Exchange = exchange;
            AvgPrice = avgPrice;
            QtyUnits = qtyUnits;
            OpenUnits = openUnits;
            LotSize = lotSize;
            ShortName = shortName;
            QtyT0 = qtyT0;
            QtyT1 = qtyT1;
            QtyT2 = qtyT2;
            QtyTFuture = qtyTFuture;
            DailyUnrealisedPl = dailyUnrealisedPl;
            UnrealisedPl = unrealisedPl;
            IsCurrency = isCurrency;
            Existing = existing;
        }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responsePosition"]/Member[@name="volume"]/*' />
        [DataMember(Name = "v", EmitDefaultValue = false)]
        public decimal? Volume { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responsePosition"]/Member[@name="currentVolume"]/*' />
        [DataMember(Name = "cv", EmitDefaultValue = false)]
        public decimal? CurrentVolume { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responsePosition"]/Member[@name="symbol"]/*' />
        [DataMember(Name = "sym", EmitDefaultValue = false)]
        public string? Symbol { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responsePosition"]/Member[@name="brokerSymbol"]/*' />
        [DataMember(Name = "tic", EmitDefaultValue = false)]
        public string? BrokerSymbol { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responsePosition"]/Member[@name="portfolio"]/*' />
        [DataMember(Name = "p", EmitDefaultValue = false)]
        public string? Portfolio { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responsePosition"]/Member[@name="exchange"]/*' />
        [DataMember(Name = "ex", EmitDefaultValue = false)]
        public Exchange? Exchange { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responsePosition"]/Member[@name="avgPrice"]/*' />
        [DataMember(Name = "pxavg", EmitDefaultValue = false)]
        public decimal? AvgPrice { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responsePosition"]/Member[@name="qtyUnits"]/*' />
        [DataMember(Name = "q", EmitDefaultValue = false)]
        public decimal? QtyUnits { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responsePosition"]/Member[@name="openUnits"]/*' />
        [DataMember(Name = "o", EmitDefaultValue = false)]
        public decimal? OpenUnits { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responsePosition"]/Member[@name="lotSize"]/*' />
        [DataMember(Name = "lot", EmitDefaultValue = false)]
        public decimal? LotSize { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responsePosition"]/Member[@name="shortName"]/*' />
        [DataMember(Name = "n", EmitDefaultValue = false)]
        public string? ShortName { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responsePosition"]/Member[@name="qtyT0"]/*' />
        [DataMember(Name = "q0", EmitDefaultValue = false)]
        public decimal? QtyT0 { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responsePosition"]/Member[@name="qtyT1"]/*' />
        [DataMember(Name = "q1", EmitDefaultValue = false)]
        public decimal? QtyT1 { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responsePosition"]/Member[@name="qtyT2"]/*' />
        [DataMember(Name = "q2", EmitDefaultValue = false)]
        public decimal? QtyT2 { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responsePosition"]/Member[@name="qtyTFuture"]/*' />
        [DataMember(Name = "qf", EmitDefaultValue = false)]
        public decimal? QtyTFuture { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responsePosition"]/Member[@name="dailyUnrealisedPl"]/*' />
        [DataMember(Name = "upd", EmitDefaultValue = false)]
        public decimal? DailyUnrealisedPl { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responsePosition"]/Member[@name="unrealisedPl"]/*' />
        [DataMember(Name = "up", EmitDefaultValue = false)]
        public decimal? UnrealisedPl { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responsePosition"]/Member[@name="isCurrency"]/*' />
        [DataMember(Name = "cur", EmitDefaultValue = false)]
        public bool? IsCurrency { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responsePosition"]/Member[@name="existing"]/*' />
        [DataMember(Name = "h", EmitDefaultValue = false)]
        public bool? Existing { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PositionSlim {").Append(Environment.NewLine);
            sb.Append("  Volume: ").Append(Volume).Append(Environment.NewLine);
            sb.Append("  CurrentVolume: ").Append(CurrentVolume).Append(Environment.NewLine);
            sb.Append("  SymbolSimple: ").Append(Symbol).Append(Environment.NewLine);
            sb.Append("  BrokerSymbol: ").Append(BrokerSymbol).Append(Environment.NewLine);
            sb.Append("  Portfolio: ").Append(Portfolio).Append(Environment.NewLine);
            sb.Append("  Exchange: ").Append(Exchange).Append(Environment.NewLine);
            sb.Append("  AvgPrice: ").Append(AvgPrice).Append(Environment.NewLine);
            sb.Append("  QtyUnits: ").Append(QtyUnits).Append(Environment.NewLine);
            sb.Append("  OpenUnits: ").Append(OpenUnits).Append(Environment.NewLine);
            sb.Append("  LotSize: ").Append(LotSize).Append(Environment.NewLine);
            sb.Append("  ShortName: ").Append(ShortName).Append(Environment.NewLine);
            sb.Append("  QtyT0: ").Append(QtyT0).Append(Environment.NewLine);
            sb.Append("  QtyT1: ").Append(QtyT1).Append(Environment.NewLine);
            sb.Append("  QtyT2: ").Append(QtyT2).Append(Environment.NewLine);
            sb.Append("  QtyTFuture: ").Append(QtyTFuture).Append(Environment.NewLine);
            sb.Append("  DailyUnrealisedPl: ").Append(DailyUnrealisedPl).Append(Environment.NewLine);
            sb.Append("  UnrealisedPl: ").Append(UnrealisedPl).Append(Environment.NewLine);
            sb.Append("  IsCurrency: ").Append(IsCurrency).Append(Environment.NewLine);
            sb.Append("  Existing: ").Append(Existing).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Volume);
            hash.Add(CurrentVolume);
            hash.Add(Symbol);
            hash.Add(BrokerSymbol);
            hash.Add(Portfolio);
            hash.Add(Exchange);
            hash.Add(AvgPrice);
            hash.Add(QtyUnits);
            hash.Add(OpenUnits);
            hash.Add(LotSize);
            hash.Add(ShortName);
            hash.Add(QtyT0);
            hash.Add(QtyT1);
            hash.Add(QtyT2);
            hash.Add(QtyTFuture);
            hash.Add(DailyUnrealisedPl);
            hash.Add(UnrealisedPl);
            hash.Add(IsCurrency);
            hash.Add(Existing);
            return hash.ToHashCode();
        }

        private static bool EqualsHelper(PositionSlim? first, PositionSlim? second) =>
            first?.Volume == second?.Volume &&
            first?.CurrentVolume == second?.CurrentVolume &&
            first?.Symbol == second?.Symbol &&
            first?.BrokerSymbol == second?.BrokerSymbol &&
            first?.Portfolio == second?.Portfolio &&
            first?.Exchange == second?.Exchange &&
            first?.AvgPrice == second?.AvgPrice &&
            first?.QtyUnits == second?.QtyUnits &&
            first?.OpenUnits == second?.OpenUnits &&
            first?.LotSize == second?.LotSize &&
            first?.ShortName == second?.ShortName &&
            first?.QtyT0 == second?.QtyT0 &&
            first?.QtyT1 == second?.QtyT1 &&
            first?.QtyT2 == second?.QtyT2 &&
            first?.QtyTFuture == second?.QtyTFuture &&
            first?.DailyUnrealisedPl == second?.DailyUnrealisedPl &&
            first?.UnrealisedPl == second?.UnrealisedPl &&
            first?.IsCurrency == second?.IsCurrency &&
            first?.Existing == second?.Existing;

        public bool Equals(PositionSlim? other)
        {
            if (this == (object?)other)
                return true;

            if (other is null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as PositionSlim);

        private static bool Equals(PositionSlim? first, PositionSlim? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(PositionSlim? first, PositionSlim? second) => Equals(first, second);

        public static bool operator !=(PositionSlim? first, PositionSlim? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
