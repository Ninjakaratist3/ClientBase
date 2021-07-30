using ClientBase.Core.Models;
using ClientBase.Core.ViewModels;
using ClientBase.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClientBase.Core.Services
{
    public class IndustryService : IIndustryService
    {
        private readonly IRepository<Industry> _industryRepository;
        private readonly IRepository<Client> _clientRepository;

        public IndustryService(IRepository<Industry> industryRepository, IRepository<Client> clientRepository)
        {
            _industryRepository = industryRepository;
            _clientRepository = clientRepository;
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
            model.DateOfCreation = DateTime.Now;
            model.DateOfChange = DateTime.Now;

            _industryRepository.Add(model);
            _industryRepository.SaveChanges();
        }

        public void Update(Industry model)
        {
            model.DateOfChange = DateTime.Now;

            _industryRepository.Update(model);
            _industryRepository.SaveChanges();
        }

        public void Delete(long id)
        {
            var clients = _clientRepository.Query().Include(c => c.Industry).Where(c => c.Industry.Id == id).ToList();

            foreach (var client in clients)
            {
                client.Industry = null;
            }
            _clientRepository.SaveChanges();

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
