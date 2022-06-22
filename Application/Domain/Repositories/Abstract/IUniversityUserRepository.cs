using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Repositories.Abstract
{
    public interface IUniversityUserRepository
    {
        IQueryable<UniversityUser> GetAllUniversityUsers();
        UniversityUser GetUserById(string id); 
        void AddAndSaveUser(UniversityUser newUser);
        void DeleteUser(string id);
    }
}
