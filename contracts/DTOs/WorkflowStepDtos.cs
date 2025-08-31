using System.ComponentModel.DataAnnotations;
using Pyrick.Api.Data.Entities;

namespace Pyrick.Api.Data.DTOs.WorkflowStep
{
    public class WorkflowStepCreateDto
    {
        [Required]
        public Guid WorkflowId { get; set; }
        
        [Required]
        public Guid StageId { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(100)]
        public string? EngagementFieldName { get; set; }
        
        public bool IsRequired { get; set; } = true;
        
        public bool CanBeWaived { get; set; } = false;
        
        [StringLength(500)]
        public string? Description { get; set; }
    }

    public class WorkflowStepReadDto
    {
        public Guid Id { get; set; }
        public Guid WorkflowId { get; set; }
        public string WorkflowName { get; set; } = string.Empty;
        public Guid StageId { get; set; }
        public string StageName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public StepStatus Status { get; set; }
        public string? EngagementFieldName { get; set; }
        public bool IsRequired { get; set; }
        public bool CanBeWaived { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public string? CompletedByUserId { get; set; }
        public string? Notes { get; set; }
    }

    public class WorkflowStepUpdateDto
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
        
        public bool IsRequired { get; set; }
        
        public bool CanBeWaived { get; set; }
        
        [StringLength(500)]
        public string? Description { get; set; }
    }

    public class WorkflowStepStatusUpdateDto
    {
        [Required]
        public StepStatus Status { get; set; }
        
        [StringLength(1000)]
        public string? Notes { get; set; }
    }

    public class WorkflowStepsListDto
    {
        public List<WorkflowStepReadDto> Steps { get; set; } = new();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}