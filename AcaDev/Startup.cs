using System;
using System.Collections.Generic;
using AcaDev.Domain.Entities;
using AcaDev.Persistance.DbContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AcaDev
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("Default");
            AppDbDesign.ConnectionString = connectionString;
            AppDbContext.ConnectionString = connectionString;

            services.AddDbContext<AppDbContext>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });

                // Creates the database as soon as the docker container is up
                using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
                using (var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>())
                {
                    SetupDevDatabase(context);
                }
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }

        private void SetupDevDatabase(AppDbContext context)
        {
            context.Database.Migrate();

            Tag tag = new Domain.Entities.Tag { Name = ".net core", Description = "About .net core" };
            Author author = new Domain.Entities.Author { Name = "John Doe" };

            context.Tag.Add(tag);
            context.Author.Add(author);
            context.SaveChanges();

            Post post = new Post
            {
                Title = "Test Post III",
                AuthorId = author.Id,
                PublishDate = new DateTime(2019, 06, 12, 0, 0, 0),
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                "Proin nec egestas felis, et suscipit purus. Nam condimentum leo purus, " +
                "sit amet pellentesque eros eleifend quis. Duis eu tincidunt sapien, at commodo magna. " +
                "Integer placerat est eu velit varius, eu ullamcorper elit posuere. " +
                "In sed magna quis massa volutpat egestas. Aenean eu faucibus mi. Duis blandit auctor justo in placerat. " +
                "Maecenas ante nunc, malesuada et interdum a, euismod in dui. " +
                "Suspendisse auctor massa vel lorem scelerisque fringilla. Vivamus et libero arcu. " +
                "Proin imperdiet mi vitae purus feugiat, id rhoncus dolor placerat. Curabitur erat dolor, convallis at aliquam " +
                "et, interdum nec massa. Quisque sollicitudin, quam a condimentum rhoncus, libero nisi ornare nibh, id molestie " +
                "felis velit quis nibh."
            };

            context.Post.Add(post);
            context.SaveChanges();

            List<Comment> comments =
                new List<Comment>
                {
                    new Comment { Author = "Test I", Content = "test test test test", PostId = post.Id }
                };

            context.Comment.AddRange(comments);
            context.PostTag.Add(new Domain.Entities.PostTag { PostId = post.Id, TagId = tag.Id });
            context.SaveChanges();
        }
    }
}
