using ClientBase.Core.Models;
using ClientBase.Core.ViewModels;
using System.Collections.Generic;

namespace ClientBase.Core.Services
{
    public interface IClientService
    {
        public ClientViewModel Get(long id);
        public IEnumerable<ClientViewModel> GetAll();
        public ClientForm GetClientForm();
        public ClientForm GetClientForm(long id);
        public void Create(ClientForm model);
        public void Update(ClientForm model);
        public void Delete(long id);
    }
}
