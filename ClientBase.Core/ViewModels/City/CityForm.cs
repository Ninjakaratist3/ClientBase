using ClientBase.Core.Models;
using System.Collections.Generic;

namespace ClientBase.Core.ViewModels
{
    public class CityForm
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public IList<Country> Countries { get; set; } = new List<Country>();

        public long CountryId { get; set; }
    }
}
