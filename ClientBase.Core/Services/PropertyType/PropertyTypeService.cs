using ClientBase.Core.Models;
using ClientBase.Core.ViewModels;
using ClientBase.Infrastructure.Data;
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

        public PropertyTypeViewModel Get(long id)
        {
            var propertyType = _propertyTypeRepository.Query().FirstOrDefault(p => p.Id == id);

            return ConvertToPropertyTypeViewModel(propertyType);
        }

        public IEnumerable<PropertyTypeViewModel> GetAll()
        {
            var propertyTypes = _propertyTypeRepository.Query().ToList().Select(p => ConvertToPropertyTypeViewModel(p));

            return propertyTypes;
        }

        public async void Create(PropertyType model)
        {
            // Validation

            _propertyTypeRepository.Add(model);
            await _propertyTypeRepository.SaveChangesAsync();
        }

        public async void Update(PropertyType model)
        {
            // Validation

            _propertyTypeRepository.Update(model);
            await _propertyTypeRepository.SaveChangesAsync();
        }

        public async void Delete(long id)
        {
            _propertyTypeRepository.Delete(id);
            await _propertyTypeRepository.SaveChangesAsync();
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
