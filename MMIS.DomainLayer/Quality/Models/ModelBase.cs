using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMIS.DomainLayer.Quality.Models
{
    public class ModelBase
    {
        public string Plant { get; set; }
        public string Analyst { get; set; }

    }

    public class ModelBaseCOA : ModelBase
    {
        public DateTime DateOfDelivery { get; set; }
        public string Supplier { get; set; }
        public string BatchNo { get; set; }
        public IFormFile COA { get; set; }
    }

}
