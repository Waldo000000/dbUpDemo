using System;
using System.Data.SqlClient;
using DbUp;
using Serilog;
using Serilog.Core;

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
                .LogTo(new SerilogUpgradeLog(new LoggerConfiguration().WriteTo.LiterateConsole().CreateLogger()))
                .Build()
                .PerformUpgrade();

            Console.WriteLine($"Database upgrade {(result.Successful ? "succeeded" : $"failed: {result.Error.Message}")}");
            Console.ReadLine();
        }
    }
}
