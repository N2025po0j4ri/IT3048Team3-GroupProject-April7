namespace ConferenceApp;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}
    private void loginbutton_Clicked(object sender, EventArgs e)
    {
        ErrorLabel.IsVisible = false;

        // Basic required field validation
        if (string.IsNullOrWhiteSpace(Username.Text) ||
            string.IsNullOrWhiteSpace(UserEmail.Text) )
        {
            ShowError("All fields are required.");
            return;
        }

        
        // If valid, navigate with parameters

        var myData = new Dictionary<string, object>
            {
                {"username",$"{Username.Text}" },
                {"useremail", $"{UserEmail.Text}" }
            };
        //  Shell.Current.GoToAsync($"{nameof(HomePage)}?username={Username.Text}&age={Age.Text}");
        Shell.Current.GoToAsync(nameof(TopicsPage), myData);
    }
    private void ShowError(string message)
    {
        ErrorLabel.Text = message;
        ErrorLabel.IsVisible = true;
    }

    private void guestbutton_Clicked(object sender, EventArgs e)
    {
        //  DisplayAlert("Save Contact", $"You clicked Save", "OK");
        Shell.Current.GoToAsync(nameof(TopicsPage));

        // Navigation.PushAsync(new TopicsPage());
    }
    private void backButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
        // Shell.Current.GoToAsync("../AnotherPage");
    }
}