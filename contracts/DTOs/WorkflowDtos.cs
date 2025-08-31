using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pyrick.Api.Data.DTOs.Workflow
{
    // Legacy workflow DTOs removed - use WorkflowType/WorkflowInstance DTOs instead

    // WorkflowType DTOs for Phase 2
    public class WorkflowTypeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsShared { get; set; }
        public bool IsLocked { get; set; }
        public int Version { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid? EngagementTypeId { get; set; }
        public EngagementTypeBasicDto? EngagementType { get; set; }
        public bool IsTightlyCoupled => EngagementTypeId.HasValue;
        public Guid? WorkflowStatusTypeSetId { get; set; }
        public WorkflowStatusTypeSetBasicDto? WorkflowStatusTypeSet { get; set; }
        public List<WorkflowTypeStageDto> Stages { get; set; } = new List<WorkflowTypeStageDto>();
    }

    public class WorkflowTypeStageDto
    {
        public Guid Id { get; set; }
        public Guid StageId { get; set; }
        public string StageName { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
        public bool IsRequired { get; set; }
    }

    public class CreateWorkflowTypeDto
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? Description { get; set; }
        
        public bool IsShared { get; set; } = false;
        
        public Guid? EngagementTypeId { get; set; }
        
        public Guid? WorkflowStatusTypeSetId { get; set; }
        
        [Required]
        public List<CreateWorkflowTypeStageDto> Stages { get; set; } = new List<CreateWorkflowTypeStageDto>();
    }

    public class CreateWorkflowTypeStageDto
    {
        [Required]
        public Guid StageId { get; set; }
        
        [Required]
        [Range(1, int.MaxValue)]
        public int DisplayOrder { get; set; }
        
        public bool IsRequired { get; set; } = true;
    }

    public class UpdateWorkflowTypeDto
    {
        [StringLength(100, MinimumLength = 1)]
        public string? Name { get; set; }
        
        [StringLength(500)]
        public string? Description { get; set; }
        
        public bool? IsShared { get; set; }
        
        public Guid? EngagementTypeId { get; set; }
        
        public Guid? WorkflowStatusTypeSetId { get; set; }
    }

    public class ReorderStagesDto
    {
        [Required]
        public List<StageReorderItem> Stages { get; set; } = new List<StageReorderItem>();
    }

    public class StageReorderItem
    {
        [Required]
        public Guid Id { get; set; }
        
        [Required]
        [Range(1, int.MaxValue)]
        public int DisplayOrder { get; set; }
    }

    public class CreateWorkflowInstanceDto
    {
        [Required]
        public Guid WorkflowTypeId { get; set; }
        
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; } = string.Empty;
    }

    // WorkflowStatusType DTOs
    public class WorkflowStatusTypeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string StatusCategory { get; set; } = string.Empty;
        public string? Color { get; set; }
        public bool IsSystem { get; set; }
    }

    public class CreateWorkflowStatusTypeDto
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? Description { get; set; }
        
        [Required]
        public string StatusCategory { get; set; } = string.Empty;
        
        [StringLength(7)]
        public string? Color { get; set; }
    }

    // WorkflowStatusTypeSet DTOs
    public class WorkflowStatusTypeSetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsDefault { get; set; }
        public bool IsSystem { get; set; }
        public bool IsActive { get; set; }
        public List<WorkflowStatusTypeDto> StatusTypes { get; set; } = new List<WorkflowStatusTypeDto>();
    }

    public class WorkflowStatusTypeSetBasicDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsDefault { get; set; }
        public bool IsSystem { get; set; }
        public bool IsActive { get; set; }
    }

    public class CreateWorkflowStatusTypeSetDto
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? Description { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        [Required]
        public List<Guid> StatusTypeIds { get; set; } = new List<Guid>();
    }

    public class UpdateWorkflowStatusTypeSetDto
    {
        [StringLength(100, MinimumLength = 1)]
        public string? Name { get; set; }
        
        [StringLength(500)]
        public string? Description { get; set; }
        
        public bool? IsActive { get; set; }
        
        public List<Guid>? StatusTypeIds { get; set; }
    }

    // System Source DTOs
    public class SystemSourceDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string SourceType { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }

    public class CreateSystemSourceDto
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public string SourceType { get; set; } = string.Empty;
        
        public bool IsActive { get; set; } = true;
    }

    // Engagement Role Definition DTOs
    public class EngagementRoleDefinitionDto
    {
        public Guid Id { get; set; }
        public Guid EngagementTypeId { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public string RoleCode { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsRequired { get; set; }
        public int? MaxOccurrences { get; set; }
        public Guid SystemSourceId { get; set; }
        public SystemSourceDto? SystemSource { get; set; }
        public string? EngagementTypeName { get; set; }
    }

    public class CreateEngagementRoleDefinitionDto
    {
        [Required]
        public Guid EngagementTypeId { get; set; }
        
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string RoleName { get; set; } = string.Empty;
        
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string RoleCode { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? Description { get; set; }
        
        public bool IsRequired { get; set; } = false;
        
        [Range(1, int.MaxValue)]
        public int? MaxOccurrences { get; set; }
        
        [Required]
        public Guid SystemSourceId { get; set; }
    }

    // Engagement Role DTOs
    public class EngagementRoleDto
    {
        public Guid Id { get; set; }
        public Guid EngagementId { get; set; }
        public Guid PartyId { get; set; }
        public Guid RoleDefinitionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsPrimary { get; set; }
        public string? Notes { get; set; }
        public EngagementRoleDefinitionDto? RoleDefinition { get; set; }
        public string? PartyName { get; set; }
    }

    public class CreateEngagementRoleDto
    {
        [Required]
        public Guid EngagementId { get; set; }
        
        [Required]
        public Guid PartyId { get; set; }
        
        [Required]
        public Guid RoleDefinitionId { get; set; }
        
        public DateTime? StartDate { get; set; }
        
        public DateTime? EndDate { get; set; }
        
        public bool IsPrimary { get; set; } = false;
        
        [StringLength(1000)]
        public string? Notes { get; set; }
    }

    public class EngagementTypeBasicDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}