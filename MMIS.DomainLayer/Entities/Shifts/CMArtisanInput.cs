using MMIS.DomainLayer.Entities.Shared;
using Moq;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Entities.Shifts
{
    public class CMArtisanInput
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public string IDNo { get; private set; }
        public string ShiftNo { get; set; }
        public string Artisan { get; set; }
        public string Machine { get; set; }
        public string Issue { get; set; }
        public string WoNumber { get; set; }
        public string completion { get; set; }
         public double duration { get; set; }
        public string Notification { get; set; }
        public double sparesCost { get; set; }
            
        public DateTime CreatedOn { get;private set; }

        public string Createdby { get; set; }
        

    }
}

