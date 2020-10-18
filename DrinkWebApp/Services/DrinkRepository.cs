using DrinkWebApp.Data.DbContexts;
using DrinkWebApp.Data.Entities;
using DrinkWebApp.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkWebApp.Services
{
    public class DrinkRepository : IDrinkRepository
    {
        private readonly AppDbContext _appDbContext;

        public DrinkRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Drink> PreferredDrinks => _appDbContext.Drinks.Where(p => p.IsPreferredDrink).Include(c => c.Category);

        public IEnumerable<Drink> Drinks { get => _appDbContext.Drinks.Include(c => c.Category); }

        public Drink GetDrinkById(int drinkId) => _appDbContext.Drinks.FirstOrDefault(p => p.DrinkId == drinkId);
    }
}