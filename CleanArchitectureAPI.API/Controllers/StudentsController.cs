using CleanArchitectureAPI.Service.ICustomServices;
using CleanArchitectureAPI.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ICustomService<StudentServiceModel> _customService;
        public StudentsController(ICustomService<StudentServiceModel> customService)
        {
            _customService = customService;
        }

        [HttpGet(nameof(GetStudentById))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult GetStudentById(int Id)
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
        [HttpGet(nameof(GetAllStudent))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult GetAllStudent()
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


        [HttpPost(nameof(CreateStudent))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult CreateStudent(StudentServiceModel student)
        {
            if (student != null)
            {
                _customService.Insert(student);
                return Ok("Created Successfully");
            }
            else
            {
                return BadRequest("Somethingwent wrong");
            }
        }

        [HttpPut(nameof(UpdateStudent))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult UpdateStudent(int Id, StudentServiceModel student)
        {
            if (student != null)
            {
                if (Id != student.Id || student.Id == 0)
                {
                    return BadRequest();
                }

                var obj = _customService.Get(student.Id);
                if (obj == null)
                {
                    return NotFound();
                }

                _customService.Update(student);
                return Ok("Updated SuccessFully");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete(nameof(DeleteStudent))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult DeleteStudent(int Id)
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

        [HttpDelete(nameof(RemoveStudent))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult RemoveStudent(int Id)
        {
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
