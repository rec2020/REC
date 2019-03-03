using NajmetAlraqee.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace NajmetAlraqee.Data
{
    public class NajmetAlraqeeContext : IdentityDbContext<User>
    {
        public NajmetAlraqeeContext(DbContextOptions<NajmetAlraqeeContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            var cascadeFKs = modelbuilder.Model.GetEntityTypes()
               .SelectMany(t => t.GetForeignKeys())
               .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            modelbuilder.Entity<CustomerType>()
                .HasData(new CustomerType
                {
                    Id = 1,
                    Name = "داخلي",
                },
                new CustomerType
                {
                    Id = 2,
                    Name = "خارجي",
                }
            );

            modelbuilder.Entity<DelegateType>()
                .HasData(new DelegateType
                {
                    Id = 1,
                    Name = "مندوب داخلي ",
                },
                new DelegateType
                {
                    Id = 2,
                    Name = "مندوب خارجي ",
                }
            );
            modelbuilder.Entity<Nationality>()
                .HasData(new Nationality
                {
                    Id = 1,
                    Name = "السعودية"
                },
                new Nationality
                {
                    Id = 2,
                    Name = "مصر",
                }
            );
            modelbuilder.Entity<CurrencyType>()
               .HasData(new CurrencyType
               {
                   Id = 1,
                   Name = "عملة محلية"
               },
               new CurrencyType
               {
                   Id = 2,
                   Name = "عملة أجنبية",
               }
           );
        }

        // Lookups        
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<HospitalType> HospitalTypes { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<ScheduleStatus> ScheduleStatuses { get; set; }
        public DbSet<VacationStatus> VacationStatuses { get; set; }
        public DbSet<VacationType> VacationTypes { get; set; }
        public DbSet<AppointmentStatus> AppointmentStatuses { get; set; }

        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorEducationLevel> DoctorEducationLevels { get; set; }
        public DbSet<DoctorLanguage> DoctorLanguages { get; set; }
        public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
        public DbSet<DoctorScheduleConfiguration> DoctorScheduleConfigurations { get; set; }
        public DbSet<DoctorSpecialty> DoctorSpecialties { get; set; }
        public DbSet<DoctorFeedback> DoctorFeedbacks { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<HospitalOffer> HospitalOffers { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientAppointment> PatientAppointments { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        //public DbSet<User> Users { get; set; }
        public DbSet<DoctorVacation> DoctorVacations { get; set; }



        public DbSet<BankDetail> BankDetails { get; set; }

        public DbSet<JobType> JobTypes { get; set; }

        public DbSet<CustomerType> CustomerTypes { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<UserDelegate> UserDelegates { get; set; }

        public DbSet<DelegateType> DelegateTypes { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<CurrencyType> CurrencyTypes { get; set; }

        public DbSet<Arrival> Arrivals { get; set; }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<ForeignAgency> ForeignAgencies { get; set; }

        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        public DbSet<Partner> Partners { get; set; }

    }
}
