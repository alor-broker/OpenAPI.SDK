﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using SpanJson;

namespace Alor.OpenAPI.Models.Heavy
{
    [DataContract]
    public sealed class FortsriskHeavy : IEquatable<FortsriskHeavy>, IValidatableObject
    {
        public FortsriskHeavy() { }

        /// <include file='../../XmlDocs/CoreModels.xml'
        ///          path='Docs/Members[@name="responseFortsRisk"]
        ///               /Member[@name="responseFortsRisk"]
        ///               /param[
        ///                      @name="portfolio" or @name="moneyFree" or @name="moneyBlocked" or @name="fee" or @name="moneyOld"
        ///                      or @name="moneyAmount" or @name="moneyPledgeAmount" or @name="vmInterCl" or @name="vmCurrentPositions"
        ///                      or @name="varMargin" or @name="isLimitsSet" or @name="indicativeVarMargin" or @name="netOptionValue"
        ///                      or @name="posRisk" 
        ///                     ]'/>
        public FortsriskHeavy(string? portfolio = null, decimal? moneyFree = null,
            decimal? moneyBlocked = null, decimal? fee = null, decimal? moneyOld = null,
            decimal? moneyAmount = null, decimal? moneyPledgeAmount = null, decimal? vmInterCl = null,
            decimal? vmCurrentPositions = null, decimal? varMargin = null, bool? isLimitsSet = null,
            decimal? indicativeVarMargin = null,
            decimal? netOptionValue = null, decimal? posRisk = null)
        {
            Portfolio = portfolio;
            MoneyFree = moneyFree;
            MoneyBlocked = moneyBlocked;
            Fee = fee;
            MoneyOld = moneyOld;
            MoneyAmount = moneyAmount;
            MoneyPledgeAmount = moneyPledgeAmount;
            VmInterCl = vmInterCl;
            VmCurrentPositions = vmCurrentPositions;
            VarMargin = varMargin;
            IsLimitsSet = isLimitsSet;
            IndicativeVarMargin = indicativeVarMargin;
            NetOptionValue = netOptionValue;
            PosRisk = posRisk;
        }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFortsRisk"]/Member[@name="portfolio"]/*' />
        [DataMember(Name = "portfolio", EmitDefaultValue = false)]
        public string? Portfolio { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFortsRisk"]/Member[@name="moneyFree"]/*' />
        [DataMember(Name = "moneyFree", EmitDefaultValue = false)]
        public decimal? MoneyFree { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFortsRisk"]/Member[@name="moneyBlocked"]/*' />
        [DataMember(Name = "moneyBlocked", EmitDefaultValue = false)]
        public decimal? MoneyBlocked { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFortsRisk"]/Member[@name="fee"]/*' />
        [DataMember(Name = "fee", EmitDefaultValue = false)]
        public decimal? Fee { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFortsRisk"]/Member[@name="moneyOld"]/*' />
        [DataMember(Name = "moneyOld", EmitDefaultValue = false)]
        public decimal? MoneyOld { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFortsRisk"]/Member[@name="moneyAmount"]/*' />
        [DataMember(Name = "moneyAmount", EmitDefaultValue = false)]
        public decimal? MoneyAmount { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFortsRisk"]/Member[@name="moneyPledgeAmount"]/*' />
        [DataMember(Name = "moneyPledgeAmount", EmitDefaultValue = false)]
        public decimal? MoneyPledgeAmount { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFortsRisk"]/Member[@name="vmInterCl"]/*' />
        [DataMember(Name = "vmInterCl", EmitDefaultValue = false)]
        public decimal? VmInterCl { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFortsRisk"]/Member[@name="vmCurrentPositions"]/*' />
        [DataMember(Name = "vmCurrentPositions", EmitDefaultValue = false)]
        public decimal? VmCurrentPositions { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFortsRisk"]/Member[@name="varMargin"]/*' />
        [DataMember(Name = "varMargin", EmitDefaultValue = false)]
        public decimal? VarMargin { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFortsRisk"]/Member[@name="isLimitsSet"]/*' />
        [DataMember(Name = "isLimitsSet", EmitDefaultValue = false)]
        public bool? IsLimitsSet { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFortsRisk"]/Member[@name="indicativeVarMargin"]/*' />
        [DataMember(Name = "indicativeVarMargin", EmitDefaultValue = false)]
        public decimal? IndicativeVarMargin { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFortsRisk"]/Member[@name="netOptionValue"]/*' />
        [DataMember(Name = "netOptionValue", EmitDefaultValue = false)]
        public decimal? NetOptionValue { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFortsRisk"]/Member[@name="posRisk"]/*' />
        [DataMember(Name = "posRisk", EmitDefaultValue = false)]
        public decimal? PosRisk { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FortsriskHeavy {").Append(Environment.NewLine);
            sb.Append("  Portfolio: ").Append(Portfolio).Append(Environment.NewLine);
            sb.Append("  MoneyFree: ").Append(MoneyFree).Append(Environment.NewLine);
            sb.Append("  MoneyBlocked: ").Append(MoneyBlocked).Append(Environment.NewLine);
            sb.Append("  Fee: ").Append(Fee).Append(Environment.NewLine);
            sb.Append("  MoneyOld: ").Append(MoneyOld).Append(Environment.NewLine);
            sb.Append("  MoneyAmount: ").Append(MoneyAmount).Append(Environment.NewLine);
            sb.Append("  MoneyPledgeAmount: ").Append(MoneyPledgeAmount).Append(Environment.NewLine);
            sb.Append("  VmInterCl: ").Append(VmInterCl).Append(Environment.NewLine);
            sb.Append("  VmCurrentPositions: ").Append(VmCurrentPositions).Append(Environment.NewLine);
            sb.Append("  VarMargin: ").Append(VarMargin).Append(Environment.NewLine);
            sb.Append("  IsLimitsSet: ").Append(IsLimitsSet).Append(Environment.NewLine);
            sb.Append("  IndicativeVarMargin: ").Append(IndicativeVarMargin).Append(Environment.NewLine);
            sb.Append("  NetOptionValue: ").Append(NetOptionValue).Append(Environment.NewLine);
            sb.Append("  PosRisk: ").Append(PosRisk).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Portfolio);
            hash.Add(MoneyFree);
            hash.Add(MoneyBlocked);
            hash.Add(Fee);
            hash.Add(MoneyOld);
            hash.Add(MoneyAmount);
            hash.Add(MoneyPledgeAmount);
            hash.Add(VmInterCl);
            hash.Add(VmCurrentPositions);
            hash.Add(VarMargin);
            hash.Add(IsLimitsSet);
            hash.Add(IndicativeVarMargin);
            hash.Add(NetOptionValue);
            hash.Add(PosRisk);
            return hash.ToHashCode();
        }

        private static bool EqualsHelper(FortsriskHeavy? first, FortsriskHeavy? second) =>
            first?.Portfolio == second?.Portfolio &&
            first?.MoneyFree == second?.MoneyFree &&
            first?.MoneyBlocked == second?.MoneyBlocked &&
            first?.Fee == second?.Fee &&
            first?.MoneyOld == second?.MoneyOld &&
            first?.MoneyAmount == second?.MoneyAmount &&
            first?.MoneyPledgeAmount == second?.MoneyPledgeAmount &&
            first?.VmInterCl == second?.VmInterCl &&
            first?.VmCurrentPositions == second?.VmCurrentPositions &&
            first?.VarMargin == second?.VarMargin &&
            first?.IsLimitsSet == second?.IsLimitsSet &&
            first?.IndicativeVarMargin == second?.IndicativeVarMargin &&
            first?.NetOptionValue == second?.NetOptionValue &&
            first?.PosRisk == second?.PosRisk;

        public bool Equals(FortsriskHeavy? other)
        {
            if (this == (object?)other)
                return true;

            if (other is null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as FortsriskHeavy);

        private static bool Equals(FortsriskHeavy? first, FortsriskHeavy? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(FortsriskHeavy? first, FortsriskHeavy? second) => Equals(first, second);

        public static bool operator !=(FortsriskHeavy? first, FortsriskHeavy? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
