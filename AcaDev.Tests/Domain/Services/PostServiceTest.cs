using AcaDev.Domain.Services;
using Xunit;

namespace AcaDev.Tests.Domain.Services
{
    public class PostServiceTest
    {
        [Fact]
        public void TitleToUrlTitleTest()
        {
            var service = new PostService();
            var result = service.TitleToUrlTitle("Creating a new .net core app");
            Assert.Equal("creating-a-new-net-core-app", result);
        }
    }
}
