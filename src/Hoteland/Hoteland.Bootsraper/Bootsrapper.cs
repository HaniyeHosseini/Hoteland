using Hoteland.Application.Contract.FeatureAgg;
using Hoteland.Application.Contract.Place;
using Hoteland.Application.FeatureAgg;
using Hoteland.Application.PlaceAgg;
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
            services.AddTransient<IPlaceRepository, PlaceRepository>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IHotelRepository , HotelRepository>();
            services.AddDbContext<HotelandContext>(x => x.UseSqlServer(connectionString,x=> x.UseNetTopologySuite()));
        }
    }
}