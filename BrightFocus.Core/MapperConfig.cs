


namespace BrightFocus.Core
{
    public static class MapperConfig
    {
        public static IServiceCollection ConfigureMapper(this IServiceCollection services)
        {
            _ = services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(new ConfigurationAutoMapperProfiles("BrightFocus"));
            });

            return services;
        }
    }
}
