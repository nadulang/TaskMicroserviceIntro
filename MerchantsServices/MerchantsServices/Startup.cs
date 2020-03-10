using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MerchantsServices.Infrastructure.Persistences;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using MediatR;
using MerchantsServices.Application.UseCases.Merchants.Command.CreateMerchant;
using MerchantsServices.Application.UseCases.Merchants.Queries.GetMerchant;
using MerchantsServices.Application.Interfaces;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MerchantsServices
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
            services.AddDbContext<MerchantContext>(options => options.UseNpgsql("Host=127.0.0.1;Database=microservicesdb;Username=postgres;Password=docker"));
            services.AddControllers();
            services.AddMvc()
                   .AddFluentValidation(opt => opt.RegisterValidatorsFromAssemblyContaining(typeof(CreateMerchantValidation)));

            services.AddMediatR(typeof(GetMerchantQueryHandler).GetTypeInfo().Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidatorBehaviour<,>));

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option => {
                option.RequireHttpsMetadata = false;
                option.SaveToken = false;
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("ini secretnya kurang panjaaaaaangggggg banget")),
                    ValidateAudience = false,
                    ValidateIssuer = false
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
