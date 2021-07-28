using ClientBase.Core.Models;
using ClientBase.Core.ViewModels;
using System.Collections.Generic;

namespace ClientBase.Core.Services
{
    public interface IIndustryService
    {
        public Industry Get(long id);
        public IndustryViewModel GetViewModel(long id);
        public IEnumerable<IndustryViewModel> GetAll();
        public void Create(Industry model);
        public void Update(Industry model);
        public void Delete(long id);
        public IndustryViewModel ConvertToIndustryViewModel(Industry model);
    }
}
