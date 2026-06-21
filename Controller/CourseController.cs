using Microsoft.AspNetCore.Mvc;
using WebApplication11.Service;

namespace WebApplication11.Controllers;

public class CourseController : ControllerBase
{
    private readonly IServiceCourse _serviceCourse;

    public CourseController(IServiceCourse serviceCourse)
    {
        _serviceCourse = serviceCourse;
    }

    [HttpGet("api/course-statistics")]
    public async Task<IActionResult> GetCourse([FromQuery] int? courseId = null)
    {   
        var courseSummaries = _serviceCourse.GetCourseStatisticsAsync(courseId);
        return Ok(await courseSummaries);
    }
}