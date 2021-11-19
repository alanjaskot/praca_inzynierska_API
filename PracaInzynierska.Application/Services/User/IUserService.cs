using PracaInzynierska.Application.DTO.User;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Application.Services.User
{
    public interface IUserService
    {
        public ResponseModel<IEnumerable<UserDTO>> GetAllUsers();
        public ResponseModel<UserDTO> GetUserById(Guid id);
        public ResponseModel<UserDTO> GetUserByEmail(string email);
        public ResponseModel<UserDTO> GetUserByUserName(string login);
        public ResponseModel<UserDTO> Login(string emailOrUserName, string password);
        public ResponseModel<Guid> UpdateUser(UserDTO userModel);
        public ResponseModel<Guid> AddUser(UserDTO userModel);
        public ResponseModel<Guid> DeleteUser(Guid guid);
    }
}
