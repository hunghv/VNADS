using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Data.Entities
{
    [Serializable]
    [Table("VNADS_UserProfile")]
    public class UserProfile : IdentityUser
    {
        public UserProfile()
        {
            UserRoles = new List<UserRole>();
            Posts = new List<Post>();
        }

        [MaxLength(255)]
        public string DisplayName { get; set; }
        [MaxLength(255)]
        public string FirstName { get; set; }
        [MaxLength(255)]
        public string LastName { get; set; }
        public string NickName { get; set; }
        public byte[] ThumbnailPhoto { get; set; }
        public string Domain { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool? ReceiveEmail { get; set; }
        public bool? Active { get; set; }
        [MaxLength(30)]
        public string TelephoneNumber { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}