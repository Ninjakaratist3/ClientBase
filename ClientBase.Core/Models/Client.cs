using ClientBase.Infrastructure.Models;
using System;

namespace ClientBase.Core.Models
{
    public class Client : EntityBase
    {
        public string Name { get; set; }

        public string INN { get; set; }

        public string KPP { get; set; }

        public PropertyType PropertyType { get; set; }

        public City City { get; set; }

        public Country Country { get; set; }

        public Industry Industry { get; set; }

        public DateTime DateOfCreation { get; set; }

        public DateTime DateOfChange { get; set; }
    }
}
