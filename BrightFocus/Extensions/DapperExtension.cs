

namespace BrightFocus.Extensions
{
    public static class DapperExtension
    {
        public static IServiceCollection AddDapperConfig(this IServiceCollection services)
        {
            _ = services.AddAutoMapper(typeof(AutoMapperProfiles));
            return services;
        }
    }
}
