var builder = DistributedApplication.CreateBuilder(args);

#if UseRedisCache
var cache = builder.AddRedisContainer("cache");

#endif
var apiservice = builder.AddProject<Projects.AspireStarterApplication__1_ApiService>("apiservice");

builder.AddProject<Projects.AspireStarterApplication__1_Web>("webfrontend")
#if UseRedisCache
    .WithReference(cache)
#endif
    .WithReference(apiservice);

builder.Build().Run();
