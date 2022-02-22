using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using MMIS.CommonLayer.Automapper.Contracts;
using MMIS.DomainLayer.ManDev.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMIS.DomainLayer.ManDev.Dto
{
    public class ClauseDto : DtoBase, IHaveCustomMappings
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public virtual ICollection<SectionDto> Sections { get; set; }

        public void CreateMaps(MapperConfigurationExpression config)
        {
            config.CreateMap<Clause, ClauseDto>().ReverseMap();
        }

    }

    public class SectionDto : IHaveCustomMappings
    {
        public int Id { get; set; }
        public virtual ClauseDto Clause { get; set; }
        public string Name { get; set; }
        public string Question { get; set; }
        public bool Response { get; set; }
        public virtual ICollection<EvidenceDto> Evidence { get; set; }

        public void CreateMaps(MapperConfigurationExpression config)
        {
            config.CreateMap<Section, SectionDto>().ReverseMap();
        }
    }

    public class EvidenceDto : IHaveCustomMappings
    {
        public int Id { get; set; }
        public virtual SectionDto Section { get; set; }
        public string Name { get; set; }
        public string Comments { get; set; }
        public string Link { get; set; }
        public string File { get; set; }

        public void CreateMaps(MapperConfigurationExpression config)
        {
            config.CreateMap<Evidence, EvidenceDto>().ReverseMap();
        }
    }

    public class EvidenceFile
    {
        public IFormFile File { get; set; }
    }

    public class EvidencePath
    {
        public string File { get; set; }
    }
}
