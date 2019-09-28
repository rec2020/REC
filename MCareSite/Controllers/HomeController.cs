using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FastReport.Web;
using NToastNotify;
using AutoMapper;
using NajmetAlraqee.Data.Repositories;
using FastReport.Utils;
using System.IO;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Hosting;
using NajmetAlraqee.Site;
using Microsoft.Extensions.Configuration;

namespace NajmetAlraqeeSite.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        #region Filed 
        private readonly IAccountClassificationRepository _AccClassification;
        private readonly IAccountClassificationTypeRepository _Acctype;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;
        private readonly IAccountTreeRepository _tree;
        private readonly IHostingEnvironment _hostingEnvironment;
        public WebReport webReport = new WebReport();
       

 
        #endregion

        public HomeController(
          IMapper mapper, IToastNotification toastNotification, IHostingEnvironment hostingEnvironment,
          IAccountClassificationTypeRepository acctype, IAccountClassificationRepository accClassification,
          IAccountTreeRepository tree)
        {
            _mapper = mapper;
            _toastNotification = toastNotification;
            _AccClassification = accClassification;
            _Acctype = acctype;
            _tree = tree;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
           
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

    }
}
