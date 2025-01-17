





WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
Assembly assembly = Assembly.GetExecutingAssembly();
ConfigurationManager configuration = builder.Configuration;

builder.AddAppConfigurations();
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
    _ = services.AddDbContextConfigure<BrightFocusDbContext>(configuration);
    _ = services.AddCors(configuration);
    _ = services.AddScoped<IUnitOfWork, UnitOfWork>();
    _ = services.AddAutoMapper(typeof(TaskInListDto),
                               typeof(ChemicalsInListDto),
                               typeof(FibersInListDto),
                               typeof(FinishedProductInListDto),
                               typeof(PaperTubeInListDto),
                               typeof(WastesInListDto),
                               typeof(WoodsInListDto));
    _ = services.AddPermissionFilter<Permission>();

    WebApplication app = builder.Build();
    _ = app.UseCors("MAllowDomains");
    _ = app.UseDefaultMiddleware();
    _ = app.AddLocalization(assembly);
    _ = app.UseRouting();
    _ = app.UseAuthentication();
    _ = app.UseAuthorization();
    _ = app.ConfigureEndpoints();
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