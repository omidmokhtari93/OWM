﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using OWM.Application.Services.Interfaces;
using OWM.Domain.Entities;
using OWM.Domain.Services;
using OWM.Domain.Services.Interfaces;
using URF.Core.Abstractions;
using URF.Core.Abstractions.Trackable;
using URF.Core.EF;
using URF.Core.EF.Trackable;

namespace OWM.Application.Services.AppConfigs
{
    public static class AppStartupConfigs
    {
        public static void AddApplicationConfigs(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ITrackableRepository<City>, TrackableRepository<City>>();
            services.AddScoped<ITrackableRepository<Country>, TrackableRepository<Country>>();
            services.AddScoped<ITrackableRepository<Ethnicity>, TrackableRepository<Ethnicity>>();
            services.AddScoped<ITrackableRepository<Occupation>, TrackableRepository<Occupation>>();
            services.AddScoped<ITrackableRepository<User>, TrackableRepository<User>>();
            services.AddScoped<ITrackableRepository<UserIdentity>, TrackableRepository<UserIdentity>>();

            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IEthnicityService, EthnicityService>();
            services.AddScoped<IOccupationService, OccupationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserIdentityService, UserIdentityService>();

            services.AddScoped<IUserRegistrationService, UserRegistrationService>();
        }
    }
}
