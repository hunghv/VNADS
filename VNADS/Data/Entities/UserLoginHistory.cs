using System;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Entities.Base;

namespace Data.Entities
{
    [Serializable]
    [Table("VNADS_UserLoginHistory")]
    public class UserLoginHistory : Entity
    {
        public int UserId { get; set; }
        public virtual UserProfile User { get; set; }
        public Guid AccessToken { get; set; }
        public bool IsLoggedOut { get; set; }
        public bool IsAppToken { get; set; }
    }
}