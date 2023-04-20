using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Name_Query.Data;
using Name_Query.Models;
using Name_Query.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Name_Query.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NameController : ControllerBase
    {
        private readonly INameRepository _nameRepository;

        private readonly StudentsContext _context;

        public NameController(INameRepository nameRepository, StudentsContext context)
        {
            _nameRepository = nameRepository;
            _context = context;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllName()
        {
            var names = await _nameRepository.GetAllNameAsync();
            return Ok(names);
        }

        //[HttpGet("{Id}")]
        //public async Task<IActionResult> GetNameById([FromRoute] int id)
        //{
        //    var name = await _nameRepository.GetNameByIdAsync(id);
        //    if (name == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(name);
        //}


        [HttpPost("")]
        public async Task<IActionResult> AddNewName([FromBody] NameModel nameModel)
        {
            var id = await _nameRepository.AddNameAsync(nameModel);
            return CreatedAtAction(nameof(GetNameByName), new { id = id, controller = "names" }, id);
        }


        [HttpPost("{NoExisting}")]
        
        public  async Task<IActionResult> AddNoExistingAsync([FromBody] Students student)
        {
            
            var id = await _nameRepository.AddNoExistingAsync(student);
            _context.Students.Add(student);
            return CreatedAtAction("GetStudent", new { id = student.Id, controller = "names" }, student);


        }

        




        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteName([FromRoute] int id)
        {
            await _nameRepository.DeleteNameAsync(id);
            return Ok();
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetNameByName([FromRoute] string name)
        {
            var students = await _nameRepository.GetNameByNameAsync(name);
            //var student =  _context.Students.Where(s => s.Name == name);

            if (students == null)
            {
                return NotFound();
            }
            return Ok(students);


        }








    }
}
    


    
        


    




        



    


       
