using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using MMIS.CommonLayer.Automapper.Contracts;
using MMIS.DomainLayer.Entities.Shared;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class ChangeRequestDto :  IHaveCustomMappings
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

        [NotMapped]
        public IFormFile files { get; set; }

        public void CreateMaps(MapperConfigurationExpression config)
        {
            config.CreateMap<ChangeRequest, ChangeRequestDto>().ReverseMap();
        }




    }
}

