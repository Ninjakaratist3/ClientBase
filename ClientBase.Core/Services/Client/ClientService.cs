using ClientBase.Core.Models;
using ClientBase.Core.ViewModels;
using ClientBase.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClientBase.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly IRepository<Client> _clientRepository;
        private readonly IRepository<PropertyType> _propertyTypeRepository;
        private readonly IRepository<City> _cityRepository;
        private readonly IRepository<Country> _countryRepository;
        private readonly IRepository<Industry> _industryRepository;

        public ClientService(IRepository<Client> clientRepository,
            IRepository<PropertyType> propertyTypeRepository,
            IRepository<City> cityRepository,
            IRepository<Country> countryRepository,
            IRepository<Industry> industryRepository)
        {
            _clientRepository = clientRepository;
            _propertyTypeRepository = propertyTypeRepository;
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
            _industryRepository = industryRepository;
        }

        public ClientViewModel Get(long id)
        {
            var client = _clientRepository
                .Query()
                .Include(c => c.Industry)
                .Include(c => c.PropertyType)
                .Include(c => c.Country)
                .Include(c => c.City)
                .FirstOrDefault(c => c.Id == id);

            return ConvertToClientViewModel(client);
        }


        public IEnumerable<ClientViewModel> GetAll()
        {
            var clients = _clientRepository
                .Query()
                .Include(c => c.Industry)
                .Include(c => c.PropertyType)
                .Include(c => c.Country)
                .Include(c => c.City)
                .ToList()
                .Select(c => ConvertToClientViewModel(c));

            return clients;
        }

        public ClientForm GetClientForm()
        {
            var clientForm = new ClientForm();
            IncludeLists(clientForm);

            return clientForm;
        }

        public ClientForm GetClientForm(long id)
        {
            var client = _clientRepository
                .Query()
                .Include(c => c.Industry)
                .Include(c => c.PropertyType)
                .Include(c => c.Country)
                .Include(c => c.City)
                .FirstOrDefault(c => c.Id == id);

            var clientForm = new ClientForm();
            clientForm.Id = client.Id;
            clientForm.Name = client.Name;
            clientForm.INN = client.INN;
            clientForm.KPP = client.KPP;
            clientForm.PropertyTypeId = client.PropertyType.Id;
            clientForm.IndustryId = client.Industry.Id;
            clientForm.CityId = client.City.Id;
            clientForm.CountryId = client.Country.Id;
            IncludeLists(clientForm);

            return clientForm;
        }

        public void Create(ClientForm model)
        {
            var client = ConvertFromClientFormToClient(model);
            client.Country = _countryRepository.Query().FirstOrDefault(c => c.Id == client.City.CountryId);
            client.DateOfCreation = DateTime.Now;
            client.DateOfChange = DateTime.Now;

            _clientRepository.Add(client);
            _clientRepository.SaveChanges();
        }

        public void Update(ClientForm model)
        {
            var client = ConvertFromClientFormToClient(model);
            client.Country = _countryRepository.Query().FirstOrDefault(c => c.Id == client.City.CountryId);
            client.DateOfChange = DateTime.Now;

            _clientRepository.Update(client);
            _clientRepository.SaveChanges();
        }

        public void Delete(long id)
        {
            _clientRepository.Delete(id);
            _clientRepository.SaveChanges();
        }

        public void IncludeLists(ClientForm clientForm)
        {
            clientForm.PropertyTypes = _propertyTypeRepository.Query().ToList();
            clientForm.Cities = _cityRepository.Query().ToList();
            clientForm.Countries = _countryRepository.Query().ToList();
            clientForm.Industries = _industryRepository.Query().ToList();
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

        private Client ConvertFromClientFormToClient(ClientForm model)
        {
            var clientViewModel = new Client()
            {
                Id = model.Id,
                Name = model.Name,
                INN = model.INN,
                KPP = model.KPP,
                PropertyType = _propertyTypeRepository.Get(model.PropertyTypeId),
                City = _cityRepository.Get(model.CityId),
                Industry = _industryRepository.Get(model.IndustryId)
            };

            return clientViewModel;
        }
    }
}
