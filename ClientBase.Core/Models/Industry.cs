using ClientBase.Infrastructure.Models;
using System;

namespace ClientBase.Core.Models
{
    public class Industry : EntityBase
    {
        public string Name { get; set; }

        public DateTime DateOfCreation { get; set; }

        public DateTime DateOfChange { get; set; }
    }
}
