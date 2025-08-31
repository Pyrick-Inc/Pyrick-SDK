using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Pyrick.Api.Data.DTOs.Engagement
{
    public class EngagementCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime? EngagementDate { get; set; }
        public JsonDocument? CustomFields { get; set; }
        // CoreConfigurationId removed - obtained from authenticated user context
        public Guid? AddressId { get; set; }
        public Guid? WorkflowId { get; set; }
        public Guid? WorkflowTypeId { get; set; }
        
        // For creating specific engagement types (e.g., JobApplication)
        public string? EngagementType { get; set; }
        public Dictionary<string, object>? SpecificFields { get; set; }
        
        // Associated roles
        public List<CreateEngagementRoleDto> Roles { get; set; } = new List<CreateEngagementRoleDto>();
    }

    public class CreateEngagementRoleDto
    {
        public Guid PartyId { get; set; }
        public Guid RoleDefinitionId { get; set; }
        public bool IsPrimary { get; set; } = false;
    }
}