using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDb.Migrations;

namespace TestDb
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    class ProductContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public ProductContext(DbConnection existingConnection, bool contextOwnsConnection) : base(existingConnection, contextOwnsConnection)
        {
            Database.SetInitializer(new CustomInitializer());
            Database.Initialize(true);
        }
        public ProductContext()
        {
            Database.Initialize(true);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public class CustomInitializer : IDatabaseInitializer<ProductContext>
        {

            #region IDatabaseInitializer<MasterDetailContext> Members

            // fix the problem with MigrateDatabaseToLatestVersion 
            // by copying the connection string FROM the context
            public void InitializeDatabase(ProductContext context)
            {
                Configuration cfg = new Configuration(); // migration configuration class
                cfg.TargetDatabase = new DbConnectionInfo(context.Database.Connection.ConnectionString, "System.Data.SqlClient");

                DbMigrator dbMigrator = new DbMigrator(cfg);
                //this will call the parameterless constructor of the datacontext
                // but the connection string from above will be then set on in
                dbMigrator.Update();
            }

            #endregion
        }
    }
}
