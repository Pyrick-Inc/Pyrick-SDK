using System;

namespace Pyrick.SDK.Contracts.DTOs
{
    /// <summary>
    /// Represents a contact (individual) in the CRM system
    /// </summary>
    public class ContactDto
    {
        public Guid Id { get; set; }
        public string? Prefix { get; set; }
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;
        public string? Suffix { get; set; }
        public string? Pronouns { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? LinkedIn { get; set; }
        public string? Website { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        // Address information
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
        
        // Additional contact methods
        public List<string> AdditionalEmails { get; set; } = new List<string>();
        public List<string> AdditionalPhones { get; set; } = new List<string>();
        public Dictionary<string, string> SocialMediaAccounts { get; set; } = new Dictionary<string, string>();
        
        // Custom fields for extensibility
        public Dictionary<string, object> CustomFields { get; set; } = new Dictionary<string, object>();
    }
}