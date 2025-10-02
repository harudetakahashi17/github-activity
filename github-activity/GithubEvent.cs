using Newtonsoft.Json;

namespace github_activity
{
    public class Actor
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("display_login")]
        public string DisplayLogin { get; set; }

        [JsonProperty("gravatar_id")]
        public string GravatarId { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }
    }

    public class Repo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class CommitAuthor
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Commit
    {
        [JsonProperty("sha")]
        public string Sha { get; set; }

        [JsonProperty("author")]
        public CommitAuthor Author { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("distinct")]
        public bool Distinct { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Payload
    {
        [JsonProperty("repository_id")]
        public long RepositoryId { get; set; }

        [JsonProperty("push_id")]
        public long PushId { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("distinct_size")]
        public int DistinctSize { get; set; }

        [JsonProperty("ref")]
        public string Ref { get; set; }

        [JsonProperty("ref_type")]
        public string RefType { get; set; }

        [JsonProperty("head")]
        public string Head { get; set; }

        [JsonProperty("before")]
        public string Before { get; set; }

        [JsonProperty("commits")]
        public List<Commit> Commits { get; set; }

        [JsonProperty("master_branch")]
        public string MasterBranch { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("pusher_type")]
        public string PusherType { get; set; }
    }

    public class GitHubEvent
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("actor")]
        public Actor Actor { get; set; }

        [JsonProperty("repo")]
        public Repo Repo { get; set; }

        [JsonProperty("payload")]
        public Payload Payload { get; set; }

        [JsonProperty("public")]
        public bool Public { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }


}