using ClientBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientBase.Core.ViewModels
{
    public class ClientForm
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string INN { get; set; }

        public string KPP { get; set; }

        public IList<PropertyType> PropertyTypes { get; set; } = new List<PropertyType>();

        public long PropertyTypeId { get; set; }

        public IList<City> Cities { get; set; } = new List<City>();

        public long CityId { get; set; }

        public IList<Country> Countries { get; set; } = new List<Country>();

        public long CountryId { get; set; }

        public IList<Industry> Industries { get; set; } = new List<Industry>();

        public long IndustryId { get; set; }
    }
}
