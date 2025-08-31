using System;
using System.Text.Json;
using Pyrick.Api.Data.Entities;

namespace Pyrick.Api.Data.DTOs.Organization
{
    public class OrganizationReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        
        // New NAICS fields
        public int? NaicsCodeId { get; set; }
        public NaicsCode? NaicsCodeEntry { get; set; }
        
        
        public string? EmployeeCount { get; set; }
        public string? Website { get; set; }
        public string? RegisteredDomicile { get; set; }
        public string? EntityType { get; set; }
        public string? ElectronicIdentificationNumber { get; set; }
        public JsonDocument? CustomFields { get; set; }
    }
}
