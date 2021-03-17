using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Controllers
{
    public interface IGenericRepository
    {
        public bool Add(Object o);
        public bool Update(Object o);
        public bool Delete(Object o);
        public Object GetAll(Object o);
        public Object GetById(Object o);
    }
}
