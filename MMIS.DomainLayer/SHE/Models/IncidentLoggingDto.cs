using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using MMIS.CommonLayer.Automapper.Contracts;
using MMIS.DomainLayer.Entities.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{


    public class IncidentLoggingDto : EntityBase, IHaveCustomMappings
    {
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
        [Required]
        public string VehicleRelated { get; set; }
        [Required]
        public string InjuryOnCompanyBusiness { get; set; }
        [Required]
        public string InjuryWhileCommuting { get; set; }
        [Required]
        public string IncidentCause { get; set; }
        [Required]
        public string IncidentSubCategory { get; set; }
        public string IncidentResult { get; set; }
        public string IncidentResultOther { get; set; }
        [Required]
        public string LocalAuthorities { get; set; }
        [Required]
        public string MediaInvolvement { get; set; }
        [Required]
        public string RegulatoryAgency { get; set; }
        [Required]
        public string RegulatoryAgencyInvolved { get; set; }
        public string RegulatoryFines { get; set; }
        public double AmountOfFines { get; set; }
        public string FinesCurrency { get; set; }
        [Required]
        public string ManagerDescription { get; set; }
        public string EmployeeDescription { get; set; }
        public string StepsToPreventIncident { get; set; }
        public string Status { get; set; }
     
        public virtual ICollection<WitnessesDto> Witnesses { get; set; }
       
        public virtual ICollection<DocumentsDto> Documents { get; set; }
        
        public virtual ICollection<AffectedBodyPartDto> AffectedBodyPart { get; set; }
       
        public virtual ICollection<NatureOfIllnessDto> NatureOfIllness { get; set; }
        public void CreateMaps(MapperConfigurationExpression config)
        {
            config.CreateMap<IncidentLogging, IncidentLoggingDto>().ReverseMap();
            //config.CreateMap<IncidentLogging, IncidentLoggingDto>()
            //.ForMember(dest => dest.AffectedBodyPart, opt => opt.MapFrom(src => src.AffectedBodyPart))
            //.ForMember(dest => dest.Documents, opt => opt.MapFrom(src => src.Documents))
            //.ForMember(dest => dest.Witnesses, opt => opt.MapFrom(src => src.Witnesses))
            //.ForMember(dest => dest.NatureOfIllness, opt => opt.MapFrom(src => src.NatureOfIllness));

        }
     


           
    }

    public class AffectedBodyPartDto : EntityBase
    {
        public string BodyPart { get; set; }
        public string Value { get; set; }
        public virtual IncidentLogging IncidentLogging { get; set; }
    }

    public class NatureOfIllnessDto : EntityBase
    {
        public string Illness { get; set; }
        public string Value { get; set; }
        public virtual IncidentLogging IncidentLogging { get; set; }
    }
    public class WitnessesDto:EntityBase
    {

        public DateTime WitnessDate { get; set; }
        public string WitnessName { get; set; }
        public string WitnessPhoneNumber { get; set; }
        public virtual IncidentLogging IncidentLogging { get; set; }
    }
    public class DocumentDto : EntityBase
    {
        public string FilePath { get; set; }
        public string description { get; set; }
        public virtual IncidentLogging IncidentLogging { get; set; }

        [NotMapped]
        public IFormFile files { get; set; }
     
    }
  
}



