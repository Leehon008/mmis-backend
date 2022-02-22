using MMIS.DomainLayer.Entities.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class CommunicationPlan : EntityBase
    {
        [Required]
        public string CommunicationType { get;  set; }
        [Required]
        public string Information { get;  set; }
        [Required]
        public string Recipient { get; set; }
        [Required]
        public string WhenToCommunicate { get; set; }
        [Required]
        public string ModeOfCommunication { get; set; }
     
        public string Plant { get; set; }
        [Required]
        public string FeedBackChannel { get; set; }
        [Required]
        public string Initiator { get; set; }
        [Required]
        public string Communicator { get; set; }
        [Required]
               
        public string CreatedBy { get; set; }
     



    }
}

    

