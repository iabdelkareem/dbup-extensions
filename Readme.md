[![Build Status](https://dev.azure.com/ibrahimabdelkareem0432/OpenSource/_apis/build/status/dbup-extensions?branchName=main)](https://dev.azure.com/ibrahimabdelkareem0432/OpenSource/_build/latest?definitionId=2&branchName=main) ![Nuget](https://img.shields.io/nuget/v/DbUp.Extensions.Microsoft.Logging)

**DbUp.Extensions.Microsoft.Logging** extends [DbUp]( https://github.com/DbUp/DbUp) logging by enabling using Microsoft.Extensions.Logging.ILogger that's registered in Microsoft Dependency Injection (i.e., IServiceProvider)


## To Use

The two ways to use this extension are described below. Both have the same result, but are different ways to pass in the logger.

### Using Service Provider

1. Add `using DbUp.Extensions.Logging;`
2. Call `AddLoggerFromServiceProvider()` on the `UpgradeEngineBuilder` passing `IServiceProvider` as an argument. Check the example below. 

```csharp
    DeployChanges.To
        .SqlDatabase(con)
        .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
        .AddLoggerFromServiceProvider(serviceProvider)
        .Build();
```

### Using Logger

1. Add `using DbUp.Extensions.Logging;`
2. Call `AddLogger()` on the `UpgradeEngineBuilder` passing `ILogger<UpgradeEngine>` as an argument. Check the example below. 

```csharp
    DeployChanges.To
        .SqlDatabase(con)
        .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
        .AddLogger(logger)
        .Build();
```

