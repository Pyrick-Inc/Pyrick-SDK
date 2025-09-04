using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pyrick.SDK.Contracts.DTOs;

namespace Pyrick.SDK.Contracts.Interfaces
{
    /// <summary>
    /// Specialized adapter for engagement-specific operations
    /// </summary>
    public interface IEngagementAdapter
    {
        /// <summary>
        /// Create a new engagement with specific workflow rules
        /// </summary>
        Task<EngagementDto> CreateEngagementAsync(CreateEngagementRequest request);
        
        /// <summary>
        /// Update engagement status with business rule validation
        /// </summary>
        Task<EngagementDto> UpdateEngagementStatusAsync(Guid engagementId, string newStatus, Guid updatedBy);
        
        /// <summary>
        /// Get engagement with full related data
        /// </summary>
        Task<EngagementDto?> GetEngagementWithDetailsAsync(Guid engagementId);
        
        /// <summary>
        /// Get engagements by status
        /// </summary>
        Task<IEnumerable<EngagementDto>> GetEngagementsByStatusAsync(string status, int limit = 50, int offset = 0);
        
        /// <summary>
        /// Get engagements created within date range
        /// </summary>
        Task<IEnumerable<EngagementDto>> GetEngagementsByDateRangeAsync(DateTime startDate, DateTime endDate, int limit = 50, int offset = 0);
        
        /// <summary>
        /// Archive old engagements based on retention policies
        /// </summary>
        Task<int> ArchiveEngagementsAsync(DateTime beforeDate);
        
        /// <summary>
        /// Get engagement statistics for reporting
        /// </summary>
        Task<EngagementStatsDto> GetEngagementStatsAsync(DateTime? startDate = null, DateTime? endDate = null);
        
        /// <summary>
        /// Validate engagement business rules before creation/update
        /// </summary>
        Task<EngagementValidationResult> ValidateEngagementAsync(CreateEngagementRequest request);
        
        /// <summary>
        /// Get available next statuses for an engagement
        /// </summary>
        Task<IEnumerable<string>> GetAvailableStatusesAsync(Guid engagementId);
    }
    
    // Supporting DTOs
    public class EngagementStatsDto
    {
        public int TotalEngagements { get; set; }
        public int ActiveEngagements { get; set; }
        public int CompletedEngagements { get; set; }
        public int CancelledEngagements { get; set; }
        public Dictionary<string, int> EngagementsByType { get; set; } = new();
        public Dictionary<string, int> EngagementsByStatus { get; set; } = new();
        public double AverageCompletionDays { get; set; }
    }
    
    public class EngagementValidationResult
    {
        public bool IsValid { get; set; }
        public List<string> Errors { get; set; } = new();
        public List<string> Warnings { get; set; } = new();
    }
}