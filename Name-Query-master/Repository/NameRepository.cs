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
        private readonly StudentsContext _context;


        public NameRepository(StudentsContext context)
        {
            _context = context;
        }
        public async Task<List<NameModel>> GetAllNameAsync()
        {
            var records = await _context.Students.Select(x => new NameModel()
            {
                Id = x.Id,
                Name = x.Name,
                Department = x.Department

            }).ToListAsync();
            return records;

        }


        //public async Task<NameModel> GetNameByIdAsync(int nameId)
        //{
        //    var records = await _context.Students.Where(x => x.Id == nameId).Select(x => new NameModel()
        //    {
        //        Id = x.Id,
        //        Name = x.Name,
        //        Department = x.Department
        //    }).FirstOrDefaultAsync();

        //    return records;

        //}

        public async Task<int> AddNameAsync(NameModel nameModel)
        {
            var name = new Students()
            {
                Name = nameModel.Name,
                Department = nameModel.Department
            };
            _context.Students.Add(name);
            await _context.SaveChangesAsync();

            return name.Id;



        }



        public async Task DeleteNameAsync(int nameId)
        {
            var name = new Students() { Id = nameId };

            _context.Students.Remove(name);

            await _context.SaveChangesAsync();

        }
       


        public async Task<List<Students>> GetNameByNameAsync(string name)
        {
            var records = await _context.Students.Where(x => x.Name.Contains(name)).ToListAsync();

            return records;

        }




        //public async Task<int> AddNoExistingAsync(NameModel name)
        //{
        //    if (_context.Students.Any(x => x.Name == NameModel.Name))
        //    {
        //        throw new ArgumentException("A Person With the same name already exists"); 
        //    }

        //    _context.Students.Add(Students);
        //}

        public  async Task<int> AddNoExistingAsync(NameModel nameModel)
        {
            var name = new Students()
            {
                Name = nameModel.Name,
                Department = nameModel.Department
            };

            if (_context.Students.Any(x => x.Name == nameModel.Name))
            {
                throw new ArgumentException("A Person With the same name already exists");

            }
            _context.Students.Add(name);
            await _context.SaveChangesAsync();

            return name.Id;



        }

        public Task<int> AddNoExistingAsync(Students students)
        {
            throw new NotImplementedException();
        }
    }
}





