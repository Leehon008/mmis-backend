using MMIS.DomainLayer.Entities.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{

   
    public class  TrainingMatrix:EntityBase
    {
        public string Ref { get; set; }
        [Required]
     
        public string Center { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string EmployeeNumber { get; set; }
        [Required]
        public string JobTitle { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string CreatedBy { get; set; }

        public virtual ICollection<Trainings> Trainings { get; set; }

        public string Plant { get; set; }
    }

     public class  Trainings: EntityBase
    {
        public string TrainingName { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public DateTime DateTrained { get; set; }
        [Required]
        public DateTime RetrainingDue { get; set; }
        [Required]

        public int RetrainingDaysLeft { get; set; }

        public virtual TrainingMatrix TrainingMatrix { get; set; }
    }

 
 public class  ChangeRequest: EntityBase
    {
  
        public string ProjectName { get; set; }
        [Required]
        public DateTime DateDubmitted { get; set; }
        [Required]
        public string ChangeInitiator { get; set; }
        [Required]
        public string ChangeSponsor { get; set; }
        [Required]
        public string ProjectManager { get; set; }
        [Required]
        public string ChangeType { get; set; }
        [Required]
        public string ChangeTypeOther { get; set; }

        public string ChangeReason { get; set; }
        [Required]
        public string ChangeReasonOther { get; set; }

        public string ChangeImpact { get; set; }
        [Required]
        public string RequestedCompletionDate { get; set; }
        [Required]
        public string TitleOfChange { get; set; }
        [Required]
        public string DescriptionOfBusinessProblem { get; set; }
        [Required]
        public string ImpactOfNoChange { get; set; }
        [Required]
        public string SystemBehaviour { get; set; }
        [Required]
        public string ChangeRequiremenets { get; set; }
        [Required]
        public string CostImpact { get; set; }
        [Required]
        public string ResourceImpact { get; set; }
        [Required]
        public DateTime ReviewDate { get; set; }
        [Required]
        public string ReviewdBy { get; set; }
        [Required]
        public string Recommendation { get; set; }
        [Required]
        public string RecommendationNotes { get; set; }
        [Required]
        public string Priority { get; set; }
        [Required]
        public string FilePath { get; set; }

        public string Plant { get; set; }
        public string Status { get; set; }
        public string AssignedTo { get; set; }
        public DateTime ExpectedResolutionDate { get; set; }
        public string Escalation { get; set; }
        public string ActionSteps { get; set; }
        public DateTime ActualResolutionDate { get; set; }
        public string FinalResolution { get; set; }


    }

 

 public class  SafeWorkMethod: EntityBase
    {
        public string ContracterResponsible { get; set; }
        [Required]
       
        public string PersonForSWMS { get; set; }
      
        public string ReviewedBy { get; set; }
      
        [Required]
        public string Location { get; set; }
        
        [Required]
        public string Scope { get; set; }
        [Required]
      
        public virtual ICollection<TasksInvolved> TasksInvolved { get; set; }
        [Required]
        public string CommunicationProcedure { get; set; }
        [Required]
        public string ProjectManagerApproval { get; set; }
        [Required]
        public string ContractorSiteApproval { get; set; }
        [Required]
        public virtual ICollection<SwmsTeam> SwmsTeam { get; set; }
        [Required]
        public string ResponsibleManager { get; set; }

        public DateTime ResponsibleManagerDate { get; set; }

        public string EngineeringManager { get; set; }

        public DateTime EngineeringManagerDate { get; set; }


    }
     public class  TasksInvolved:EntityBase
    {
        public string Task { get; set; }
        [Required]
        public string WorkMethod { get; set; }
        [Required]
        public string Responsibility { get; set; }
        public virtual SafeWorkMethod SafeWorkMethod { get; set; }

    }
     public class  SwmsTeam:EntityBase
    {
        public string Name { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public virtual SafeWorkMethod SafeWorkMethod { get; set; }

    }
}
