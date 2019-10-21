using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WorkflowCore.IntegrationTests.Scenarios;
using Xunit;
using Xunit.Abstractions;

namespace WorkflowCore.Tests.Oracle.Scenarios
{
    [Collection("Oracle collection")]
    public class OracleEventScenario : EventScenario
    {
        public OracleEventScenario(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        protected override void ConfigureLogging(IServiceCollection services)
        {
            services.AddLogging((builder) => builder.AddXUnit(_outputHelper));
        }

        protected override void ConfigureServices(IServiceCollection services)
        {
            services.AddWorkflow(x => x.UseOracle(OracleDockerSetup.ScenarioConnectionString, true, true));
        }
    }
}
