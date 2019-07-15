namespace AcaDev.Domain.Services
{
    public interface IPostService
    {
        /// <summary>
        /// Formats the post actual title to look like the url provided by the vue app
        /// </summary>
        string TitleToUrlTitle(string title);
    }
}
