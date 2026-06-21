using Microsoft.EntityFrameworkCore;
using WebApplication11.Data;
using WebApplication11.DTO;

namespace WebApplication11.Service;

public class ServiceCourse : IServiceCourse
{
    private readonly AppDbContext _context;

    public ServiceCourse(AppDbContext context)
    {
        _context = context;
    }


    public async Task<List<CourseDTO>> GetCourseStatisticsAsync(int? courseId)
    {
        var query = _context.Courses.AsQueryable();

        if (courseId.HasValue)
        {
            query = query.Where(e => e.Id == courseId.Value);
        }
        return await query.
            Select(c => new CourseDTO()
            {
                CourseId = c.Id,
                Title = c.Title,
                LessonCount = c.Lessons.Count(),
                StudentsCount = c.Enrollments.Count(),
                AverageRating = c.Reviews.Any() ? c.Reviews.Average(r => r.Rating) : 0,
                CertificatesIssued = c.Certificates.Count()
            }).ToListAsync();
    }

}