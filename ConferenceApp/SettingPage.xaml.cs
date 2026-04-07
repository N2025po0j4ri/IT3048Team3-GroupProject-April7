namespace ConferenceApp;

public partial class SettingPage : ContentPage
{
   
    public SettingPage()
	{
		InitializeComponent();
        
    }
    private void backButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
        // Shell.Current.GoToAsync("../AnotherPage");
    }

}