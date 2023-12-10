namespace LibraryOne;

public partial class CheckoutPage : ContentPage
{
	public CheckoutPage()
	{
		InitializeComponent();
	}

    private async void GoToMainPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}