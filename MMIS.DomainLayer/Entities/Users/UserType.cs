using MMIS.DomainLayer.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMIS.DomainLayer.Entities.Users
{

   
   public  class UserType: EntityBase
    {
        public UserType() { }
        public string UserTypeId  { get; set; }
        public string  userType   { get; set; }
    }
}
