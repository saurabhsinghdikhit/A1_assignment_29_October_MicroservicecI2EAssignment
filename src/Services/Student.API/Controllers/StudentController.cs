using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Student.API.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Student.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _repository;
        private readonly ILogger<StudentController> _logger;

        public StudentController(IStudentRepository repository, ILogger<StudentController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Entities.Student>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Entities.Student>>> GetProducts()
        {
            var products = await _repository.GetStudents();
            return Ok(products);
        }

        [HttpGet("{id:length(24)}", Name = "GetStudent")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Entities.Student), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Entities.Student>> GetStudentId(string id)
        {
            var product = await _repository.GetStudent(id);

            if (product == null)
            {
                _logger.LogError($"Student with id: {id}, not found.");
                return NotFound();
            }

            return Ok(product);
        }

        [Route("[action]/{name}", Name = "GetStudentByName")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Entities.Student>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Entities.Student>>> GetStudentByName(string name)
        {
            var products = await _repository.GetStudentByName(name);
            return Ok(products);
        }

        [Route("[action]/{mobile}", Name = "GetStudentByMobile")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<Entities.Student>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Entities.Student>>> GetStudentByMobile(string mobile)
        {
            var items = await _repository.GetStudentByMobile(mobile);
            if (items == null)
            {
                _logger.LogError($"Students with mobile: {mobile} not found.");
                return NotFound();
            }
            return Ok(items);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Entities.Student), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Entities.Student>> CreateStudent([FromBody] Entities.Student student)
        {
            await _repository.CreateStudent(student);

            return CreatedAtRoute("GetStudent", new { id = student.Id }, student);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Entities.Student), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateStudent([FromBody] Entities.Student student)
        {
            return Ok(await _repository.UpdateStudent(student));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteStudent")]
        [ProducesResponseType(typeof(Entities.Student), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteStudentById(string id)
        {
            return Ok(await _repository.DeleteStudent(id));
        }
    }
}
