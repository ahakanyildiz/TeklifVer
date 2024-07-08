using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Contexts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TeklifVer.Business.Abstract;
using TeklifVer.Business.Concrete;
using TeklifVer.Business.Mappings.Profiles;
using TeklifVer.DataAccess.Abstract;
using TeklifVer.DataAccess.Concrete;

namespace TeklifVer.Business.DependencyResolvers
{
    public static class DependencyExtension
    {
        public static void MappingDependencies(this IServiceCollection services)
        {
            var configuration = new MapperConfiguration(opt =>
        {
            opt.AddProfile(new CarBrandProfile());
            opt.AddProfile(new CarModelProfile());
            opt.AddProfile(new CarProfile());
            opt.AddProfile(new MemberProfile());
        });

            var mapper = configuration.CreateMapper();

            services.AddSingleton(mapper);
        }

        public static void AddIOC(this IServiceCollection services, string connectionString)
        {
            #region Dependency Injection
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IModelService, ModelService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IAdvertisingService, AdvertisingService>();
            services.AddDbContext<CarContext>(
                options =>
            options.UseSqlServer(connectionString)
            );
            //services.AddDbContext<CarContext>();
            #endregion


            #region Authentication
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
       .AddCookie(options =>
       {
           options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
           options.SlidingExpiration = true;
           options.AccessDeniedPath = "/Forbidden/";
           options.LoginPath = "/login";
       });
            #endregion
        }
    }
}
