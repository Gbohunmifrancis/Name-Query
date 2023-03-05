using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Name_Query.Data;
using Name_Query.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Name_Query.Repository
{
    public class NameRepository : INameRepository
    {
        private readonly StudentsContext _contexts;

        public NameRepository(StudentsContext contexts)
        {
            _contexts = contexts;
        }
        public async Task<List<NameModel>> GetAllNameAsync()
        {
            var records = await _contexts.Students.Select(x=> new NameModel()
            { 
              Id=x.Id,
              Name = x.Name,
              Department=x.Department
             
            }).ToListAsync();

            return records;
        }


        public async Task<NameModel> GetNamebyIdAsync(int nameId)
        {
            var records = await _contexts.Students.Where(x => x.Id == nameId).Select(x => new NameModel()
            {
                Id = x.Id,
                Name = x.Name,
                Department = x.Department,
               
            }).FirstOrDefaultAsync();

            return records;
        }


      
        public async Task DeleteNameAsync(int nameId)
        {
            var name = new Students() { Id = nameId };

            _contexts.Students.Remove(name);
            await _contexts.SaveChangesAsync();

            
        }

       
       
       

    }
}
