using ClientBase.Core.Models;
using ClientBase.Core.ViewModels;
using ClientBase.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClientBase.Core.Services
{
    public class CityService : ICityService
    {
        private readonly IRepository<City> _cityRepository;
        private readonly IRepository<Country> _countryRepository;
        private readonly IRepository<Client> _clientRepository;

        public CityService(IRepository<City> cityRepository, 
            IRepository<Country> countryRepository,
            IRepository<Client> clientRepository)
        {
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
            _clientRepository = clientRepository;
        }

        public CityViewModel Get(long id)
        {
            var city = _cityRepository.Query().FirstOrDefault(c => c.Id == id);

            return ConvertToCityViewModel(city);
        }

        public IEnumerable<CityViewModel> GetAll()
        {
            var cities = _cityRepository.Query().ToList().Select(c => ConvertToCityViewModel(c));

            return cities;
        }

        public CityForm GetCityForm()
        {
            var cityForm = new CityForm();
            IncludeLists(cityForm);

            return cityForm;
        }

        public CityForm GetCityForm(long id)
        {
            var city = _cityRepository.Query().FirstOrDefault(c => c.Id == id);

            var cityForm = new CityForm();
            cityForm.Id = city.Id;
            cityForm.Name = city.Name;
            cityForm.CountryId = city.CountryId;
            IncludeLists(cityForm);

            return cityForm;
        }

        public void Create(CityForm model)
        {
            var city = ConvertFromCityFormToCity(model);
            city.DateOfCreation = DateTime.Now;
            city.DateOfChange = DateTime.Now;

            _cityRepository.Add(city);
            _cityRepository.SaveChanges();
        }

        public void Update(CityForm model)
        {
            var city = ConvertFromCityFormToCity(model);
            city.DateOfChange = DateTime.Now;

            _cityRepository.Update(city);
            _cityRepository.SaveChanges();
        }

        public void Delete(long id)
        {
            var clients = _clientRepository.Query().Include(c => c.City).Where(c => c.City.Id == id).ToList();

            foreach (var client in clients)
            {
                client.City = null;
            }
            _clientRepository.SaveChanges();

            _cityRepository.Delete(id);
            _cityRepository.SaveChanges();
        }

        public void IncludeLists(CityForm cityForm)
        {
            cityForm.Countries = _countryRepository.Query().ToList();
        }

        private CityViewModel ConvertToCityViewModel(City model)
        {
            var cityViewModel = new CityViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                Country = _countryRepository.Get(model.CountryId),
                DateOfCreation = model.DateOfCreation,
                DateOfChange = model.DateOfChange
            };

            return cityViewModel;
        }

        private City ConvertFromCityFormToCity(CityForm model)
        {
            var cityViewModel = new City()
            {
                Id = model.Id,
                Name = model.Name,
                CountryId = model.CountryId
            };

            return cityViewModel;
        }
    }
}
