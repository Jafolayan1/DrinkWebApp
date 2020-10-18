using DrinkWebApp.Data.Entities;
using System.Collections.Generic;

namespace DrinkWebApp.Interfaces
{
    public interface IDrinkRepository
    {
        IEnumerable<Drink> Drinks { get; }
        IEnumerable<Drink> PreferredDrinks { get; }

        Drink GetDrinkById(int drinkId);
    }
}