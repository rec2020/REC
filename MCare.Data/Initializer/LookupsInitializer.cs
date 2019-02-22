using Bogus;
using NajmetAlraqee.Data.Constants;
using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NajmetAlraqee.Data.Initializer
{
    public class LookupsInitializer
    {
        public static List<Country> GetCountries()
        {
            List<Country> _items = new List<Country>
            {
                new Country() {ArabicName = "المملكة العربية السعودية", EnglishName = "Saudi Arabia"},
            };

            return _items;
        }

        public static List<City> GetCities()
        {
            List<City> _items = new List<City>
            {
                new City() {ArabicName = "الرياض", EnglishName = "Riyadh", CountryId = 1},
                new City() {ArabicName = "جده", EnglishName = "Jeddah", CountryId = 1},
                new City() {ArabicName = "مكة", EnglishName = "Makkah", CountryId = 1},
                new City() {ArabicName = "الدمام", EnglishName = "Dammam", CountryId = 1},
                new City() {ArabicName = "القصيم", EnglishName = "Qaseem", CountryId = 1},
            };

            return _items;
        }

        public static List<Gender> GetGenders()
        {
            List<Gender> _items = new List<Gender>
            {
                new Gender() {ArabicName = "ذكر", EnglishName = "Male"},
                new Gender() {ArabicName = "أنثى", EnglishName = "Female"},
            };

            return _items;
        }

        public static List<EducationLevel> GetEducationLevels()
        {
            List<EducationLevel> _items = new List<EducationLevel>
            {
                new EducationLevel() {ArabicName = "طالب", EnglishName = "Student"},
                new EducationLevel() {ArabicName = "طبيب امتياز", EnglishName = "Excellent doctor"},
                new EducationLevel() {ArabicName = "طبيب مقيم", EnglishName = "Resident doctor"},
                new EducationLevel() {ArabicName = "اخصائي", EnglishName = "Specialist"},
                new EducationLevel() {ArabicName = "اخصائي اول", EnglishName = "Senior specialist"},
                new EducationLevel() {ArabicName = "استشاري", EnglishName = "Advisory"},
                new EducationLevel() {ArabicName = "استشاري اول", EnglishName = "First Consultant"},
                new EducationLevel() {ArabicName = "بروفيسور مساعد", EnglishName = "Assistant Professor"},
                new EducationLevel() {ArabicName = "بروفيسور مشارك", EnglishName = "Associate Professor"},
                new EducationLevel() {ArabicName = "بروفيسور", EnglishName = "Proffessor"},
            };

            return _items;
        }

        public static List<VacationType> GetVacationTypes()
        {
            List<VacationType> _items = new List<VacationType>
            {
                new VacationType() {ArabicName = "سنوية", EnglishName = "Annual"},
                new VacationType() {ArabicName = "اضرارية", EnglishName = "Urgent"},
                new VacationType() {ArabicName = "رسمية", EnglishName = "Offical"},
            };

            return _items;
        }

        public static List<VacationStatus> GetVacationStatus()
        {
            List<VacationStatus> _items = new List<VacationStatus>
            {
                new VacationStatus() {ArabicName = "اتنظار", EnglishName = "Pending"},
                new VacationStatus() {ArabicName = "موافق", EnglishName = "Accepted"},
                new VacationStatus() {ArabicName = "مرفوض", EnglishName = "Rejected"},
            };

            return _items;
        }

        public static IEnumerable<HospitalOffer> GetOffers()
        {
            var hospitalOffer = new Faker<HospitalOffer>()
               .RuleFor(o => o.HospitalId, f => f.Random.Number(1, 199))
               .RuleFor(u => u.ArabicTitle, f => f.Name.FullName())
               .RuleFor(u => u.EnglishTitle, f => f.Name.FullName())             
               .RuleFor(u => u.ArabicBody, f => f.Lorem.Paragraph())
               .RuleFor(u => u.EnglishBody, f => f.Lorem.Paragraph())
               .RuleFor(u => u.ArabicImagePath, f => f.Image.Business())
               .RuleFor(u => u.EnglishImagePath, f => f.Image.Business())
               .RuleFor(o => o.CreatedOn, f => f.Date.Past())
               .RuleFor(o => o.HappendOn, f => f.Date.Future())
               .RuleFor(o => o.EndOn, f => f.Date.Future())    
               .Generate(100);

            return hospitalOffer;
        }

        public static List<HospitalType> GetHospitalTypes()
        {
            List<HospitalType> _items = new List<HospitalType>
            {
                new HospitalType() {ArabicName = "مستشفى", EnglishName = "Hospital"},
                new HospitalType() {ArabicName = "مستوصف", EnglishName = "Medical Center"},
                new HospitalType() {ArabicName = "مركز الطبي", EnglishName = "Clinic"},
                new HospitalType() {ArabicName = "مدينة طبية", EnglishName = "Medical City"},
            };

            return _items;
        }
        
        public static List<Specialty> GetSpecialties()
        {
            var images = new Faker<Specialty>()
             .RuleFor(u => u.ImagePath, f => f.Image.Business())
             .Generate(20);

            List<Specialty> _items = new List<Specialty>
            {
                new Specialty() {ArabicName = "باطنية", EnglishName = "Internist", ImagePath = images[0].ImagePath},
                new Specialty() {ArabicName = "قلب", EnglishName = "cardiologist", ImagePath = images[1].ImagePath},
                new Specialty() {ArabicName = "الغدد", EnglishName = "Endocrinologist", ImagePath = images[2].ImagePath},
                new Specialty() {ArabicName = "نساء وولادة", EnglishName = "Gynaecologist", ImagePath = images[3].ImagePath},
                new Specialty() {ArabicName = "عيون", EnglishName = "Ophthalmologist", ImagePath = images[4].ImagePath},
                new Specialty() {ArabicName = "أعصاب", EnglishName = "Neurologist", ImagePath = images[5].ImagePath},
                new Specialty() {ArabicName = "انف واذن وحنجرة", EnglishName = "ENT", ImagePath = images[6].ImagePath},
                new Specialty() {ArabicName = "مسالك بولية", EnglishName = "Urologist", ImagePath = images[7].ImagePath},
                new Specialty() {ArabicName = "جلدية", EnglishName = "Dermatologist", ImagePath = images[8].ImagePath},
                new Specialty() {ArabicName = "الكبد", EnglishName = "Hepatologist", ImagePath = images[9].ImagePath},
                new Specialty() {ArabicName = "نفسي", EnglishName = "Psychologist", ImagePath = images[10].ImagePath},
                new Specialty() {ArabicName = "تخدير", EnglishName = "Anesthesiologist", ImagePath = images[11].ImagePath},
            };

            return _items;
        }

        public static List<AppointmentStatus> GetAppointmentStatus()
        {
            List<AppointmentStatus> _items = new List<AppointmentStatus>
            {
                new AppointmentStatus() {ArabicName = "انتظار", EnglishName = "Pending"},
                new AppointmentStatus() {ArabicName = "مأكد", EnglishName = "Confirmed"},
                new AppointmentStatus() {ArabicName = "ملغى", EnglishName = "Cancled"},
                new AppointmentStatus() {ArabicName = "منتهى", EnglishName = "Completed"},
            };

            return _items;
        }

        public static List<ScheduleStatus> GetScheduleStatus()
        {
            List<ScheduleStatus> _items = new List<ScheduleStatus>
            {
                new ScheduleStatus() {ArabicName = "متاح", EnglishName = "Free"},
                new ScheduleStatus() {ArabicName = "محجوز", EnglishName = "Booked"},
                new ScheduleStatus() {ArabicName = "اجازة", EnglishName = "Vacation"},
                new ScheduleStatus() {ArabicName = "غير متاح", EnglishName = "Not Allowed"},
            };

            return _items;
        }

        public static List<Language> GetLanguages()
        {
            List<Language> _items = new List<Language>
            {
                new Language() {ArabicName = "عربي", EnglishName = "Arabic"},
                new Language() {ArabicName = "انجليزي", EnglishName = "English"},
                new Language() {ArabicName = "اردو", EnglishName = "Urdo"},
            };

            return _items;
        }

        public static IEnumerable<Hospital> GetHospitals()
        {            
            var hospitals = new Faker<Hospital>()
               .RuleFor(u => u.ArabicName, f => f.Name.FullName())
               .RuleFor(u => u.EnglishName, f => f.Name.FullName())
               .RuleFor(u => u.ArabicAddress, f => f.Address.FullAddress())
               .RuleFor(u => u.EnglishAddress, f => f.Address.FullAddress())
               .RuleFor(u => u.ArabicDescription, f => f.Lorem.Paragraph())
               .RuleFor(u => u.EnglishDescription, f => f.Lorem.Paragraph())
               .RuleFor(u => u.ImagePath, f => f.Image.Business())
               .RuleFor(u => u.LogoPath, f => f.Internet.Avatar())
               .RuleFor(o => o.HospitalTypeId, f => f.Random.Number(1, 3))
               .RuleFor(o => o.CityId, f => f.Random.Number(1, 5))
               .RuleFor(o => o.CountryId, f => f.Random.Number(1, 1))
               .RuleFor(u => u.MapLocation, (f, u) => f.Address.Latitude() + "," + f.Address.Longitude())
               .RuleFor(u => u.Latitude, (f, u) => f.Address.Latitude())
               .RuleFor(u => u.Longitude, (f, u) => f.Address.Longitude())
               .RuleFor(u => u.Phone1, f => f.Phone.PhoneNumber())
               .RuleFor(u => u.Phone1, f => f.Phone.PhoneNumber())
               .Generate(200);

            return hospitals;
        }

        //public static List<Nationality> GetNationalties()
        //{
        //    var _service = new NationalityService();

        //    _service.Add("سعودي");
        //    _service.Add("سوداني");
        //    _service.Add("مصري", "Egyptian");
        //    _service.Add("سوري", "Syrian");
        //    _service.Add("عراقي", "Iraqi");
        //    _service.Add("اردني", "Jordanian");
        //    _service.Add("كويتي", "Kuwaiti");
        //    _service.Add("لبناني", "Lebanese");
        //    _service.Add("ليبي", "Libyan");
        //    _service.Add("مغربي", "Moroccan");
        //    _service.Add("عماني", "Omani");
        //    _service.Add("بحرينى", "Bahraini");
        //    _service.Add("فلسطيني", "Palestinian");
        //    _service.Add("صومالي", "Somali");
        //    _service.Add("تونسي", "Tunisian");
        //    _service.Add("تركي", "Turkish");
        //    _service.Add("اماراتي", "Emirati");
        //    _service.Add("يمني", "Yemeni");
        //    _service.Add("قطري", "Qatari");
        //    _service.Add("جزائرى", "Algerian");
        //    _service.Add("بنجلاديشى", "Bangladeshi");
        //    _service.Add("ايراني", "Iranian");
        //    _service.Add("اندونيسي", "Indonesian");
        //    _service.Add("باكستاني", "Pakistani");
        //    _service.Add("افغانى", "Afghans");
        //    _service.Add("هندي", "Indian");
        //    _service.Add("البانى", "Albanian");
        //    _service.Add("انجولى", "Angolan");
        //    _service.Add("ارجنتينى", "Argentinean");
        //    _service.Add("ارمينى", "Armenian");
        //    _service.Add("استرالى", "Australian");
        //    _service.Add("نمساوى", "Austrian");
        //    _service.Add("بلجيكى", "Belgian");
        //    _service.Add("بنينى", "Beninese");
        //    _service.Add("بوليفي", "Bolivian");
        //    _service.Add("برازيلى", "Brazilian");
        //    _service.Add("بريطاني", "British");
        //    _service.Add("كندي", "Canadian");
        //    _service.Add("صيني", "Chinese");
        //    _service.Add("كنغولي", "Congolese");
        //    _service.Add("كرواتي", "Croatian");
        //    _service.Add("دنماركي", "Danish");
        //    _service.Add("اكوادوري", "Ecuadorean");
        //    _service.Add("ايستواني", "Estonian");
        //    _service.Add("فلندي", "Finnish");
        //    _service.Add("فرنسي", "French");
        //    _service.Add("جابونى", "Gabonese");
        //    _service.Add("جورجي", "Georgian");
        //    _service.Add("الماني", "German");
        //    _service.Add("غاني", "Ghanaian");
        //    _service.Add("يوناني", "Greek");
        //    _service.Add("هولندي", "Dutch");
        //    _service.Add("هنجاري", "Hungarian");
        //    _service.Add("ايسلندي", "Icelandic");
        //    _service.Add("ايرلندى", "Irish");
        //    _service.Add("ايطالي", "Italian");
        //    _service.Add("جاميكي", "Jamaican");
        //    _service.Add("ياباني", "Japanese");
        //    _service.Add("كيني", "Kenyan");
        //    _service.Add("لوكسمبورجي", "Luxembourger");
        //    _service.Add("مالاوي", "Malawian");
        //    _service.Add("ماليزي", "Malaysian");
        //    _service.Add("موريتاني", "Mauritanian");
        //    _service.Add("مكسيكي", "Mexican");
        //    _service.Add("موزمبيقى", "Mozambican");
        //    _service.Add("هولندي", "Dutch");
        //    _service.Add("نيوزيلندي", "NewZealander");
        //    _service.Add("نيجيري", "Nigerian");
        //    _service.Add("نرويجي", "Norwegian");
        //    _service.Add("بيرو", "Peruvian");
        //    _service.Add("فليبيني", "Philippine");
        //    _service.Add("بولندي", "Polish");
        //    _service.Add("برتغالي", "Portuguese");
        //    _service.Add("روسي", "Russian");
        //    _service.Add("اسكتلندي", "Scottish");
        //    _service.Add("سنغافوري", "Singaporean");
        //    _service.Add("جنوبافريقي", "SouthAfrican");
        //    _service.Add("اسباني", "Spanish");
        //    _service.Add("سيرلانكي", "SriLankan");
        //    _service.Add("سويدي", "Swedish");
        //    _service.Add("سويسري", "Swiss");
        //    _service.Add("تايواني", "Taiwanese");
        //    _service.Add("تايلاندي", "Thai");
        //    _service.Add("امريكي", "American");
        //    _service.Add("زامبي", "Zambian");
        //    _service.Add("ارتيري", "Eritrean ");
        //    _service.Add("اثيوبي", "Ethiopien");
        //    _service.Add("سريلانكي", "Sri Lanki");

        //    return _service._items;
        //}

        class NationalityService
        {
            public List<Nationality> _items = new List<Nationality>();

            public void Add(string name)
            {
                _items.Add(new Nationality()
                {
                    Name = name
                });
            }
        }

    }
}
