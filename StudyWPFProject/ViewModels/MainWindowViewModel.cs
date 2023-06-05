using StudyWPFProject.Models;
using StudyWPFProject.Services;
using StudyWPFProject.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Documents;

namespace StudyWPFProject.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private string _Title = "My app";
        public string Title { get => _Title; set => Set(ref _Title, value); }


        private Teacher _SelectedTeacher;
        public Teacher SelectedTeacher { get => _SelectedTeacher; set => Set(ref _SelectedTeacher, value); }

        private ObservableCollection<Teacher> Teachers { get; set; } = new ObservableCollection<Teacher>();

        public List<Institute> Institutes = new List<Institute>()
        {
            new Institute(){Name = "ИКИТ"},
            new Institute(){Name = "ГИ"},
            new Institute(){Name = "ИППС"},
            new Institute(){Name = "ИУБП"}
        };
        public List<Service> Services = new List<Service>()
        {
            new Service(){Name = "Discord"},
            new Service(){Name = "Zoom"},
            new Service(){Name = "WebinarSFU"}
        };

        private List<TopServiceItem> _TopServices;
        public List<TopServiceItem>  TopServices { get => _TopServices; set => Set(ref _TopServices, value); }
        public Teacher NewTeacher { get; set; } = new Teacher();
        private void GetTop3Services()
        {
            TopServices = new List<TopServiceItem>(
                Teachers.GroupBy(p => p.Service)
                        .Select
                            (p => new TopServiceItem
                                {
                                    ServiceName = p.Key.Name,
                                    CountOfUsing = p.Count()
                                }
                            )
                        .OrderByDescending(t => t.CountOfUsing)
                        .Take(3)
                        .ToList());
        }

        public MainWindowViewModel()
        {
            Teachers.Add(new Teacher() { FullName = "Sergey", Institute = new Institute() { Name = "ГИ" }, Service = new Service() { Name = "Discord" } });
        }
    }

    
}
