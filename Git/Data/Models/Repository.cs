namespace Git.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Repository
    {
        [Key]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(RepositoryMaxLenght)]
        public string Name { get; init; }

        public DateTime CreatedOn { get; init; } = DateTime.UtcNow;

        [Required]
        public bool IsPublic { get; init; }

        [Required]
        public string OwnerId { get; init; }
        public User Owner { get; init; }

        public IEnumerable<Commit> Commits { get; init; } = new List<Commit>();
    }
}
