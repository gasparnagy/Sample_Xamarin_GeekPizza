using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekPizza1.Models;

namespace GeekPizza1.Services
{
    public interface IRestaurant
    {
        Task<IEnumerable<PizzaMenuItem>> GetMenuItemsAsync();
    }
}
