using DDDRestAPI_JWT.Domain.DTOs;
using DDDRestAPI_JWT.Domain.Enties;
using System.Threading.Tasks;

namespace DDDRestAPI_JWT.Domain.IRepository
{
    public interface IRepositoryClientAPI : IRepositoryBase<ClientAPI>
    {
        Task<ClientAPI> GetAuthClientAPI(DTOClientAPI _dto);
    }
}