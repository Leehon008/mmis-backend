using MMIS.DomainLayer.Entities.Shared;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class RATeams: EntityBase
    {
    
        [Required]
        public string FirstName { get;  set; }
        [Required]
        public string LastName { get;  set; }
        [Required]
        public string JobTitle { get; set; }
        [Required]
        public string Function { get; set; }
        [Required]
        public string EmploymentNumber { get; set; }
        [Required]
        public string RAType { get; set; }
        [Required]
        public string Centre { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime ModifiedOn { get; set; }
       
        public string Plant { get; set; }

        public string Createdby { get; set; }


    }
}

