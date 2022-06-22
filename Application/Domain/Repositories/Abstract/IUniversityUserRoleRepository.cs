using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Repositories.Abstract
{
    public interface IUniversityUserRoleRepository
    {
        IdentityUserRole<string> GetUserRoleById(string id);
        IdentityUserRole<string> GetUserRoleByUserIdAndRoleId(string userId, string roleId);
        void AddAndSaveUserInRole(IdentityUserRole<string> newUserRole);
        void DeleteUserInRole(string userid, string roleId);
    }
}
