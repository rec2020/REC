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
                new Country() {Name = "المملكة العربية السعودية"},
            };

            return _items;
        }

        public static List<City> GetCities()
        {
            List<City> _items = new List<City>
            {
                new City() {Name = "الرياض", CountryId = 1},
                new City() {Name = "جده", CountryId = 1},
                new City() {Name = "مكة",  CountryId = 1},
                new City() {Name = "الدمام",  CountryId = 1},
                new City() {Name = "القصيم",  CountryId = 1},
            };

            return _items;
        }

        public static List<Gender> GetGenders()
        {
            List<Gender> _items = new List<Gender>
            {
                new Gender() {Name = "ذكر"},
                new Gender() {Name = "أنثى"}
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
