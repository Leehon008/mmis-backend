using MMIS.DomainLayer.Entities.Shared;
using MMIS.DomainLayer.SHE.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{

    // Incident Cause

    public class IncidentCauses : EntityBase
    {
        public string IncidentNumber { get; set; }
        public string IndividualsInvolved { get; set; }

        public string Status { get; set; }
        public string WorkEnvironment { get; set; }
        public string Equipment { get; set; }
        public string Methods { get; set; }
        public string Organization { get; set; }
        public string ImmediateCause { get; set; }

        public string VpoType { get; set; }
        public string DpoType { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public virtual ICollection<IncidentWhys> IncidentWhys { get; set; }
        public virtual ICollection<IncidentRootCauseConditions> IncidentRootCauseConditions { get; set; }
        public virtual ICollection<IncidentRootCauseActions> IncidentRootCauseActions { get; set; }
        public virtual ICollection<IncidentImmediateCauseConditions> IncidentImmediateCauseConditions { get; set; }
    }

    public class IncidentWhys : EntityBase
    {
        public string Why { get; set; }
        public virtual IncidentCauses IncidentCauses { get; set; }
    }

    public class IncidentImmediateCauseConditions : EntityBase
    {
        public string Condition { get; set; }
        public virtual IncidentCauses IncidentCauses { get; set; }
    }

    public class IncidentRootCauseActions : EntityBase
    {
        public string RootCause { get; set; }
        public virtual IncidentCauses IncidentCauses { get; set; }
    }

    public class IncidentRootCauseConditions : EntityBase
    {
        public string RootCauseCondition { get; set; }
        public virtual IncidentCauses IncidentCauses { get; set; }
    }
}