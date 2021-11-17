using DDDRestAPI_JWT.Domain.DTOs;
using DDDRestAPI_JWT.Domain.Enties;
using DDDRestAPI_JWT.Domain.IRepository;
using DDDRestAPI_JWT.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DDDRestAPI_JWT.Repository.Repository
{
    public class RepositoryClientAPI : RepositoryBase<ClientAPI>, IRepositoryClientAPI
    {
        private readonly DbContextOptions<ContextDatabase> ContextOptions;

        public RepositoryClientAPI()
        {
            ContextOptions = new DbContextOptions<ContextDatabase>();
        }

        public ClientAPI GetAuthClientAPI(DTOClientAPI _dto)
        {
            using (var context = new ContextDatabase(ContextOptions))
            {
                return context.ClientAPIs
                    .Where(x => x.NameId == _dto.NameId)
                    .Where(x => x.Secret == _dto.Secret)
                    .FirstOrDefault();
            }
        }
    }
}