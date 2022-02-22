using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MMIS.DomainLayer.Brewing.Entities
{
    public class PlantAccess
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public string PlantId { get; set; }
        public string PlantName { get; set; }
        public string Username { get; set; }
        public string CreatedBy { get; set; }
    
   
    }
}
