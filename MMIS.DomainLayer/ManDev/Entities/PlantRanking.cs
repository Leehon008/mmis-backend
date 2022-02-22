using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MMIS.CommonLayer.Automapper.Contracts;
using System.Text;
using AutoMapper.Configuration;

namespace MMIS.DomainLayer.ManDev.Entities
{
    public class PlantRanking : EntityBase, IHaveCustomMappings
    {
        public virtual ICollection<KPIBasket> Baskets { get; set; }

        public void CreateMaps(MapperConfigurationExpression config)
        {
            config.CreateMap<PlantRankingMaster, PlantRanking>().ReverseMap();
        }

    }

    public class KPIBasket : IHaveCustomMappings
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public virtual PlantRanking PR { get;  set; }
        public string Name { get; set; }
        public virtual ICollection<KPI> KPIs { get; set; }
        public decimal Percentage { get; set; }

        public void CreateMaps(MapperConfigurationExpression config)
        {
            config.CreateMap<KPIBasketMaster, KPIBasket>().ReverseMap();
        }
    }

    public class KPI : IHaveCustomMappings
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public virtual KPIBasket KPIB { get; set; }
        public string Name { get; set; }
        public decimal Incentive { get; set; }
        public string Target { get; set; }
        public decimal Actual { get; set; }
        public string Description { get; set; }

        public void CreateMaps(MapperConfigurationExpression config)
        {
            config.CreateMap<KPIMaster, KPI>().ReverseMap();
        }
    }

    public class PlantRankingMaster
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Plant { get; set; }
        public string Personnel { get; set; }
        public virtual ICollection<KPIBasketMaster> Baskets { get; set; }
    }

    public class KPIBasketMaster
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public virtual PlantRankingMaster PRM { get; set; }
        public string Name { get; set; }
        public virtual ICollection<KPIMaster> KPIs { get; set; }
        public decimal Percentage { get; set; }
    }

    public class KPIMaster
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public virtual KPIBasketMaster Basket { get; set; }
        public string Name { get; set; }
        public decimal Incentive { get; set; }
        public string Target { get; set; }
        public string Description { get; set; }
    }

}
