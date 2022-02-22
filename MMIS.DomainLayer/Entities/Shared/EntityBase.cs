using MMIS.DomainLayer.Entities.Shared.Contracts;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Entities.Shared
{
    public class EntityBase : IEntity
    {
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool Active { get; set; }

    }
}
