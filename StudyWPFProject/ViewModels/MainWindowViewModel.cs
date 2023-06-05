using StudyWPFProject.Models;
using StudyWPFProject.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows.Documents;

namespace StudyWPFProject.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private string _Title = "My app";
        public string Title { get => _Title; set => Set(ref _Title, value); }

        private ObservableCollection<Teacher> _Teachers = new ObservableCollection<Teacher>();
        public ObservableCollection<Teacher> Teachers { get => _Teachers; set => Set(ref _Teachers, value); }

        
        public MainWindowViewModel()
        {
            Teachers = new ObservableCollection<Teacher>()
            {
                new Teacher(){FullName = "Pupkin", Service = new Service(){Name = "Skype"},Institute = new Institute(){ Name = "ITMO"} },
                new Teacher(){FullName = "Vasay", Service = new Service(){Name = "Skype"}, Institute = new Institute(){ Name = "BGTU"} }
            };
        }

    }
}
