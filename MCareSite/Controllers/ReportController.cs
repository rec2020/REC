using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FastReport.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NajmetAlraqee.Data.Repositories;
using NToastNotify;

namespace NajmetAlraqee.Site.Controllers
{   [Authorize]
    public class ReportController : Controller
    {
        #region Filed
        private readonly IAccountClassificationRepository _AccClassification;
        private readonly IAccountClassificationTypeRepository _Acctype;
        private readonly IMapper _mapper;
        private readonly IAccountTreeRepository _tree;
        private readonly IHostingEnvironment _hostingEnvironment;
        public readonly IConfiguration _configuration;
        public WebReport webReport = new WebReport();
        #endregion

        public ReportController(
         IMapper mapper,  IHostingEnvironment hostingEnvironment,
         IAccountClassificationTypeRepository acctype, IAccountClassificationRepository accClassification,
         IAccountTreeRepository tree , IConfiguration configuration)
        {
            _mapper = mapper;
            _AccClassification = accClassification;
            _Acctype = acctype;
            _tree = tree;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }

        #region AccountTreeReport 
        public IActionResult AccountTreeIndex(int accountLevel, string accName , string accNo)
        {
            if (accountLevel>0 || accName!= null || accNo!= null ) {
                SetReportAccountTree(accountLevel, accName, accNo);
            }
            else {
                SetReportAccountTree();
            }
            return View(webReport);
        }
        private void SetReportAccountTree(int accountLevel, string accName, string accNo)
        {
            var webRoot = _hostingEnvironment.WebRootPath + "\\Reporting\\AccountTree\\";
            webReport.Width = "1000"; // Set the width of the report
            webReport.Height = "1000"; // Set the height of the report
            var file = Path.Combine(webRoot, "AccountTreeFilterReport.frx");
            string report_path = file;
            var connection = _configuration.GetConnectionString("DefaultConnection");
            MsSqlDataConnection sqlConnection = new MsSqlDataConnection
            {
                ConnectionString = _configuration.GetConnectionString("DefaultConnection")
            };
            sqlConnection.CreateAllTables();
            webReport.Report.Dictionary.Connections.Add(sqlConnection);
            webReport.Report.Load(file);
            webReport.Report.SetParameterValue("AccountLevel", accountLevel);
            webReport.Report.SetParameterValue("AccountName", accName);
            webReport.Report.Prepare();
        }
        private void SetReportAccountTree()
        {
            var webRoot = _hostingEnvironment.WebRootPath + "\\Reporting\\AccountTree\\";
            webReport.Width = "1000"; // Set the width of the report
            webReport.Height = "1000"; // Set the height of the report
            var file = Path.Combine(webRoot, "AccountTreeReport.frx");
            string report_path = file;
            MsSqlDataConnection sqlConnection = new MsSqlDataConnection
            {
                ConnectionString = _configuration.GetConnectionString("DefaultConnection")
        };
            sqlConnection.CreateAllTables();
            webReport.Report.Dictionary.Connections.Add(sqlConnection);
            webReport.Report.Load(file);
        }
        #endregion

        #region ContractReport 
        public IActionResult ContractIndex(string FromDate, string ToDate, string Country , int LateDate,string ForiegnAgency)
        {
            if ( FromDate!= null || ToDate != null ||Country != null || LateDate > 0 || ForiegnAgency != null)
            {
                SetReportContract(FromDate, ToDate, Country, LateDate, ForiegnAgency);
            }
            else
            {
                SetReportContract();
            }
            return View(webReport);
        }
        private void SetReportContract(string FromDate, string ToDate, string Country, int LateDate, string ForiegnAgency)
        {
            var webRoot = _hostingEnvironment.WebRootPath + "\\Reporting\\Contracts\\";
            webReport.Width = "1000"; // Set the width of the report
            webReport.Height = "1000"; // Set the height of the report
            var file = Path.Combine(webRoot, "ContractFilterReport.frx");
            string report_path = file;
            MsSqlDataConnection sqlConnection = new MsSqlDataConnection
            {
                ConnectionString = _configuration.GetConnectionString("DefaultConnection")
            };
            sqlConnection.CreateAllTables();
            webReport.Report.Dictionary.Connections.Add(sqlConnection);
            webReport.Report.Load(file);
            //webReport.Report.SetParameterValue("FromDate", FromDate);
            //webReport.Report.SetParameterValue("ToDate", ToDate);
            webReport.Report.SetParameterValue("Country", Country);
            webReport.Report.SetParameterValue("LateDate", LateDate);
            webReport.Report.SetParameterValue("ForiegnAgency", ForiegnAgency);
            webReport.Report.Prepare();
        }
        private void SetReportContract()
        {
            var webRoot = _hostingEnvironment.WebRootPath + "\\Reporting\\Contracts\\";
            webReport.Width = "1000"; // Set the width of the report
            webReport.Height = "1000"; // Set the height of the report
            var file = Path.Combine(webRoot, "ContractReport.frx");
            string report_path = file;
            MsSqlDataConnection sqlConnection = new MsSqlDataConnection
            {
                ConnectionString = _configuration.GetConnectionString("DefaultConnection")
            };
            sqlConnection.CreateAllTables();
            webReport.Report.Dictionary.Connections.Add(sqlConnection);
            webReport.Report.Load(file);
        }
        #endregion 


    }
}