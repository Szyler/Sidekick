using System.ComponentModel.DataAnnotations;

namespace Sidekick.Database.Tables
{
    public class Setting
    {
        [Key]
        [MaxLength(64)]
        public required string Key { get; set; }

        [MaxLength(64)]
        public required string? Value { get; set; }
    }
}
