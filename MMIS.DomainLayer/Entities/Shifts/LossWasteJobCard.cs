using MMIS.DomainLayer.Entities.Shared;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Entities.Shifts
{
    public class LossWasteJobCard
    {
      
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public string JobCardNo { get; private set;  }
        public string WONumber { get; set; }
        public string AssignedTo { get; set; }
        public DateTime TargetCompTime { get; set; }
        public int FaultId { get;private set; }
  
        public DateTime CreatedOn { get;private set; }
        public string FaultNo { get; private set; }
        public virtual LossWasteFaults LossWaste { get; set; }
    }
}

