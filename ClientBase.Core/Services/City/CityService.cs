using ClientBase.Core.Models;
using ClientBase.Core.ViewModels;
using ClientBase.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClientBase.Core.Services
{
    public class CityService : ICityService
    {
        private readonly IRepository<City> _cityRepository;
        private readonly IRepository<Country> _countryRepository;

        public CityService(IRepository<City> cityRepository, IRepository<Country> countryRepository)
        {
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
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
            cityForm.Countries = _countryRepository.Query().ToList();

            return cityForm;
        }

        public CityForm GetCityForm(long id)
        {
            var city = _cityRepository.Query().FirstOrDefault(c => c.Id == id);

            var cityForm = new CityForm();
            cityForm.Id = city.Id;
            cityForm.Name = city.Name;
            cityForm.Countries = _countryRepository.Query().ToList();

            return cityForm;
        }

        public void Create(CityForm model)
        {
            // Validation

            var city = ConvertFromCityFormToCity(model);
            city.DateOfCreation = DateTime.Now;
            city.DateOfChange = DateTime.Now;

            _cityRepository.Add(city);
            _cityRepository.SaveChanges();
        }

        public void Update(CityForm model)
        {
            // Validation

            var city = ConvertFromCityFormToCity(model);
            city.DateOfChange = DateTime.Now;

            _cityRepository.Update(city);
            _cityRepository.SaveChanges();
        }

        public void Delete(long id)
        {
            _cityRepository.Delete(id);
            _cityRepository.SaveChanges();
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
