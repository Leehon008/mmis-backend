using Castle.Components.DictionaryAdapter;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Entities.Shared.Contracts
{
    public interface IEntity
    {
     
        int Id { get; set; }
        DateTime DateCreated { get; set; }
        DateTime DateModified { get; set; }
        bool Active { get; set; }
    }
}
