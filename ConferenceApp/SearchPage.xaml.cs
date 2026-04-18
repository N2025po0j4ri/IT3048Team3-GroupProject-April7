namespace ConferenceApp;

public partial class SearchPage : ContentPage
{
    private readonly LocalDBService _dbService;
    private List<Session> _favorites = new List<Session>();

    public SearchPage(LocalDBService dbService)
    {
        InitializeComponent();
        _dbService = dbService;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        _favorites = await _dbService.GetFavorites();
        LvTopics.ItemsSource = _favorites;
    }

    private void SearchInput_TextChanged(object sender, EventArgs e)
    {
        string searchText = SearchInput.Text;
        if (string.IsNullOrWhiteSpace(searchText))
        {
            LvTopics.ItemsSource = _favorites;
            return;
        }

        var filtered = _favorites
            .Where(t => t.TopicName.Contains(searchText, StringComparison.OrdinalIgnoreCase))
            .ToList();

        LvTopics.ItemsSource = filtered;
    }

    private void backButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}