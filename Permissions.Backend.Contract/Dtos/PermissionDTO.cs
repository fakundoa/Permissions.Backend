using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Permissions.Backend.Contract.Dtos
{
    public class PermissionDTO
    {
        [Required] 
        public int Id { get; set; }

        [Required] 
        public string Name { get; set; }

        [Required] 
        public string LastName { get; set; }

        [Required] 
        public DateTime Date { get; set; }

        [Required] 
        public int PermissionTypeId { get; set; }
    }
}
