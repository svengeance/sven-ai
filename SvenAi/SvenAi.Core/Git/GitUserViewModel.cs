namespace SvenAi.Core.Git
{
    public class GitUserViewModel
    {
        public string AvatarUrl { get; set; } = string.Empty;
        public string Blog { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public bool? Hireable { get; set; }
        public string HtmlUrl { get; set; } = string.Empty;
        public int? NumPrivateGists { get; set; }
        public int NumPrivateRepos { get; set; }
        public int NumPublicRepos { get; set; }
        public int NumPublicGists { get; set; }
        public string Url { get; set; } = string.Empty;
    }
}