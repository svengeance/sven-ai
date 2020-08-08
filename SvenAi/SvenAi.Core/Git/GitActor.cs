using System.Text.Json;

namespace SvenAi.Core.Git
{
    public class GitActor
    {
        public string DisplayName { get; set; } = string.Empty;
        public string AvatarUrl { get; set; } = string.Empty;

        public static GitActor MapToActor(in JsonElement actorRaw)
        {
            var actor = new GitActor();
            foreach (var prop in actorRaw.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case "display_login": { actor.DisplayName = prop.Value.GetString(); break; }
                    case "avatar_url": { actor.AvatarUrl = prop.Value.GetString(); break; }
                    default: break;
                }
            }

            return actor;
        }
    }
}