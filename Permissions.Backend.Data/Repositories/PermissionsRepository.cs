using Permissions.Backend.Data.Models;
using Permissions.Backend.Data.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Permissions.Backend.Data.Repositories
{
    public class PermissionsRepository : IPermissionsRepository
    {
        private PermissionsContext _context;

        public PermissionsRepository(PermissionsContext permissionsContext)
        {
            _context = permissionsContext;
        }

        public Permission GetPermission(int id)
        {
            Permission permission = _context.Permissions.FirstOrDefault(x => x.Id == id);

            return permission;

        }

        public IList<Permission> GetPermissions()
        {
            IList<Permission> permissions = _context.Permissions.ToList();

            return permissions;
        }

        public PermissionType GetPermissionType(int id)
        {
            PermissionType permissionType = _context.PermissionsType.FirstOrDefault(x => x.Id == id);

            return permissionType;

        }

        public IList<PermissionType> GetPermissionTypes()
        {
            IList<PermissionType> permissionsType = _context.PermissionsType.ToList();

            return permissionsType;
        }

        public void SavePermission(Permission permission)
        {
            _context.Permissions.Add(permission);

            _context.SaveChanges();

        }

        public void UpdatePermission(Permission permission)
        {
            _context.Permissions.Update(permission);

            _context.SaveChanges();

        }

        public void Delete(Permission permission)
        {
            _context.Permissions.Remove(permission);

            _context.SaveChanges();

        }

        public void Detach(Permission permission)
        {
            _context.Entry<Permission>(permission).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
        }
    }
}
