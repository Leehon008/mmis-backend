using MMIS.DomainLayer.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMIS.DomainLayer.Entities.Users
{
    public class UserGroup: EntityBase
    {
        public UserGroup() { }
        public string UserGroupID { get; set; }
        public string GroupName    { get; set; }

    }
}
