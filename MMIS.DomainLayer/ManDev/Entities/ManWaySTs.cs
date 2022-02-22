using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MMIS.CommonLayer.Automapper.Contracts;
using System.Text;
using AutoMapper.Configuration;

namespace MMIS.DomainLayer.ManDev.Entities
{
    public class ManWaySTs 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public string STType { get; set; }
        public string Category { get; set; }
        public string QuestionType { get; set; }
        public string Question { get; set; }


    }

    public class ManWaySTHeader : EntityBase
    {
     
        public string STType { get; set; }     
        public string Changedby { get; set; }
        public virtual ICollection<MWSTsLineItems> MWSTsLineItems { get; set; }

        public virtual MWSTsEmpowerment MWSTsEmpowerment { get; set; }
    }

    public class MWSTsLineItems 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
         public string STType { get; set; }
        public string Category { get; set; }
        public string QuestionType { get; set; }
        public string Question { get; set; }
        public bool Response { get; set; }
        public string Changedby { get; set; }


    }


    public class MWSTsEmpowerment : EntityBase
    {
        public string STType { get; set; }
        public string Category { get; set; }
        public string AreaofAccountability { get; set; }
        public string Description { get; set; }
        public string FacilitiesNeeded { get; set; }
        public string InformationNeeded { get; set; }
        public string TrainingRequired { get; set; }
        public DateTime TrainingStartDate { get; set; }
        public DateTime TrainingEndDate { get; set; }
        public DateTime TranferStartDate { get; set; }
        public DateTime TransferEndDate { get; set; }
        public string Status { get; set; }
        public string Changedby { get; set; }



    }

}
