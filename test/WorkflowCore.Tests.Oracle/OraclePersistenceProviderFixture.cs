using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using WorkflowCore.Interface;
using WorkflowCore.Persistence.EntityFramework.Services;
using WorkflowCore.Persistence.Oracle;
using WorkflowCore.UnitTests;
using Xunit;

namespace WorkflowCore.Tests.Oracle
{
    [Collection("Oracle collection")]
    public class OraclePersistenceProviderFixture : BasePersistenceFixture
    {
        private readonly string _connectionString;
        private readonly ILoggerFactory _loggerFactory;

        private readonly IPersistenceProvider _subject;
        protected override IPersistenceProvider Subject => _subject;

        public OraclePersistenceProviderFixture()
        {
            _connectionString = OracleDockerSetup.ConnectionString;
            this._loggerFactory = new NullLoggerFactory();

            _subject = new EntityFrameworkPersistenceProvider(new OracleContextFactory(_connectionString, _loggerFactory), true, true);
            _subject.EnsureStoreExists();
        }
    }
}
