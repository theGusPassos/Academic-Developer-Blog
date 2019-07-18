using AcaDev.Domain.Entities;
using AcaDev.Domain.Services;
using Xunit;

namespace AcaDev.Tests.Domain.Services
{
    public class CommentServiceTest
    {
        [Fact]
        public void IsValidComment_Valid_ReturnTrue()
        {
            var service = new CommentService();
            var comment = new Comment
            {
                Content = "lorem",
                Author = "test test"
            };

            bool result = service.IsValidComment(comment);

            Assert.True(result);
        }

        [Fact]
        public void IsValidComment_NotValid_ReturnFalse()
        {
            var service = new CommentService();
            var comment = new Comment
            {
                Content = "",
                Author = ""
            };

            bool result = service.IsValidComment(comment);

            Assert.False(result);
        }
        
        [Fact]
        public void IsValidComment_NotValidOnlySpaces_ReturnFalse()
        {
            var service = new CommentService();
            var comment = new Comment
            {
                Content = "    ",
                Author = "    "
            };

            bool result = service.IsValidComment(comment);

            Assert.False(result);
        }
    }
}
