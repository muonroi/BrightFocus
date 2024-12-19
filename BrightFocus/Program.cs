WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
Assembly assembly = Assembly.GetExecutingAssembly();
ConfigurationManager configuration = builder.Configuration;

builder.AddAppConfiguration();
builder.AddAutofacConfiguration();
builder.Host.UseSerilog((context, services, loggerConfiguration) =>
{
    MSerilogAction.Configure(context, services, loggerConfiguration, false);
});

Log.Information("Starting {ApplicationName} API up", builder.Environment.ApplicationName);

try
{
    IServiceCollection services = builder.Services;

    // Register services
    _ = services.AddApplication(assembly);
    _ = services.AddInfrastructure<Program>(configuration);
    _ = services.SwaggerConfig(builder.Environment.ApplicationName);
    _ = services.AddScopeServices(typeof(BrightFocusDbContext).Assembly);
    _ = services.AddValidateBearerToken<MTokenInfo, Permission>(configuration);
    _ = services.AddDbContextConfigure<BrightFocusDbContext, Permission>(configuration);
    _ = services.AddCors(configuration);
    _ = services.AddPermissionFilter<Permission>();
    _ = services.RegisterService();
    _ = services.ConfigureMapper();
    WebApplication app = builder.Build();
    using (IServiceScope scope = app.Services.CreateScope())
    {
        BrightFocusDbContext dbContext = scope.ServiceProvider.GetRequiredService<BrightFocusDbContext>();
        await dbContext.Database.MigrateAsync();
    }
    _ = app.UseDefaultMiddleware<BrightFocusDbContext, Permission>();
    _ = app.UseCors("MAllowDomains");
    _ = app.AddLocalization(assembly);
    _ = app.UseRouting();
    _ = app.UseAuthentication();
    _ = app.UseAuthorization();
    _ = app.ConfigureEndpoints();
    _ = app.UseStaticFiles();
    _ = app.MigrateDatabase<BrightFocusDbContext>();

    await app.RunAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception: {Message}", ex.Message);
}
finally
{
    Log.Information("Shut down {ApplicationName} complete", builder.Environment.ApplicationName);
    await Log.CloseAndFlushAsync();
}