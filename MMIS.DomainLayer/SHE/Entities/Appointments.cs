using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class Appointments
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
         [Key, Column(Order = 0)]
        public long Id { get; set; }

        [DisplayName("FirstName")]
        public string FirstName { get; set; }
        [DisplayName("LastName")]
        public string LastName { get; set; }
        [DisplayName("Region")]
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
        public bool Active { get; set; }
      
        public string Plant { get; set; }
        public string Createdby { get; set; }
    }
}