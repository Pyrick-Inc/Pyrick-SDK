using System;
using System.Threading.Tasks;
using Pyrick.SDK.Contracts.DTOs;

namespace Pyrick.SDK.Contracts.Interfaces
{
    /// <summary>
    /// Interface for workflow/process management in CRM systems
    /// </summary>
    public interface IWorkflowAdapter
    {
        // Workflow template operations
        Task<WorkflowTemplateDto?> GetWorkflowTemplateAsync(Guid id);
        Task<IEnumerable<WorkflowTemplateDto>> GetWorkflowTemplatesAsync();
        Task<WorkflowTemplateDto> CreateWorkflowTemplateAsync(WorkflowTemplateDto template);
        Task<WorkflowTemplateDto> UpdateWorkflowTemplateAsync(WorkflowTemplateDto template);
        Task DeleteWorkflowTemplateAsync(Guid id);
        
        // Workflow instance operations
        Task<WorkflowInstanceDto?> GetWorkflowInstanceAsync(Guid id);
        Task<IEnumerable<WorkflowInstanceDto>> GetWorkflowInstancesAsync(int skip = 0, int take = 100);
        Task<IEnumerable<WorkflowInstanceDto>> GetWorkflowInstancesByEngagementAsync(Guid engagementId);
        Task<WorkflowInstanceDto> StartWorkflowAsync(Guid templateId, Guid engagementId);
        Task<WorkflowInstanceDto> AdvanceWorkflowAsync(Guid instanceId, Guid stepId, Dictionary<string, object>? stepData = null);
        Task<WorkflowInstanceDto> CompleteWorkflowAsync(Guid instanceId);
        Task CancelWorkflowAsync(Guid instanceId, string? reason = null);
        
        // Step operations
        Task<IEnumerable<WorkflowStepDto>> GetCurrentStepsAsync(Guid instanceId);
        Task<IEnumerable<WorkflowStepDto>> GetCompletedStepsAsync(Guid instanceId);
        Task<WorkflowStepDto> CompleteStepAsync(Guid stepId, Dictionary<string, object>? stepData = null);
        
        // Workflow monitoring
        Task<IEnumerable<WorkflowInstanceDto>> GetActiveWorkflowsAsync();
        Task<IEnumerable<WorkflowInstanceDto>> GetOverdueWorkflowsAsync();
        Task<WorkflowMetricsDto> GetWorkflowMetricsAsync(Guid? templateId = null, DateTime? fromDate = null, DateTime? toDate = null);
    }
    
    /// <summary>
    /// Represents a workflow template
    /// </summary>
    public class WorkflowTemplateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string Category { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<WorkflowStepTemplateDto> Steps { get; set; } = new List<WorkflowStepTemplateDto>();
    }
    
    /// <summary>
    /// Represents a step template in a workflow
    /// </summary>
    public class WorkflowStepTemplateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int Order { get; set; }
        public string StepType { get; set; } = null!; // "task", "approval", "automated", etc.
        public bool IsRequired { get; set; }
        public int? EstimatedDurationDays { get; set; }
        public List<string> RequiredFields { get; set; } = new List<string>();
        public List<Guid> DependsOnSteps { get; set; } = new List<Guid>();
        public Dictionary<string, object> Configuration { get; set; } = new Dictionary<string, object>();
    }
    
    /// <summary>
    /// Represents a workflow instance
    /// </summary>
    public class WorkflowInstanceDto
    {
        public Guid Id { get; set; }
        public Guid TemplateId { get; set; }
        public Guid EngagementId { get; set; }
        public string Status { get; set; } = null!; // "active", "completed", "cancelled", "on-hold"
        public DateTime StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public DateTime? DueDate { get; set; }
        public string? CurrentStage { get; set; }
        public int ProgressPercentage { get; set; }
        public List<WorkflowStepDto> Steps { get; set; } = new List<WorkflowStepDto>();
    }
    
    /// <summary>
    /// Represents a workflow step instance
    /// </summary>
    public class WorkflowStepDto
    {
        public Guid Id { get; set; }
        public Guid TemplateStepId { get; set; }
        public Guid WorkflowInstanceId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string Status { get; set; } = null!; // "pending", "in-progress", "completed", "skipped"
        public DateTime? StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public DateTime? DueDate { get; set; }
        public string? AssignedTo { get; set; }
        public string? CompletedBy { get; set; }
        public Dictionary<string, object> StepData { get; set; } = new Dictionary<string, object>();
        public string? Notes { get; set; }
    }
    
    /// <summary>
    /// Workflow performance metrics
    /// </summary>
    public class WorkflowMetricsDto
    {
        public int TotalWorkflows { get; set; }
        public int ActiveWorkflows { get; set; }
        public int CompletedWorkflows { get; set; }
        public int CancelledWorkflows { get; set; }
        public int OverdueWorkflows { get; set; }
        public double AverageCompletionDays { get; set; }
        public Dictionary<string, int> WorkflowsByStatus { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, double> AverageCompletionByTemplate { get; set; } = new Dictionary<string, double>();
    }
}