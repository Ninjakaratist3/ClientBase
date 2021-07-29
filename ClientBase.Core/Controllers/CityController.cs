using ClientBase.Core.Services;
using ClientBase.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CityBase.Core.Controllers
{
    [Route("city")]
    public class CityController : Controller
    {
        private readonly ICityService _cityService;
        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet("/cities")]
        public IActionResult List()
        {
            var cities = _cityService.GetAll();

            return View(cities);
        }

        [HttpGet("{id}")]
        public IActionResult Details(long id)
        {
            var city = _cityService.Get(id);

            return View(city);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            var cityForm = _cityService.GetCityForm();

            return View(cityForm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost("create")]
        public IActionResult Create(CityForm model)
        {
            if (!ModelState.IsValid)
            {
                _cityService.IncludeLists(model);
                return View(model);
            }

            _cityService.Create(model);

            return Redirect("/cities");
        }

        [HttpGet("edit/{id}")]
        public IActionResult Update(long id)
        {
            var cityForm = _cityService.GetCityForm(id);

            return View(cityForm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost("edit/{id}")]
        public IActionResult Update(CityForm model)
        {
            if (!ModelState.IsValid)
            {
                _cityService.IncludeLists(model);
                return View(model);
            }

            _cityService.Update(model);

            return Redirect("/cities");
        }

        [HttpPost("delete/{id}")]
        public IActionResult Delete(long id)
        {
            if (id <= 0)
            {
                return View();
            }

            _cityService.Delete(id);

            return Redirect("/cities");
        }
    }
}
