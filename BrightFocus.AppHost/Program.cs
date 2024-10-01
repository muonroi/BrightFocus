var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.BrightFocus>("brightfocus");

builder.Build().Run();
