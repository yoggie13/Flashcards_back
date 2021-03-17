using Microsoft.EntityFrameworkCore;
using REST.Data;
using REST.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Controllers
{
    public class EFCoreController
    {
        private FlashcardsContext _fscontext = new FlashcardsContext();

        public bool Add(Object o)
        {
            try
            {
                _fscontext.Add(o);
                _fscontext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool Update(Object o)
        {
            return false;
        }
        public bool Delete(Object o)
        {

            return false;
        }
        public Object Select(Object o)
        {
            return null;
        }
    }
}
