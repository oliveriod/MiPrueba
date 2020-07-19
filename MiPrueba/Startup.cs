using AutoMapper;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System.Globalization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using System.Security.Claims;
using Microsoft.Extensions.Logging;


using ByblosMiPH.API.Domain.Repositories;
using ByblosMiPH.API.Domain.Services;
using ByblosMiPH.API.Persistence.Contexts;
using ByblosMiPH.API.Persistence.Repositories;
using ByblosMiPH.API.Services;

using MiPrueba.API.Domain.Models;


namespace MiPrueba.API
{
	public class Startup
	{
		public IConfiguration Configuration { get; }



		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}




		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{


			services.AddCors();	// esto se requiere con MariaDB

			var ParámetrosParaBitácora = Configuration.GetSection("ParámetrosParaBitácora").Get<ParámetrosParaBitácora>();


            services.AddDbContext<MiPruebaDbContext>(item => item.UseMySql(Configuration.GetConnectionString("MiPruebaConn")
			, mySqlOptionsAction : mySqlOptions => 
			{
                mySqlOptions.EnableRetryOnFailure(
                maxRetryCount: 2,
                maxRetryDelay: TimeSpan.FromSeconds(10),
                errorNumbersToAdd: null);
            }
			 ));


			services.AddLocalization(opts => { opts.ResourcesPath = "Resources"; });

			services.Configure<ParámetrosParaAutenticar>(Configuration.GetSection("ParametrosParaAutenticar"));

			var ParámetrosParaAutenticar = Configuration.GetSection("ParametrosParaAutenticar").Get<ParámetrosParaAutenticar>();

			if (ParámetrosParaAutenticar.MiLlaveParaLogin == null)
			{

				return;
			}
  

			var supportedCultures = new[]
			{
				new CultureInfo("es-PA")
			};
			
			services.Configure<RequestLocalizationOptions>(s =>
		   {
				// Formatting numbers, dates, etc.
				s.SupportedCultures = supportedCultures;
				// UI strings that we have localized.
				s.SupportedUICultures = supportedCultures;
			   s.DefaultRequestCulture = new RequestCulture("es-PA");
		   });



			services.AddControllers()
				.AddViewLocalization(
					LanguageViewLocationExpanderFormat.SubFolder,
					opts => { opts.ResourcesPath = "Resources"; })
				.AddDataAnnotationsLocalization();

			services.AddAutoMapper(typeof(Startup));


            services.AddScoped<IBancoRepository, BancoRepository>();
            services.AddScoped<IBancoService, BancoService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>(); //Se requiere

		}



		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			{
				if (app == null)
				{
					return;
				}

				if (env.IsDevelopment())
				{
					app.UseDeveloperExceptionPage();
				}
				else
				{
					app.UseExceptionHandler("/Home/Error");
				}



				app.UseStaticFiles();

				// Using localization 
				var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
				app.UseRequestLocalization(locOptions.Value);



				//			app.UseHttpsRedirection();
				app.UseRouting();



//	ODI20200716				app.UseAuthentication();
//	ODI20200716				app.UseAuthorization();




				app.UseEndpoints(endpoints =>
				{
					endpoints.MapControllers();
				});




			}
		}
	}
}
