using System;
using System.Collections.Generic;
using System.Text;

namespace MMIS.DomainLayer.ManDev.Entities
{
    public class Clause : EntityBase
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
    }

    public class Section : ChildBase
    {
        public virtual Clause Clause { get; set; }
        public string Name { get; set; }
        public string Question { get; set; }
        public bool Response { get; set; }
        public virtual ICollection<Evidence> Evidence { get; set; }
    }

    public class Evidence : ChildBase
    {
        public virtual Section Section { get; set; }
        public string Name { get; set; }
        public string Comments { get; set; }
        public string Link { get; set; }
        public string File { get; set; }
    }
}
