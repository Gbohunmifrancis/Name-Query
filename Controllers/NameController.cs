using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly object _contexts;
        private Task<Students> _students;

        public NameController(INameRepository nameRepository)
        {
            _nameRepository = nameRepository;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllName()
        {
            var names = await _nameRepository.GetAllNameAsync();
            return Ok(names);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNameById([FromRoute] int id)
        {
            var name = await _nameRepository.GetNamebyIdAsync(id);
            if (name == null)
            {
                return NotFound();
            }
            return Ok(name);
        }

        //[HttpPost("")]
        //public async Task<IActionResult> AddNewName([FromBody] NameModel nameModel)
        //{
        //    var id = await _nameRepository.AddNameAsync(nameModel);
        //    return CreatedAtAction(nameof(GetNameById), new { id = id, controller = "names" }, id);
        //}



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            await _nameRepository.DeleteNameAsync(id);
            return Ok();
        }
    }



       
}



        



    


       
