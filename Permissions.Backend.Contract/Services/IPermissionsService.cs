using Permissions.Backend.Contract.Dtos;
using Permissions.Backend.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Permissions.Backend.Contract.Services
{
    public interface IPermissionsService
    {
        IList<PermissionResponse> GetPermissions();

        PermissionResponse GetPermission(int id);

        PermissionTypeResponse GetPermissionType(int id);

        IList<PermissionTypeResponse> GetPermissionTypes();

        void SavePermission(PermissionDTO permission);

        void UpdatePermission(PermissionDTO permission);

        void Delete(int permissionId);
    }
}
