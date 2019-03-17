using AcaDev.Model.Entities;
using AcaDev.Model.IService;
using AcaDev.Repository.Repositories.Interfaces;
using AcaDev.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaDev.Model.Services
{
    public class PostsService : BaseService<Post, IPostsRepository>, IPostsService
    {   
        public PostsService(IPostsRepository repository) : base(repository)
        {
        }

        public async Task<Result<List<Post>>> GetByTag(int tagId)
        {
            var posts = await repository.GetAll()
                .Where(a => a.PostTags.Contains(new PostTag { TagId = tagId }))
                .AsQueryable().ToListAsync();

            if (posts.Count > 0)
            {
                return Result.Ok(posts);
            }

            return Result.Fail<List<Post>>("No post found in this tag", ResultCode.NotFound);
        }

        public async Task<Result<Post>> GetWithComments(int id)
        {
            var post = await repository.GetWithComments(id);
            if (post != null)
            {
                return Result.Ok(post);
            }

            return Result.Fail<Post>("Entity not found", ResultCode.NotFound);
        }
    }
}
