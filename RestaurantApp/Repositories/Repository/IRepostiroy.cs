namespace Repositories.Repository;

public interface  IRepositroy<T>
{
    public T GetOne(int id);
    public void Post(T item);
    public void Delete(int id);
    
}