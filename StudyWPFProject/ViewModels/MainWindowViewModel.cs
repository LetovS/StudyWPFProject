using StudyWPFProject.Infrastructure.Commands;
using StudyWPFProject.Models;
using StudyWPFProject.Services;
using StudyWPFProject.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Input;

namespace StudyWPFProject.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private string _Title = "My app";
        public string Title { get => _Title; set => Set(ref _Title, value); }

        public ObservableCollection<Teacher> Teachers { get; set; } = new ObservableCollection<Teacher>();

        #region Заглушки
        public List<Institute> Institutes = new ()
        {
            new Institute(){Name = "ИКИТ"},
            new Institute(){Name = "ГИ"},
            new Institute(){Name = "ИППС"},
            new Institute(){Name = "ИУБП"}
        };
        public List<Service> Services = new ()
        {
            new Service(){Name = "Discord"},
            new Service(){Name = "Zoom"},
            new Service(){Name = "WebinarSFU"}
        };
        #endregion

        private List<TopServiceItem> _TopServices = new ();
        public List<TopServiceItem>  TopServices { get => _TopServices; set => Set(ref _TopServices, value); }

        public Teacher NewTeacher { get; set; } = new Teacher();
        private void GetTop3Services()
        {
            TopServices = new List<TopServiceItem>(
                Teachers.GroupBy(p => p.Service)
                        .Select
                            (p => new TopServiceItem
                                {
                                    ServiceName = p.Key!.Name,
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
            AddNewTeacherCommand = new LambdaCommand(ExecuteAddNewTeacherCommand, CanExecuteAddNewTeacherCommand);
            GetTopServicesCommand = new LambdaCommand(ExecuteGetTopServicesCommand, CanExecuteGetTopServicesCommand);
            #region Init Commands

            #endregion

        }

        #region Commands
        public ICommand AddNewTeacherCommand { get; }
        private bool CanExecuteAddNewTeacherCommand(object arg) => true;
        private void ExecuteAddNewTeacherCommand(object obj)
        {
            throw new NotImplementedException();
        }

        //public RelayCommand GetTopServicesCommand { get; set => GetTop3Services(); }
        public ICommand GetTopServicesCommand { get; }
        private bool CanExecuteGetTopServicesCommand(object arg) => true;
        private void ExecuteGetTopServicesCommand(object obj) => GetTop3Services();
        #endregion

    }


}
