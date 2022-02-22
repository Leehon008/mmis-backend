using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMIS.DomainLayer.Authentication
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
        {

        }

        public ApplicationRole(string name)
        {
            this.Name = name;
        }

        public ApplicationRole(string roleName, string userGroup, string roleType, string createdBy)
        {
            this.Name = roleName;
            this.Created = DateTime.Now;
            this.CreatedBy = createdBy;
            this.Usergroup = userGroup;
            this.RoleType = roleType;
        }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string Usergroup { get; set; }
        public string RoleType { get; set; }
    }
    
    public static class UserRoles
    {
        //Admin role
        public const string Admin = "Admin";

        //Standard role
        public const string Standard = "Standard";

        //Admin Reg Key
        public static string RegKey = "2021-CREAMv1-(734m";
    }
}
