using System.Text.Json;

namespace SvenAi.Core.Git
{
    public class GitRepo
    {
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;

        public static GitRepo FromJsonElement(in JsonElement repoRaw)
        {
            var repo = new GitRepo();
            foreach (var prop in repoRaw.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case "name": { repo.Name = prop.Value.GetString(); break; }
                    case "url": { repo.Url = prop.Value.GetString(); break; }
                    default: break;
                }
            }

            return repo;
        }
    }
}