using System;
using System.Collections.Generic;
using System.Text;

namespace MMIS.DomainLayer.Maltings.Entities
{
    public class Maintenance : EntityBase
    {
        public string JobcardNumber { get; set; }
        public string SAPWorkorderNumber { get; set; }
    }
}
