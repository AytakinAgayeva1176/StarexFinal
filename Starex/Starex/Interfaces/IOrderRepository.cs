using Starex.Models;
using Starex.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starex.Interfaces
{
    public interface IOrderRepository
    {
        Task<bool> Create(OrderViewModel orderViewModel);
        Task Delete(int id);
        bool Pay(int id, string userId);
        Task<Order> GetOrderById(int id);

    }
}
