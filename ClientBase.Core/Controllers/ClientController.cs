using ClientBase.Core.Models;
using ClientBase.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClientBase.Core.Controllers
{
    [Route("client")]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("/clients")]
        public IActionResult List()
        {
            var clients = _clientService.GetAll();

            return View(clients);
        }

        [HttpGet("{id}")]
        public IActionResult Details(long id)
        {
            var client = _clientService.Get(id);

            return View(client);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost("create")]
        public IActionResult Create(Client model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _clientService.Create(model);

            return Redirect("/clients");
        }

        [HttpGet("edit/{id}")]
        public IActionResult Update(long id)
        {
            var client = _clientService.Get(id);

            return View(client);
        }

        [ValidateAntiForgeryToken]
        [HttpPost("edit/{id}")]
        public IActionResult Update(Client model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _clientService.Update(model);

            return Redirect("/products");
        }

        [HttpPost("delete/{id}")]
        public IActionResult Delete(long id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            _clientService.Delete(id);

            return Redirect("/products");
        }
    }
}
