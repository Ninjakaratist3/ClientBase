using ClientBase.Core.Models;
using ClientBase.Core.ViewModels;
using ClientBase.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClientBase.Core.Services
{
    public class CountryService : ICountryService
    {
        private readonly IRepository<Country> _countryRepository;
        private readonly IRepository<Client> _clientRepository;

        public CountryService(IRepository<Country> countryRepository, IRepository<Client> clientRepository)
        {
            _countryRepository = countryRepository;
            _clientRepository = clientRepository;
        }

        public Country Get(long id)
        {
            var country = _countryRepository.Query().FirstOrDefault(c => c.Id == id);

            return country;
        }

        public CountryViewModel GetViewModel(long id)
        {
            var country = _countryRepository.Query().FirstOrDefault(c => c.Id == id);

            return ConvertToCountryViewModel(country);
        }

        public IEnumerable<CountryViewModel> GetAll()
        {
            var countries = _countryRepository.Query().ToList().Select(c => ConvertToCountryViewModel(c));

            return countries;
        }

        public void Create(Country model)
        {
            // Validation

            model.DateOfCreation = DateTime.Now;
            model.DateOfChange = DateTime.Now;

            _countryRepository.Add(model);
            _countryRepository.SaveChanges();
        }

        public void Update(Country model)
        {
            // Validation

            model.DateOfChange = DateTime.Now;

            _countryRepository.Update(model);
            _countryRepository.SaveChanges();
        }

        public void Delete(long id)
        {
            var clients = _clientRepository.Query().Include(c => c.Country).Where(c => c.Country.Id == id).ToList();

            foreach (var client in clients)
            {
                client.Country = null;
            }
            _clientRepository.SaveChanges();

            _countryRepository.Delete(id);
            _countryRepository.SaveChanges();
        }

        private CountryViewModel ConvertToCountryViewModel(Country model)
        {
            var countryViewModel = new CountryViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                DateOfCreation = model.DateOfCreation,
                DateOfChange = model.DateOfChange
            };

            return countryViewModel;
        }

    }
}
