using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.ManDev
{
    public class EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Plant { get; set; }
        public DateTime Date { get; set; }
        public string Personnel { get; set; }

    }

    public class DtoBase
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Plant { get; set; }
        public DateTime Date { get; set; }
        public string Personnel { get; set; }

    }

    public class ChildBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
    }
}
