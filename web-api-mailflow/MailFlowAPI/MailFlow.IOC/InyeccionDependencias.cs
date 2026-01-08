
using FluentValidation;
using MailFlow.BLL.Mapper;
using MailFlow.BLL.Interfaces;
using MailFlow.BLL.Validations;
using MailFlow.DAL;
using MailFlow.DAL.Context;
using MailFlow.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MailFlow.BLL.Services;

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

            services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:5173") // <- React dev server
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                    });
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();


            services.AddValidatorsFromAssemblyContaining<LoginValidator>();
            services.AddAutoMapper(config => config.AddProfile(typeof(MapperProfile)));

        }

    }
}
