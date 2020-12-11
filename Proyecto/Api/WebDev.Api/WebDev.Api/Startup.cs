using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;
using WebDev.Api.Context;

namespace WebDev.Api
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
      services.AddAuthentication(x => 
        {
          x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
          x.DefaultChallengeScheme= JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
          options.RequireHttpsMetadata = true;
          options.SaveToken = true;
          options.TokenValidationParameters = new TokenValidationParameters()
          {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = Configuration["JWT:Issuer"],
            ValidAudience = Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:SecretKey"]))
          };
        });

      services.AddCors();
      services.AddControllers();
      services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CnnStr")));
      services.AddSwaggerGen(s => 
      {
        s.SwaggerDoc("v1", new OpenApiInfo { Title = "WebDev API", Version = "v1" });
        s.AddSecurityDefinition("Bearer",
          new OpenApiSecurityScheme
          {
            Scheme= "Bearer",
            In = ParameterLocation.Header,
            Description = "Please enter into field the word 'Bearer' following by space and JWT",
            Name = "Authorization",
            Type =  SecuritySchemeType.ApiKey
          });
        s.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
          {
            new OpenApiSecurityScheme
            {
              Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              }
            },
            Array.Empty<string>()
            }
          });
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseCors(options =>
      {
        options.WithOrigins("http://localhost:3000");
        options.AllowAnyMethod();
        options.AllowAnyHeader();
      });

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();
      app.UseAuthentication();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });

      // Enable middleware to serve generated Swagger as a JSON endpoint.
      app.UseSwagger();

      // Enable middleware to serve swagger-ui (HTML. JS, CSS, etc.),
      // specifying the Swagger JSON endpoint
      app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "Users API"));

      // Add the Authentication to Enable the JWT Service
      app.UseAuthentication();
    }
  }
}