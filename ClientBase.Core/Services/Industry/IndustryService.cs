using ClientBase.Core.Models;
using ClientBase.Core.ViewModels;
using ClientBase.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace ClientBase.Core.Services
{
    public class IndustryService : IIndustryService
    {
        private readonly IRepository<Industry> _industryRepository;

        public IndustryService(IRepository<Industry> industryRepository)
        {
            _industryRepository = industryRepository;
        }

        public IndustryViewModel Get(long id)
        {
            var industry = _industryRepository.Query().FirstOrDefault(i => i.Id == id);

            return ConvertToIndustryViewModel(industry);
        }

        public IEnumerable<IndustryViewModel> GetAll()
        {
            var industries = _industryRepository.Query().ToList().Select(i => ConvertToIndustryViewModel(i));

            return industries;
        }

        public async void Create(Industry model)
        {
            // Validation

            _industryRepository.Add(model);
            await _industryRepository.SaveChangesAsync();
        }

        public async void Update(Industry model)
        {
            // Validation

            _industryRepository.Update(model);
            await _industryRepository.SaveChangesAsync();
        }

        public async void Delete(long id)
        {
            _industryRepository.Delete(id);
            await _industryRepository.SaveChangesAsync();
        }

        public IndustryViewModel ConvertToIndustryViewModel(Industry model)
        {
            var industryViewModel = new IndustryViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                DateOfCreation = model.DateOfCreation,
                DateOfChange = model.DateOfChange
            };

            return industryViewModel;
        }
    }
}
