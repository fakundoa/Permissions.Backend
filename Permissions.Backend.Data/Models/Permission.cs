using System;
using System.Collections.Generic;
using System.Text;

namespace Permissions.Backend.Data.Models
{
    public class Permission
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime Date { get; set; }

        public int PermissionTypeId { get; set; }

    }
}
