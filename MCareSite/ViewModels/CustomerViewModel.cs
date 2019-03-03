using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class CustomerViewModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage ="الرجاء ادخال الاسم الاول")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "الرجاء ادخال الاسم الاوسط")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "الرجاء ادخال الاسم الاخير")]
        public string LastName { get; set; }

        public string Name { get; set; }

        [Required(ErrorMessage = "الرجاء ادخال رقم الهوية")]
        public string IdentityNo { get; set; }

        [Required(ErrorMessage = "الرجاء ادخال رقم الهاتف")]
        public string FirstPhone { get; set; }
        public string SecondPhone { get; set; }

        [Required(ErrorMessage = "الرجاء تحديد نوع العميل")]
        public int CustomerTypeId { get; set; }
        public string CustomerTypeName { get; set; }
       
        public string IdentiyImage { get; set; }

        [Required(ErrorMessage = " الرجاء ارفاق الهوية")]
        public IFormFile IdentiyImageFile { get; set; }

        public string FamilyImage { get; set; }

        [Required(ErrorMessage = "الرجاء ارفاق كرت العائلة")]
        public IFormFile FamilyImageFile { get; set; }
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "الرجاء تحديد المندوب")]
        public int UserDelegateId { get; set; }

        public string UserDelegateName { get; set; }

        [Required(ErrorMessage = "الرجاء ادخال العنوان")]

        public string Address { get; set; }
    }
}
