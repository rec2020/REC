using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqeeSite.ViewModels
{
    public class EditUserViewModel
    {
        public string UserId { get; set; }
        public List<SelectListItem> ApplicationRoles { get; set; }

        [Display(Name = "Role")]
        public string ApplicationRoleId { get; set; }

       // public bool SelectedRole { get; set; }
        public string UserName { get; set; }
        public List<string> UserRoles { get; set; }
    }
}
