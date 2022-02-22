using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class HRAImprovementSuggestion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
      
        public string SuggestionType { get;  set; }

        public string Suggestion { get; set; }
        public virtual HRAHeader HRAHeader { get; set; }

    }
}

