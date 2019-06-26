using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Entities.Base;

namespace Data.Entities
{
    [Serializable]
    [Table("VNADS_UserProfile")]
    public class UserProfile : Entity
    {
        public UserProfile()
        {
            UserRoles = new List<UserRole>();
            Posts = new List<Post>();
        }

        [MaxLength(50)]
        [Required]
        public string UserName { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
        [MaxLength(50)]
        public string ConfirmPassword { get; set; }
        [MaxLength(255)]
        public string DisplayName { get; set; }
        [MaxLength(100)]
        [Required]
        public string Email { get; set; }
        [MaxLength(50)]
        public string NickName { get; set; }
        public byte[] ThumbnailPhoto { get; set; }
        public string Domain { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool? ReceiveEmail { get; set; }
        public bool? Active { get; set; }
        [MaxLength(30)]
        public string TelephoneNumber { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}