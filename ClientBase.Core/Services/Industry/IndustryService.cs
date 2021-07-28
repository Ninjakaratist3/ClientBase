using ClientBase.Core.Models;
using ClientBase.Core.ViewModels;
using ClientBase.Infrastructure.Data;
using System;
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

        public Industry Get(long id)
        {
            var industry = _industryRepository.Query().FirstOrDefault(i => i.Id == id);

            return industry;
        }

        public IndustryViewModel GetViewModel(long id)
        {
            var industry = _industryRepository.Query().FirstOrDefault(i => i.Id == id);

            return ConvertToIndustryViewModel(industry);
        }

        public IEnumerable<IndustryViewModel> GetAll()
        {
            var industries = _industryRepository.Query().ToList().Select(i => ConvertToIndustryViewModel(i));

            return industries;
        }

        public void Create(Industry model)
        {
            // Validation

            model.DateOfCreation = DateTime.Now;
            model.DateOfChange = DateTime.Now;

            _industryRepository.Add(model);
            _industryRepository.SaveChanges();
        }

        public void Update(Industry model)
        {
            // Validation

            model.DateOfChange = DateTime.Now;

            _industryRepository.Update(model);
            _industryRepository.SaveChanges();
        }

        public void Delete(long id)
        {
            _industryRepository.Delete(id);
            _industryRepository.SaveChanges();
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
