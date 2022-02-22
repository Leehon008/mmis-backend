using MMIS.DomainLayer.Entities.Shared;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class SHERegistry:EntityBase
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Region { get; set; }
        [Required]
        public string Center { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string JobTitle { get; set; }
        [Required]
        public string Function { get; set; }
        [Required]
        public string EmploymentNumber { get; set; }
        [Required]
        public string EmploymentStatus { get; set; }
        [Required]
        public string AppointmentStatus { get; set; }
        [Required]
        public DateTime TrainingDue { get; set; }
        [Required]
      
        public string RegistryType { get; set; }
      
        public string Plant { get; set; }


    }
}