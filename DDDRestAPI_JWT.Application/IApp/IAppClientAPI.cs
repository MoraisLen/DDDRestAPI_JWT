using DDDRestAPI_JWT.Domain.DTOs;
using DDDRestAPI_JWT.Domain.Enties;
using System.Collections.Generic;

namespace DDDRestAPI_JWT.Application.IApp
{
    public interface IAppClientAPI
    {
        void Add(DTOClientAPI _obj);

        void Update(ClientAPI _obj);

        void Remove(ClientAPI _obj);

        IEnumerable<ClientAPI> GetAll();

        ClientAPI Get(int Id);

        ClientAPI GetAuth(DTOClientAPI _obj);
    }
}