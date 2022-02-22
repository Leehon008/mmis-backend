using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MMIS.DomainLayer.Authentication
{
    public class RoleModification
    {
        [Required]
        public string RoleName { get; set; }

        public string[] AddIds { get; set; }

        public string[] DeleteIds { get; set; }
    }

    public class UserModification
    {
        [Required]
        public string userName { get; set; }

        public string[] AddRoles { get; set; }

        public string[] DeleteRoles { get; set; }
    }

    public class UserCreation
    {
        [Required]
        public string userName { get; set; }

        public string[] Roles { get; set; }
    }

    public class RoleUsers
    {
        public ApplicationRole Role { get; set; }
        public IEnumerable<ApplicationUser> Members { get; set; }
    }

    public class UserRole
    {
        public ApplicationUser User { get; set; }
        public IEnumerable<ApplicationRole> Roles { get; set; }
    }
}
