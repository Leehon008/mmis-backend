using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.Brewing.Entities
{
    public class Brew
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       [System.ComponentModel.DataAnnotations.Key, Column("Id",Order = 0)]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Plant { get; set; }
        public string Shift { get; set; }

        public string Product { get; set; }
        public DateTime Date { get; set; }
        public string BrewNumber { get; set; }
        public string RawMaterialSapWorkOrder { get; set; }
        public string MaltPieceNumber { get; set; }
        public string YeastBatchNumber { get; set; }
        public string WaterSource { get; set; }
        public virtual ICollection<Stocks> Stocks { get; set; }
    }

    public class Stocks
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column("Id", Order = 0)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Material { get; set; }
        public decimal OpeningStock { get; set; }
        public decimal ClosingStock { get; set; }
        public virtual Brew Brew {get;set;}
    }

    public class BrewingCycle
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column("Id", Order = 0)]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Plant { get; set; }
        public string Shift { get; set; }
        public int BrewId { get; set; }
        public virtual ICollection<Process> Processes { get; set; }
        public virtual ICollection<Stoppage> Stoppages { get; set; }
        public int TotalCycleTime { get; set; }
    }

    public class Process
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column("Id", Order = 0)]
        public int Id { get; set; }
        public string Shift { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public decimal StartTemp { get; set; }
        public decimal EndTemp { get; set; }
        public int Duration { get; set; }
        public virtual BrewingCycle BC { get; set; }
    }

    public class Stoppage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column("Id", Order = 0)]
        public int Id { get; set; }
        public string Shift { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Duration { get; set; }
        public virtual BrewingCycle BC { get; set; }

    }
}
