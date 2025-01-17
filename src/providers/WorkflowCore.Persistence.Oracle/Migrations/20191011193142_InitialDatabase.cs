﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Oracle.EntityFrameworkCore.Metadata;

namespace WorkflowCore.Persistence.Oracle.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    PersistenceId = table.Column<long>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    EventId = table.Column<string>(type: "VARCHAR2(200)", nullable: false),
                    EventName = table.Column<string>(maxLength: 200, nullable: true),
                    EventKey = table.Column<string>(maxLength: 200, nullable: true),
                    EventData = table.Column<string>(nullable: true),
                    EventTime = table.Column<DateTime>(nullable: false),
                    IsProcessed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.PersistenceId);
                });

            migrationBuilder.CreateTable(
                name: "ExecutionError",
                columns: table => new
                {
                    PersistenceId = table.Column<long>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    WorkflowId = table.Column<string>(maxLength: 100, nullable: true),
                    ExecutionPointerId = table.Column<string>(maxLength: 100, nullable: true),
                    ErrorTime = table.Column<DateTime>(nullable: false),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExecutionError", x => x.PersistenceId);
                });

            migrationBuilder.CreateTable(
                name: "Subscription",
                columns: table => new
                {
                    PersistenceId = table.Column<long>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    SubscriptionId = table.Column<string>(type: "VARCHAR2(200)", maxLength: 200, nullable: false),
                    WorkflowId = table.Column<string>(maxLength: 200, nullable: true),
                    StepId = table.Column<int>(nullable: false),
                    EventName = table.Column<string>(maxLength: 200, nullable: true),
                    EventKey = table.Column<string>(maxLength: 200, nullable: true),
                    SubscribeAsOf = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription", x => x.PersistenceId);
                });

            migrationBuilder.CreateTable(
                name: "Workflow",
                columns: table => new
                {
                    PersistenceId = table.Column<long>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    InstanceId = table.Column<string>(type: "VARCHAR2(200)", maxLength: 200, nullable: false),
                    WorkflowDefinitionId = table.Column<string>(maxLength: 200, nullable: true),
                    Version = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Reference = table.Column<string>(maxLength: 200, nullable: true),
                    NextExecution = table.Column<long>(nullable: true),
                    Data = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CompleteTime = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflow", x => x.PersistenceId);
                });

            migrationBuilder.CreateTable(
                name: "ExecutionPointer",
                columns: table => new
                {
                    PersistenceId = table.Column<long>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    WorkflowId = table.Column<long>(nullable: false),
                    Id = table.Column<string>(maxLength: 50, nullable: true),
                    StepId = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    SleepUntil = table.Column<DateTime>(nullable: true),
                    PersistenceData = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: true),
                    EndTime = table.Column<DateTime>(nullable: true),
                    EventName = table.Column<string>(maxLength: 100, nullable: true),
                    EventKey = table.Column<string>(maxLength: 100, nullable: true),
                    EventPublished = table.Column<bool>(nullable: false),
                    EventData = table.Column<string>(nullable: true),
                    StepName = table.Column<string>(maxLength: 100, nullable: true),
                    RetryCount = table.Column<int>(nullable: false),
                    Children = table.Column<string>(nullable: true),
                    ContextItem = table.Column<string>(nullable: true),
                    PredecessorId = table.Column<string>(maxLength: 100, nullable: true),
                    Outcome = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Scope = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExecutionPointer", x => x.PersistenceId);
                    table.ForeignKey(
                        name: "FK_ExecutionPointer_Workflow_~",
                        column: x => x.WorkflowId,
                        principalTable: "Workflow",
                        principalColumn: "PersistenceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExtensionAttribute",
                columns: table => new
                {
                    PersistenceId = table.Column<long>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    ExecutionPointerId = table.Column<long>(nullable: false),
                    AttributeKey = table.Column<string>(maxLength: 100, nullable: true),
                    AttributeValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtensionAttribute", x => x.PersistenceId);
                    table.ForeignKey(
                        name: "FK_ExtensionAttribute_Executi~",
                        column: x => x.ExecutionPointerId,
                        principalTable: "ExecutionPointer",
                        principalColumn: "PersistenceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_EventId",
                table: "Event",
                column: "EventId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Event_EventTime",
                table: "Event",
                column: "EventTime");

            migrationBuilder.CreateIndex(
                name: "IX_Event_IsProcessed",
                table: "Event",
                column: "IsProcessed");

            migrationBuilder.CreateIndex(
                name: "IX_Event_EventName_EventKey",
                table: "Event",
                columns: new[] { "EventName", "EventKey" });

            migrationBuilder.CreateIndex(
                name: "IX_ExecutionPointer_WorkflowId",
                table: "ExecutionPointer",
                column: "WorkflowId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtensionAttribute_Executi~",
                table: "ExtensionAttribute",
                column: "ExecutionPointerId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_EventKey",
                table: "Subscription",
                column: "EventKey");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_EventName",
                table: "Subscription",
                column: "EventName");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_SubscriptionId",
                table: "Subscription",
                column: "SubscriptionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workflow_InstanceId",
                table: "Workflow",
                column: "InstanceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workflow_NextExecution",
                table: "Workflow",
                column: "NextExecution");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "ExecutionError");

            migrationBuilder.DropTable(
                name: "ExtensionAttribute");

            migrationBuilder.DropTable(
                name: "Subscription");

            migrationBuilder.DropTable(
                name: "ExecutionPointer");

            migrationBuilder.DropTable(
                name: "Workflow");
        }
    }
}
