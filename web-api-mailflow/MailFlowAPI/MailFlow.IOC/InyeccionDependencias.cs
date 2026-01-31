
using FluentValidation;
using Hangfire;
using MailFlow.BLL.Interfaces;
using MailFlow.BLL.Mapper;
using MailFlow.BLL.Services;
using MailFlow.BLL.Validations;
using MailFlow.DAL.Context;
using MailFlow.DAL.Interfaces;
using MailFlow.DAL.Respository;
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

            services.AddScoped<IContactoRepository, ContactoRepository>();
            services.AddScoped<IContactoService, ConctactoService>();

            services.AddScoped<IListaRespository, ListaRepository>();
            services.AddScoped<IListaService, ListaService>();

            services.AddScoped<ICampaniaService, CampaniaService>();
            services.AddScoped<ICampaniaRepository, CampaniaRepository>();

            services.AddScoped<IMailService, GmailService>();

            services.AddScoped<IEnvioRepository, EnvioRepository>();

            services.AddAutoMapper(config => config.AddProfile(typeof(MapperProfile)));

            // Add Hangfire services.
            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(conf.GetConnectionString("cadenaSQL")));

            // Add the processing server as IHostedService
            services.AddHangfireServer();


        }

    }
}
