using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class PreTaskRAPermisions
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }

        public string PermissionNo { get; set; }
        public string FormId { get; private set; }
        public bool HotWork { get;  set; }
        public bool WorkAtHeight { get; set; }
        public bool ScaffoldingWork { get; set; }
        public bool RoofWork { get; set; }
        public bool LockOutTag { get; set; }

        public virtual PreTaskRAHeader PreTaskRAHeader { get; set; }

    }
}

