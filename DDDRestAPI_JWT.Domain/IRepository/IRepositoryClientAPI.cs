using DDDRestAPI_JWT.Domain.DTOs;
using DDDRestAPI_JWT.Domain.Enties;

namespace DDDRestAPI_JWT.Domain.IRepository
{
    public interface IRepositoryClientAPI : IRepositoryBase<ClientAPI>
    {
        ClientAPI GetAuthClientAPI(DTOClientAPI _dto);
    }
}