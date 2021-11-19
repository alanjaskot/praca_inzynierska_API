using PracaInzynierskaAPI.Entities.User;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.DataBase.Repository.User
{
    public interface IUserRepository
    {
        
        public ResponseModel<IEnumerable<UserDbModel>> GetAll();
        public ResponseModel<UserDbModel> GetById(Guid id);
        public ResponseModel<UserDbModel> GetByEmail(string email);
        public ResponseModel<UserDbModel> GetByUserName(string login);
        public ResponseModel<UserDbModel> Login(string login, string password);
        public ResponseModel<bool> Ban(UserDbModel user);
        public ResponseModel<Guid> Add(UserDbModel user);
        public ResponseModel<long> AddLike(Guid userId, int plus = 1);
        public ResponseModel<Guid> Update(UserDbModel user);
        public ResponseModel<Guid> Delete(Guid id);
    }
}
