using System;

namespace ClientBase.Core.ViewModels
{
    public class PropertyTypeViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfCreation { get; set; }

        public DateTime DateOfChange { get; set; }
    }
}
