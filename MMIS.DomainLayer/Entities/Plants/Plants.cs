using MMIS.DomainLayer.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMIS.DomainLayer.Entities.Plants
{
    public class Plant : EntityBase
    {
        public Plant() { }
        public string PlantId { get; set; }
        public string PlantName { get; set; }
        public string Name { get; set; }
        public string RegionMain { get; set; }
        public string RegionDistrict { get; set; }
        public string SorghumRegion { get; set; }
        public string SorghumTerritory { get; set; }
        public string LagersTerritory { get; set; }
        public string SalesOrg { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
           
    }
}
