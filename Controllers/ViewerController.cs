using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Base;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using Stimulsoft_Test.Models;

namespace Stimulsoft_Test.Controllers
{
    public class ViewerController : Controller
    {
        private readonly IWebHostEnvironment _host;
        public ViewerController(IWebHostEnvironment host)
        {
            _host = host;
            // How to Activate
            //Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnO...";
            //Stimulsoft.Base.StiLicense.LoadFromFile("license.key");
            //Stimulsoft.Base.StiLicense.LoadFromStream(stream);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetReport()
        {
            //return null;
            var Address = "Reports/Report-Mamadi.mrt";
            var mamadi = GetDataMamadi();

            // Create the report object
            var report = new StiReport();
            report.Load(StiNetCoreHelper.MapPath(this, Address));
            report.Compile();
            report.RegData("Mamadi", mamadi);
            return StiNetCoreViewer.GetReportResult(this, report);

        }

        private static List<Mamadi> GetDataMamadi()
        {
            return new List<Mamadi>()
            {
                new Mamadi()
                {
                    Id = 1,
                    Title = "headr 1",
                    Created = "1399/09/01"
                },
                new Mamadi()
                {
                    Id = 2,
                    Title = "headr 2",
                    Created = "1399/09/02"
                },
                new Mamadi()
                {
                    Id = 3,
                    Title = "headr 3",
                    Created = "1399/09/03"
                },

            };
        }

        public IActionResult ViewerEvent()
        {
            
            return StiNetCoreViewer.ViewerEventResult(this);
        }

    }
}
