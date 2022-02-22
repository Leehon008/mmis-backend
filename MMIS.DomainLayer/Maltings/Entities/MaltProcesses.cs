using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.Maltings.Entities
{
    public class MaltProcesses
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Plant { get; set; }
        public string Shift { get; set; }
        public DateTime Date { get; set; }
        public string MaltBatch { get; set; }
    }

    public class MaltDryLoad
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Plant { get; set; }
        public string Shift { get; set; }

        public string MaltBatch { get; set; }
        public string ByProductsQty { get; set; }
        public string VarietyOfGrain { get; set; }
        public string SourceOfGrain { get; set; }
    }
    public class MaltingTranfer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Plant { get; set; }
        public string Shift { get; set; }

        public string MaltBatch { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string HMBNumber { get; set; }
    }

    public class MaltMilling
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Plant { get; set; }
        public string Shift { get; set; }
        public string STONumber { get; set; }
        public double Tonnage { get; set; }
        public string MaltBatch { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Yield { get; set; }
        public string MillingPlan { get; set; }
    }
    public class MaltDispatch
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Plant { get; set; }
        public string Shift { get; set; }

        public string MaltBatch { get; set; }

        public string Dispatches { get; set; }
        public string Tonnages { get; set; }
        public string STONumber { get; set; }

    }

}
