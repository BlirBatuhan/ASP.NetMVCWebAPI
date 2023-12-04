namespace BlogApi.Controller;
using BlogRepositories;
using BlogEntities.Models;
using Microsoft.AspNetCore.Mvc;

 [ApiController]
[Route("api/posts")]
public class PostsController: ControllerBase
{
    [HttpPost]
    public IActionResult AddPost(Posts posts)
    {
        PostRepositories.AddPost(posts);
        return Ok();
    }

    [HttpPut("addcomment/{postId}")]
    public IActionResult AddComment(int postId,Comments comment)
    {
        try
    {
        PostRepositories.AddComment(postId, comment);
        return Ok();
    }
    catch (Exception ex)
    {
        return BadRequest($"Error adding comment: {ex.Message}");
    }
    }

    [HttpGet]
    public IActionResult GetAllPosts()
    {
        PostRepositories.GetAllPosts();
        return Ok();
    }

    [HttpGet("getallpostsbyauthor/{userId}")]
    public IActionResult GetAllPostByAuthor(int userId)
    {
        PostRepositories.GetAllPostByAuthor(userId);
        return Ok();
    }

    [HttpGet("getonepostbyauthor/{postId}/{userId}")]
    public IActionResult GetOnePostByAuthor(int postId,int userId)
    {
        PostRepositories.GetOnePostByAuthor(postId,userId);
        return Ok();
    }


}