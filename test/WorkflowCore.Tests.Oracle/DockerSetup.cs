﻿using Docker.DotNet;
using Docker.DotNet.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Docker.Testify;
using Xunit;
using Microsoft.Extensions.Logging;

namespace WorkflowCore.Tests.Oracle
{
    public class OracleDockerSetup// : DockerSetup
    {
        public static string ConnectionString { get; set; } = @"__CONNECTION__STRING__";
        public static string ScenarioConnectionString { get; set; } = @"__CONNECTION__STRING__";

        //public override string ImageName => "microsoft/mssql-server-linux";
        //public override int InternalPort => 1433;
        //public override TimeSpan TimeOut => TimeSpan.FromSeconds(120);

        //public const string SqlPassword = "I@mJustT3st1ing";

        //public override IList<string> EnvironmentVariables => new List<string> { "ACCEPT_EULA=Y", $"SA_PASSWORD={SqlPassword}" };

        //public override void PublishConnectionInfo()
        //{
        //    ConnectionString = $"Server=127.0.0.1,{ExternalPort};Database=workflowcore-tests;User Id=sa;Password={SqlPassword};";
        //    ScenarioConnectionString = $"Server=127.0.0.1,{ExternalPort};Database=workflowcore-scenario-tests;User Id=sa;Password={SqlPassword};";
        //}

        //public override bool TestReady()
        //{
        //    try
        //    {
        //        var client = new SqlConnection($"Server=127.0.0.1,{ExternalPort};Database=master;User Id=sa;Password={SqlPassword};");
        //        client.Open();
        //        client.Close();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }

        //}
    }

    //[CollectionDefinition("Oracle collection")]
    //public class OracleCollection : ICollectionFixture<OracleDockerSetup>
    //{

    //}

}