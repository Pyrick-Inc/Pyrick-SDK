namespace Pyrick.ATS.Application.DTOs;

public class InterviewDto
{
    public Guid Id { get; set; }
    public Guid JobApplicationId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime ScheduledDateTime { get; set; }
    public int DurationMinutes { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string? Location { get; set; }
    public string? MeetingLink { get; set; }
    public List<Guid> InterviewerUserIds { get; set; } = new();
    public List<string> InterviewerNames { get; set; } = new();
    public string? Notes { get; set; }
    public int? Rating { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

public class CreateInterviewDto
{
    public Guid JobApplicationId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime ScheduledDateTime { get; set; }
    public int DurationMinutes { get; set; } = 60;
    public string Type { get; set; } = "Phone";
    public string? Location { get; set; }
    public string? MeetingLink { get; set; }
    public List<Guid> InterviewerUserIds { get; set; } = new();
    public List<string> InterviewerNames { get; set; } = new();
}

public class UpdateInterviewDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime? ScheduledDateTime { get; set; }
    public int? DurationMinutes { get; set; }
    public string? Type { get; set; }
    public string? Status { get; set; }
    public string? Location { get; set; }
    public string? MeetingLink { get; set; }
    public List<Guid>? InterviewerUserIds { get; set; }
    public List<string>? InterviewerNames { get; set; }
    public string? Notes { get; set; }
    public int? Rating { get; set; }
}