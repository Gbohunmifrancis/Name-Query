using Microsoft.AspNetCore.Mvc;
using Name_Query.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Name_Query.Repository
{
    public interface INameRepository
    {
        Task<List<NameModel>> GetAllNameAsync();
        Task<NameModel> GetNamebyIdAsync(int nameId);
        Task DeleteNameAsync(int nameId);
    }
   
    
}
