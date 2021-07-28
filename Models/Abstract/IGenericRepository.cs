using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolWebSite.Models.Abstract
{
    public interface IGenericRepository<T> where T :class
    {
        void Add(T entity);
        void Delete(int id);
        T Get(int id);
        IEnumerable<T> GetAll();
        void Update(T entity);
    }
}
