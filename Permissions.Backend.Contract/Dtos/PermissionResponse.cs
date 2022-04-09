using System;
using System.Collections.Generic;
using System.Text;

namespace Permissions.Backend.Contract.Dtos
{
    public class PermissionResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Date { get; set; }

        public PermissionTypeResponse PermissionType { get; set; }
    }
}
