using EF_app_1;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestExample.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        /*

        // GET: api/<SeedController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SeedController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SeedController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SeedController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        */

        [HttpPost]
        public void SeedData()
        {
            var db = new MyDbContext();
            var blog1 = new Blog { Url = "http://myblog.net" };
            db.Blogs.Add(blog1);
            db.Blogs.Add(new Blog { Url = "http://travelblog.net" });
            var post1 = new Post { Content = "My first travel content", Title = "Trip to Spain" };
            var post2 = new Post { Content = "My second travel content", Title = "Trip to France" };

            blog1.Posts.Add(post1);
            blog1.Posts.Add(post2);

            db.SaveChanges();
        }

        /*
        // DELETE api/<SeedController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        */
    }
}
