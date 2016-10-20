using System;
using System.Data.SqlClient;
using DbUp;

namespace dbUpDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = new SqlConnectionStringBuilder { DataSource = ".", InitialCatalog = "dbUpDemo", IntegratedSecurity = true }.ConnectionString;

            EnsureDatabase.For.SqlDatabase(connectionString);

            var result = DeployChanges.To
                .SqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(typeof(Program).Assembly)
                .Build()
                .PerformUpgrade();

            Console.WriteLine($"Database upgrade {(result.Successful ? "succeeded" : $"failed: {result.Error.Message}")}");
            Console.ReadLine();
        }
    }
}
