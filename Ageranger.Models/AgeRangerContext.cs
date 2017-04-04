using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeRanger.Models
{
   

    public class AgeRangerContext:DbContext 
    {
        public AgeRangerContext():
            base("name = AgeRangerConnection")
        {
            try
            {
                if ((Database.Connection == null))
                {
                    throw new Exception("please specify connection string");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("please specify connection string",ex);
            }
           
        }
        public virtual  DbSet<AgeGroup > AgeGroups { get; set; }
        public virtual DbSet<Person > Persons { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Person>();
            modelBuilder.Entity<AgeGroup>();
        }
    }
}
