using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkWebApp.Interfaces
{
    public interface IDbInitializer
    {
        void Seed(IServiceProvider svp);
    }
}