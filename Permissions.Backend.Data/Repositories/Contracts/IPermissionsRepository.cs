using Permissions.Backend.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Permissions.Backend.Data.Repositories.Contracts
{
    public interface IPermissionsRepository
    {
        IList<Permission> GetPermissions();

        Permission GetPermission(int id);

        PermissionType GetPermissionType(int id);

        IList<PermissionType> GetPermissionTypes();
        
        void SavePermission(Permission permission);

        void UpdatePermission(Permission permission);

        void Delete(Permission permission);

        void Detach(Permission permission);
    }
}
