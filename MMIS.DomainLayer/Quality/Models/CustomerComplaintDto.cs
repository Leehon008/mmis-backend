using AutoMapper.Configuration;
using MMIS.CommonLayer.Automapper.Contracts;
using MMIS.DomainLayer.Quality.Entities;
using System;

namespace MMIS.DomainLayer.Quality.Models
{
    public class CustomerComplaintDto : ModelBase, IHaveCustomMappings
    {
        public DateTime Date { get; set; }
        public string Driver { get; set; }
        public string Route { get; set; }
        public string DateofCompaint { get; set; }
        public string Customer { get; set; }
        public string BatchNumber { get; set; }
        public string Line { get; set; }
        public DateTime BBDate { get; set; }
        public int Quantity { get; set; }
        public string NatureOfComplaint { get; set; }
        public string Confirmation { get; set; }
        public string RootCause { get; set; }
        public string CorrectiveActions { get; set; }
        public string ByWho { get; set; }
        public string ByWhen { get; set; }
        public void CreateMaps(MapperConfigurationExpression config)
        {
            config.CreateMap<CustomerComplaint, CustomerComplaintDto>().ReverseMap();
        }

    }
}
