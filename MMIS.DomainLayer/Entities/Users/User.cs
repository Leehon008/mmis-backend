using Castle.Components.DictionaryAdapter;
using MMIS.DomainLayer.Entities.Plants;
using MMIS.DomainLayer.Entities.Shared;
using MMIS.DomainLayer.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.Entities.Users
{
    public class UserOld : EntityBase
    {


        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CreatedBy { get; set; }
        public string Email { get; set; }
        public string Cell { get; set; }
        public string PlantId { get; set; }
        public string UsergroupID { get; set; }
        public string UserTypeID { get; set; }

        public string Designation { get; set; }
      

    }
}

