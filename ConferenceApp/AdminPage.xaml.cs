namespace ConferenceApp;

public partial class AdminPage : ContentPage
{
    private readonly LocalDBService _dbService;
    private int _editSessionId;
    public AdminPage(LocalDBService dbService)
    {
        InitializeComponent();
        _dbService = dbService;
        Task.Run(async () => Lv.ItemsSource = await _dbService.GetSessions());
    }

    private async void saveButton_Clicked(object sender, EventArgs e)
    {
        if (_editSessionId == 0)
        {
            await _dbService.Create(new Session
            {
                TopicName = nameEntry.Text,
                Speakers = speakersEntry.Text,
                Detail = detailEntry.Text
            });

        }
        else
        {
            await _dbService.Update(new Session
            {
                Id = _editSessionId,
                TopicName = nameEntry.Text,
                Speakers = speakersEntry.Text,
                Detail = detailEntry.Text

            });
            _editSessionId = 0;
        }
        nameEntry.Text = "";
        speakersEntry.Text = "";
        detailEntry.Text = "";
        Lv.ItemsSource = await _dbService.GetSessions();
    }

    private async void Lv_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var session = e.Item as Session;
        var action = await DisplayActionSheet("Action", "Cancel", null, "Edit", "Delete");
        switch (action)
        {
            case "Edit":
                _editSessionId = session.Id;
                nameEntry.Text = session.TopicName;
                speakersEntry.Text = session.Speakers;
                detailEntry.Text = session.Detail;
                break;
            case "Delete":
                await _dbService.Delete(session);
                Lv.ItemsSource = await _dbService.GetSessions();
                break;
        }

    }
    private void backButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
        // Shell.Current.GoToAsync("../AnotherPage");
    }
}