using ClientBase.Core.Models;
using System;

namespace ClientBase.Core.ViewModels
{
    public class ClientViewModel
    {
        public long Id { get; set; }

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
