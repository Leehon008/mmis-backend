using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.Maltings.Entities
{
    public class MaltBatch : EntityBase
    {
        public string BatchNumber { get; set; }
        public string SAPWorkorderNumber { get; set; }
        public string JobcardNumber { get; set; }
        public string WaterSource { get; set; }
        public virtual ICollection<MStocks> Stocks { get; set; }
    }

    public class MStocks
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column("Id", Order = 0)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Material { get; set; }
        public decimal OpeningStock { get; set; }
        public decimal ClosingStock { get; set; }
        public virtual MaltBatch Batch { get; set; }
    }

    public class MaltingCycle : EntityBase
    {
        public int MaltId { get; set; }
        public virtual ICollection<MProcess> Processes { get; set; }
        public virtual ICollection<MStoppage> Stoppages { get; set; }
        public int TotalCycleTime { get; set; }
    }

    public class MProcess
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
        public decimal StartMoisture { get; set; }
        public decimal EndMoisture { get; set; }
        public int Duration { get; set; }
        public virtual MaltingCycle MC { get; set; }
    }

    public class MStoppage
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
        public virtual MaltingCycle MC { get; set; }

    }
}
