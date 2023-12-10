namespace LibraryOne;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
	}

    private async void GoToCheckoutPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CheckoutPage());
    }
}

