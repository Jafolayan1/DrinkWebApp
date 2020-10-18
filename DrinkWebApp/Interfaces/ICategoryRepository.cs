using DrinkWebApp.Data.Entities;
using System.Collections.Generic;

namespace DrinkWebApp.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}