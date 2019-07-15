namespace AcaDev.Domain.Services
{
    public class PostService : IPostService
    {
        public string TitleToUrlTitle(string title)
        {
            return title
                .ToLower()
                // remove characters that can't be used in a url
                .Replace(".", string.Empty)
                .Replace(",", string.Empty)
                .Replace(" ", "-");
        }
    }
}
