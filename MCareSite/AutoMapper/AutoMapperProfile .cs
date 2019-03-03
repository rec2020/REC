using AutoMapper;
using NajmetAlraqee.Data.Entities;
using NajmetAlraqee.Site.ViewModels;
using NajmetAlraqeeSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqeeSite.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // city
            CreateMap<CityViewModel, City>();
            CreateMap<City, CityViewModel>();


            // Country 
            CreateMap<CountryViewModel, Country>();
            CreateMap<Country, CountryViewModel>();
            // Doctor
            CreateMap<Doctor, DoctorViewModel>();
            CreateMap<DoctorViewModel, Doctor>();
            //CreateMap<DoctorViewModel, Doctor>()
            //    .ForPath(dest => dest.Gender.ArabicName, src => src.MapFrom(y => y.GenderName))
            //    .ForPath(dest => dest.Hospital.EnglishName, src => src.MapFrom(y => y.HospitalName));

            CreateMap<HospitalViewModel, Hospital>();
            CreateMap<Hospital, HospitalViewModel>();

            CreateMap<HospitalOfferViewModel, HospitalOffer>();
            CreateMap<HospitalOffer, HospitalOfferViewModel>();

            CreateMap<DoctorScheduleConfigurationViewModels, DoctorScheduleConfiguration>();
            CreateMap<DoctorScheduleConfiguration, DoctorScheduleConfigurationViewModels>();


            CreateMap<DoctorVacationViewModel, DoctorVacation>();
            CreateMap<DoctorVacation, DoctorVacationViewModel>();


            CreateMap<PatientAppointmentViewModel, PatientAppointment>();
            CreateMap<PatientAppointment, PatientAppointmentViewModel>();

            CreateMap<NationalityViewModel, Nationality>();
            CreateMap<Nationality, NationalityViewModel>();

            CreateMap<JobTypeViewModels, JobType>();
            CreateMap<JobType, JobTypeViewModels>();


            CreateMap<BankDetailViewModels, BankDetail>();
            CreateMap<BankDetail, BankDetailViewModels>();

            CreateMap<UserDelegate, DelegateViewModel>();
            CreateMap<DelegateViewModel, UserDelegate>();

            CreateMap<Customer, CustomerViewModel>();
            CreateMap<CustomerViewModel, Customer>();

            CreateMap<Currency, CurrencyViewModel>();
            CreateMap<CurrencyViewModel, Currency>();


            CreateMap<Arrival, ArrivalViewModel>();
            CreateMap<ArrivalViewModel, Arrival>();

            CreateMap<Expense, ExpenseViewModel>();
            CreateMap<ExpenseViewModel, Expense>();


            CreateMap<ForeignAgency, ForeignAgencyViewModel>();
            CreateMap<ForeignAgencyViewModel, ForeignAgency>();

            CreateMap<PaymentMethod, PaymentMethodViewModel>();
            CreateMap<PaymentMethodViewModel, PaymentMethod>();

            CreateMap<Partner, PartnerViewModel>();
            CreateMap<PartnerViewModel, Partner>();


            //  CreateMap<ForeignAgency, ForeignAgencyViewModel>()
            // .ForMember(d => d.BankName, o => o.MapFrom(s => s.BankDetail.Name))
            // .ForMember(d => d.BankAccountNo, o => o.MapFrom(s => s.BankDetail.AccountNumber))
            // .ForAllMembers(o => o.Condition((src, dest, value) => value != null));

            //  CreateMap<ForeignAgency, ForeignAgencyViewModel>()
            // .ForMember(d => d.CurrencyName, o => o.MapFrom(s => s.Currency.Name))
            // .ForAllMembers(o => o.Condition((src, dest, value) => value != null));

            // CreateMap<ForeignAgency, ForeignAgencyViewModel>()
            //.ForMember(d => d.JobTypeName, o => o.MapFrom(s => s.JobType.Name))
            //.ForAllMembers(o => o.Condition((src, dest, value) => value != null));

            // CreateMap<ForeignAgency, ForeignAgencyViewModel>()
            //.ForMember(d => d.NationalityName, o => o.MapFrom(s => s.Nationality.Name))
            //.ForAllMembers(o => o.Condition((src, dest, value) => value != null));
        }
    }
}
