using System.ComponentModel.DataAnnotations;

namespace GithubActionsDemoApp.Entities
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 150)]
        public required string Name { get; set; }
    }
}
