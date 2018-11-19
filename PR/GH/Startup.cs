using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GH.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using GH.Repository;
using GH.Extensions;
using AutoMapper;
using GH.Services;
using GH.Resolvers;

namespace GH
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<PreguntasContext>(options => options.UseSqlServer(Configuration.GetConnectionString("GHCS")));

            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddScoped<IApiDbQuery, ApiDbQuery>();
            //services.AddScoped(typeof(IValueResolver<,,>), typeof(PreguntaResolver));

            services.AddScoped<IUrlFilterToDynamicLinqParser, UrlFilterToDynamicLinqParser>();
            
            services.AddScoped<IApiQueryResultFilter, ApiQueryResultFilter>();
            
            services.AddScoped<IDbContextFactory, DbContextFactory>();
            

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllHeaders",
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                                 .AllowAnyHeader()
                                 .AllowAnyMethod()
                                 .AllowCredentials();
                      });
            });

            services.AddAutoMapper(typeof(PreguntaResolver));
        }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IMapper autoMapper)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }


            app.UseCors("AllowAllHeaders");
            app.UseMvc();
            autoMapper.ConfigurationProvider.AssertConfigurationIsValid();

        }
        }
    
}
