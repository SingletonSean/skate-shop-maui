using System.Collections.ObjectModel;
using Windows.ApplicationModel.Store;

namespace SkateShop.Maui.Views;

public partial class CartView : ContentPage
{
    public CartView()
    {
		InitializeComponent();

        cartListing.ItemsSource = new ObservableCollection<string>()
        {
            "Grip Tape", "Deck", "Wheels", "Bearings", "Trucks"
        };
    }
}