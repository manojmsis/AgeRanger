using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeRanger.Models
{
    class DatabaseUnitOfWork : IUnitOfWork
    {
        public IDbSet<AgeGroup> AgeGroups => Set<AgeGroup>();

        public IDbSet<AgeGroup> AgeGroups
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public DbContext Context
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Database Database
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IDbSet<Person> Persons
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool TrackChanges
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public DbContext GetContext()
        {
            throw new NotImplementedException();
        }

        public IDbSet<T> GetTable<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
