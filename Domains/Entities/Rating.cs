using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolWebSite.Domains.Entities
{
    public class Rating
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int LPId { get; set; }
        public int Mark { get; set; }
        public DateTime Date { get; set; }
        public int Index { get; set; }//порядковый номер оценки(имитация даты)
    }
}
