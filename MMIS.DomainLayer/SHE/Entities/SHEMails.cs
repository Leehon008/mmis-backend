using MMIS.DomainLayer.Entities.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class SHEMails : EntityBase
    {
      
        public string Plant { get;  set; }
       
        public string PositionID { get;  set; }
      
        public string Position { get; set; }

        public string Department { get; set; }


        public string Email { get; set; }
    

    }

    public class IncidentTypes : EntityBase
    {

        public string IncidentID { get; set; }

        public string IncidentType { get; set; }

        public string IncidentCategory { get; set; }



    }
}

    

