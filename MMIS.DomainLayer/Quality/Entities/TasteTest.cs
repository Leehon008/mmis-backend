using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.Quality.Entities
{
    public class TasteTest : Entitybase
    {
        public string BatchNo { get; set; }
        public DateTime TasteDate { get; set; }
        public string BBDate { get; set; }
        public string ProductType { get; set; }
        public virtual ICollection<Tester> Testers { get; set; }

    }

    public class Tester
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public virtual TasteTest TT {get;set;}
        public int TesterNo { get; set; }
        public int Carbonation { get; set; }
        public int Bite { get; set; }
        public int AlcoholContent { get; set; }
        public int Thickness { get; set; }
        public int SourAcetic { get; set; }
        public int Alkaline { get; set; }
        public int Chlorophenol { get; set; }
        public int Earthy { get; set; }
        public int Metallic { get; set; }
        public int Musty { get; set; }
        public int Phenolic { get; set; }
        public int RancidOil { get; set; }
        public int Sulphury { get; set; }
        public int Other { get; set; }
        public int Sliminess { get; set; }
        public int Colour { get; set; }
        public int Mouthfeel { get; set; }
        public int Sweetness { get; set; }
        public int Texture { get; set; }
        public int Cracking { get; set; }
    }
}
