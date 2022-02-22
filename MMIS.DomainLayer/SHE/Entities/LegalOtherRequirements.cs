using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class LegalOtherRequirements
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }

        public string RequirementType { get; set; }

        public string Requirement { get; set; }
        public string ComplainceMechanism { get; set; }
        public string Responsibility { get; set; }

        public virtual LegalOtherHeader LegalOtherHeader { get; set; }

    }
}

