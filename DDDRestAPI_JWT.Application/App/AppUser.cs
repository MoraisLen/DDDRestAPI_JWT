using DDDRestAPI_JWT.Application.IApp;
using DDDRestAPI_JWT.Domain.DTOs;
using DDDRestAPI_JWT.Domain.Enties;
using DDDRestAPI_JWT.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.IO;

namespace DDDRestAPI_JWT.Application.App
{
    public class AppUser : IAppUser
    {
        private readonly IRepositoryUser RepositoryUser;

        public AppUser(IRepositoryUser _RepositoryUser)
        {
            this.RepositoryUser = _RepositoryUser;
        }

        public void Add(List<DTOUser> lstDTOUsers)
        {
            List<User> lstUsers = new List<User>();

            foreach (var _obj in lstDTOUsers)
            {
                try
                {
                    User newUser = new User
                    {
                        Name = _obj.Name,
                        Email = _obj.Email,
                        Phone = _obj.Phone,
                        Password = _obj.Password,
                    };

                    lstUsers.Add(newUser);
                }
                catch
                {
                    throw;
                }
            }

            foreach (var _obj in lstUsers)
            {
                this.RepositoryUser.Add(_obj);
            }
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

        public void ImportUser(string path)
        {
            StreamReader reader = new StreamReader(path);
            string data = reader.ReadToEnd();

            List<DTOUser> lstDTOUsers = new List<DTOUser>();

            var array = data.Split('\n');

            foreach (var line in array)
            {
                var infor = line.Split(';');

                if (infor.Length >= 4)
                {
                    try
                    {
                        DTOUser newDTOUser = new DTOUser
                        {
                            Name = infor[0],
                            Phone = infor[1],
                            Email = infor[2],
                            Password = infor[3]
                        };

                        lstDTOUsers.Add(newDTOUser);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

            reader.Close();

            this.Add(lstDTOUsers);
        }

        public string ExportUser()
        {
            IEnumerable<User> users = this.GetAll();

            string path = $"Path/EXPORT_USER_{DateTime.Now.ToString("dd/MM/mm/HH").Replace("/", "")}.txt";

            StreamWriter newText = File.CreateText(path);

            foreach (var user in users)
            {
                string query = $"{user.Name};{user.Phone};{user.Email};{user.Password}\n";
                newText.WriteLine(query);
            }

            newText.Close();

            return path;
        }
    }
}