using CommunityToolkit.Mvvm.Messaging;

namespace SkateShop.Maui.Entities.Cart
{
    public class CartStore
    {
        private readonly IMessenger _messenger;
        private readonly List<CartItem> _items;

        public CartStore(IMessenger messenger)
        {
            _messenger = messenger;
            _items = new List<CartItem>();

            messenger.Register<CartStore, CartItemsRequestMessage>(this, (cartStore, message) =>
            {
                message.Reply(cartStore._items);
            });
        }

        public void AddToCart(CartItem item)
        {
            _items.Add(item);

            _messenger.Send(new CartItemAddedMessage(item));
        }
    }
}
