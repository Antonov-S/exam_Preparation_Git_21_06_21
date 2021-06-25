using System;
using System.ComponentModel.DataAnnotations;

namespace Git.Data
{
    public class Commit
    {
        [Key]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedOn { get; init; } = DateTime.UtcNow;

        [Required]
        public string CreatorId { get; init; }
        public User Creator { get; init; }

        [Required]
        public string RepositoryId { get; init; }
        public Repository Repository { get; init; }

    }
}
