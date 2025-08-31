using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Pyrick.Api.Data.DTOs.Engagement
{
    public class EngagementUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime? EngagementDate { get; set; }
        public JsonDocument? CustomFields { get; set; }
        public Guid? AddressId { get; set; }
        public Guid? WorkflowId { get; set; }
        
        // For updating specific engagement type fields
        public Dictionary<string, object>? SpecificFields { get; set; }
        
        // Associated roles (full replacement)
        public List<CreateEngagementRoleDto> Roles { get; set; } = new List<CreateEngagementRoleDto>();
    }
}