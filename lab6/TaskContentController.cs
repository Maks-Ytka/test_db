using Microsoft.AspNetCore.Mvc;
using TaskContentCRUD.Data;
using TaskContentCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskContentCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskContentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TaskContentController(AppDbContext context)
        {
            _context = context;
        }

        // CREATE: POST api/TaskContent
        [HttpPost]
        public async Task<IActionResult> CreateTaskContent([FromBody] TaskContent taskContent)
        {
            if (taskContent == null)
                return BadRequest();

            await _context.TaskContents.AddAsync(taskContent);
            await _context.SaveChangesAsync();

            return Ok(taskContent);
        }

        // READ ALL: GET api/TaskContent
        [HttpGet]
        public async Task<IActionResult> GetAllTaskContents()
        {
            var taskContents = await _context.TaskContents.ToListAsync();
            return Ok(taskContents);
        }

        // READ ONE: GET api/TaskContent/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskContentById(int id)
        {
            var taskContent = await _context.TaskContents.FindAsync(id);

            if (taskContent == null)
                return NotFound();

            return Ok(taskContent);
        }

        // UPDATE: PUT api/TaskContent/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskContent(int id, [FromBody] TaskContent taskContent)
        {
            if (id != taskContent.Id)
                return BadRequest();

            var existingTaskContent = await _context.TaskContents.FindAsync(id);
            if (existingTaskContent == null)
                return NotFound();

            existingTaskContent.MediaContentId = taskContent.MediaContentId;
            existingTaskContent.AnalysisTaskId = taskContent.AnalysisTaskId;

            _context.TaskContents.Update(existingTaskContent);
            await _context.SaveChangesAsync();

            return Ok(existingTaskContent);
        }

        // DELETE: DELETE api/TaskContent/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskContent(int id)
        {
            var taskContent = await _context.TaskContents.FindAsync(id);

            if (taskContent == null)
                return NotFound();

            _context.TaskContents.Remove(taskContent);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
