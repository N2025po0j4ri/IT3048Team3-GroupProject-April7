using System.Collections.ObjectModel;

namespace ConferenceApp;

public partial class SearchPage : ContentPage
{
    public List<Topic> Topics = new List<Topic>();
    public SearchPage()
	{
		InitializeComponent();
        Topics.Add(new Topic() { Name = "Artificial Intelligence", Speakers = "John Paul", ImageName = "ai.png", Detail = "Gen AI" });
        Topics.Add(new Topic() { Name = "Image AI", Speakers = "Guru V", ImageName = "ai.png", Detail = "Image AI" });
        Topics.Add(new Topic() { Name = "Artificial Intelligence", Speakers = "John Paul", ImageName = "ai.png", Detail = "Gen AI" });
        Topics.Add(new Topic() { Name = "Data Analysis", Speakers = "Data Guru", ImageName = "dataanalysis.png", Detail = "Advanced Data analytics" });
      
        LvTopics.ItemsSource = Topics;
    }
    
    private void FilterPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selected = FilterPicker.SelectedItem?.ToString();

        if (selected == "All" || string.IsNullOrEmpty(selected))
        {
            LvTopics.ItemsSource = Topics;
            return;
        }

        // Filter by Name only
        var filtered = Topics
            .Where(t => t.Name.Contains(selected, StringComparison.OrdinalIgnoreCase))
            .ToList();

        LvTopics.ItemsSource = filtered;
    }

    private void SearchInput_TextChanged(object sender, EventArgs e)
    {
        string SearchText = SearchInput.Text;
        if (string.IsNullOrWhiteSpace(SearchText))
        {
            LvTopics.ItemsSource = Topics;
            return;
        }
        else
        {
            var lower = SearchText.ToLower();

            var filtered = Topics
            .Where(t => t.Name.Contains(lower, StringComparison.OrdinalIgnoreCase))
            .ToList();

            LvTopics.ItemsSource = filtered;
        }


       
    }
    private void backButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
        // Shell.Current.GoToAsync("../AnotherPage");
    }

}