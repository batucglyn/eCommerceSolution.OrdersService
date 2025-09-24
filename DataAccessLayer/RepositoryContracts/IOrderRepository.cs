using eCommerce.OrdersMicroervice.DataAccessLayer.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.OrdersMicroervice.DataAccessLayer.RepositoryContracts;

public interface IOrderRepository
{

    Task<IEnumerable<Order>> GetOrders();

    Task<IEnumerable<Order?>> GetOrdersByCondition(FilterDefinition<Order>filter);
    Task<Order?> GetOrderByCondition(FilterDefinition<Order>filter);

    Task<Order?> AddOrder(Order order);
    Task<Order?> UpdateOrder(Order order);

    Task<bool> DeleteOrder(Guid orderID);







}

