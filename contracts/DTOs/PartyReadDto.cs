using System;
using System.Collections.Generic;
using System.Text.Json;
using Pyrick.Api.Data.Entities;

namespace Pyrick.Api.Data.DTOs.Party
{
    public class PartyReadDto
    {
        public Guid Id { get; set; }
        public string? PartyType { get; set; } // "Individual" or "Organization"
        public string? Website { get; set; }
        public JsonDocument? CustomFields { get; set; }

        // Individual fields
        public string? Prefix { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Suffix { get; set; }
        public string? Pronouns { get; set; }
        public string? Linkedin { get; set; }
        public string? Disability { get; set; }
        public string? VeteranStatus { get; set; }
        public string? Sex { get; set; }
        public string? Ethnicity { get; set; }

        // Organization fields
        public string? Name { get; set; }
        
        // New NAICS fields
        public int? NaicsCodeId { get; set; }
        public NaicsCode? NaicsCodeEntry { get; set; }
        
        
        public string? EmployeeCount { get; set; }

        // Computed
        public string? FullName { get; set; }
        
        // Primary contact information
        public string? PrimaryEmail { get; set; }
        public string? PrimaryPhone { get; set; }
        public string? PrimaryAddress { get; set; }
    }
}
