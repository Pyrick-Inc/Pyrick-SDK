using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Pyrick.Api.Data.DTOs.Engagement
{
    public class EngagementReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? EngagementDate { get; set; }
        public JsonDocument? CustomFields { get; set; }
        // CoreConfigurationId removed - should not be exposed to frontend
        public Guid? AddressId { get; set; }
        public Guid? WorkflowId { get; set; }
        
        // Engagement type information for polymorphic queries
        public string EngagementType { get; set; } = null!;
        public Dictionary<string, object>? SpecificFields { get; set; }
        
        // Related entities
        public List<EngagementRoleDto> Roles { get; set; } = new List<EngagementRoleDto>();
    }

    public class EngagementRoleDto
    {
        public Guid PartyId { get; set; }
        public Guid RoleDefinitionId { get; set; }
        public string? Role { get; set; } // RoleName for display
        public string PartyName { get; set; } = string.Empty;
        public string PartyType { get; set; } = string.Empty;
        public bool IsPrimary { get; set; } = false;
    }
}