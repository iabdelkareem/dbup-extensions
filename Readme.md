**DbUp.Extensions.Microsoft.Logging** extends [DbUp]( https://github.com/DbUp/DbUp) logging by enabling using Microsoft.Extensions.Logging.ILogger that's registered in Microsoft Dependency Injection (i.e., IServiceProvider)

## To Use
1. Add `using DbUp.Extensions.Logging;`
2. Call `AddLoggerFromServiceProvider()` on the `UpgradeEngineBuilder` passing `IServiceProvider` as an argument. Check the example below. 

```csharp
    DeployChanges.To
        .SqlDatabase(con)
        .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
        .AddLoggerFromServiceProvider(serviceProvider)
        .Build();
```

