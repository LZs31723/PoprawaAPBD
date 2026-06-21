namespace WebApplication11.DTO;

public class CourseDTO
{
    public int CourseId { get; set; }
    public string Title { get; set; } = null !;
    public int LessonCount { get; set; }
    public int StudentsCount { get; set; }
    public double AverageRating { get; set; }
    public int CertificatesIssued { get; set; }
}