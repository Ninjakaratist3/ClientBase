using ClientBase.Core.Models;
using ClientBase.Core.ViewModels;
using System.Collections.Generic;

namespace ClientBase.Core.Services
{
    public interface ICityService
    {
        public CityViewModel Get(long id);
        public IEnumerable<CityViewModel> GetAll();
        public CityForm GetCityForm();
        public CityForm GetCityForm(long id);
        public void Create(CityForm model);
        public void Update(CityForm model);
        public void Delete(long id);
    }
}
