using System;
using System.ComponentModel.DataAnnotations;

namespace Pyrick.SDK.Contracts.DTOs
{
    public class JobApplicationDto
    {
        public Guid Id { get; set; }
        
        /// <summary>
        /// Reference to the Engagement (no FK constraint - loose coupling)
        /// </summary>
        public Guid EngagementId { get; set; }
        
        [Required]
        public Guid CandidateId { get; set; }
        
        [Required]
        public Guid JobPostingId { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Status { get; set; } = "SUBMITTED";
        
        public DateTime ApplicationDate { get; set; }
        
        [StringLength(1000)]
        public string? CoverLetter { get; set; }
        
        public string? ResumeUrl { get; set; }
        
        [Range(0, 10)]
        public decimal? Score { get; set; }
        
        public string? Notes { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }
        
        [Required]
        public Guid CreatedBy { get; set; }
        
        public Guid? UpdatedBy { get; set; }
        
        // Navigation properties (DTOs)
        public CandidateDto? Candidate { get; set; }
        public JobPostingDto? JobPosting { get; set; }
    }
    
    public class CandidateDto
    {
        public Guid Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; } = string.Empty;
        
        [Phone]
        [StringLength(20)]
        public string? Phone { get; set; }
        
        public string? ResumeUrl { get; set; }
        
        public string? LinkedInUrl { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }
        
        public string FullName => $"{FirstName} {LastName}";
    }
    
    public class JobPostingDto
    {
        public Guid Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;
        
        [Required]
        public string Description { get; set; } = string.Empty;
        
        [StringLength(100)]
        public string? Department { get; set; }
        
        [StringLength(100)]
        public string? Location { get; set; }
        
        [StringLength(50)]
        public string? EmploymentType { get; set; }
        
        [Range(0, double.MaxValue)]
        public decimal? MinSalary { get; set; }
        
        [Range(0, double.MaxValue)]
        public decimal? MaxSalary { get; set; }
        
        [StringLength(50)]
        public string Status { get; set; } = "OPEN";
        
        public DateTime PostedDate { get; set; }
        
        public DateTime? ClosingDate { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }
        
        [Required]
        public Guid CreatedBy { get; set; }
        
        public Guid? UpdatedBy { get; set; }
    }
}