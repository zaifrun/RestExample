using EF_app_1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace RestExample.Controllers;

[ApiController]
[Route("[controller]")]
public class BlogController : ControllerBase
{


    private readonly ILogger<BlogController> _logger;
    MyDbContext context = new MyDbContext();

    public BlogController(ILogger<BlogController> logger)
    {
        _logger = logger;
    }

    // RestDTO<BoardGame[]>>

    // Data = await query.ToArrayAsync(),

    [HttpGet(Name = "GetBlogs")]
    public async Task<RestDto<Blog[]>> GetBlogs()
    {
        /* Dummy data - just to test endpoint before adding db*/
        /*var list = new List<Blog>();
        list.Add(new Blog()
        {
            Url = "my new blog"
        }); */

        var query = context.Blogs.OrderBy(b => b.BlogId)
            .Include(b => b.Posts);

        return new RestDto<Blog[]>()
        {
            Data = await query.ToArrayAsync(),
            RecordCount = await context.Blogs.CountAsync(),
        };
    }

    [HttpPost]
    public void AddBlog(BlogDto model)
    {
        var blog = new Blog
        {
            Url = model.Url
        };
        context.Blogs.Add(blog);
        context.SaveChangesAsync();

    }
}


