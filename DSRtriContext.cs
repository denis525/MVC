using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace DSRtri.Models
{
    public class DSRtriContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public DSRtriContext() : base("name=DSRtriContext")
        {
            Database.SetInitializer<DSRtriContext>(new DataContextDBInitializer());

            this.Configuration.ValidateOnSaveEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<DSRtri.Models.Vozila> Vozilas { get; set; }

        public System.Data.Entity.DbSet<DSRtri.Models.NovaVozila> NovaVozilas { get; set; }

        public System.Data.Entity.DbSet<DSRtri.Models.Registracija> Uporabniki { get; set; }

        public class DataContextDBInitializer : CreateDatabaseIfNotExists<DSRtriContext>
        {
            Random r = new Random();

            protected override void Seed(DSRtriContext context)
            {

                for (int i = 0; i < 2; i++)
                {
                    int viewCount = r.Next(250000, 1250000);


                }

                base.Seed(context);

            }

        }

    }
}
