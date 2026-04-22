using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ConferenceApp.ViewModels
{
    public class TopicsViewModel : BindableObject
    {
        private readonly LocalDBService _dbService;

        public ObservableCollection<DayGroup> Groups { get; } = new ObservableCollection<DayGroup>();

        public TopicsViewModel(LocalDBService dbService)
        {
            _dbService = dbService;
        }

        public async Task LoadSessions(string filter = null)
        {
            var sessions = await _dbService.GetSessions();
            if (!string.IsNullOrWhiteSpace(filter))
            {
                sessions = sessions.Where(s => s.TopicName.Contains(filter, System.StringComparison.OrdinalIgnoreCase)).ToList();
            }

            var grouped = sessions
                .GroupBy(s => s.Day)
                .Select(g => new DayGroup(g.Key ?? "Other", g.ToList()))
                .ToList();

            Groups.Clear();
            foreach (var g in grouped)
                Groups.Add(g);
        }
    }
}