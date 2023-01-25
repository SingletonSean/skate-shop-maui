using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateShop.Maui.Entities.Cart
{
    public class CartStore
    {
        private readonly List<CartItem> _items;

        public CartStore()
        {
            _items = new List<CartItem>();

            StrongReferenceMessenger.Default.Register<CartStore, CartItemsRequestMessage>(this, (cartStore, message) =>
            {
                message.Reply(cartStore._items);
            });
        }

        public void AddToCart(CartItem item)
        {
            _items.Add(item);

            StrongReferenceMessenger.Default.Send(new CartItemAddedMessage(item));
        }
    }
}
