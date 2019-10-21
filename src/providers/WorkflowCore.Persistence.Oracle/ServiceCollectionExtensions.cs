using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using WorkflowCore.Persistence.EntityFramework.Services;
using WorkflowCore.Persistence.Oracle;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static WorkflowOptions UseOracle(this WorkflowOptions options,
            string connectionString, bool canCreateDB, bool canMigrateDB)
        {
            options.UsePersistence(sp => new EntityFrameworkPersistenceProvider(new OracleContextFactory(connectionString, sp.GetService<ILoggerFactory>()), canCreateDB, canMigrateDB));
            options.Services.AddTransient<IWorkflowPurger>(sp => new WorkflowPurger(new OracleContextFactory(connectionString, sp.GetService<ILoggerFactory>())));
            return options;
        }
    }
}
