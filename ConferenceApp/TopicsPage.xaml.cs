
namespace ConferenceApp;

[QueryProperty(nameof(User_Name), "username")]
[QueryProperty(nameof(UserEmail), "useremail")]
public partial class TopicsPage : ContentPage
{
    public string User_Name { get; set; }
    public string UserEmail { get; set; }

    private readonly LocalDBService _dbService;

    public TopicsPage(LocalDBService dbService)
    {
        InitializeComponent();
        _dbService = dbService;
    }

    private List<Session> _allSessions = new List<Session>();

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        MessageLabel.Text = string.IsNullOrWhiteSpace(User_Name)
            ? "Welcome!"
            : $"Welcome {User_Name}!";

        var sessions = await _dbService.GetSessions();
        _allSessions = sessions;
        GroupAndDisplay(_allSessions);
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
        if (string.IsNullOrWhiteSpace(searchText))
        {
            GroupAndDisplay(_allSessions);
            return;
        }
        var filtered = _allSessions
            .Where(s => s.TopicName.Contains(searchText, StringComparison.OrdinalIgnoreCase))
            .ToList();
        GroupAndDisplay(filtered);
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
        _allSessions = await _dbService.GetSessions();
        GroupAndDisplay(_allSessions);
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