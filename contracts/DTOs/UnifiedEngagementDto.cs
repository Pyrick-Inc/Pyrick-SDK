using System;

namespace Pyrick.Api.Data.DTOs
{
    public class UnifiedEngagementDto
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string EngagementTypeDisplayName { get; set; } = null!;
        public DateTime EngagementDate { get; set; }
        public string? PrimaryPartyName { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? WorkflowStatus { get; set; } // "Assigned" or "Unassigned"
        public string? WorkflowId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}