using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateShop.Maui.Entities.Cart
{
    public class CartItemAddedMessage
    {
        public CartItem Item { get; }

        public CartItemAddedMessage(CartItem item)
        {
            Item = item;
        }
    }
}
