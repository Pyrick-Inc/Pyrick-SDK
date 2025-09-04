using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pyrick.SDK.Contracts.DTOs;

namespace Pyrick.SDK.Contracts.Interfaces
{
    /// <summary>
    /// Adapter interface for Applicant Tracking System (ATS) integration
    /// Provides job posting, candidate, and application management capabilities
    /// </summary>
    public interface IATSAdapter
    {
        /// <summary>
        /// Check if ATS service is available
        /// </summary>
        Task<bool> IsServiceAvailableAsync();

        #region Job Posting Management

        /// <summary>
        /// Create a new job posting
        /// </summary>
        Task<JobPostingDto> CreateJobPostingAsync(CreateJobPostingRequest request);

        /// <summary>
        /// Get job posting by ID
        /// </summary>
        Task<JobPostingDto?> GetJobPostingAsync(Guid jobPostingId);

        /// <summary>
        /// Update job posting
        /// </summary>
        Task<JobPostingDto> UpdateJobPostingAsync(Guid jobPostingId, UpdateJobPostingRequest request);

        /// <summary>
        /// Get all job postings for core configuration
        /// </summary>
        Task<IEnumerable<JobPostingDto>> GetJobPostingsAsync(Guid coreConfigurationRef, JobPostingFilters? filters = null);

        /// <summary>
        /// Delete job posting
        /// </summary>
        Task DeleteJobPostingAsync(Guid jobPostingId);

        #endregion

        #region Job Application Management

        /// <summary>
        /// Create a new job application
        /// </summary>
        Task<JobApplicationDto> CreateJobApplicationAsync(CreateJobApplicationRequest request);

        /// <summary>
        /// Get job application by ID
        /// </summary>
        Task<JobApplicationDto?> GetJobApplicationAsync(Guid jobApplicationId);

        /// <summary>
        /// Update job application status
        /// </summary>
        Task<JobApplicationDto> UpdateJobApplicationStatusAsync(Guid jobApplicationId, string status, string? notes = null);

        /// <summary>
        /// Get all applications for a job posting
        /// </summary>
        Task<IEnumerable<JobApplicationDto>> GetApplicationsForJobAsync(Guid jobPostingId);

        /// <summary>
        /// Get all applications for a candidate
        /// </summary>
        Task<IEnumerable<JobApplicationDto>> GetApplicationsForCandidateAsync(Guid candidateRef);

        #endregion

        #region Interview Management

        /// <summary>
        /// Schedule an interview
        /// </summary>
        Task<InterviewDto> ScheduleInterviewAsync(CreateInterviewRequest request);

        /// <summary>
        /// Update interview status
        /// </summary>
        Task<InterviewDto> UpdateInterviewAsync(Guid interviewId, UpdateInterviewRequest request);

        /// <summary>
        /// Get interviews for a job application
        /// </summary>
        Task<IEnumerable<InterviewDto>> GetInterviewsForApplicationAsync(Guid jobApplicationId);

        /// <summary>
        /// Cancel interview
        /// </summary>
        Task CancelInterviewAsync(Guid interviewId, string reason);

        #endregion

        #region Candidate Management

        /// <summary>
        /// Create candidate profile (if needed for ATS-specific data)
        /// </summary>
        Task<CandidateProfileDto> CreateCandidateProfileAsync(CreateCandidateProfileRequest request);

        /// <summary>
        /// Get candidate profile
        /// </summary>
        Task<CandidateProfileDto?> GetCandidateProfileAsync(Guid candidateRef);

        /// <summary>
        /// Update candidate profile
        /// </summary>
        Task<CandidateProfileDto> UpdateCandidateProfileAsync(Guid candidateRef, UpdateCandidateProfileRequest request);

        #endregion

        #region Reporting and Analytics

        /// <summary>
        /// Get recruitment pipeline analytics
        /// </summary>
        Task<RecruitmentAnalyticsDto> GetRecruitmentAnalyticsAsync(Guid coreConfigurationRef, DateTime? startDate = null, DateTime? endDate = null);

        /// <summary>
        /// Get job posting performance metrics
        /// </summary>
        Task<JobPostingMetricsDto> GetJobPostingMetricsAsync(Guid jobPostingId);

        #endregion
    }

    #region Request DTOs

    public class CreateJobPostingRequest
    {
        public Guid CoreConfigurationRef { get; set; }
        public Guid EmployerRef { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string EmploymentType { get; set; } = string.Empty;
        public decimal? SalaryMin { get; set; }
        public decimal? SalaryMax { get; set; }
        public DateTime? ApplicationDeadline { get; set; }
        public Dictionary<string, object>? Requirements { get; set; }
    }

    public class UpdateJobPostingRequest
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Department { get; set; }
        public string? Location { get; set; }
        public string? EmploymentType { get; set; }
        public decimal? SalaryMin { get; set; }
        public decimal? SalaryMax { get; set; }
        public DateTime? ApplicationDeadline { get; set; }
        public Dictionary<string, object>? Requirements { get; set; }
        public string? Status { get; set; }
    }

    public class CreateJobApplicationRequest
    {
        public Guid JobPostingRef { get; set; }
        public Guid CandidateRef { get; set; }
        public string? CoverLetter { get; set; }
        public Dictionary<string, object>? ApplicationData { get; set; }
        public string Source { get; set; } = "Direct";
    }

    public class CreateInterviewRequest
    {
        public Guid JobApplicationRef { get; set; }
        public DateTime ScheduledTime { get; set; }
        public string InterviewType { get; set; } = "Phone";
        public string? Location { get; set; }
        public Guid InterviewerRef { get; set; }
        public string? Notes { get; set; }
    }

    public class UpdateInterviewRequest
    {
        public DateTime? ScheduledTime { get; set; }
        public string? InterviewType { get; set; }
        public string? Location { get; set; }
        public Guid? InterviewerRef { get; set; }
        public string? Notes { get; set; }
        public string? Status { get; set; }
        public Dictionary<string, object>? Feedback { get; set; }
    }

    public class CreateCandidateProfileRequest
    {
        public Guid CandidateRef { get; set; }
        public string? ResumeUrl { get; set; }
        public Dictionary<string, object>? Skills { get; set; }
        public Dictionary<string, object>? Experience { get; set; }
        public Dictionary<string, object>? Education { get; set; }
        public Dictionary<string, object>? Preferences { get; set; }
    }

    public class UpdateCandidateProfileRequest
    {
        public string? ResumeUrl { get; set; }
        public Dictionary<string, object>? Skills { get; set; }
        public Dictionary<string, object>? Experience { get; set; }
        public Dictionary<string, object>? Education { get; set; }
        public Dictionary<string, object>? Preferences { get; set; }
    }

    public class JobPostingFilters
    {
        public string? Department { get; set; }
        public string? Location { get; set; }
        public string? EmploymentType { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedAfter { get; set; }
        public DateTime? CreatedBefore { get; set; }
    }

    #endregion

    #region Analytics DTOs

    public class RecruitmentAnalyticsDto
    {
        public Guid CoreConfigurationRef { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalJobPostings { get; set; }
        public int TotalApplications { get; set; }
        public int TotalInterviews { get; set; }
        public int TotalHires { get; set; }
        public double AverageTimeToHire { get; set; }
        public double ApplicationsPerPosting { get; set; }
        public double InterviewToHireRatio { get; set; }
        public IEnumerable<DepartmentMetricsDto> DepartmentMetrics { get; set; } = new List<DepartmentMetricsDto>();
        public IEnumerable<SourceMetricsDto> SourceMetrics { get; set; } = new List<SourceMetricsDto>();
    }

    public class JobPostingMetricsDto
    {
        public Guid JobPostingRef { get; set; }
        public int TotalApplications { get; set; }
        public int QualifiedApplications { get; set; }
        public int InterviewsScheduled { get; set; }
        public int InterviewsCompleted { get; set; }
        public int OffersExtended { get; set; }
        public int Hires { get; set; }
        public double QualificationRate { get; set; }
        public double InterviewRate { get; set; }
        public double OfferRate { get; set; }
        public double HireRate { get; set; }
        public double AverageTimeToFirstInterview { get; set; }
        public IEnumerable<string> TopSources { get; set; } = new List<string>();
    }

    public class DepartmentMetricsDto
    {
        public string Department { get; set; } = string.Empty;
        public int JobPostings { get; set; }
        public int Applications { get; set; }
        public int Hires { get; set; }
        public double HireRate { get; set; }
        public double AverageTimeToHire { get; set; }
    }

    public class SourceMetricsDto
    {
        public string Source { get; set; } = string.Empty;
        public int Applications { get; set; }
        public int Hires { get; set; }
        public double HireRate { get; set; }
        public double CostPerHire { get; set; }
    }

    public class CandidateProfileDto
    {
        public Guid CandidateRef { get; set; }
        public string? ResumeUrl { get; set; }
        public Dictionary<string, object>? Skills { get; set; }
        public Dictionary<string, object>? Experience { get; set; }
        public Dictionary<string, object>? Education { get; set; }
        public Dictionary<string, object>? Preferences { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    #endregion
}