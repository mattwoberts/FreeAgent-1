using FreeAgent.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace FreeAgent.Model
{
    public class Company : IUrl
    {
        public Uri Url { get; set; }
        public string Name { get; set; }
        public string Subdomain { get; set; }
        public CompanyType Type { get; set; }
        public string Currency { get; set; }
        public MileageUnits MileageUnits { get; set; }

        [JsonConverter(typeof(IsoDateConverter))]
        public DateTime CompanyStartDate { get; set; }

        [JsonConverter(typeof(IsoDateConverter))]
        public DateTime FreeagentStartDate { get; set; }

        [JsonConverter(typeof(IsoDateConverter))]
        public DateTime FirstAccountingYearEnd { get; set; }

        public string CompanyRegistrationNumber { get; set; }
        public SalesTaxRegistrationStatus SalesTaxRegistrationStatus { get; set; }
        public string SalesTaxRegistrationNumber { get; set; }
    }

    public enum CompanyType
    {
        UkLimitedCompany = 1
    }

    public enum MileageUnits
    {
        [EnumMember(Value = "miles")] Miles
    }

    public enum SalesTaxRegistrationStatus
    {
        [EnumMember(Value = "Registered")] Registered,
        [EnumMember(Value = "Not Registered")] NotRegistered
    }

    public class CompanyWrapper
    {
        public Company Company { get; set; }
    }
}
