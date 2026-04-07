
namespace ConferenceApp;

[QueryProperty(nameof(User_Name), "username")]
[QueryProperty(nameof(UserEmail), "useremail")]
public partial class TopicsPage : ContentPage
{
    public string User_Name { get; set; }
    public string UserEmail { get; set; }

    public List<DayGroup> Topics = new List<DayGroup>();
    public TopicsPage()
    {
        InitializeComponent();
        Topics.Add(new DayGroup("Day 1", new List<Topic>
        {
            new Topic(){ Name="Artificial Intelligence",Speakers="John Paul",ImageName="ai.png",Detail="Gen AI"},
            new Topic(){ Name="Image AI",Speakers="Guru V",ImageName="ai.png",Detail="Image AI"},
        }));
        Topics.Add(new DayGroup("Day 2", new List<Topic>
        {
            new Topic(){ Name="Artificial Intelligence",Speakers="John Paul",ImageName="ai.png",Detail="Gen AI"},
            new Topic(){ Name="Data Analysis",Speakers="Data Guru",ImageName="dataanalysis.png",Detail="Advanced Data analytics"},
        }));
        LvTopics.ItemsSource = Topics;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Add blank line after the text

        MessageLabel.Text = "Welcome " + $"{User_Name}"+ "!"+ $"{Environment.NewLine}";
    }

    private void LvTopic_SelectionChangedd(object sender, SelectionChangedEventArgs e)
    {
        var selectedItem = e.CurrentSelection.FirstOrDefault() as Topic;
        if (selectedItem == null) return;
        Navigation.PushAsync(new TopicDetailPage(selectedItem));
        ((CollectionView)sender).SelectedItem = null;
    }
    private void settingButton_Clicked(object sender, EventArgs e)
    {
        //  DisplayAlert("Save Contact", $"You clicked Save", "OK");  

        Navigation.PushAsync(new SettingPage());
    }
    private void searchButton_Clicked(object sender, EventArgs e)
    {
        //  DisplayAlert("Save Contact", $"You clicked Save", "OK");  

        Navigation.PushAsync(new SearchPage());
    }
    private void SignOutButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
        // Shell.Current.GoToAsync("../AnotherPage");
    }
}