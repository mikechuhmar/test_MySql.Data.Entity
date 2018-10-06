using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDb
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    class ProductContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public ProductContext(DbConnection existingConnection, bool contextOwnsConnection) : base(existingConnection, contextOwnsConnection)
        {

        }

    }
}
