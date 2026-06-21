using WebApplication11.DTO;

namespace WebApplication11.Service;

public interface IServiceCourse
{
    Task<List<CourseDTO>> GetCourseStatisticsAsync(int? courseId);
}