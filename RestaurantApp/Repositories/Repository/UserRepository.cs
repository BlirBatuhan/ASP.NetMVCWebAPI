using System.Security.Cryptography;
using Entities;
using Repositories.Repository;
using Repositories.Services;

namespace Repositories;

public class UserRepository : IRepositroy<User>
{
    private RepositoryDbContext dbContext;

    public UserRepository(RepositoryDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public void Delete(int id)
    {
        var item = GetOne(id);
        if (item is null)
            return;
        dbContext.Users.Remove(item);
        dbContext.SaveChanges();
    }

    public User GetOne(int id)
    {
        return dbContext.Users.SingleOrDefault(user => user.Id.Equals(id));
    }

    public void Post(User item)
    {
        if (item is null)
            return;

        var salt = RandomNumberGenerator.GetInt32(10000);

        var pass = item.Password.Encoder(salt);
        item.Password = pass;
        item.Salt = salt;
        dbContext.Users.Add(item);
        dbContext.SaveChanges();
    }

    public User GetData(string email, string password)
    {
        var user = dbContext.Users.SingleOrDefault(user => user.Email.Equals(email));
        if (user is null)
            return null;

        var pass = password.Encoder(user.Salt);

        if (user.Password.Equals(pass))
            return user;
        return null;
    }
}

