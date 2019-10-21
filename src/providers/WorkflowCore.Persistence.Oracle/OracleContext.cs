using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;
using Oracle.EntityFrameworkCore.Infrastructure;
using WorkflowCore.Persistence.EntityFramework.Models;
using WorkflowCore.Persistence.EntityFramework.Services;

namespace WorkflowCore.Persistence.Oracle
{
    public class OracleContext : WorkflowDbContext
    {
        private  readonly ILoggerFactory _loggerFactory;
        private readonly string _connectionString;
        private readonly Action<OracleDbContextOptionsBuilder> _oracleOptionsAction;

        public OracleContext(string connectionString, ILoggerFactory logFactory, Action<OracleDbContextOptionsBuilder> oracleOptionsAction = null)
            : base()
        {   
            _connectionString = connectionString;
            _oracleOptionsAction = oracleOptionsAction;
            _loggerFactory = logFactory;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Model.Relational().MaxIdentifierLength = 30; //instead of 128
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(_loggerFactory)
                            .EnableSensitiveDataLogging() // For troubleshooting
                            .UseOracle(_connectionString);
        }

        protected override void ConfigureSubscriptionStorage(EntityTypeBuilder<PersistedSubscription> builder)
        {
            builder.ToTable("Subscription");
            builder.Property(x => x.PersistenceId).UseOracleIdentityColumn();
            var converter = new GuidToStringConverter(); 
            builder.Property(x => x.SubscriptionId).HasConversion(converter).HasColumnType("VARCHAR2(200)"); // For troubleshooting
        }

        protected override void ConfigureWorkflowStorage(EntityTypeBuilder<PersistedWorkflow> builder)
        {
            builder.ToTable("Workflow");
            builder.Property(x => x.PersistenceId).UseOracleIdentityColumn();
            var converter = new GuidToStringConverter();
            builder.Property(x => x.InstanceId).HasConversion(converter).HasColumnType("VARCHAR2(200)"); // For troubleshooting
        }
                
        protected override void ConfigureExecutionPointerStorage(EntityTypeBuilder<PersistedExecutionPointer> builder)
        {
            builder.ToTable("ExecutionPointer");
            builder.Property(x => x.PersistenceId).UseOracleIdentityColumn();
        }

        protected override void ConfigureExecutionErrorStorage(EntityTypeBuilder<PersistedExecutionError> builder)
        {
            builder.ToTable("ExecutionError");
            builder.Property(x => x.PersistenceId).UseOracleIdentityColumn();
        }

        protected override void ConfigureExetensionAttributeStorage(EntityTypeBuilder<PersistedExtensionAttribute> builder)
        {
            builder.ToTable("ExtensionAttribute");
            builder.Property(x => x.PersistenceId).UseOracleIdentityColumn();
        }

        protected override void ConfigureEventStorage(EntityTypeBuilder<PersistedEvent> builder)
        {
            builder.ToTable("Event");
            builder.Property(x => x.PersistenceId).UseOracleIdentityColumn();
            var converter = new GuidToStringConverter();
            builder.Property(x => x.EventId).HasConversion(converter).HasColumnType("VARCHAR2(200)"); // For troubleshooting
        }
    }
}

