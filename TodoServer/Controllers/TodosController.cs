using Microsoft.AspNetCore.Mvc;
using TodoLib.Models;
using TodoLib.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodosRepository _repository;

        public TodosController(ITodosRepository repo)
        {
           _repository = repo;
        }

        // GET: api/<TodosController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<ToDo> list = await _repository.GetAll();

           return !list.Any() ? NoContent() : Ok(list);

        }


        // GET api/<TodosController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var todoToGet = await _repository.Read(id);
                return Ok(todoToGet);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/<TodosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ToDo todo)
        {
            if (!Enum.IsDefined(typeof(PriorityLevel), todo.Priority))
            {
                return BadRequest("Invalid Priority level.");
            }

            try
            {
                var result = await _repository.Create(todo);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<TodosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ToDo todo)
        {
            try
            {
                var updatedItem = await _repository.Update(id, todo);

                return Ok(updatedItem);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE api/<TodosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _repository.Delete(id);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }
    }
}
