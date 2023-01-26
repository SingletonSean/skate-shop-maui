using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SkateShop.Maui.Entities.Cart;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace SkateShop.Maui.Views
{
    public class CartItemViewModel : ObservableObject
    {
        public string Name { get; }
        public decimal Price { get; }

        public CartItemViewModel(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }


    public partial class CartViewModel : ObservableValidator,
        IRecipient<CartItemAddedMessage>
    {
        private readonly ObservableCollection<CartItemViewModel> _cartItems;

        public ObservableCollection<CartItemViewModel> CartItems => _cartItems;

        [ObservableProperty]
        [IsTrue]
        private bool _hasAgreedToTermsAndConditions;

        public CartViewModel(IMessenger messenger)
        {
            _cartItems = new ObservableCollection<CartItemViewModel>();

            messenger.RegisterAll(this);

            var response = messenger.Send<CartItemsRequestMessage>();
            Receive(response);
        }


        [RelayCommand]
        private async Task Checkout()
        {
            ValidateAllProperties();

            if (HasErrors)
            {
                return;
            }

            await Application.Current.MainPage.DisplayAlert("Success", "Checkout completed!", "Ok");
        }

        //protected override void OnActivated()
        //{
        //    StrongReferenceMessenger.Default.Register<CartItemAddedMessage>(this);
        //    StrongReferenceMessenger.Default.Register<CartItemsRequestMessage>(this);

        //    StrongReferenceMessenger.Default.Send<CartItemsRequestMessage>();

        //    base.OnActivated();
        //}

        //protected override void OnDeactivated()
        //{
        //    StrongReferenceMessenger.Default.Unregister<CartItemAddedMessage>(this);
        //    StrongReferenceMessenger.Default.Unregister<CartItemsRequestMessage>(this);

        //    base.OnDeactivated();
        //}

        public void Receive(CartItemAddedMessage message)
        {
            AddCartItem(message.Item);
        }

        public void Receive(CartItemsRequestMessage message)
        {
            if (!message.HasReceivedResponse)
            {
                return;
            }

            _cartItems.Clear();

            foreach (CartItem item in message.Response)
            {
                AddCartItem(item);
            }
        }

        private void AddCartItem(CartItem item)
        {
            _cartItems.Add(new CartItemViewModel(item.Name, item.Price));
        }
    }

    public sealed class IsTrueAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return bool.TryParse(value.ToString(), out bool result) && result
                ? ValidationResult.Success
                : new ValidationResult("Value must be true");
        }
    }
}
