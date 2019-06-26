using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Entities.Base;

namespace Data.Entities
{
    //[Serializable]
    //[Table("VNADS_Roles")]
    public class Role : Entity
    {

        public Role()
        {
            UserRoles = new List<UserRole>();
        }

        [MaxLength(255)]
        public string Name { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
