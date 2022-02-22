using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class PreTaskRAEquipment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        public string FormId { get; set; }
        public bool Headphones { get;  set; }
        public bool Goggles { get; set; }
        public bool Helmet { get; set; }
        public bool SafetyShoes { get; set; }
        public bool Gloves { get; set; }
        public bool Respirator { get; set; }
        public bool FaceMask { get; set; }
        public bool Vest { get; set; }
        public bool FaceShield { get; set; }
        public bool Overalls { get; set; }
        public bool Harness { get; set; }
        public bool WeldingMask { get; set; }
        public virtual PreTaskRAHeader PreTaskRAHeader { get; set; }

    }
}

