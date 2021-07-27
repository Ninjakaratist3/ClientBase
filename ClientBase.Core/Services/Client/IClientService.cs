using ClientBase.Core.Models;
using ClientBase.Core.ViewModels;
using System.Collections.Generic;

namespace ClientBase.Core.Services
{
    public interface IClientService
    {
        public ClientViewModel Get(long id);
        public IEnumerable<ClientViewModel> GetAll();
        public void Create(Client model);
        public void Update(Client model);
        public void Delete(long id);
    }
}
