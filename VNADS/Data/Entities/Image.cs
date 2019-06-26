using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Entities.Base;

namespace Data.Entities
{
    //[Serializable]
    //[Table("VNADS_Image")]
    public class Image : Entity
    {
        public Image()
        {
            PostImages = new List<PostImage>();
        }

        public string ImageUrl { get; set; }

        public ICollection<PostImage> PostImages { get; set; }
    }
}
