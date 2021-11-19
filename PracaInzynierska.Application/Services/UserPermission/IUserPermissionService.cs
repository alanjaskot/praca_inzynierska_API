using PracaInzynierska.Application.DTO.UserPermission;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Application.Services.UserPermission
{
    public interface IUserPermissionService
    {
        public ResponseModel<List<UserPermissionDTO>> GetAllPermissionsByUserGuid(Guid userGuid);
        public ResponseModel<UserPermissionDTO> GetPermitionByUserGuidAndPermission(Guid userGuid, string permitionName);
        public ResponseModel<List<Guid>> AddPermissionsByUserGuid(List<UserPermissionDTO> permisions);
        public ResponseModel<List<Guid>> DeleteAllPermissionsByUserGuid(List<UserPermissionDTO> permisions);
        public ResponseModel<Guid> DeletePermitionForUser(Guid userGuid, string permitionName);
    }
}
