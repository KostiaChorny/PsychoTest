namespace PsychoTest.Model
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Tests.ConfusedLines;
    using Tests.NumberSort;
    using Tests.Strup;
    public class DB : DbContext
    {
        // Your context has been configured to use a 'DB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'PsychoTest.Model.DB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DB' 
        // connection string in the application configuration file.
        public DB()
            : base("name=DB")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<StrupResult> StrupTestResults { get; set; }
        public virtual DbSet<PartResult> StrupPartResults { get; set; }
        public virtual DbSet<NumberSortResult> NumberSortTestResults { get; set; }
        public virtual DbSet<ConfusedLinesTestResult> ConfusedLinesTestResults { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}