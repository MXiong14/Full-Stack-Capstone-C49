using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using KicksKollector.Repositories;
using Microsoft.IdentityModel.Logging;
using System.IdentityModel.Tokens.Jwt;
using System;

namespace KicksKollector
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

            services.AddTransient<IUserProfileRepository, UserProfileRepository>();
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();

            var firebaseProjectId = Configuration.GetValue<string>("FirebaseProjectId");
            var googleTokenUrl = $"https://securetoken.google.com/{firebaseProjectId}";
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = CreateTokenValidationParameters(googleTokenUrl);
                    //options.TokenValidationParameters = new TokenValidationParameters
                    //{
                    //    ValidateIssuer = false,
                    //    ValidIssuer = googleTokenUrl,
                    //    ValidateAudience = false,
                    //    ValidAudience = firebaseProjectId,
                    //    ValidateLifetime = false,
                    //    ValidateIssuerSigningKey = false,
                    //    RequireSignedTokens = false,
                    //    RequireExpirationTime = false
                    //};
                });

            services.AddControllers();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "KicksKollector", Version = "v1" });

                var securitySchema = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    BearerFormat = "JWT",
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Type = SecuritySchemeType.ApiKey,
                    In = ParameterLocation.Header,
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme,
                    }
                };

                c.AddSecurityDefinition("Bearer", securitySchema);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securitySchema, new[] { "Bearer"} }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "KicksKollector v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public TokenValidationParameters CreateTokenValidationParameters(string google)
        {
            var result = new TokenValidationParameters
            {
                ValidateIssuer = false,
                //ValidIssuer = google,

                ValidateAudience = false,
                //ValidAudience = google,

                ValidateIssuerSigningKey = false,

                //IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey)),
                //comment this and add this line to fool the validation logic
                SignatureValidator = delegate (string token, TokenValidationParameters parameters)
                {
                    var jwt = new JwtSecurityToken(token);

                    return jwt;
                },

                RequireExpirationTime = true,
                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero,
            };

            result.RequireSignedTokens = false;

            return result;
        }
    }
}
