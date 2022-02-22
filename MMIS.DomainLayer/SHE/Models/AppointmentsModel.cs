using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using MMIS.CommonLayer.Automapper.Contracts;
using MMIS.DomainLayer.Entities.Shared;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class AppointmentsModel :  IHaveCustomMappings
    {


        [DisplayName("FirstName")]
        public string FirstName { get; set; }
        [DisplayName("LastName")]
        public string LastName { get; set; }
        [DisplayName("Region")]
        public string Plant { get; set; }
        public string Region { get; set; }
        [DisplayName("Centre")]
        public string Centre { get; set; }
        [DisplayName("Title")]
        public string Title { get; set; }
        [DisplayName("Employee Number")]
        public string EmployeeNo { get; set; }
        [DisplayName("Employeement Status")]
        public string EmployeementStatus { get; set; }
        [DisplayName("Appointment Letter")]
        public string AppointmentLetter { get; set; }
        [DisplayName("ExpiryDate")]
        public DateTime ExpiryDate { get; set; }
        [DisplayName("DateCreated")]
        public DateTime DateCreated { get; set; }
        [DisplayName("DateModified")]
        public DateTime DateModified { get; set; }
        [DisplayName("Active")]
        public string Createdby { get; set; }
        public bool Active { get; set; }
        [NotMapped]
        public IFormFile files { get; set; }

        public void CreateMaps(MapperConfigurationExpression config)
        {
            config.CreateMap<Appointments, AppointmentsModel>().ReverseMap();
        }




    }
}

