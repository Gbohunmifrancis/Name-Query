using Microsoft.AspNetCore.Mvc;
using Name_Query.Data;
using Name_Query.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Name_Query.Repository
{
    public interface INameRepository
    {
        Task<List<NameModel>> GetAllNameAsync();
        //Task<NameModel> GetNameByIdAsync(int nameId);
        Task<int> AddNameAsync(NameModel nameModel);
        Task DeleteNameAsync(int nameId);
        Task<List<Students>> GetNameByNameAsync(string name);
        Task<int> AddNoExistingAsync(Students students);
       // Task<ActionResult<Students>> AddNoExistingAsync(Students student);
       // Task<int> AddNoExistingAsync(NameModel students);

        // Task<List<Students>> GetNameByNameAsync(string name);
        //Task UpdateNameAsync(int nameId, NameModel nameModel);

    }


}
