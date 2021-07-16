using Basket.API.Entity;
using System.Threading.Tasks;

namespace Basket.API.Repository
{
    interface IBasketRepository
    {
        public Task<ShoppingCart> getBasket(string userName);

        public Task<ShoppingCart> updateBasket(ShoppingCart cart);

        public Task deleteBasket(string userName);
    }
}
