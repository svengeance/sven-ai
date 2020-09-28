using System;
using System.Text.Json;

namespace SvenAi.Core.Git
{
    public class GitActivityItemViewModel
    {
        public string Id { get; set; }
        public string Date { get; set; }
        public bool IsPublic { get; set; }
        public string ActivityType { get; set; }
        public GitActor Actor { get; set; }
        public GitRepo Repo { get; set; }
        public ActivityAction Action { get; set; } = ActivityAction.EmptyAction;

        public static GitActivityItemViewModel FromJsonElement(JsonElement activityRaw)
        {
            var activity = new GitActivityItemViewModel();
            foreach (var prop in activityRaw.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case "id": { activity.Id = prop.Value.GetString(); break; }
                    case "created_at": { activity.Date = prop.Value.GetDateTime().ToString("M"); break; }
                    case "type": { activity.ActivityType = prop.Value.GetString(); break; }
                    case "public": { activity.IsPublic = prop.Value.GetBoolean(); break; }
                    case "actor": { activity.Actor = GitActor.MapToActor(prop.Value); break; }
                    case "repo": { activity.Repo = GitRepo.FromJsonElement(prop.Value); break; }
                    default: break;
                }
            }

            var hasPayload = activityRaw.TryGetProperty("payload", out var payload);
            if (hasPayload)
                activity.Action = ActivityAction.FromJsonElement(activity.ActivityType, payload);

            if (activity.Action.LinkText != null && string.IsNullOrWhiteSpace(activity.Action.Link))
                activity.Action.Link = activity.Repo.Url;

            return activity;
        }

        /// <summary>
        /// Returns the pathmapping that maps from an API call of this Activity's type using its Action URL to the
        /// human-friendly HTML url. For most resources in the git API, this is simply html_url
        /// </summary>
        public string ApiHtmlUrlPath
            => ActivityType switch
               {
                   _ => "html_url"
               };
    }
}