using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekPizza.Models;

namespace GeekPizza.Services
{
    public interface IRestaurant
    {
        Task<IEnumerable<PizzaMenuItem>> GetMenuItemsAsync();
        Task<Address> GetDefaultDeliveryAddressAsync();
    }
}
