using ClientBase.Core.Models;
using ClientBase.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientBase.Core.Controllers
{
    [Route("industry")]
    public class IndustryController : Controller
    {
        private readonly IIndustryService _industryService;
        public IndustryController(IIndustryService industryService)
        {
            _industryService = industryService;
        }

        [HttpGet("/industries")]
        public IActionResult List()
        {
            var industries = _industryService.GetAll();

            return View(industries);
        }

        [HttpGet("{id}")]
        public IActionResult Details(long id)
        {
            var industry = _industryService.GetViewModel(id);

            return View(industry);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost("create")]
        public IActionResult Create(Industry model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _industryService.Create(model);

            return Redirect("/industries");
        }

        [HttpGet("edit/{id}")]
        public IActionResult Update(long id)
        {
            var industry = _industryService.Get(id);

            return View(industry);
        }

        [ValidateAntiForgeryToken]
        [HttpPost("edit/{id}")]
        public IActionResult Update(Industry model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _industryService.Update(model);

            return Redirect("/industries");
        }

        [HttpPost("delete/{id}")]
        public IActionResult Delete(long id)
        {
            if (id <= 0)
            {
                return View();
            }

            _industryService.Delete(id);

            return Redirect("/industries");
        }
    }
}
