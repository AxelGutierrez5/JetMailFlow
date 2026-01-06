
using FluentValidation;
using MailFlow.BLL;
using MailFlow.BLL.Interfaces;
using MailFlow.BLL.Validations;
using MailFlow.DAL;
using MailFlow.DAL.Context;
using MailFlow.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MailFlow.IOC
{
    public static class InyeccionDependencias
    {

        public static void Inyeccion(this IServiceCollection services, IConfiguration conf)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(conf.GetConnectionString("cadenaSQL"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuaarioService>();


            services.AddValidatorsFromAssemblyContaining<LoginValidator>();

        }

    }
}
