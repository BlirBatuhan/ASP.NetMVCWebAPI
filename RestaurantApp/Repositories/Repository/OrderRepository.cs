using Entities;

namespace Repositories.Repository;

public class OrderRepository : IRepositroy<Order>
{
    private List<Order> orders;

    public OrderRepository(List<Order> orders)
    {
        this.orders = orders;
    }

    public void Delete(int id)
    {
        var item = GetOne(id);
        orders.Remove(item);
    }

    public Order GetOne(int id)
    {
       
            return orders.SingleOrDefault(o => o.Id.Equals(id));
        
    }

    public void Post(Order item)
    {
        orders.Add(item);
    }
}
