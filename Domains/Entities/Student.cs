using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySchoolWebSite.Controllers;

namespace MySchoolWebSite.Domains.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int ClassId { get; set; }
        public Uri ProfileImg { get; set; }
        public string Info { get; set; }
    }
}
