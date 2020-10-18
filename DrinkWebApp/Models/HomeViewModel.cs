using DrinkWebApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkWebApp.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Drink> PreferredDrinks { get; set; }
    }
}