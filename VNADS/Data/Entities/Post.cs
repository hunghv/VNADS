using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Entities.Base;

namespace Data.Entities
{
    [Serializable]
    [Table("VNADS_Post")]
    public class Post : Entity
    {
        public Post()
        {
            PostImages = new List<PostImage>();
        }

        public int PostTypeId { get; set; }
        public virtual PostType PostType { get; set; }
        public int UserProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public int AdsFormId { get; set; }
        public virtual AdsForm AdsForm { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }
        public float Price { get; set; }
        [MaxLength(50)]
        public string PriceDescription { get; set; }

        //TODO: Location

        [MaxLength(50)]
        public string Property1 { get; set; } //Not happy about this
        [MaxLength(50)]
        public string Property2 { get; set; } //Not happy about this

        public string Description { get; set; }


        public ICollection<PostImage> PostImages { get; set; }
    }
}