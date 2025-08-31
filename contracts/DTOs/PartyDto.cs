using System;
using System.ComponentModel.DataAnnotations;

namespace Pyrick.SDK.Contracts.DTOs
{
    public abstract class PartyDto
    {
        public Guid Id { get; set; }
        
        [Required]
        [StringLength(20)]
        public string PartyType { get; set; } = string.Empty; // "INDIVIDUAL" or "ORGANIZATION"
        
        [Required]
        [StringLength(200)]
        public string DisplayName { get; set; } = string.Empty;
        
        [EmailAddress]
        [StringLength(255)]
        public string? PrimaryEmail { get; set; }
        
        [Phone]
        [StringLength(20)]
        public string? PrimaryPhone { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }
        
        [Required]
        public Guid CreatedBy { get; set; }
        
        public Guid? UpdatedBy { get; set; }
    }
    
    public class IndividualDto : PartyDto
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;
        
        [StringLength(100)]
        public string? MiddleName { get; set; }
        
        [StringLength(10)]
        public string? Suffix { get; set; }
        
        public DateTime? DateOfBirth { get; set; }
        
        [StringLength(20)]
        public string? Gender { get; set; }
        
        [StringLength(11)]
        public string? SSN { get; set; } // Should be encrypted
        
        public IndividualDto()
        {
            PartyType = "INDIVIDUAL";
        }
    }
    
    public class OrganizationDto : PartyDto
    {
        [Required]
        [StringLength(200)]
        public string LegalName { get; set; } = string.Empty;
        
        [StringLength(200)]
        public string? DBA { get; set; } // Doing Business As
        
        [StringLength(20)]
        public string? TaxId { get; set; } // EIN - Should be encrypted
        
        [StringLength(100)]
        public string? OrganizationType { get; set; } // Corporation, LLC, etc.
        
        public DateTime? IncorporationDate { get; set; }
        
        [StringLength(100)]
        public string? Industry { get; set; }
        
        [StringLength(2)]
        public string? State { get; set; }
        
        public OrganizationDto()
        {
            PartyType = "ORGANIZATION";
        }
    }
}