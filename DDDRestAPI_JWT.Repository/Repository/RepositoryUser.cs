using DDDRestAPI_JWT.Domain.Enties;
using DDDRestAPI_JWT.Domain.IRepository;

namespace DDDRestAPI_JWT.Repository.Repository
{
    public class RepositoryUser : RepositoryBase<User>, IRepositoryUser
    {
    }
}