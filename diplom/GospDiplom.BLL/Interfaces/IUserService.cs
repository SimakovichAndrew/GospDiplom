using GospDiplom.BLL.DTO;
using GospDiplom.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GospDiplom.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> CreateUser(/*string email, string userName, string password,*/ UserDTO userDto);

        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
        Task SetInitialData(UserDTO AdminDto, List<string> roles);
        UserDTO FindByName(/*int? id*/string name);
        Task<OperationDetails> EditRole(string name, string role, bool z);
    }

}
