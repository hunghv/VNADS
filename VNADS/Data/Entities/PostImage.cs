using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;
using Data.Entities.Base;

namespace Data.Entities
{
    [Serializable]
    [Table("VNADS_PostImage")]
    public class PostImage : Entity
    {
        public int ImageId { get; set; }
        public virtual Image Image { get; set; }
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}