using ClientBase.Core.Models;
using ClientBase.Core.ViewModels;
using System.Collections.Generic;

namespace ClientBase.Core.Services
{
    public interface ICountryService
    {
        public CountryViewModel Get(long id);
        public IEnumerable<CountryViewModel> GetAll();
        public void Create(Country model);
        public void Update(Country model);
        public void Delete(long id);
        public CountryViewModel ConvertToCountryViewModel(Country model);
    }
}
