using MMIS.DomainLayer.Entities.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{


    public class IncidentLogging:EntityBase
    {
        
        public string IncidentNumber { get; private set; }
        public string Company { get; private set; }
        [Required]
        public string createdBy { get; set; }
        [Required]
        public int EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string JobTitle { get; set; }
        public string FacilityWhereIncidentOcurred { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string Centre { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string DepartmentAssignedToNon { get; set; }
        [Required]
        public string Supervisor { get; set; }
        public string HomeAddress { get; set; }
        [Required]
        public string MobilePhoneNumber { get; set; }
        public string HomePhone { get; set; }
        public string OtherPhone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        [Required]
        public string EmploymentStatus { get; set; }
        [Required]
        public string ShiftDay { get; set; }
        [Required]
        public string ShiftTime { get; set; }
        [Required]
        public DateTime DateTimeOcurred { get; set; }
        [Required]
        public DateTime DateTimeReported { get; set; }
        [Required]
        public string DepartmentWhereOcurred { get; set; }
        [Required]
        public string InjuryClassification { get; set; }
        public double ManLostHours { get; set; }
        //public double LostManHours { get; set; }
        //[Required]
        public string VehicleRelated { get; set; }
      
        public string InjuryOnCompanyBusiness { get; set; }
        
        public string InjuryWhileCommuting { get; set; }
      
        public string IncidentCause { get; set; }
        [Required]
        public string IncidentSubCategory { get; set; }
        public string IncidentResult { get; set; }
        public string IncidentResultOther { get; set; }
    
        public string LocalAuthorities { get; set; }
        
        public string MediaInvolvement { get; set; }
       
        public string RegulatoryAgency { get; set; }
      
        public string RegulatoryAgencyInvolved { get; set; }
        public string RegulatoryFines { get; set; }
        public double AmountOfFines { get; set; }
        public string FinesCurrency { get; set; }
       
        public string ManagerDescription { get; set; }
        public string EmployeeDescription { get; set; }
        public string StepsToPreventIncident { get; set; }
        public string Status { get; set; }
       
        public virtual ICollection<Witnesses> Witnesses { get; set; }
       
        public virtual ICollection<Documents> Documents { get; set; }
         public virtual ICollection<AffectedBodyPart> AffectedBodyPart { get; set; }
      
        public virtual ICollection<NatureOfIllness> NatureOfIllness { get; set; }

    }

    public class AffectedBodyPart : EntityBase
    {
        public string BodyPart { get; set; }
        public string Value { get; set; }
        public virtual IncidentLogging IncidentLogging { get; set; }
    }

    public class NatureOfIllness : EntityBase
    {
        public string Illness { get; set; }
        public string Value { get; set; }
        public virtual IncidentLogging IncidentLogging { get; set; }
    }
    public class Witnesses:EntityBase
    {

        public DateTime WitnessDate { get; set; }
        public string WitnessName { get; set; }
        public string WitnessPhoneNumber { get; set; }
        public virtual IncidentLogging IncidentLogging { get; set; }
    }
    public class Documents : EntityBase
    {
        public string FilePath { get; set; }
        public string description { get; set; }
        public virtual IncidentLogging IncidentLogging { get; set; }
    }

}



