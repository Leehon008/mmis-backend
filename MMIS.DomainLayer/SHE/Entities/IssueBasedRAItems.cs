using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class IssueBasedRAItems
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        public string DocumentNo { get; private set; }
        public string PotentialHazard { get;  set; }
        public string Task { get; set; }
        public string Risk { get; set; }
        public string AffectedPerson { get; set; }
        public string ExistingMeasures { get; set; }
        public string RiskRating { get; set; }
        public string PreventionMeasures { get; set; }
        public string Responsibilities { get; set; }
        public DateTime TargetCompletion { get; set; }
 
        public virtual IssueBasedRAHeader IssueBasedRAHeader { get; set; }

    }
}

