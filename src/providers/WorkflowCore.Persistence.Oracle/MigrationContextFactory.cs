using System;
using Microsoft.EntityFrameworkCore.Design;

namespace WorkflowCore.Persistence.Oracle
{
    public class MigrationContextFactory : IDesignTimeDbContextFactory<OracleContext>
    {
        public OracleContext CreateDbContext(string[] args)
        {
            return new OracleContext(@"__CONNECTION__STRING__", null);
        }
    }
}
