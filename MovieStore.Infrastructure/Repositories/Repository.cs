using MovieStore.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieStore.Infrastructure.Repositories
{
    // Genric constrict
    public class Repository<T> where T: class
    {
        //we are gonna have some base class methods for talking to our database
        private MovieStoreDbContext _dbContext;
        public Repository (MovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<T> GetAll(string filter)
        {
            // some data access code to get all records from data 
            // LINQ => Collection of extenstion methods... on Ienumerable type, that means any class that implments IEnumerable will have access to all the extension methods in LINQ

            var test = new List<T>();


            return _dbContext.Set<T>().ToList();
        }
    }
}
