using ClientBase.Core.Models;
using ClientBase.Core.ViewModels;
using ClientBase.Infrastructure.Data;
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

        public async void Create(City model)
        {
            // Validation

            _cityRepository.Add(model);
            await _cityRepository.SaveChangesAsync();
        }

        public async void Update(City model)
        {
            // Validation

            _cityRepository.Update(model);
            await _cityRepository.SaveChangesAsync();
        }

        public async void Delete(long id)
        {
            _cityRepository.Delete(id);
            await _cityRepository.SaveChangesAsync();
        }

        public CityViewModel ConvertToCityViewModel(City model)
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
    }
}
