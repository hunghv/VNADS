using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Entities.Base;

namespace Data.Entities
{
    [Serializable]
    [Table("VNADS_ApplicationLanguage")]
    public class ApplicationLanguage : Entity
    { 
        public const int MaxNameLength = 10;

        public const int MaxDisplayNameLength = 64;

        public const int MaxIconLength = 128;

        [Required]
        [StringLength(MaxNameLength)]
        public virtual string Name { get; set; }

        [Required]
        [StringLength(MaxDisplayNameLength)]
        public virtual string DisplayName { get; set; }

        [StringLength(MaxIconLength)]
        public virtual string Icon { get; set; }

        public virtual bool IsDisabled { get; set; }

        public ApplicationLanguage()
        {
        }

        public ApplicationLanguage( string name, string displayName, string icon = null, bool isDisabled = false)
        {
            Name = name;
            DisplayName = displayName;
            Icon = icon;
            IsDisabled = isDisabled;
        }

    }
}