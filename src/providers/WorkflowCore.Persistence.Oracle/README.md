# Oracle Persistence provider for Workflow Core

Provides support to persist workflows running on [Workflow Core](../../README.md) to a Oracle database.

## Installing

Install the NuGet package "WorkflowCore.Persistence.Oracle"

```
PM> Install-Package WorkflowCore.Persistence.Oracle -Pre
```

## Usage

Use the .UseOracle extension method when building your service provider.

```C#
services.AddWorkflow(x => x.UseOracle(@"aadsadwa", true, true));
```


## Note

dotnet ef migrations add InitialDatabase --startup-project ../../samples/WorkflowCore.Sample01