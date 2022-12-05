using Microsoft.AspNetCore.Mvc;

namespace dotnet_api_test.Controllers;

[ApiController]
[Route("[controller]")]
public class BloggingController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<BloggingController> _logger;

    public BloggingController(ILogger<BloggingController> logger)
    {
        _logger = logger;
    }

    [HttpGet()]
    public IEnumerable<Blog> Get()
    {

        using var db = new BloggingContext();

        // Note: This sample requires the database to be created before running.
        Console.WriteLine($"Database path: {db.DbPath}.");

        // Create
        // Console.WriteLine("Inserting a new blog");
        // db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
        // db.SaveChanges();

        // Read
        Console.WriteLine("Querying for a blog");
        var blog = db.Blogs
            .OrderBy(b => b.BlogId)
            .ToList();
        return blog;
    }
    [HttpPost()]
    public IEnumerable<Blog> Post([FromBody] Blog body)
    {

        using var db = new BloggingContext();

        // Note: This sample requires the database to be created before running.
        Console.WriteLine($"Database path: {db.DbPath}.");

        // Create
        Console.WriteLine("Inserting a new blog");
        db.Add(body);
        db.SaveChanges();

        // Read
        Console.WriteLine("Querying for a blog");
        var blog = db.Blogs
            .OrderBy(b => b.BlogId)
            .ToList();
        return blog;
    }
    [HttpPut("{id}")]
    public IEnumerable<Blog> Delete([FromBody] Blog body, int id)
    {

        using var db = new BloggingContext();

        // Note: This sample requires the database to be created before running.
        Console.WriteLine($"Database path: {db.DbPath}.");

        // Update
        Console.WriteLine("Querying for a blog");
        var blog = db.Blogs
            .Find(id);
        blog.Url = body.Url;
        db.SaveChanges();
        // Read
        Console.WriteLine("Querying for a blog");
        var list = db.Blogs
            .OrderBy(b => b.BlogId)
            .ToList();
        return list;
    }
    [HttpDelete("{id}")]
    public IEnumerable<Blog> Delete(int id)
    {

        using var db = new BloggingContext();

        // Note: This sample requires the database to be created before running.
        Console.WriteLine($"Database path: {db.DbPath}.");

        // Create
        Console.WriteLine("Inserting a new blog");
        // Delete
        Console.WriteLine("Delete the blog");
        db.Remove(new Blog { BlogId = id });
        db.SaveChanges();

        // Read
        Console.WriteLine("Querying for a blog");
        var blog = db.Blogs
            .OrderBy(b => b.BlogId)
            .ToList();
        return blog;
    }
}
