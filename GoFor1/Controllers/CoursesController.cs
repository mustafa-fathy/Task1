using GoFor1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace GoFor1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        DbCon db;
        public CoursesController(DbCon _db)
        {
            db = _db;
        }
        [HttpGet]
        public IActionResult GetAllCourses()
        {
            return Ok(db.Courses);
        }
        [HttpGet("{id}")]
        public IActionResult Getbyid(int id)
        {

            Courses CO=db.Courses.Find(id);
            if (CO == null) return NotFound("No Course Found");
            else return Ok(CO);

        }
        [HttpGet("{name:alpha}")]
        public IActionResult GetByName(string name)
        {
            Courses CO = db.Courses.FirstOrDefault(C=>C.Name== name);
            if (CO == null) return NotFound("No Course Found");
            else return Ok(CO);
        }
        [HttpPost]
        public IActionResult AddCourse (Courses C)
        {
            if (C == null) return BadRequest("No Data Found");
            if(!ModelState.IsValid) return BadRequest("Invalid Data");
            db.Courses.Add(C);
            db.SaveChanges();
            return Created("DoneCreating",C);
           // return CreatedAtAction("Getbyid", new {id=C.Id}, C);
        }
        [HttpPut("{id}")]
        public IActionResult EditCourses (Courses C,int id)
        {
         if (C == null) return BadRequest("No Data Found");
         if(C.Id!=id )return BadRequest("Id Mismatch");
            if(!ModelState.IsValid) return BadRequest("Invalid Data");
            //db.Courses.Update(C);
            db.Entry(C).State=EntityState.Modified;
            db.SaveChanges();

           // return Ok(C);
           return NoContent();

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            Courses Co = db.Courses.Find(id);
            if (Co == null ) return NotFound("No Course Found");
            db.Courses.Remove(Co);
            db.SaveChanges();
            return Ok("Course Deleted");
        }
    }
}
