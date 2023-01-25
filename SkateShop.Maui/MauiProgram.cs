using Microsoft.Extensions.DependencyInjection;
using SkateShop.Maui.Entities.Cart;
using SkateShop.Maui.Views;

namespace SkateShop.Maui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<CartStore>();

		builder.Services.AddTransient<ProductViewModel>();
		builder.Services.AddTransient<ProductView>((s) => new ProductView()
		{
			BindingContext = s.GetRequiredService<ProductViewModel>()
		});
        
		builder.Services.AddTransient<CartViewModel>();
        builder.Services.AddTransient<CartView>((s) => new CartView()
        {
            BindingContext = s.GetRequiredService<CartViewModel>()
        });

        return builder.Build();
	}
}
