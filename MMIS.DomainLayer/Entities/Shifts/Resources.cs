using MMIS.DomainLayer.Entities.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Entities.Shifts
{
    public class Resources
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        public string ResourceCategoryId { get; set; }
        public string ResourceName { get; set; }
        public string ResCategory { get; set; }
       

    }
}

