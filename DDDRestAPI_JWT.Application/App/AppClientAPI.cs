using DDDRestAPI_JWT.Application.IApp;
using DDDRestAPI_JWT.Domain.DTOs;
using DDDRestAPI_JWT.Domain.Enties;
using DDDRestAPI_JWT.Domain.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DDDRestAPI_JWT.Application.App
{
    public class AppClientAPI : IAppClientAPI
    {
        private readonly IRepositoryClientAPI RepositoryClientAPI;

        public AppClientAPI(IRepositoryClientAPI _RepositoryClientAPI)
        {
            this.RepositoryClientAPI = _RepositoryClientAPI;
        }

        public void Add(DTOClientAPI _obj)
        {
            ClientAPI newClient = new ClientAPI
            {
                NameId = _obj.NameId,
                Secret = _obj.Secret
            };

            this.RepositoryClientAPI.Add(newClient);
        }

        public void Remove(ClientAPI _obj)
        {
            this.RepositoryClientAPI.Remove(_obj);
        }

        public void Update(ClientAPI _obj)
        {
            this.RepositoryClientAPI.Update(_obj);
        }

        public ClientAPI Get(int Id)
        {
            return this.RepositoryClientAPI.Get(Id);
        }

        public IEnumerable<ClientAPI> GetAll()
        {
            return this.RepositoryClientAPI.GetAll();
        }

        public async Task<ClientAPI> GetAuth(DTOClientAPI _obj)
        {
            return await this.RepositoryClientAPI.GetAuthClientAPI(_obj);
        }
    }
}