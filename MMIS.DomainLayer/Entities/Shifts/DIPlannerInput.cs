using MMIS.DomainLayer.Entities.Shared;
using Moq;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Entities.Shifts
{
    public class    DIArtisanInput
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public string IDNo { get; private set; }
        public string ShiftNo { get; set; }
        public string Artisan { get; set; }
        public string Machine { get; set; }
        public string TagNo { get; set; }
      
        public string Description { get; set; }
        public string Notification { get; set; }
        public DateTime IdentifiedOn { get; set; }
       
        public DateTime CreatedOn { get;private set; }

        public string Createdby { get; set; }


    }
}

