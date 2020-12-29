using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;
using SoccerApp.Middlewares;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Application.Interfaces.Persistence;
using Persistence;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Persistence.UnitOfWork;
using SoccerApp.Extensions;
using AutoMapper;
using Application.MappingProfiles;
using Application.Interfaces.Services;
using Application.Services;

using Domain.Entities;
using Identity.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Application.Interfaces.Identity;
using Identity.Managers ;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;

namespace SoccerApp
{
    public class Startup
    {
        IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ModelToResource());
                mc.AddProfile(new ResourceToModel());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SoccerDatabase"));
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<IStadiumService, StadiumService>();
            services.AddScoped<ITokenManager, JWTManager>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IEmailService, EmailService>();
            var tokenOptionsSection = Configuration.GetSection("TokenOptions");
            services.Configure<AppSettings>(tokenOptionsSection);
            var tokenOptions = tokenOptionsSection.Get<AppSettings>();
            var key =  Encoding.ASCII.GetBytes(tokenOptions.Secret);
            services.AddIdentity<User, IdentityRole>(option => {
                option.Password.RequireDigit = false;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireDigit = false;
                option.Password.RequiredLength = 3;
                option.Password.RequireLowercase = true;
                option.Password.RequireUppercase = false;
                option.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {

                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });

            services.AddCors();
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            });

        }

        private static NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter()
        {
            var builder = new ServiceCollection()
                .AddLogging()
                .AddMvc()
                .AddNewtonsoftJson()
                .Services.BuildServiceProvider();

            return builder
                .GetRequiredService<IOptions<MvcOptions>>()
                .Value
                .InputFormatters
                .OfType<NewtonsoftJsonPatchInputFormatter>()
                .First();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseErrorHandlingMiddleware();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
