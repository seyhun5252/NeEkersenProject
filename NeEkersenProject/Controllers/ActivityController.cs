using BusinesLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace NeEkersenProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpPost("addActivity")]
        public IActionResult AddActivity(ActivityDto activityDto)
        {
            var result = _activityService.Add(activityDto);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("activityList")]
        public IActionResult GetCompanyList()
        {
            var result = _activityService.GetList();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete]
        public IActionResult DeleteActivity(string Id)
        {
            var result = _activityService.Delete(Id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpPut("activityUpdate")]
        public IActionResult UpdateActivity(Activity activity, string Id)
        {
            var result = _activityService.Update(activity, Id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
