using Application.Interfaces.Contexts;
using Domain.Interfaces;
using Domain.Interfaces.Base;
using Infrastructure.DatabaseContext;
using Infrastructure.Identity.Models;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Base;
using Infrastructure.UnitOfWorks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region DB Context
            services.AddDbContext<IdentityContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("IdentityConnection"),
                    b=>b.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName)));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DataConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            //https://codewithmukesh.com/blog/jquery-datatable-in-aspnet-core/
            //https://alexcodetuts.com/2020/02/05/asp-net-core-3-1-clean-architecture-invoice-management-app-part-1/
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        configuration.GetConnectionString("DefaultConnection"),
            //        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));


            #endregion            

            #region Identity
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<IdentityContext>();
            //services.AddIdentityServer()
            //    .AddApiAuthorization<ApplicationUser, IdentityContext>();            

            //https://alexcodetuts.com/2020/02/05/asp-net-core-3-1-clean-architecture-invoice-management-app-part-1/
            //Microsoft.AspNetCore.ApiAuthorization.IdentityServer
            //services.AddIdentityServer()
            //    .AddApiAuthorization<ApplicationUser, IdentityContext>();
            #endregion


            #region Register Service 
            //Normally any Service Will have interface in the Inner layer and Implementation in Outer Layer
            #region Interface from Application Layer and Implemented in Infrastructure Layer
                services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            #endregion

            #region Service from Domain Layer and Implemented in Infrastructure Layer
                services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
                services.AddTransient<IDeveloperRepository, DeveloperRepository>();
                services.AddTransient<IProjectRepository, ProjectRepository>();
                services.AddScoped<IBookRepository, BookRepository>();
                services.AddTransient<IMovieRepository, MovieRepository>();
                services.AddTransient<IEmployeeRepository, EmployeeRepository>();
                services.AddScoped<IGadgetLogic, GadgetLogic>();
            #endregion

            #endregion

            #region UnitofWork

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            #endregion
            return services;
        }
    }
}
