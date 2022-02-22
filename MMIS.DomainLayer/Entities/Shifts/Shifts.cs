using Castle.Components.DictionaryAdapter;
using MMIS.DomainLayer.Entities.Plants;
using MMIS.DomainLayer.Entities.Shared;
using MMIS.DomainLayer.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.Entities.Shifts
{
    public class Shifts: EntityBase
    {

       
        public string ShiftId { get; set; }
        public string ShiftName { get; set; }
        public string UserGroupId { get; set; }
        public string PlantId { get; set; }

    }
}

