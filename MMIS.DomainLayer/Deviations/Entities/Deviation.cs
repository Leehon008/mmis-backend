using MMIS.DomainLayer.ManDev;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.Deviations.Entities
{
    public class Deviation : EntityBase
    {
        public string Function { get; set; }
        public string DCT { get; set; }
        public string Type { get; set; }
        public virtual ICollection<DParam> Parameters { get; set; }
        public string RootCause { get; set; }
        public virtual ICollection<CorrectiveAction> CorrectiveActions { get; set; }
        public string Impact { get; set; }
        public virtual ICollection<TechnicalApproval> TechnicalApproval { get; set; }
        public virtual ICollection<Approval> Approvals { get; set; }
    }

    public class DParam
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Standard { get; set; }
        public string Required { get; set; }
        public virtual Deviation D { get; set; }
    }
    public class CorrectiveAction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public string Action { get; set; }
        public DateTime When { get; set; }
        public string Who { get; set; }
        public virtual Deviation D { get; set; }
    }
    public class TechnicalApproval
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Condition { get; set; }
        public DateTime Date { get; set; }
        public DateTime ExpiryDate { get; set; }
        public virtual Deviation D { get; set; }
    }
    public class Approval
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public bool Approve { get; set; }
        public DateTime Date { get; set; }
        public int Level { get; set; }
        public virtual Deviation D { get; set; }
    }
}
