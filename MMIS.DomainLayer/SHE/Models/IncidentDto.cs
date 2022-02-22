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
    public class DocumentsDto : EntityBase,IHaveCustomMappings
    {
      
    public string FilePath { get; set; }
    public string description { get; set; }
    

    [NotMapped]
    public IFormFile files { get; set; }
    public void CreateMaps(MapperConfigurationExpression config)
    {
        config.CreateMap<Documents, DocumentsDto>().ReverseMap();
    }

}

    
}

    

