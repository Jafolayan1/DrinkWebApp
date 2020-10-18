using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkWebApp.Data.Entities
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Drink Drink { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}