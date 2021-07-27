using ClientBase.Core.Models;
using ClientBase.Core.ViewModels;
using System.Collections.Generic;

namespace ClientBase.Core.Services
{
    public interface ICityService
    {
        public CityViewModel Get(long id);
        public IEnumerable<CityViewModel> GetAll();
        public void Create(City model);
        public void Update(City model);
        public void Delete(long id);
        public CityViewModel ConvertToCityViewModel(City model);
    }
}
