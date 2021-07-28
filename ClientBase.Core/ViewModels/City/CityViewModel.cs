using ClientBase.Core.Models;
using System;

namespace ClientBase.Core.ViewModels
{
    public class CityViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public Country Country { get; set; }

        public DateTime DateOfCreation { get; set; }

        public DateTime DateOfChange { get; set; }
    }
}
