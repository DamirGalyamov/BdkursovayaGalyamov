using BD.Logic.Interfaces.Repositories;
using BD.Logic.Interfaces.Services;
using DB.Logic.Interfaces.Repositories;
using DB.Logic.Interfaces.Services;
using DB.Logic.Repositories;
using DB.Logic.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DB.Logic.Extarions
{
    public static class ServiceCollectionsExtentions
    {
        public static void AddLogicServices(this IServiceCollection services)
        {
            services.AddSingleton<IBelt_characteristicService, Belt_characteristicService>();
            services.AddSingleton<IEnter_valueService, Enter_valueService>();
            services.AddSingleton<IkofC1Service, kofC1Service>();
            services.AddSingleton<IOut_valueService, Out_valueService>();
            services.AddSingleton<IPhi0Service, Phi0Service>();
            services.AddSingleton<ISig0Service, Sig0Service>();
            services.AddSingleton<IBelt_characteristicRepository, Belt_characteristicRepository>();
            services.AddSingleton<IEnter_valueRepository, Enter_valueRepository>();
            services.AddSingleton<IOut_valueRepository, Out_valueRepository>();
            services.AddSingleton<IPhi0Repository, Phi0Repository>();
            services.AddSingleton<IkofC1Repository, kofC1Repository>();
            services.AddSingleton<ISig0Repository, Sig0Repository>();
        }
    }
}
