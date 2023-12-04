using BlogEntities.Models;

namespace BlogRepositories;

public static class PostRepositories
{
    private static List<Posts> posts;
    static PostRepositories()
    {
        posts = new List<Posts>();
    }
    // Post listesine ekler
    public static void AddPost(Posts item)
    {
        posts.Add(item);
    }


    public static void AddComment(int postId, Comments comment)
    {
    var post = posts.FirstOrDefault(p => p.PostId == postId);

    if (post != null)
    {
        // Yorumun tarihini ayarla
        comment.DatePosted = DateTime.Now;
        

        // Eğer CommentList null ise, yeni bir liste oluştur
        post.CommentList ??= new List<Comments>();

        // Yorumu gönderiye ekle
        post.CommentList.Add(comment);
    }
    else
    {
        Console.WriteLine($"Post with ID {postId} not found.");
    }
    }

    public static List<Posts> GetAllPosts()
    {
        //Tüm Listeyi Getirir
        return posts.ToList();
    }

    public static List<Posts> GetAllPostByAuthor(int userId)
    {
         return posts.Where(p => p.Author?.UserId == userId).ToList();
    }
    
    public static Posts GetOnePostByAuthor(int postId,int userId)
    {
        // Verilen postıd ve userıd'nin parametlerinin sadece paylaşımını gösterir. 
         var post = posts.FirstOrDefault(p => p.PostId == postId && p.Author?.UserId == userId);
    //Null değer dönerse hata fırlatır.
    if (post == null)
    {
        throw new InvalidOperationException($"Post with postId: {postId} and userId: {userId} not found.");
    }

    return post;
    }

}
