using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SkateShop.Maui.Entities.Cart;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SkateShop.Maui.Views
{
    public partial class ProductItemViewModel : ObservableObject
    {
        private readonly CartStore _cartStore;

        public string Name { get; }
        public decimal Price { get; }

        public ProductItemViewModel(string name, decimal price, CartStore cartStore)
        {
            Name = name;
            Price = price;
            _cartStore = cartStore;
        }

        [RelayCommand]
        private void AddToCart()
        {
            _cartStore.AddToCart(new CartItem(Name, Price));
        }
    }

    public class ProductViewModel : ObservableObject
    {
        private readonly ObservableCollection<ProductItemViewModel> _products;

        public ObservableCollection<ProductItemViewModel> Products => _products;

        public ProductViewModel(CartStore cartStore)
        {
            _products = new ObservableCollection<ProductItemViewModel>()
            {
                new ProductItemViewModel("Grip Tape", 9.99m, cartStore),
                new ProductItemViewModel("Deck", 9.99m, cartStore),
                new ProductItemViewModel("Wheels", 9.99m, cartStore),
                new ProductItemViewModel("Bearings", 9.99m, cartStore),
                new ProductItemViewModel("Trucks", 9.99m, cartStore)
            };
        }
    }
}
