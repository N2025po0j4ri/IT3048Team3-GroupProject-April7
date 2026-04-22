
namespace ConferenceApp;

[QueryProperty(nameof(User_Name), "username")]
[QueryProperty(nameof(UserEmail), "useremail")]
public partial class TopicsPage : ContentPage
{
    public string User_Name { get; set; }
    public string UserEmail { get; set; }

    private readonly LocalDBService _dbService;
    private readonly ViewModels.TopicsViewModel _vm;

    public TopicsPage(LocalDBService dbService)
    {
        InitializeComponent();
        _dbService = dbService;
        _vm = new ViewModels.TopicsViewModel(_dbService);
        BindingContext = _vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        MessageLabel.Text = string.IsNullOrWhiteSpace(User_Name)
            ? "Welcome!"
            : $"Welcome {User_Name}!";

        await _vm.LoadSessions();
        LvTopics.ItemsSource = _vm.Groups;
    }

    private void GroupAndDisplay(List<Session> sessions)
    {
        var grouped = sessions
            .GroupBy(s => s.Day)
            .Select(g => new DayGroup(g.Key ?? "Other", g.ToList()))
            .ToList();
        LvTopics.ItemsSource = grouped;
    }

    private void SessionSearch_TextChanged(object sender, TextChangedEventArgs e)
    {
        string searchText = e.NewTextValue;
        _ = _vm.LoadSessions(searchText);
        LvTopics.ItemsSource = _vm.Groups;
    }

    private void LvTopic_SelectionChangedd(object sender, SelectionChangedEventArgs e)
    {
        var selectedItem = e.CurrentSelection.FirstOrDefault() as Session;
        if (selectedItem == null) return;
        Navigation.PushAsync(new TopicDetailPage(selectedItem));
        ((CollectionView)sender).SelectedItem = null;
    }
    private async void FavoriteButton_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var session = button.CommandParameter as Session;
        if (session == null) return;
        await _dbService.ToggleFavorite(session);
        await _vm.LoadSessions();
        LvTopics.ItemsSource = _vm.Groups;
    }

    private void searchButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new SearchPage(_dbService));
    }
    private void SignOutButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}