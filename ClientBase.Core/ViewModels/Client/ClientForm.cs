using ClientBase.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientBase.Core.ViewModels
{
    public class ClientForm
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Поле \"Название\" обязательное")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле \"ИНН\" обязательное")]
        [StringLength(10, ErrorMessage = "Длина ИНН должна быть равна 10", MinimumLength = 10)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Поле может содержать тольцо цифры")]
        public string INN { get; set; }

        [Required(ErrorMessage = "Поле \"КПП\" обязательное")]
        [StringLength(9, ErrorMessage = "Длина КПП должна быть равна 9", MinimumLength = 9)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Поле может содержать тольцо цифры")]
        public string KPP { get; set; }

        public IList<PropertyType> PropertyTypes { get; set; } = new List<PropertyType>();

        [Range(1, long.MaxValue, ErrorMessage = "Поле \"Тип собственности\" обязательное")]
        public long PropertyTypeId { get; set; }

        public IList<City> Cities { get; set; } = new List<City>();

        [Range(1, long.MaxValue, ErrorMessage = "Поле \"Город\" обязательное")]
        public long CityId { get; set; }

        public IList<Country> Countries { get; set; } = new List<Country>();

        public long CountryId { get; set; }

        public IList<Industry> Industries { get; set; } = new List<Industry>();

        [Range(1, long.MaxValue, ErrorMessage = "Поле \"Отрасль\" обязательное")]
        public long IndustryId { get; set; }
    }
}
