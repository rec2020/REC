using Bogus;
using NajmetAlraqee.Data.Constants;
using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using static NajmetAlraqee.Data.Initializer.IdentityInitializing;

namespace NajmetAlraqee.Data.Initializer
{
    public class DoctorInitializer
    {
        public static void GenerateDoctorUsers(IServiceProvider serviceProvider, NajmetAlraqeeContext _context)
        {
            if (!_context.Doctors.Any())
            {                
                for (int i = 1; i < 1000; i++)
                {
                    try
                    {
                        DoctorUser doctor = GetTempDoctor();

                        User user = IdentityInitializing.AddUser(serviceProvider,
                            doctor.Email, doctor.Password, doctor.ArabicName, doctor.Mobile,
                            ROLES.Doctor.ToString());

                        if (user != null)
                        {
                            doctor.Id = user.Id;

                            Doctor realDoctor = GetDoctor(doctor);

                            _context.Doctors.Add(realDoctor);

                            _context.SaveChanges();
                        }
                    }
                    catch(Exception e)
                    {
                        Debug.WriteLine(e.InnerException);
                    }
                }
            }
        }

        private static Doctor GetDoctor(DoctorUser doctorUser)
        {
            return new Doctor()
            {
                ArabicName = doctorUser.ArabicName,
                ArabicBio = doctorUser.ArabicBio,
                HospitalId = doctorUser.HospitalId,
                NationalityId = doctorUser.NationalityId,
                GenderId = doctorUser.GenderId,
                UserId = doctorUser.Id,
                ImagePath = doctorUser.ImagePath,
                BirthDate = doctorUser.BirthDate,
                Experience = doctorUser.Experience,
                EnglishBio = doctorUser.EnglishBio,
                EnglishName = doctorUser.EnglishName,
                PhoneExtension = doctorUser.Extension,
                PhoneNo = doctorUser.PhoneNumber,
                Rate = doctorUser.Rate,
                MobileNo = doctorUser.Mobile,
                DoctorEducationLevels = doctorUser.DoctorEducationLevels,
                DoctorLanguages = doctorUser.DoctorLanguages,
                DoctorSpecialtys = doctorUser.DoctorSpecialtys,
                DoctorSchedules = GetOnYearScedule(1),
                EnglishCVPath = "",
                ArabicCVPath = "",
                IdentityNo = "",
            };
        }

        private static DoctorUser GetTempDoctor()
        {
            var fakeLanguages = new Faker<DoctorLanguage>()                
                .RuleFor(t => t.LanguageId, f => f.Random.Number(1, 3));

            var fakeSpecality = new Faker<DoctorSpecialty>()
                .RuleFor(t => t.SpecialtyId, f => f.Random.Number(1, 10));

            var fakeEducation = new Faker<DoctorEducationLevel>()
                .RuleFor(t => t.EducationLevelId, f => f.Random.Number(1, 8));

            DoctorUser doctor = new Faker<DoctorUser>()
                .RuleFor(u => u.ArabicName, f => f.Name.FullName())
                .RuleFor(u => u.EnglishName, f => f.Name.FullName())
                .RuleFor(u => u.ArabicBio, f => f.Lorem.Sentence(15))
                .RuleFor(u => u.EnglishBio, f => f.Lorem.Sentence(15))
                .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.ArabicName))
                .RuleFor(u => u.ImagePath, f => f.Internet.Avatar())
                .RuleFor(u => u.Password, f => "P@ssw0rd")
                .RuleFor(u => u.Mobile, f => f.Phone.PhoneNumber())
                .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(u => u.Extension, f => f.Phone.PhoneNumber())
                .RuleFor(bp => bp.BirthDate, f => f.Date.Past(65))
                .RuleFor(bp => bp.Experience, f => f.Date.Past(15))
                .RuleFor(o => o.HospitalId, f => f.Random.Number(1, 199))
                .RuleFor(o => o.GenderId, f => f.Random.Number(1, 2))
                .RuleFor(o => o.Rate, f => f.Random.Number(1, 5))
                .RuleFor(o => o.NationalityId, f => f.Random.Number(1, 50))
                .RuleFor(o => o.DoctorSpecialtys, f => fakeSpecality.Generate(2))
                .RuleFor(o => o.DoctorEducationLevels, f => fakeEducation.Generate(3))               
                .RuleFor(o => o.DoctorLanguages, f => fakeLanguages.Generate(2))
                
            .FinishWith((f, bp) => Console.WriteLine($"User created. Name={bp.ArabicName}"));

            return doctor;
        }      

        public class DoctorUser
        {
            public string ArabicName { get; set; }
            public string EnglishName { get; set; }
            public string ArabicBio { get; set; }
            public string EnglishBio { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Mobile { get; set; }

            // Randomlly
            public long HospitalId { get; set; }
            public long GenderId { get; set; }
            public long NationalityId { get; set; }
            public List<DoctorSpecialty> DoctorSpecialtys { get; set; }
            public List<DoctorEducationLevel> DoctorEducationLevels { get; set; }
            public List<DoctorLanguage> DoctorLanguages { get; set; }
            public decimal Rate { get; set; }
            public string PhoneNumber { get; set; }
            public string Extension { get; set; }
            public string ImagePath { get; set; }
            public DateTime BirthDate { get; set; }
            public DateTime Experience { get; set; }

            public string Id { get; set; }
        }

        private static List<DoctorSchedule> GetOnYearScedule(int hospitalId)
        {
            DateTime now = DateTime.UtcNow;

            Array values = Enum.GetValues(typeof(ScheduleStatusEnum));
            Random random = new Random();


            List<DoctorSchedule> doctorSchedules = new List<DoctorSchedule>();
            for (int i = 0; i < 100; i++)
            {
                DateTime dayAfter = now.AddDays(i);
                List<string> timing = GetTiming(dayAfter);
                foreach (var time in timing)
                {
                    var schedule = new DoctorSchedule()
                    {
                        HospitalId = hospitalId,
                        Time = time,
                        CreatedOn = DateTime.UtcNow,
                        ScheduleStatusId = ((int)((ScheduleStatusEnum)values.GetValue(random.Next(values.Length)))),
                        Date = dayAfter
                    };

                    doctorSchedules.Add(schedule);
                }
            }

            return doctorSchedules;
        }

        private static List<string> GetTiming(DateTime day)
        {
            List<string> times = new List<string>();
            DateTime date = new DateTime(day.Year, day.Month, day.Day, 8, 0, 0);
            while (date.Hour < 20)
            {
                if (date.Hour > 12 && date.Hour < 3)
                {
                    date = date.AddMinutes(30);
                    continue;
                }

                times.Add(date.ToString("HH:mm tt"));
                date = date.AddMinutes(30);
            }

            return times;
        }
    }
}
