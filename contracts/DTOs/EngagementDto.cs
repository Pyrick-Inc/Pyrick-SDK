using System;
using System.ComponentModel.DataAnnotations;

namespace Pyrick.SDK.Contracts.DTOs
{
    public class EngagementDto
    {
        public Guid Id { get; set; }
        
        [Required]
        public Guid PartyId { get; set; }
        
        [Required]
        public Guid EngagementTypeId { get; set; }
        
        [Required]
        public Guid RegisteredOrganizationId { get; set; }
        
        [Required]
        public Guid CoreConfigurationId { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Status { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? Title { get; set; }
        
        public string? Description { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }
        
        [Required]
        public Guid CreatedBy { get; set; }
        
        public Guid? UpdatedBy { get; set; }
        
        // Navigation properties (DTOs)
        public PartyDto? Party { get; set; }
        public EngagementTypeDto? EngagementType { get; set; }
    }
    
    public class EngagementTypeDto
    {
        public Guid Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? Description { get; set; }
        
        public bool IsActive { get; set; } = true;
    }
}