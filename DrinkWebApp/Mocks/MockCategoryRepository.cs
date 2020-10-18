using DrinkWebApp.Data.Entities;
using DrinkWebApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkWebApp.Mocks
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> Categories
        {
            get
            {
                return new List<Category>
                {
                    new Category {CategoryName ="Alcoholic", Description= "All Alcoholic Drinks", },
                    new Category {CategoryName ="Non-Alcoholic", Description= "All None-Alcoholic Drinks"}
                };
            }
            set
            {
            }
        }
    }
}