using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pyrick.SDK.Contracts.Interfaces
{
    /// <summary>
    /// Adapter interface for Audit Service integration
    /// Provides compliance and audit trail capabilities
    /// </summary>
    public interface IAuditAdapter
    {
        /// <summary>
        /// Check if Audit service is available
        /// </summary>
        Task<bool> IsServiceAvailableAsync();

        /// <summary>
        /// Log an audit event for compliance tracking
        /// </summary>
        Task<Guid> LogAuditEventAsync(AuditEventDto auditEvent);

        /// <summary>
        /// Search audit events with filters
        /// </summary>
        Task<AuditSearchResultDto> SearchAuditEventsAsync(AuditSearchRequestDto request);

        /// <summary>
        /// Get audit trail for a specific entity
        /// </summary>
        Task<IEnumerable<AuditEventDto>> GetEntityAuditTrailAsync(string entityType, Guid entityId, Guid coreConfigurationRef);

        /// <summary>
        /// Get compliance report for date range
        /// </summary>
        Task<ComplianceReportDto> GetComplianceReportAsync(Guid coreConfigurationRef, DateTime startDate, DateTime endDate);

        /// <summary>
        /// Export audit data for compliance reporting
        /// </summary>
        Task<byte[]> ExportAuditDataAsync(AuditExportRequestDto request);
    }

    /// <summary>
    /// Audit event DTO for logging
    /// </summary>
    public class AuditEventDto
    {
        public Guid Id { get; set; }
        public Guid CoreConfigurationRef { get; set; }
        public Guid? UserId { get; set; }
        public string? UserName { get; set; }
        public string EntityType { get; set; } = string.Empty;
        public Guid? EntityId { get; set; }
        public string Action { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Dictionary<string, object>? Metadata { get; set; }
        public Dictionary<string, object>? OldValues { get; set; }
        public Dictionary<string, object>? NewValues { get; set; }
        public string? IpAddress { get; set; }
        public string? UserAgent { get; set; }
        public DateTime Timestamp { get; set; }
        public string Severity { get; set; } = "Info";
        public string? SessionId { get; set; }
        public Guid? CorrelationId { get; set; }
        public bool ContainsPII { get; set; }
        public bool ContainsPHI { get; set; }
    }

    /// <summary>
    /// Audit search request DTO
    /// </summary>
    public class AuditSearchRequestDto
    {
        public Guid CoreConfigurationRef { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? EntityType { get; set; }
        public Guid? EntityId { get; set; }
        public Guid? UserId { get; set; }
        public string? Action { get; set; }
        public string? Severity { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 50;
        public string? SearchTerm { get; set; }
    }

    /// <summary>
    /// Audit search result DTO
    /// </summary>
    public class AuditSearchResultDto
    {
        public IEnumerable<AuditEventDto> Events { get; set; } = new List<AuditEventDto>();
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public bool HasMore { get; set; }
    }

    /// <summary>
    /// Compliance report DTO
    /// </summary>
    public class ComplianceReportDto
    {
        public Guid CoreConfigurationRef { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalEvents { get; set; }
        public int LoginEvents { get; set; }
        public int DataAccessEvents { get; set; }
        public int DataModificationEvents { get; set; }
        public int SecurityEvents { get; set; }
        public int PIIAccessEvents { get; set; }
        public int PHIAccessEvents { get; set; }
        public IEnumerable<UserActivitySummaryDto> TopUsers { get; set; } = new List<UserActivitySummaryDto>();
        public IEnumerable<EntityActivitySummaryDto> TopEntities { get; set; } = new List<EntityActivitySummaryDto>();
    }

    /// <summary>
    /// User activity summary for compliance reports
    /// </summary>
    public class UserActivitySummaryDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int EventCount { get; set; }
        public int PIIAccesses { get; set; }
        public int PHIAccesses { get; set; }
        public DateTime LastActivity { get; set; }
    }

    /// <summary>
    /// Entity activity summary for compliance reports
    /// </summary>
    public class EntityActivitySummaryDto
    {
        public string EntityType { get; set; } = string.Empty;
        public Guid EntityId { get; set; }
        public int AccessCount { get; set; }
        public int ModificationCount { get; set; }
        public DateTime LastAccessed { get; set; }
    }

    /// <summary>
    /// Audit export request DTO
    /// </summary>
    public class AuditExportRequestDto
    {
        public Guid CoreConfigurationRef { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Format { get; set; } = "CSV"; // CSV, JSON, Excel
        public bool IncludePII { get; set; }
        public bool IncludePHI { get; set; }
        public string? EntityType { get; set; }
        public IEnumerable<string> IncludedFields { get; set; } = new List<string>();
    }
}