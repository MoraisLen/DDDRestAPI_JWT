using DDDRestAPI_JWT.Domain.DTOs;
using DDDRestAPI_JWT.Domain.Enties;
using System.Collections.Generic;

namespace DDDRestAPI_JWT.Application.IApp
{
    public interface IAppUser
    {
        void Add(List<DTOUser> lstDTOUsers);

        void Update(User _obj);

        void Remove(User _obj);

        IEnumerable<User> GetAll();

        User Get(int Id);

        void ImportUser(string path);

        string ExportUser();
    }
}