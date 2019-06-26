using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Data.Entities.Base;

namespace Data.Entities
{

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
