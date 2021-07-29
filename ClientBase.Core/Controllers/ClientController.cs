using ClientBase.Core.Services;
using ClientBase.Core.ViewModels;
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
            var clientForm = _clientService.GetClientForm();
            return View(clientForm);
        }

        [HttpPost("create")]
        public IActionResult Create(ClientForm model)
        {
            if (!ModelState.IsValid)
            {
                _clientService.IncludeLists(model);
                return View(model);
            }

            _clientService.Create(model);

            return Redirect("/clients");
        }

        [HttpGet("edit/{id}")]
        public IActionResult Update(long id)
        {
            var clientForm = _clientService.GetClientForm(id);

            return View(clientForm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost("edit/{id}")]
        public IActionResult Update(ClientForm model)
        {
            if (!ModelState.IsValid)
            {
                _clientService.IncludeLists(model);
                return View(model);
            }

            _clientService.Update(model);

            return Redirect("/clients");
        }

        [HttpPost("delete/{id}")]
        public IActionResult Delete(long id)
        {
            if (id <= 0)
            {
                return View();
            }

            _clientService.Delete(id);

            return Redirect("/clients");
        }
    }
}
