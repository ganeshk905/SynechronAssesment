namespace SynechronAssesment
{
    using Model;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class InformationDB : DbContext
    {
        // Your context has been configured to use a 'InformationDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'SynechronAssesment.InformationDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'InformationDB' 
        // connection string in the application configuration file.
        public InformationDB()
            : base("name=InformationDB")
        {
        }
        public DbSet<InformationCapture> Person { get; set; }
       
    }

    
}