
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using PostGreBE.Data;
using PostGreBE.Entity;
using PostGreBE.Service;
using PostGreBE.Settings;
using System;
using System.Text;

namespace PostGreBE
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
            services.AddControllers();

            //Configuration from AppSettings
            services.Configure<JWT>(Configuration.GetSection("JWT"));
            //user manager services
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            services.AddScoped<IUserService, UserService>();

            var connectionString = Configuration["ConnectionString"];
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

            //Adding Authentication - JWT
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
              .AddJwtBearer(o =>
              {
                  o.RequireHttpsMetadata = false;
                  o.SaveToken = false;
                  o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters {
                      ValidateIssuerSigningKey = true,
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateLifetime = true,
                      ClockSkew = TimeSpan.Zero,

                      ValidIssuer = Configuration["JWT:Issuer"],
                      ValidAudience = Configuration["JWT:Audience"],
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"]))
                  };
              });

            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddSwaggerGen();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyCorsPolicy", policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test API V1");
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("AllowAnyCorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
