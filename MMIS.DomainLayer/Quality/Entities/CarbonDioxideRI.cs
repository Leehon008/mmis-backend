using MMIS.DomainLayer.Deviations.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Quality.Entities
{
    public class CarbonDioxideRI : EntityBaseCOA
    {
        public string Tank { get; set; }
        public string Quantity { get; set; }
        public string Taste { get; set; }
        public string Odour { get; set; }
        public string ApperanceInWater { get; set; }
        public string Purity { get; set; }
        public string OdourAfterAcidification { get; set; }
        public string SnowTest { get; set; }

        public DeviationTemp Deviation()
        {
            List<Param> Params = new List<Param>();

            Params.Add(new Param { name = nameof(Quantity), value = Quantity });
            Params.Add(new Param { name = nameof(Taste), value = Taste });
            Params.Add(new Param { name = nameof(Odour), value = Odour });
            Params.Add(new Param { name = nameof(ApperanceInWater), value = ApperanceInWater });
            Params.Add(new Param { name = nameof(Purity), value = Purity });
            Params.Add(new Param { name = nameof(OdourAfterAcidification), value = OdourAfterAcidification });
            Params.Add(new Param { name = nameof(SnowTest), value = SnowTest });
            DeviationTemp dTemp = new DeviationTemp
            {
                Plant = Plant,
                Function = "Quality",
                DCT = "RICarbonDioxide",
                Date = DateOfDelivery,
                Personnel = Analyst,
                Params = Params
            };

            return dTemp;

        }
    }
}
