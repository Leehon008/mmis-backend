using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.Quality.Entities
{
    public class MarketDispatched : Entitybase
    {
        public DateTime Date { get; set; }
        public string Driver { get; set; }
        public string Route { get; set; }
        public string BatchNumber { get; set; }
        public DateTime BBDate { get; set; }
        public int Quantity { get; set; }
    }
}
