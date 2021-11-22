using DDDRestAPI_JWT.Application.IApp;
using DDDRestAPI_JWT.Domain.DTOs;
using DDDRestAPI_JWT.Domain.Enties;
using DDDRestAPI_JWT.Domain.IRepository;
using System.Collections.Generic;

namespace DDDRestAPI_JWT.Application.App
{
    public class AppUser : IAppUser
    {
        private readonly IRepositoryUser RepositoryUser;

        public AppUser(IRepositoryUser _RepositoryUser)
        {
            this.RepositoryUser = _RepositoryUser;
        }

        public void Add(DTOUser _obj)
        {
            User newUser = new User
            {
                Name = _obj.Name,
                Email = _obj.Email,
                Phone = _obj.Phone,
                Password = _obj.Password,
            };

            this.RepositoryUser.Add(newUser);
        }

        public User Get(int Id)
        {
            return this.RepositoryUser.Get(Id);
        }

        public IEnumerable<User> GetAll()
        {
            return RepositoryUser.GetAll();
        }

        public void Remove(User _obj)
        {
            this.RepositoryUser.Remove(_obj);
        }

        public void Update(User _obj)
        {
            this.RepositoryUser.Update(_obj);
        }

        public void ImportUser(string data)
        {
            var array = data.Split('\n');

            foreach (var line in array)
            {
                var infor = line.Split(':');

                if (infor.Length >= 4)
                {
                    DTOUser newUser = new DTOUser
                    {
                        Name = infor[0],
                        Phone = infor[1],
                        Email = infor[2],
                        Password = infor[3]
                    };

                    this.Add(newUser);
                }
            }
        }
    }
}