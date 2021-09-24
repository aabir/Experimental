using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PostGreBE.Entity
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        [StringLength(50)]
        public string RecID { get; set; }
        public int PersonId { get; set; }
        public int ParentCompanyId { get; set; }
        public int AddressId { get; set; }
        public int? PartnerId { get; set; }
        [StringLength(100)]
        public string CompanyName { get; set; }
        [StringLength(100)]
        public string ActivationName { get; set; }
        [StringLength(50)]
        public string Type { get; set; }
        [StringLength(50)]
#nullable enable
        public string? Source { get; set; }
        [StringLength(50)]
        public string? Territory { get; set; }
        [StringLength(50)]
#nullable disable
        public string Revenue { get; set; }
        [StringLength(50)]
        public string Employees { get; set; }
        [StringLength(50)]
        public string IndCode { get; set; }
        [StringLength(50)]
#nullable enable
        public string? Website { get; set; }
        [StringLength(50)]
        public string? PhoneCountryCode { get; set; }
        [StringLength(50)]
        public string? PhoneAreaCode { get; set; }
        [StringLength(50)]
        public string? PhoneNumber { get; set; }
        [StringLength(50)]
        public string? FaxCountryCode { get; set; }
        [StringLength(50)]
        public string? FaxAreaCode { get; set; }
        [StringLength(50)]
        public string? FaxNumber { get; set; }
        [StringLength(50)]
        public string? EmailAddress { get; set; }
        [StringLength(1)]
        public string? BillingCompany { get; set; }
        public byte? MailRestriction { get; set; }
        public byte? Renewal { get; set; }
        [DefaultValue("0")]
        public byte? Subscription { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        [StringLength(450)]
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        [DefaultValue(0)]
        public byte Status { get; set; }
    }
}
