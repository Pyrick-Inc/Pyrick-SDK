namespace Pyrick.ATS.Application.DTOs;

public class JobApplicationDto
{
    public Guid Id { get; set; }
    public string ApplicationNumber { get; set; } = string.Empty;
    public Guid ApplicantId { get; set; }
    public Guid JobPostingId { get; set; }
    public DateTime ApplicationDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public string? CoverLetter { get; set; }
    public string? ResumeUrl { get; set; }
    public Dictionary<string, object> CustomFields { get; set; } = new();
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    // Related data
    public JobPostingDto? JobPosting { get; set; }
    public List<InterviewDto> Interviews { get; set; } = new();
}

public class CreateJobApplicationDto
{
    public Guid ApplicantId { get; set; }
    public Guid JobPostingId { get; set; }
    public string? CoverLetter { get; set; }
    public string? ResumeUrl { get; set; }
    public Dictionary<string, object> CustomFields { get; set; } = new();
}

public class UpdateJobApplicationDto
{
    public string Status { get; set; } = string.Empty;
    public string? CoverLetter { get; set; }
    public string? ResumeUrl { get; set; }
    public Dictionary<string, object> CustomFields { get; set; } = new();
}