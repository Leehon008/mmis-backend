using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using MMIS.CommonLayer.Automapper.Contracts;
using MMIS.DomainLayer.Entities.Shared;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class ChangeManagementModel :  IHaveCustomMappings
    {

[DisplayName("ProjectName")]
        public string ProjectName { get; set; }
        [DisplayName("DateDubmitted")]
        public DateTime DateDubmitted { get; set; }
        [DisplayName("ChangeInitiator")]
        public string ChangeInitiator { get; set; }
        [DisplayName("ChangeSponsor")]
        public string ChangeSponsor { get; set; }
        [DisplayName("ProjectManager")]
        public string ProjectManager { get; set; }
        [DisplayName("ChangeType")]
        public string ChangeType { get; set; }
        [DisplayName("ChangeTypeOther")]
        public string ChangeTypeOther { get; set; }
[DisplayName("ChangeReason")]
        public string ChangeReason { get; set; }
        [DisplayName("ChangeReasonOther")]
        public string ChangeReasonOther { get; set; }
[DisplayName("ChangeImpact")]
        public string ChangeImpact { get; set; }
        [DisplayName("RequestedCompletionDate")]
        public string RequestedCompletionDate { get; set; }
        [DisplayName("TitleOfChange")]
        public string TitleOfChange { get; set; }
        [DisplayName("DescriptionOfBusinessProblem")]
        public string DescriptionOfBusinessProblem { get; set; }
        [DisplayName("ImpactOfNoChange")]
        public string ImpactOfNoChange { get; set; }
        [DisplayName("SystemBehaviour")]
        public string SystemBehaviour { get; set; }
        [DisplayName("ChangeRequiremenets")]
        public string ChangeRequiremenets { get; set; }
        [DisplayName("CostImpact")]
        public string CostImpact { get; set; }
        [DisplayName("ResourceImpact")]
        public string ResourceImpact { get; set; }
        [DisplayName("ReviewDate")]
        public DateTime ReviewDate { get; set; }
        [DisplayName("ReviewdBy")]
        public string ReviewdBy { get; set; }
        [DisplayName("Recommendation")]
        public string Recommendation { get; set; }
        [DisplayName("RecommendationNotes")]
        public string RecommendationNotes { get; set; }
        [DisplayName("Priority")]
        public string Priority { get; set; }
        [DisplayName("FilePath")]
        public string FilePath { get; set; }
[DisplayName("Plant")]
        public string Plant { get; set; }
		[DisplayName("Status")]
        public string Status { get; set; }
		[DisplayName("AssignedTo")]
        public string AssignedTo { get; set; }
		
[DisplayName("ExpectedResolutionDate")]
        public DateTime ExpectedResolutionDate { get; set; }
		[DisplayName("Escalation")]
        public string Escalation { get; set; }
		[DisplayName("ActionSteps")]
        public string ActionSteps { get; set; }
		[DisplayName("ActualResolutionDate")]
        public DateTime ActualResolutionDate { get; set; }
		[DisplayName("FinalResolution")]
        public string FinalResolution { get; set; }
        public bool Active { get; set; }
        [NotMapped]
        public IFormFile files { get; set; }

        public void CreateMaps(MapperConfigurationExpression config)
        {
            config.CreateMap<ChangeRequest, ChangeManagementModel>().ReverseMap();
        }
    }
}

