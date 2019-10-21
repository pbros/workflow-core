using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Oracle.EntityFrameworkCore.Infrastructure;
using WorkflowCore.Persistence.EntityFramework.Interfaces;
using WorkflowCore.Persistence.EntityFramework.Services;

namespace WorkflowCore.Persistence.Oracle
{
    public class OracleContextFactory : IWorkflowDbContextFactory
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly string _connectionString;
        private readonly Action<OracleDbContextOptionsBuilder> _oracleOptionsAction;

        public OracleContextFactory(string connectionString, ILoggerFactory loggerFactory, Action<OracleDbContextOptionsBuilder> oracleOptionsAction = null )
        {
            _connectionString = connectionString;
            _oracleOptionsAction = oracleOptionsAction;
            _loggerFactory = loggerFactory;
        }

        public WorkflowDbContext Build()
        {
            return new OracleContext(_connectionString, _loggerFactory, _oracleOptionsAction);
        }
    }
}
