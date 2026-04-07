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
            // Shell.Current.GoToAsync(nameof(AdminPage));
            Shell.Current.Navigation.PushAsync(new AdminPage(new LocalDBService()));
        }
    }
}
