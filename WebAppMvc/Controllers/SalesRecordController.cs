using Microsoft.AspNetCore.Mvc;
using System;
using WebAppMvc.Services;
using System.Threading.Tasks;

namespace WebAppMvc.Controllers
{
    public class SalesRecordController : Controller
    {

        private readonly SalesRecordService _salesRecordService;

        public SalesRecordController(SalesRecordService salesRecordService)
        {
            _salesRecordService = salesRecordService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? min, DateTime? max)
        {
            if (!min.HasValue)
            {
                min = new DateTime(DateTime.Now.Year, 1, 1);
            }

            if (!max.HasValue)
            {
                max = DateTime.Now;
            }
            ViewData["minDate"] = min.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = max.Value.ToString("yyyy-MM-dd");
            var result = await _salesRecordService.FindByDateAsync(min, max);
            return View(result);
        }

        public IActionResult GroupingSearch()
        {
            return View();
        }
    }
}
