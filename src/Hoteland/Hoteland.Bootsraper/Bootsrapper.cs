using Hoteland.Application.Contract.Feature;
using Hoteland.Application.FeatureAgg;
using Hoteland.Common;
using Hoteland.Domain.Base;
using Hoteland.Infrastructure;
using Hoteland.Infrastructure.Repository.Implements;
using Hoteland.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Hoteland.Bootsrapper
{
    public static class Bootsrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IFeatureRepository, FeatureRepository>();
            services.AddTransient<IFeatureServices, FeatureServices>();

            services.AddDbContext<HotelandContext>(x => x.UseSqlServer(connectionString));
        }
    }
}