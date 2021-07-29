using ClientBase.Core.Models;
using ClientBase.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientBase.Core.Controllers
{
    [Route("property-type")]
    public class PropertyTypeController : Controller
    {
        private readonly IPropertyTypeService _propertyTypeService;
        public PropertyTypeController(IPropertyTypeService propertyTypeService)
        {
            _propertyTypeService = propertyTypeService;
        }

        [HttpGet("/property-types")]
        public IActionResult List()
        {
            var propertyTypes = _propertyTypeService.GetAll();

            return View(propertyTypes);
        }

        [HttpGet("{id}")]
        public IActionResult Details(long id)
        {
            var propertyType = _propertyTypeService.GetViewModel(id);

            return View(propertyType);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost("create")]
        public IActionResult Create(PropertyType model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _propertyTypeService.Create(model);

            return Redirect("/property-types");
        }

        [HttpGet("edit/{id}")]
        public IActionResult Update(long id)
        {
            var propertyType = _propertyTypeService.Get(id);

            return View(propertyType);
        }

        [ValidateAntiForgeryToken]
        [HttpPost("edit/{id}")]
        public IActionResult Update(PropertyType model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _propertyTypeService.Update(model);

            return Redirect("/property-types");
        }

        [HttpPost("delete/{id}")]
        public IActionResult Delete(long id)
        {
            if (id <= 0)
            {
                return View();
            }

            _propertyTypeService.Delete(id);

            return Redirect("/property-types");
        }
    }
}
