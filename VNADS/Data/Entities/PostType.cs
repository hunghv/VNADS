using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Entities.Base;

namespace Data.Entities
{

    [Serializable]
    [Table("VNADS_PostType")]
    public class PostType : Entity
    {
        public PostType()
        {
            Posts = new List<Post>();
        }

        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
