namespace SvenAi.Core
{
    public static class SvenAiConstants
    {
        public static class GitApi
        {
            public const string RepositoryHtmlUrlPropertyPath = "html_url";
        }

        public static class GitEventType
        {
            public const string CommitCommentEvent = "CommitCommentEvent";
            public const string CreateEvent = "CreateEvent";
            public const string DeleteEvent = "DeleteEvent";
            public const string ForkEvent = "ForkEvent";
            public const string GollumEvent = "GollumEvent";
            public const string IssueCommentEvent = "IssueCommentEvent";
            public const string IssuesEvent = "IssuesEvent";
            public const string MemberEvent = "MemberEvent";
            public const string PublicEvent = "PublicEvent";
            public const string PullRequestEvent = "PullRequestEvent";
            public const string PullRequestReviewEvent = "PullRequestReviewEvent";
            public const string PullRequestReviewCommentEvent = "PullRequestReviewCommentEvent";
            public const string PushEvent = "PushEvent";
            public const string ReleaseEvent = "ReleaseEvent";
            public const string SponsorshipEvent = "SponsorshipEvent";
            public const string WatchEvent = "WatchEvent";
        }
    }
}