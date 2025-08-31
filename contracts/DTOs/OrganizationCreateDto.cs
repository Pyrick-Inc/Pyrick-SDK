using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Pyrick.Api.Data.DTOs.Organization
{
    public class OrganizationCreateDto
    {
        [Required]
        public string Name { get; set; } = null!;
        
        // New NAICS field
        public int? NaicsCodeId { get; set; }
        
        
        public string? EmployeeCount { get; set; }
        public string? Website { get; set; }
        public string? RegisteredDomicile { get; set; }
        public string? EntityType { get; set; }
        public string? ElectronicIdentificationNumber { get; set; }
        public JsonDocument? CustomFields { get; set; }
    }
}
