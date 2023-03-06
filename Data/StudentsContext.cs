using Microsoft.EntityFrameworkCore;
using Name_Query.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Name_Query.Data
{
    public class StudentsContext : DbContext
    {
        public StudentsContext(DbContextOptions<StudentsContext> options)
            : base (options)
        {
            
        }
        public DbSet<Students> Students { get; set; }
        public static IQueryable<NameModel> NameModels(this StudentsContext context, string firstLetter)
        {
            return context.NameModels.Where(x => x.Name.StartsWith(firstLetter));
        }

    }
}
