using ElevaManageSchools.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ElevaManageSchools.Initialization
{
    public static class ServicesDependencyInjectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ISchoolService, SchoolService>();
            services.AddScoped<IClassService, ClassService>();
        }
    }
}
