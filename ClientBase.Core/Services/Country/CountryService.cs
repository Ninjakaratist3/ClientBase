using ClientBase.Core.Models;
using ClientBase.Core.ViewModels;
using ClientBase.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace ClientBase.Core.Services
{
    public class CountryService : ICountryService
    {
        private readonly IRepository<Country> _countryRepository;

        public CountryService(IRepository<Country> countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public CountryViewModel Get(long id)
        {
            var country = _countryRepository.Query().FirstOrDefault(c => c.Id == id);

            return ConvertToCountryViewModel(country);
        }

        public IEnumerable<CountryViewModel> GetAll()
        {
            var countries = _countryRepository.Query().ToList().Select(c => ConvertToCountryViewModel(c));

            return countries;
        }

        public async void Create(Country model)
        {
            // Validation

            _countryRepository.Add(model);
            await _countryRepository.SaveChangesAsync();
        }

        public async void Update(Country model)
        {
            // Validation

            _countryRepository.Update(model);
            await _countryRepository.SaveChangesAsync();
        }

        public async void Delete(long id)
        {
            _countryRepository.Delete(id);
            await _countryRepository.SaveChangesAsync();
        }

        public CountryViewModel ConvertToCountryViewModel(Country model)
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
