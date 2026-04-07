

namespace ConferenceApp;

public partial class TopicDetailPage : ContentPage
{
	public TopicDetailPage(Topic topic)
	{
		
        InitializeComponent();
        TopicImage.Source = topic.ImageName;
        LblTopicName.Text = topic.Name;
        LblTopicDesc.Text = topic.Detail;
    }

    private void backButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
        // Shell.Current.GoToAsync("../AnotherPage");
    }
}