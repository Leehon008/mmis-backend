using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.Quality.Models
{
    public class ShelflifeDto : ModelBase
    {
        public int Id { get; set; }
        public string BatchNumber { get; set; }
        public virtual ICollection<SLParametersDto> Parameters { get; set; }
    }

    public class SLParametersDto
    {
        public int Id { get; set; }
        public int Day { get; set; }
        public decimal TotalAcids { get; set; }
        public decimal AlcoholContent { get; set; }
        public decimal CO2Content { get; set; }
        public string Analyst { get; set; }

        public ShelflifeDto SL { get; set; }
    }
}
