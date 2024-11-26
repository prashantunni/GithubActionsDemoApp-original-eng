using GithubActionsDemoApp.Entities;

namespace GithubActionsDemoApp.Models
{
    public class PeopleIndex
    {
        public IEnumerable<Person> People { get; set; } = new List<Person>();
    }
}
