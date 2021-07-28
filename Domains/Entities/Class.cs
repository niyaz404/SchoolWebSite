using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolWebSite.Domains.Entities
{
    public class Class
    {
        public int Id { get; set; }
        [Column("ClassName")]
        public string ClassName { get; set; }
    }
}
