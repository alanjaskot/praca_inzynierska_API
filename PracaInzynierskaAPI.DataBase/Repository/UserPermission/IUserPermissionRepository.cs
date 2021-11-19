using PracaInzynierskaAPI.Entities.UserPermission;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.DataBase.Repository.UserPermission
{
    public interface IUserPermissionRepository
    {
        
        public ResponseModel<List<UserPermissionDbModel>> GetAllByUserGuid(Guid userGuid);
        public ResponseModel<UserPermissionDbModel> GetByUserGuidAndPermission(Guid userGuid, string permitionName);
        public ResponseModel<List<Guid>> AddAllByUserGuid(List<UserPermissionDbModel> permisions);
        public ResponseModel<List<Guid>> DeleteAllByUserGuid(List<UserPermissionDbModel> permisions);
        public ResponseModel<Guid> DeletePermissionForUser(Guid userGuid, string permitionName);
    }
}
