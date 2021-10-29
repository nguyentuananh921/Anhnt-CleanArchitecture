using Application.Common.Behaviours;
using Application.Interfaces;
using Application.Interfaces.Contexts;
using Application.Services;
using FluentValidation;
using MediatR;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Extensions
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            #region Service in Application Layer
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IMovieService, MovieService>();
            #endregion

            #region MediatR Registration
            //Required Package MediatR.Extensions.Microsoft.DependencyInjection
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            #endregion

            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
