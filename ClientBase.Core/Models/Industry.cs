using ClientBase.Infrastructure.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ClientBase.Core.Models
{
    public class Industry : EntityBase
    {
        [Required(ErrorMessage = "Поле \"Название\" обязательное")]
        public string Name { get; set; }

        public DateTime DateOfCreation { get; set; }

        public DateTime DateOfChange { get; set; }
    }
}
