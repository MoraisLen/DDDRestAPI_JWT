using System.Collections.Generic;

namespace DDDRestAPI_JWT.Domain.IRepository
{
    public interface IRepositoryBase <TEntie> where TEntie : class
    {
        void Add (TEntie entie);
        void Remove (TEntie entie);
        void Update (TEntie entie);
        IEnumerable<TEntie> GetAll();
        TEntie Get (int Id);
    }
}
