using ClientBase.Core.Models;
using ClientBase.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CountryBase.Core.Controllers
{
    [Route("country")]
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet("/countries")]
        public IActionResult List()
        {
            var countries = _countryService.GetAll();

            return View(countries);
        }

        [HttpGet("{id}")]
        public IActionResult Details(long id)
        {
            var country = _countryService.GetViewModel(id);

            return View(country);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost("create")]
        public IActionResult Create(Country model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _countryService.Create(model);

            return Redirect("/countries");
        }

        [HttpGet("edit/{id}")]
        public IActionResult Update(long id)
        {
            var country = _countryService.Get(id);

            return View(country);
        }

        [ValidateAntiForgeryToken]
        [HttpPost("edit/{id}")]
        public IActionResult Update(Country model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _countryService.Update(model);

            return Redirect("/countries");
        }

        [HttpPost("delete/{id}")]
        public IActionResult Delete(long id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            _countryService.Delete(id);

            return Redirect("/countries");
        }
    }
}
