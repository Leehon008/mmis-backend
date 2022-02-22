using MMIS.DomainLayer.Entities.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{

    public class Suggestions
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public long Id { get; set; }


        public string ExplanationOfSuggestion { get; set; }

        public string benefit { get; set; }

        public string Cost { get; set; }

        public string EstimatedCost { get; set; }

        public string risk { get; set; }

        public string RiskExplanation { get; set; }

        public string RiskOtherExplanation { get; set; }

        public string Explanation { get; set; }
        [Required]
        public string Plant { get; set; }
        public string Department { get; set; }

        public string CreatedBy { get; set; }

        public string NameOfSuggestor { get; set; }

        public DateTime dateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public string ReviewerAdditions { get; set; }

        public string RecommendedAction { get; set; }

        public string Responsibility { get; set; }

        public DateTime DueDate { get; set; }

        public string ClosureStatus { get; set; }

        public string Remarks { get; set; }

        public string ReviewStatus { get; set; }


    }


    public class MedicalData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public long Id { get; set; }
        [Required]

        public string FirstName { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string EmployeeNumber { get; set; }
        [Required]
        public string JobTitle { get; set; }
        [Required]
        public string Department { get; set; }

        public DateTime DateCreated { get; set; }
        [Required]
        public DateTime DateModified { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public string Plant { get; set; }

        public string Centre { get; set; }

        public string Comment { get; set; }
        public virtual ICollection<Medicals> Medicals { get; set; }

    }
    public class Medicals
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public long Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public DateTime MedicalDate { get; set; }
        [Required]
        public DateTime MedicalDue { get; set; }
       
        public int DaysLeft { get; set; }

        public string Comment { get; set; }
        public virtual MedicalData MedicalData { get; set; }
    }
    public class PermitsAndLicenses : EntityBase
    {
        public string Sbu { get; set; }
        [Required]
        public string Site { get; set; }
        [Required]
        public string LicenceRequired { get; set; }
        [Required]
        public string WhereLicenseObtained { get; set; }
        [Required]
        public double CostOfLicense { get; set; }
        [Required]
        public string ModeOfPayment { get; set; }
        [Required]
        public string Process { get; set; }
        [Required]
        public string ContactEmployee { get; set; }
        [Required]
        public string IntermediaryInvolved { get; set; }
        [Required]
        public string Intermediary { get; set; }
        [Required]
        public string IntermediaryRole { get; set; }
        [Required]
        public string IntermediaryFeeStructure { get; set; }
        [Required]
        public string FrequencyOfRenewal { get; set; }
        [Required]
        public string AntiCorruptionTraining { get; set; }
        [Required]
        public string LicenseStatus { get; set; }
        public double FinesLevied { get; set; }

        [Required]
        public string FinesPossibility { get; set; }

        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public string Plant { get; set; }
    }
    public class MonitoringPlan : EntityBase
    {
        public string NosaElement { get; set; }
        [Required]

        public string Activity { get; set; }
        [Required]

        public string Type { get; set; }

        [Required]
        public string SapScheduleNo { get; set; }
        [Required]

        public string ResponsiblePerson { get; set; }
        [Required]

        public string Frequency { get; set; }
        [Required]
        public string DocumentRetentionPlace { get; set; }
        [Required]
        public string Vendor { get; set; }
        [Required]
        public string CurrentDate { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public double cost { get; set; }
        [Required]
        public string Comments { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public string Plant { get; set; }
    }

    public class SustainableDevelopment : EntityBase
    {
        public string RefNo { get; set; }
        [Required]
        public virtual ICollection<SDParameters> SDParameters { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        public double Total { get; set; }
        [Required]
        public string Plant { get; set; }
    }
    public class SDParameters : EntityBase
    {
        [Required]
        public string ParameterName { get; set; }
        [Required]
        public string ParameterValue { get; set; }
        [Required]
        public string ParameterLocation { get; set; }
        public virtual SustainableDevelopment SustainableDevelopment { get; set; }
    }

    public class HighRiskTaskObservationRecords : EntityBase
    {
        public DateTime DateObserved { get; set; }
        [Required]
        public string SopTitled { get; set; }
        [Required]
        public string SopNumberd { get; set; }
        [Required]
        public string Departmentd { get; set; }
        [Required]
        public string PersonObserved { get; set; }
        [Required]
        public string Designationd { get; set; }
        [Required]
        public string Observed { get; set; }
        [Required]
        public string ReasonForObservationd { get; set; }
        [Required]
        public string FilePath { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public string Plant { get; set; }
    }


    public class AuditRecords : EntityBase
    {
        public string RefNo { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string Centre { get; set; }
        [Required]
        public string Auditor { get; set; }
        [Required]
        public string Auditee { get; set; }
        [Required]
        public DateTime AuditDate { get; set; }
        [Required]
        public double AuditScore { get; set; }
        [Required]
        public string AuditDue { get; set; }
        [Required]
        public string FilePath { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public string Plant { get; set; }
    }



    public class InductionRequest : EntityBase
    {
        public string InductionRequestTo { get; set; }
        [Required]
        public string InductionRequestFrom { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string SheReceivedBY { get; set; }
        [Required]
        public DateTime ScheduledDate { get; set; }
        [Required]
        public double NoOfInductees { get; set; }
        [Required]
        public string WorkstationLocation { get; set; }
        public virtual ICollection<JobTitle> JobTitle { get; set; }
        [Required]
        public string Plant { get; set; }
        public string JobFunction { get; set; }
        [Required]
        public double Duration { get; set; }
        [Required]
        public string Hazards { get; set; }
        [Required]
        public string HODApproval { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        public DateTime DateReceived { get; set; }
        public DateTime DateToSupervisor { get; set; }
    }
    public class JobTitle : EntityBase
    {
        public string title { get; set; }
        public virtual InductionRequest InductionRequest { get; set; }

    }



    public class InductionInventory : EntityBase
    {
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string CompanyNumber { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public DateTime DateOfInduction { get; set; }
        [Required]
        public string departmentAssignedTo { get; set; }
        [Required]
        public string InductionDoneBy { get; set; }
        [Required]
        public DateTime DateOfMeedicalExamination;
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public string Plant { get; set; }
        
    }

    public class InductionInventoryContractors:EntityBase
    {
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string IdNumber { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        public string DepartmentAssignedTo { get; set; }
        [Required]
        public string Expiry { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string InductionDoneBy { get; set; }
        [Required]
        public DateTime DateOfInduction { get; set; }
        public DateTime DateOfMeedicalExamination { get; set; }
        public string CreatedBy { get; set; }
    
        public string Plant { get; set; }
    }

}

