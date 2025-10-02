using Newtonsoft.Json;

namespace github_activity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string username = string.Empty;

            if (args.Length == 0)
            {
                Console.Write("Enter GitHub username: ");
                username = Console.ReadLine();
            }
            else
            {
                username = args[0];
            }

            string endpoint = $"https://api.github.com/users/{username}/events";
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; AcmeInc/1.0)");
                var response = client.GetAsync(endpoint).Result;

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = response.Content.ReadAsStringAsync().Result;
                    var events = JsonConvert.DeserializeObject<List<GitHubEvent>>(jsonResponse);

                    Console.WriteLine($"\nRecent activity for GitHub user: {username}\n");

                    foreach (var githubEvent in events)
                    {
                        Console.WriteLine($"{githubEvent.Type} at {githubEvent.CreatedAt}");
                        if (githubEvent.Type == "PushEvent")
                        {
                            Console.WriteLine($" - Pushed : {githubEvent.Payload.Commits.Count} commits to {githubEvent.Repo.Name} branch " +
                                $"{githubEvent.Payload.Ref}");
                        }
                        else if (githubEvent.Type == "CreateEvent")
                        {
                            string desc = githubEvent.Payload.RefType == "repository" ? githubEvent.Repo.Name : githubEvent.Payload.Ref;
                            Console.WriteLine($"  - Created : {githubEvent.Payload.RefType} - {desc}");
                        }
                        else if (githubEvent.Type == "PullRequestEvent")
                        {
                            Console.WriteLine($"  - Pull Request to: {githubEvent.Repo.Name}");
                        }
                        // Add more event types as needed
                    }
                }
                else
                {
                    Console.WriteLine($"Error: Unable to fetch data for user '{username}'. Status Code: {response.StatusCode}");
                }
            }
        }
    }
}
