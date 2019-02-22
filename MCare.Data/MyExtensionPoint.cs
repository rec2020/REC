using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NajmetAlraqee.Data
{
    public static class MyExtensionPoint
    {
        public static IServiceCollection AddMyLibraryDbContext(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddEntityFrameworkNpgsql();
            services.AddDbContext<NajmetAlraqeeContext>(options => options.UseNpgsql(Configuration["ConnectionStrings:NajmetAlraqeeConnection"]));
            return services;
        }
    }

}
