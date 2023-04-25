using ERP_WCI_API.Helpers;
using ERP_WCI_Business.Common;
using ERP_WCI_Business.Common.Interfaces;
using ERP_WCI_Business.Companies;
using ERP_WCI_Business.Companies.Interfaces;
using ERP_WCI_Business.General;
using ERP_WCI_Business.General.Interfaces;
using ERP_WCI_Business.Identity;
using ERP_WCI_Business.Identity.Interfaces;
using ERP_WCI_Business.Planetun;
using ERP_WCI_Business.Planetun.Interfaces;
using ERP_WCI_Context;
using ERP_WCI_Model.General;
using ERP_WCI_Model.Identity;
using ERP_WCI_Repository.Common;
using ERP_WCI_Repository.Common.Interfaces;
using ERP_WCI_Repository.Companies;
using ERP_WCI_Repository.Companies.Interfaces;
using ERP_WCI_Repository.Identity;
using ERP_WCI_Repository.Identity.Interfaces;
using ERP_WCI_Repository.Planetun;
using ERP_WCI_Repository.Planetun.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

namespace ERP_WCI_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken token, TokenValidationParameters @params)
        {
            if (expires != null)
            {
                return expires > DateTime.UtcNow;
            }
            return false;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
           

            services.Configure<Settings>(options => Configuration.GetSection("Settings").Bind(options));

            #region .: MySQL
            //var connection = Configuration["ConexaoMySql:ConnectionString"];

            //services.AddDbContext<Context>(options =>
            //    options.UseMySql(connection)
            //);
            #endregion

            #region .: SQL
            var connection = Configuration["ConexaoSql:ConnectionString"];

            services.AddDbContext<Context>(options =>
                options.UseSqlServer(connection)
            );
            #endregion


            services.AddIdentity<User, IdentityRole>()
               .AddEntityFrameworkStores<Context>()
               .AddDefaultTokenProviders();

            var key = Encoding.ASCII.GetBytes(Configuration["Settings:Secret"]);

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwtBearerOptions =>
            {
                jwtBearerOptions.RequireHttpsMetadata = false;
                jwtBearerOptions.SaveToken = true;
                jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    LifetimeValidator = LifetimeValidator,
                    ValidateAudience = false
                };
            });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });         


            services.AddScoped<ICustomAuthorizeAttribute, CustomAuthorizeAttribute>();

            services.AddScoped<IBUser, BUser>();
            services.AddScoped<IBWciClaim, BWciClaim>();
            services.AddScoped<IBCity, BCity>();
            services.AddScoped<IBState, BState>();
            services.AddScoped<IBAccount, BAccount>();
            services.AddScoped<IBCompany, BCompany>();
            services.AddScoped<IBPersonalInformation, BPersonalInformation>();

            services.AddScoped<IBInspection, BInspection>();

            services.AddScoped<IRWciClaim, RWciClaim>();
            services.AddScoped<IRProfile_x_Claim, RProfile_x_Claim>();
            services.AddScoped<IRAccount, RAccount>();
            services.AddScoped<IRAddress, RAddress>();
            services.AddScoped<IRCity, RCity>();            
            services.AddScoped<IRPersonalInformation, RPersonalInformation>();
            services.AddScoped<IRPhoneNumberPersonalInformation, RPhoneNumberPersonalInformation>();
            services.AddScoped<IRState, RState>();
            services.AddScoped<IRCompany, RCompany>();
            services.AddScoped<IRCompanyConfigNfe, RCompanyConfigNfe>();
            services.AddScoped<IRPhoneNumberCompany, RPhoneNumberCompany>();

            services.AddScoped<IRInspection, RInspection>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "API NFe - WCI",
                        Version = "v1",
                        Description = "API NFe - WCI criada com o ASP.NET Core",
                        Contact = new OpenApiContact
                        {
                            Name = "Samuel Apolion Benevenuto"
                        }
                    });
            });

            services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);  
            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            Context context,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<IdentityRole> roleManager)
        {

            new IdentityInitializer(context, userManager, signInManager, roleManager).Initialize();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder
             .AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "API NFe - WCI");
            });
        }
    }
}
