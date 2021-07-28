using ClientBase.Core.Models;
using ClientBase.Core.ViewModels;
using ClientBase.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClientBase.Core.Services
{
    public class PropertyTypeService : IPropertyTypeService
    {
        private readonly IRepository<PropertyType> _propertyTypeRepository;

        public PropertyTypeService(IRepository<PropertyType> propertyTypeRepository)
        {
            _propertyTypeRepository = propertyTypeRepository;
        }

        public PropertyType Get(long id)
        {
            var propertyType = _propertyTypeRepository.Query().FirstOrDefault(p => p.Id == id);

            return propertyType;
        }

        public PropertyTypeViewModel GetViewModel(long id)
        {
            var propertyType = _propertyTypeRepository.Query().FirstOrDefault(p => p.Id == id);

            return ConvertToPropertyTypeViewModel(propertyType);
        }

        public IEnumerable<PropertyTypeViewModel> GetAll()
        {
            var propertyTypes = _propertyTypeRepository.Query().ToList().Select(p => ConvertToPropertyTypeViewModel(p));

            return propertyTypes;
        }

        public void Create(PropertyType model)
        {
            // Validation

            model.DateOfCreation = DateTime.Now;
            model.DateOfChange = DateTime.Now;

            _propertyTypeRepository.Add(model);
            _propertyTypeRepository.SaveChanges();
        }

        public void Update(PropertyType model)
        {
            // Validation

            model.DateOfChange = DateTime.Now;

            _propertyTypeRepository.Update(model);
            _propertyTypeRepository.SaveChanges();
        }

        public void Delete(long id)
        {
            _propertyTypeRepository.Delete(id);
             _propertyTypeRepository.SaveChanges();
        }

        public PropertyTypeViewModel ConvertToPropertyTypeViewModel(PropertyType model)
        {
            var propertyTypeViewModel = new PropertyTypeViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                DateOfCreation = model.DateOfCreation,
                DateOfChange = model.DateOfChange
            };

            return propertyTypeViewModel;
        }
    }
}
