using Microsoft.AspNetCore.Mvc;
using RoomOfMusicApi.Models;
using RoomOfMusicApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomOfMusicApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentsController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public ActionResult<List<Student>> Get() =>
            _studentService.Get();

        [HttpGet("{id:length(24)}", Name = "GetStudent")]
        public ActionResult<Student> Get(string id)
        {
            var student = _studentService.Get(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        /// <summary>
        /// Creates a Student.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Student
        ///     {
        ///        "id": 1,
        ///        "firstName": "Leo",
        ///        "lastName": "Doe",
        ///        "isRetired": "false",
        ///        "parentName": "Jenny Doe",
        ///        "email": "leo.doe@me.com",
        ///        "phone": "0731447788",
        ///        "mobile": "0453698512",
        ///        "instrument": "Clarinet",
        ///        "grade": 4,
        ///        "dob": 1995-08-26T14:00:00.000+00:00
        ///     }
        ///
        /// </remarks>
        /// <param name="student"></param>
        /// <returns>A newly created Student</returns>
        /// <response code="201">Returns the newly created student</response>
        /// <response code="400">If the student is null</response> 
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult<Student> Create(Student student)
        {
            _studentService.Create(student);

            return CreatedAtRoute("GetStudent", new { id = student.Id.ToString() }, student);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Student studentIn)
        {
            var student = _studentService.Get(id);

            if (student == null)
            {
                return NotFound();
            }

            _studentService.Update(id, studentIn);

            return NoContent();
        }

        /// <summary>
        /// Deletes a specific Student.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var student = _studentService.Get(id);

            if (student == null)
            {
                return NotFound();
            }

            _studentService.Remove(student.Id);

            return NoContent();
        }
    }
}
