using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST
{
    public interface IGenericRepository
    {
        public void Get();
        public void GetById(int id);
        public bool Post(int id);
        public bool Delete(int id);
    }
}
