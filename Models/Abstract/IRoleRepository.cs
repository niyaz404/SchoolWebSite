﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySchoolWebSite.Domains.Entities;

namespace MySchoolWebSite.Models.Abstract
{
    public interface IRoleRepository
    {
        Role Get(int id);
        IEnumerable<Role> GetAll();
    }
}
