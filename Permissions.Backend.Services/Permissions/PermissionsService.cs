using Permissions.Backend.Contract.Dtos;
using Permissions.Backend.Contract.Services;
using Permissions.Backend.Data.Models;
using Permissions.Backend.Data.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Permissions.Backend.Services.Permissions
{
    public class PermissionsService : IPermissionsService
    {
        private IPermissionsRepository _permissionsRepository;

        public PermissionsService(IPermissionsRepository permissionsRepository)
        {
            _permissionsRepository = permissionsRepository;
        }

        public PermissionResponse GetPermission(int id)
        {
            var permission = _permissionsRepository.GetPermission(id);

            if (permission == null)
                throw new InvalidOperationException("No existe el permiso que ha elegido.");

            return ConvertToPermissionResponse(permission);
        }

        public PermissionTypeResponse GetPermissionType(int id)
        {
            var permissionType = _permissionsRepository.GetPermissionType(id);

            if (permissionType == null)
                throw new InvalidOperationException("No existe el tipo de permiso que ha elegido.");

            return ConvertToPermissionTypeResponse(permissionType);

        }

        public IList<PermissionResponse> GetPermissions()
        {
            var permissionResponse = new List<PermissionResponse>();

            var permissions = _permissionsRepository.GetPermissions();

            foreach (var permission in permissions)
            {
                permissionResponse.Add(ConvertToPermissionResponse(permission));
            }

            return permissionResponse;
        }

        public IList<PermissionTypeResponse> GetPermissionTypes()
        {
            var permissionsTypeResponse = new List<PermissionTypeResponse>();

            var permissionsType = _permissionsRepository.GetPermissionTypes();

            foreach (var permissionType in permissionsType)
            {
                permissionsTypeResponse.Add(ConvertToPermissionTypeResponse(permissionType));
            }

            return permissionsTypeResponse;
        }

        public void SavePermission(PermissionDTO permissionDTO)
        {
            ValidatePermissionDTO(permissionDTO, false);

            Permission permission = ConvertToPermission(permissionDTO, false);

            _permissionsRepository.SavePermission(permission);
        }

        public void UpdatePermission(PermissionDTO permissionDTO)
        {
            ValidatePermissionDTO(permissionDTO, true);

            Permission permission = ConvertToPermission(permissionDTO, true);

            _permissionsRepository.UpdatePermission(permission);
        }

        public void Delete(int permissionId)
        {
            Permission permission = _permissionsRepository.GetPermission(permissionId);

            if (permission == null)
            {
                throw new InvalidOperationException("No existe el permiso que desea eliminar");
            }

            _permissionsRepository.Delete(permission);
        }


        #region Private Methods

        private Permission ConvertToPermission(PermissionDTO permissionDTO, bool isUpdating)
        {
            if (!isUpdating) permissionDTO.Id = 0;

            return new Permission()
            {
                Id = permissionDTO.Id,
                Name = permissionDTO.Name,
                LastName = permissionDTO.LastName,
                Date = permissionDTO.Date,
                PermissionTypeId = permissionDTO.PermissionTypeId
            };
        }

        private PermissionResponse ConvertToPermissionResponse(Permission permission)
        {
            return new PermissionResponse()
            {
                Id = permission.Id,
                Name = permission.Name,
                LastName = permission.LastName,
                Date = permission.Date.ToString("yyyy-MM-dd"),
                PermissionType = GetPermissionType(permission.PermissionTypeId)
            };
        }

        private PermissionTypeResponse ConvertToPermissionTypeResponse(PermissionType permissionType)
        {
            return new PermissionTypeResponse()
            {
                Id = permissionType.Id,
                Description = permissionType.Description
            };
        }

        private void ValidatePermissionDTO(PermissionDTO permissionDTO, bool isUpdating)
        {
            if (isUpdating)
            {
                var PermissionInDB = _permissionsRepository.GetPermission(permissionDTO.Id);

                if (PermissionInDB == null)
                    throw new InvalidOperationException("No existe el permiso que ha elegido.");
                else
                    _permissionsRepository.Detach(PermissionInDB);

            }

            var permissionType = GetPermissionType(permissionDTO.PermissionTypeId);

            if (permissionType == null)
            {
                throw new InvalidOperationException("No existe el tipo de permiso que ha elegido.");
            }

        }
        #endregion
    }
}
