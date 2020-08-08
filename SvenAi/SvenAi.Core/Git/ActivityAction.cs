using System;
using System.Linq;
using System.Text.Json;
using Humanizer;
using static SvenAi.Core.Git.ActivityAction.EventType;

namespace SvenAi.Core.Git
{
    public class ActivityAction
    {
        private const int MaxTitleLength = 50;
        private const int MaxSubTitleLength = 200;
        private const int MaxCaptionLength = 30;

        public static ActivityAction EmptyAction = new ActivityAction(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);

        public string VerbSentence { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Caption { get; set; }
        public string Link { get; set; }
        public string LinkText { get; set; }

        public ActivityAction(string verbSentence, string title, string subtitle, string caption, string link, string linkText)
        {
            VerbSentence = verbSentence.Humanize(LetterCasing.Title);
            Title = title.Humanize(LetterCasing.Sentence).Truncate(MaxTitleLength, "...");
            Subtitle = subtitle.Replace(@"\r\n", " ").Truncate(MaxSubTitleLength, "...");
            Caption = caption.Replace(@"\r\n", " ").Truncate(MaxCaptionLength, "...");
            Link = link;
            LinkText = linkText;
        }

        public static ActivityAction FromJsonElement(string eventType, in JsonElement payload) =>
            eventType switch
            {
                CommitCommentEvent => new ActivityAction("Commented on a commit",
                    JString(payload, "comment.body"),
                    $"File: {JString(payload, "comment.path")}",
                    "",
                    JString(payload, "comment.html_url"),
                    ""),
                CreateEvent => new ActivityAction($"Created a {JString(payload, "ref_type")}",
                    "",
                    "",
                    "",
                    "",
                    $"View {JString(payload, "ref_type")}"),
                DeleteEvent => new ActivityAction($"Deleted a {JString(payload, "ref_type")}",
                    "",
                    "",
                    "",
                    "",
                    ""),
                ForkEvent => new ActivityAction("Forked a repository",
                    "",
                    "",
                    "",
                    "",
                    "View Repo"),
                GollumEvent => new ActivityAction("Updated a wiki entry",
                    "",
                    "",
                    "",
                    "",
                    ""),
                IssueCommentEvent => new ActivityAction($"{JString(payload, "action")} a comment on an issue",
                    JString(payload, "issue.title"),
                    JString(payload, "comment.body"),
                    "",
                    JString(payload, "comment.html_url"),
                    "View Issue"),
                IssuesEvent => new ActivityAction($"{JString(payload, "action")} an issue",
                    JString(payload, "issue.title"),
                    JString(payload, "issue.body"),
                    "",
                    JString(payload, "issue.html_url"),
                    "View Issue"),
                MemberEvent => new ActivityAction($"Added as a contributor",
                    "",
                    "",
                    "",
                    "",
                    "View Repo"),
                PublicEvent => new ActivityAction("Published a repository",
                    "",
                    "",
                    "",
                    "",
                    "View Repo"),
                PullRequestEvent => new ActivityAction($"{JString(payload, "action")} a pull request",
                    JString(payload, "pull_request.title"),
                    JString(payload, "pull_request.body"),
                    $"Comments: {JString(payload, "pull_request.comments")}, Commits: {JString(payload, "pull_request.commits")}",
                    JString(payload, "pull_request.html_url"),
                    "View Pull Request"),
                PullRequestReviewCommentEvent => new ActivityAction($"{JString(payload, "action")} a review on a pull request",
                    JString(payload, "pull_request.title"),
                    JString(payload, "comment.body"),
                    $"Comments: {JString(payload, "pull_request.comments")}, Commits: {JString(payload, "pull_request.commits")}",
                    JString(payload, "comment.html_url"),
                    "View comment"),
                PushEvent => new ActivityAction($"Pushed {"commits".ToQuantity(int.Parse(JString(payload, "size")))} to {JString(payload, "ref").Split('/').Last()}",
                    "",
                    JString(payload, "commits.0.message"),
                    "",
                    JString(payload, "commits.0.url"),
                    "View Commit"),
                ReleaseEvent => new ActivityAction($"{JString(payload, "action")} a release",
                    JString(payload, "label"),
                    JString(payload, "name"),
                    "",
                    JString(payload, "browser_download_url"),
                    "Download Release"),
                _ => EmptyAction
            };

        private static string JString(in JsonElement element, string path)
        {
            return path.Split('.')
                       .Aggregate(element, (ele, next)
                            => char.IsNumber(next[0]) ? ele.EnumerateArray().ElementAt(int.Parse(next)) : ele.GetProperty(next)).GetRawText()
                       .Trim('"');
        }


        public static class EventType
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
            public const string PullRequestReviewCommentEvent = "PullRequestReviewCommentEvent";
            public const string PushEvent = "PushEvent";
            public const string ReleaseEvent = "ReleaseEvent";
            public const string SponsorshipEvent = "SponsorshipEvent";
            public const string WatchEvent = "WatchEvent";
        }
    }
}