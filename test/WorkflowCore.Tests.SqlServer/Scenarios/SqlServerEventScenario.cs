﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.IntegrationTests.Scenarios;
using Xunit;

namespace WorkflowCore.Tests.SqlServer.Scenarios
{
    [Collection("SqlServer collection")]
    public class SqlServerEventScenario : EventScenario
    {
        public SqlServerEventScenario(Xunit.Abstractions.ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        protected override void ConfigureServices(IServiceCollection services)
        {
            services.AddWorkflow(x => x.UseSqlServer(SqlDockerSetup.ScenarioConnectionString, true, true));
        }
    }
}
