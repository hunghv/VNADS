using System;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Entities.Base;

namespace Data.Entities
{
    [Serializable]
    [Table("VNADS_UserRole")]
    public class UserRole : Entity
    {
        public int UserProfileId { get; set; }
        public int RoleId { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public virtual Role Role { get; set; }
    }
}