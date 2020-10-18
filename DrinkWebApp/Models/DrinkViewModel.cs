using DrinkWebApp.Data.Entities;
using System.Collections.Generic;

namespace DrinkWebApp.Models
{
    public class DrinkViewModel
    {
        public IEnumerable<Drink> Drinks { get; set; }
        public string CurrentCategory { get; set; }
    }
}