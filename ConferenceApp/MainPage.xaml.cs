namespace ConferenceApp
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
        }

        private void startButton_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(HomePage));
        }

        private void adminButton_Clicked(object sender, EventArgs e)
        {
            var page = Application.Current.Handler.MauiContext.Services.GetService<AdminPage>();
            Shell.Current.Navigation.PushAsync(page);
        }
    }
}
