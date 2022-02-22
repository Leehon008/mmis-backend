using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.Quality.Entities
{
    public class Params
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public string Class { get; set; }
        public string Variable { get; set; }
        public string Unit { get; set; }
        public decimal LCL { get; set; }
        public decimal Target { get; set; }
        public decimal UCL { get; set; }
    }
}
