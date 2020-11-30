using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Models;


namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public QLSV QLSV { get; set; }
        public StudentController() {
            QLSV = new QLSV();
        }
        [Route("GetStudent")]
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return QLSV.Students.ToList();
        }

        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return QLSV.Students.FirstOrDefault(e => e.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            QLSV.Students.Add(student);
            await QLSV.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        }

        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }

        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            var student = await QLSV.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            QLSV.Remove(student);
            await QLSV.SaveChangesAsync();

            return NoContent();
        }
    }
}