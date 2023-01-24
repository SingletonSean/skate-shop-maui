using System.Collections.ObjectModel;

namespace SkateShop.Maui.Views;

public partial class ProductView : ContentPage
{
	public ProductView()
	{
		InitializeComponent();

		productListing.ItemsSource = new ObservableCollection<string>()
		{
			"Grip Tape", "Deck", "Wheels", "Bearings", "Trucks"
		};
	}
}