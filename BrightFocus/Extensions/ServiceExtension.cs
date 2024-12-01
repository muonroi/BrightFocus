namespace BrightFocus.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection RegisterService(this IServiceCollection services)
        {
            _ = services.AddSingleton<IFileStorageService, FileStorageService>();
            return services;
        }
    }
}
