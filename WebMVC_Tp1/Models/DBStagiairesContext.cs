using System;
using System.Data.Entity;
using System.Linq;

namespace WebMVC_Tp1.Models
{
    public class DBStagiairesContext : DbContext
    {
        // Your context has been configured to use a 'DBStagiairesContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'WebMVC_Tp1.Models.DBStagiairesContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DBStagiairesContext' 
        // connection string in the application configuration file.
        public DBStagiairesContext()
            : base("name=DBStagiairesContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Stagiaire > Stagiaires { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}