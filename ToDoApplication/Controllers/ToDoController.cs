using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApplication.DAL;
using ToDoApplication.Models;

namespace ToDoApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly MyAppDbContext _context;

        public ToDoController(MyAppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("GetNotes")]
        public IActionResult Get()
        {
            try
            {
                var notes = _context.notes.ToList();
                if (notes.Count == 0)
                {
                    return NotFound("ToDos Not found");
                }
                return Ok(notes);
            }
            catch (Exception Ex)
            {

                return BadRequest(Ex.Message);
            }
        }

        [HttpPost]
        [Route("AddNotes")]
        public IActionResult Post(Notes model)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();
                return Ok(new { message = "Task Added" });
            }
            catch (Exception Ex)
            {

                return BadRequest(Ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteNotes")]
        public IActionResult Delete(long id)
        {
            try
            {
                var note
                                = _context.notes.Find(id);
                if (note == null)
                {
                    return NotFound($"Task details not found with id {id}");
                }
                _context.notes.Remove(note);
                _context.SaveChanges();
                return Ok(new { message = "Task deleted" });
            }
            catch (Exception Ex)
            {

                return BadRequest(Ex.Message);
            }

        }
    }
}
