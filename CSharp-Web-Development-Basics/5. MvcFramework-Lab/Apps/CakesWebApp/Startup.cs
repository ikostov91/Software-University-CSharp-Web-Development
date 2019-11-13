using SIS.MvcFramework;
using SIS.MvcFramework.Logger;
using SIS.MvcFramework.Services;

namespace CakesWebApp
{
    public class Startup : IMvcApplication
    {
        public MvcFrameworkSettings Configure()
        {
            return new MvcFrameworkSettings();
        }

        public void ConfigureServices(IServiceCollection collection)
        {
            collection.AddService<IHashService, HashService>();
            collection.AddService<IUserCookieService, UserCookieService>();
            collection.AddService<ILogger>(() => new FileLogger());
            /*
                collection.AddTransient<IHashService, HashService>(); - new instance every time
                collection.AddScoped<IHashService, HashService>();    - one instance per request
                collection.AddSingleton<IHashService, HashService>(); - one global instance for entire app
            */
        }
    }
}
