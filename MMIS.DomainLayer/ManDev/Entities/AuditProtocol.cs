using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.ManDev.Entities
{
    public class AuditProtocol : EntityBase
    {
        public string DocumentTitle { get; set; }
        public string DocumentNumber { get; set; }
        public string DocumentType { get; set; }
        public DateTime IssueDate { get; set; }
        public string RevisionNumber { get; set; }
        public virtual ICollection<Scoping> Scopings {get;set;}
        public decimal TotalWeight { get; set; }
        public decimal TotalRated { get; set; }
        public decimal TotalScore { get; set; }
        public decimal OverallPerformance { get; set; }
    }

    public class Scoping
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public virtual AuditProtocol AP { get; set; }
        public string Parameter { get; set; }
        public decimal Weight { get; set; }
        public decimal Rating { get; set; }
        public decimal TotalScore { get; set; }
        public string AuditFindings { get; set; }
        public string BestPractice { get; set; }
    }
}
