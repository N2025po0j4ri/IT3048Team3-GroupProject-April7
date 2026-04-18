
namespace ConferenceApp;

public partial class TopicDetailPage : ContentPage
{
	public TopicDetailPage(Session session)
	{
        InitializeComponent();
        TopicImage.Source = session.ImageName;
        LblTopicName.Text = session.TopicName;
        LblSpeakers.Text = session.Speakers;
        LblTopicDesc.Text = session.Detail;
    }

    private void backButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}