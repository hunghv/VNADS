using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Entities.Base;

namespace Data.Entities
{
    [Serializable]
    [Table("VNADS_AdsType")]
    public class AdsType : Entity
    {
        public AdsType()
        {
            AdsFroms = new List<AdsForm>();
        }

        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }

        public ICollection<AdsForm> AdsFroms { get; set; }
    }
}