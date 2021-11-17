using DDDRestAPI_JWT.Domain.IRepository;
using DDDRestAPI_JWT.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DDDRestAPI_JWT.Repository.Repository
{
    public class RepositoryBase<TEntie> : IRepositoryBase<TEntie> where TEntie : class
    {
        private readonly DbContextOptions<ContextDatabase> ContextOptions;

        public RepositoryBase()
        {
            ContextOptions = new DbContextOptions<ContextDatabase>();
        }

        public void Add(TEntie entie)
        {
            using (var context = new ContextDatabase(ContextOptions))
            {
                context.Set<TEntie>().Add(entie);
                context.SaveChanges();
            }
        }

        public TEntie Get(int Id)
        {
            using (var context = new ContextDatabase(ContextOptions))
            {
                return context.Set<TEntie>().Find(Id);
            }
        }

        public IEnumerable<TEntie> GetAll()
        {
            using (var context = new ContextDatabase(ContextOptions))
            {
                return context.Set<TEntie>().ToList();
            }
        }

        public void Remove(TEntie entie)
        {
            using (var context = new ContextDatabase(ContextOptions))
            {
                context.Set<TEntie>().Remove(entie);
                context.SaveChanges();
            }
        }

        public void Update(TEntie entie)
        {
            using (var context = new ContextDatabase(ContextOptions))
            {
                context.Set<TEntie>().Update(entie);
                context.SaveChanges();
            }
        }
    }
}