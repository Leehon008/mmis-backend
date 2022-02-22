using System;
using System.Collections.Generic;
using System.Text;

namespace MMIS.DomainLayer.Quality.Entities
{
    public class PPQA : Entitybase
    {
        public DateTime Date { get; set; }
        public string Brand { get; set; }
        public string PackSize { get; set; }
        public int Shrinkpacks { get; set; }
        public int Bottles { get; set; }
        public decimal SFPAFaulty { get; set; }
        public decimal SFPAMoisture { get; set; }
        public decimal SFABurnHoles { get; set; }
        public decimal SFADefacedSoiled { get; set; }
        public decimal SFAWrinkles { get; set; }
        public decimal ContentsMDC { get; set; }
        public decimal ShrinkPackDefects { get; set; }
        public decimal ClosureLDD { get; set; }
        public decimal ClosureIPG { get; set; }
        public decimal BottleForeignObjects { get; set; }
        public decimal BottleSoiled { get; set; }
        public decimal BottleFillLevel { get; set; }
        public decimal BottleStructure { get; set; }
        public decimal Bottlecolour { get; set; }
        public decimal DateCodingLegibility { get; set; }
        public decimal CorrectDateCode { get; set; }
        public decimal IceProofingTest { get; set; }
        public decimal LabelDressMEL { get; set; }
        public decimal LabelDressHeight { get; set; }
        public decimal LabelDressSkew { get; set; }
        public decimal LAPrintLRC { get; set; }
        public decimal LADamaged { get; set; }
        public decimal LATorn { get; set; }
        public decimal LAWrinkled { get; set; }
        public decimal LAFolded { get; set; }
        public decimal LABlistersBubbles { get; set; }
        public decimal LAUnbondedEdges { get; set; }
        public decimal LALooseCorners { get; set; }
        public decimal ClosureRemovalEase { get; set; }
        public decimal BottleDefects { get; set; }
        public decimal DPMO { get; set; }
        public decimal PPQAScore { get; set; }
    }
}
