using System;

namespace Pyrick.SDK.Contracts.DTOs
{
    /// <summary>
    /// Represents a company/organization in the CRM system
    /// </summary>
    public class CompanyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Website { get; set; }
        public string? Industry { get; set; }
        public string? EmployeeCount { get; set; }
        public string? EntityType { get; set; }
        public string? RegisteredDomicile { get; set; }
        public string? ElectronicIdentificationNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        // Address information
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
        
        // Contact information
        public string? PrimaryEmail { get; set; }
        public string? PrimaryPhone { get; set; }
        public List<string> AdditionalEmails { get; set; } = new List<string>();
        public List<string> AdditionalPhones { get; set; } = new List<string>();
        public Dictionary<string, string> SocialMediaAccounts { get; set; } = new Dictionary<string, string>();
        
        // NAICS classification
        public string? NaicsCode { get; set; }
        public string? NaicsDescription { get; set; }
        
        // Custom fields for extensibility
        public Dictionary<string, object> CustomFields { get; set; } = new Dictionary<string, object>();
    }
}