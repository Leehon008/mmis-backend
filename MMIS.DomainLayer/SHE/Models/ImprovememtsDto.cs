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
    public class HighRiskTaskObservationRecordDto :EntityBase, IHaveCustomMappings
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
        public string Plant { get; set; }


        [NotMapped]
        public IFormFile files { get; set; }
        public void CreateMaps(MapperConfigurationExpression config)
        {
            config.CreateMap<HighRiskTaskObservationRecords, HighRiskTaskObservationRecordDto>().ReverseMap();
        }


    }
    public class AuditRecordsDto :EntityBase, IHaveCustomMappings
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

        public string Plant { get; set; }
        [NotMapped]
        public IFormFile files { get; set; }
        public void CreateMaps(MapperConfigurationExpression config)
        {
            config.CreateMap<AuditRecords, AuditRecordsDto>().ReverseMap();
        }


    }
}

    

