using GospDiplom.BLL.DTO;
using GospDiplom.BLL.Infrastructure;
using GospDiplom.BLL.Interfaces;
using GospDiplom.DAL.Entities;
using GospDiplom.DAL.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace GospDiplom.BLL.Service
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<OperationDetails> CreateUser(UserDTO userDto)
        {
            ApplicationUser user = await Database.UserManager.FindByNameAsync(userDto.UserName);
            if (user == null)
            {
                user = new ApplicationUser { PasswordHash = userDto.Password, UserName = userDto.UserName, Email=userDto.Email };
                var result = await Database.UserManager.CreateAsync(user, userDto.Password);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                // добавляем роль
                await Database.UserManager.AddToRoleAsync(user.Id, userDto.Role);
                // создаем профиль клиента
                ClientProfile clientProfile = new ClientProfile { Id = user.Id, Address = userDto.Address, LastName = userDto.LastName };
                Database.ClientManager.Create(clientProfile);
                await Database.SaveAsync();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");

            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }

        public async Task<OperationDetails> EditRole(string name, string role,bool z)
        {
            ApplicationUser user = await Database.UserManager.FindByNameAsync(name);
            if (user != null)
            {
                if (z)
                {
                    await Database.UserManager.AddToRoleAsync(user.Id, role);
                   
                }
                else
                {
                    await Database.UserManager.RemoveFromRoleAsync(user.Id, role);
                }

                await Database.SaveAsync();
                return new OperationDetails(true, "Изменения сохранены", "");
            }

            else
            {
                return new OperationDetails(false, "Пользователь с таким именем уже существует", "LastName");
            }
           
        }





        public UserDTO userDTO(int id)
        {
            var com = Database.ClientManager.FindId(id);
            return new UserDTO { Id = com.Id, LastName = com.LastName, UserName = com.ApplicationUser.UserName, Password = com.ApplicationUser.PasswordHash, Address=com.Address, Role = com.ApplicationUser.Roles.First().ToString()};
            throw new NotImplementedException();
        }


        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            // находим пользователя
            ApplicationUser user = await Database.UserManager.FindAsync(userDto.UserName, userDto.Password);
            // авторизуем его и возвращаем объект ClaimsIdentity
            if (user != null)
                claim = await Database.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }


        // начальная инициализация бд
        public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await Database.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    await Database.RoleManager.CreateAsync(role);
                }
            }

            await CreateUser(adminDto);
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public UserDTO FindByName(string name/*int? id*/)
        {
            if (/*id*/name==null)
                throw new System.ComponentModel.DataAnnotations.ValidationException("Имя не набрано"/*, ""*/);
            var com = Database.UserManager.FindByName(name);
            if (com == null)
                throw new System.ComponentModel.DataAnnotations.ValidationException("Имя не найдено"/*, ""*/);

            return new  UserDTO { Id = com.Id, LastName = com.ClientProfile.LastName, UserName = com.UserName, Password = com.PasswordHash, Role=com.Roles.FirstOrDefault().ToString(), Address=com.ClientProfile.Address};
            throw new NotImplementedException();
        }
    }
}

