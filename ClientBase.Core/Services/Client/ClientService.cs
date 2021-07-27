using ClientBase.Core.Models;
using ClientBase.Core.ViewModels;
using ClientBase.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace ClientBase.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly IRepository<Client> _clientRepository;

        public ClientService(IRepository<Client> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public ClientViewModel Get(long id)
        {
            var client = _clientRepository.Query().FirstOrDefault(c => c.Id == id);

            return ConvertToClientViewModel(client);
        }


        public IEnumerable<ClientViewModel> GetAll()
        {
            var clients = _clientRepository.Query().ToList().Select(c => ConvertToClientViewModel(c));

            return clients;
        }

        public async void Create(Client model)
        {
            // Validation

            _clientRepository.Add(model);
            await _clientRepository.SaveChangesAsync();
        }

        public async void Update(Client model)
        {
            // Validation

            _clientRepository.Update(model);
            await _clientRepository.SaveChangesAsync();
        }

        public async void Delete(long id)
        {
            _clientRepository.Delete(id);
            await _clientRepository.SaveChangesAsync();
        }

        private ClientViewModel ConvertToClientViewModel(Client model)
        {
            var clientViewModel = new ClientViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                INN = model.INN,
                KPP = model.KPP,
                PropertyType = model.PropertyType,
                City = model.City,
                Country = model.Country,
                Industry = model.Industry,
                DateOfCreation = model.DateOfCreation,
                DateOfChange = model.DateOfChange
            };

            return clientViewModel;
        }
    }
}
