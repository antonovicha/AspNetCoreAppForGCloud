using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreApp.ValuesDomain
{
    public class ValuesDomainInstaller
    {
        public void Install(IServiceCollection services)
        {
            services.AddScoped<IValuesService, ValuesService>();
        }
    }
}
