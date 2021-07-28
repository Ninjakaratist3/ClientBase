using ClientBase.Core.Models;
using ClientBase.Core.ViewModels;
using System.Collections.Generic;

namespace ClientBase.Core.Services
{
    public interface IPropertyTypeService
    {
        public PropertyType Get(long id);
        public PropertyTypeViewModel GetViewModel(long id);
        public IEnumerable<PropertyTypeViewModel> GetAll();
        public void Create(PropertyType model);
        public void Update(PropertyType model);
        public void Delete(long id);
        public PropertyTypeViewModel ConvertToPropertyTypeViewModel(PropertyType model);
    }
}
