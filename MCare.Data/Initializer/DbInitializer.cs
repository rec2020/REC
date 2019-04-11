using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AutoMapper.Configuration;
using static NajmetAlraqee.Data.Initializer.IdentityInitializing;

namespace NajmetAlraqee.Data.Initializer
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider, NajmetAlraqeeContext _context)
        {
            //if (!_context.Countries.Any())
            //{
            //    _context.Countries.AddRange(LookupsInitializer.GetCountries());
            //    _context.SaveChanges();
            //}

            if (!_context.Cities.Any())
            {
                _context.Cities.AddRange(LookupsInitializer.GetCities());
                _context.SaveChanges();
            }

            if (!_context.EducationLevels.Any())
            {
                _context.EducationLevels.AddRange(LookupsInitializer.GetEducationLevels());
                _context.SaveChanges();
            }

            if (!_context.Genders.Any())
            {
                _context.Genders.AddRange(LookupsInitializer.GetGenders());
                _context.SaveChanges();
            }

           

            //if (!_context.Nationalities.Any())
            //{
            //    _context.Nationalities.AddRange(LookupsInitializer.GetNationalties());
            //    _context.SaveChanges();
            //}

          

            IdentityInitializing.AddUser(serviceProvider,
                "root@hotmail.com", "NajmetAlraqee@2018", "Administrator", "0568356825", ROLES.Root.ToString());

            IdentityInitializing.AddUser(serviceProvider,
                "hadmin@gmail.com", "NajmetAlraqee@2018", "Hospital Owner", "0568356825", ROLES.Administrator.ToString());

            //DummyData();
        }

        private static void DummyData(IServiceProvider serviceProvider, NajmetAlraqeeContext _context)
        {
            //if (!_context.Hospitals.Any())
            //{
            //    var hospitals = LookupsInitializer.GetHospitals();
            //    _context.Hospitals.AddRange(hospitals);
            //    _context.SaveChanges();
            //}

            //if (!_context.HospitalOffers.Any())
            //{
            //    var offers = LookupsInitializer.GetOffers();
            //    _context.HospitalOffers.AddRange(offers);
            //    _context.SaveChanges();
            //}

            //DoctorInitializer.GenerateDoctorUsers(serviceProvider, _context);
        }
    }
}
