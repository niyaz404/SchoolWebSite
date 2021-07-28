using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySchoolWebSite.Domains.Entities;

namespace MySchoolWebSite.Models.Abstract
{
    public interface IUserRepository
    {
        User Get(string email, string password);
        User GetByEmail(string email);
        //User GetByEmail(string email);
        Task<int> Add(User user);
    }
}
