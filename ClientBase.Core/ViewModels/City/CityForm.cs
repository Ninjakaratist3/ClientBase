using ClientBase.Core.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClientBase.Core.ViewModels
{
    public class CityForm
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Поле \"Название\" обязательное")]
        public string Name { get; set; }

        public IList<Country> Countries { get; set; } = new List<Country>();

        [Required(ErrorMessage = "Поле \"Страна\" обязательное")]
        public long CountryId { get; set; }
    }
}
