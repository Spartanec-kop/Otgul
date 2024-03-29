using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Otgul.Api;
using Otgul.DataBase;
using Otgul.DataBase.Repository;
using Otgul.DataBase.Repository.Repository;
using Otgul.Models;
using Otgul.Repository.Interface;
using Otgul.Services.Interfaces;
using Otgul.Services.Security;
using Otgul.Services.Services;

namespace Otgul
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
            services.AddDbContext<OtgulDBContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString(nameof(OtgulDBContext))));

            services.AddTransient<IDataBaseRepository<User>, UserRepository>();
            services.AddTransient<IDataBaseRepository<Role>, RoleRepository>();
            services.AddTransient<IDataBaseRepository<Otdel>, OtdelRepository>();
            services.AddTransient<IDataBaseRepository<Department>, DepartmentRepository>();
            services.AddTransient<IDataBaseRepository<Right>, RightRepository>();
            services.AddTransient<IDataBaseRepository<OtgulRecord>, OtgulRecordRepository>();
            services.AddTransient<IDataBaseRepository<Guide>, GuideRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IOtdelService, OtdelService>();
            services.AddTransient<IRightService, RightService>();
            services.AddTransient<IOtgulRecordService, OtgulRecordService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IGuideService, GuideService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<Mapper, Mapper>();
            services.AddControllers();          
            // added CORS
            services.AddCors();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = AuthOptions.GetTokenParameters();
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            JsonConvert.DefaultSettings = () => ApiSettings.DefaultJsonSerializerSettings;
        }
    }
}
