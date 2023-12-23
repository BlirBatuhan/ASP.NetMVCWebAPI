using Entities;

namespace Repositories.Repository;

public class CategoryRepository : IRepositroy<Categories>
{
    private List<Categories> categories;

    public CategoryRepository(List<Categories> categories)
    {
        this.categories = categories;
    }

    public void Delete(int id)
    {
        var item = GetOne(id);
        if (item is null)
            return;
        categories.Remove(item);
    }

    public Categories GetOne(int id)
    {
        return categories.SingleOrDefault(cat => cat.Id.Equals(id));
    }

    public void Post(Categories item)
    {
         categories.Add(item);
    }
}
