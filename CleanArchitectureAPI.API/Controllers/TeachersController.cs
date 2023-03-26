using CleanArchitectureAPI.Domain.Models;
using CleanArchitectureAPI.Service.ICustomServices;
using CleanArchitectureAPI.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ICustomService<TeacherServiceModel> _customService;
        public TeachersController(ICustomService<TeacherServiceModel> customService)
        {
            _customService = customService;
        }

        [HttpGet(nameof(GetTeacherById))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult GetTeacherById(int Id)
        {
            var obj = _customService.Get(Id);
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(obj);
            }
        }

        [HttpGet(nameof(GetAllTeacher))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult GetAllTeacher()
        {
            var obj = _customService.GetAll();
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(obj);
            }
        }

        [HttpPost(nameof(CreateTeacher))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult CreateTeacher(TeacherServiceModel teacher)
        {
            if (teacher != null)
            {
                _customService.Insert(teacher);
                return Ok("Created Successfully");
            }
            else
            {
                return BadRequest("Somethingwent wrong");
            }
        }

        [HttpPut(nameof(UpdateTeacher))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult UpdateTeacher(int Id, TeacherServiceModel teacher)
        {
            if (teacher != null)
            {
                if (Id != teacher.Id || teacher.Id == 0)
                {
                    return BadRequest();
                }

                var obj = _customService.Get(teacher.Id);
                if (obj == null)
                {
                    return NotFound();
                }

                _customService.Update(teacher);
                return Ok("Updated SuccessFully");
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpDelete(nameof(DeleteTeacher))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult DeleteTeacher(int Id)
        {
            if (Id > 0)
            {
                var obj = _customService.Get(Id);
                if (obj == null)
                {
                    return NotFound();
                }

                _customService.Delete(Id);
                return Ok("Deleted Successfully");
            }
            else
            {
                return BadRequest("Invalid Input");
            }
        }

        [HttpDelete(nameof(RemoveTeacher))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult RemoveTeacher(int Id)
        {
            if(Id>10)
            {
                throw new Exception("Something went wrong");
            }

            if (Id > 0)
            {
                var obj = _customService.Get(Id);
                if (obj == null)
                {
                    return NotFound();
                }

                _customService.Remove(Id);
                return Ok("Removed Successfully");
            }
            else
            {
                return BadRequest("Invalid Input");
            }
        }
    }
}
