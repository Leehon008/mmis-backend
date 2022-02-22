 using MMIS.DomainLayer.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMIS.DomainLayer.Entities.Users
{
    public class UserRole: EntityBase
    {
        public UserRole() { }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleTypeId { get; set; }

        public string  RoleTypeDescription { get; set; }

       


    }
}
