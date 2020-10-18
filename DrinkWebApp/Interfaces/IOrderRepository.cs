using DrinkWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkWebApp.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}