using CommunityToolkit.Mvvm.Input;
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
        public List<Institute> Institutes { get; set; } = new()
        {
            new Institute(){Name = "ИКИТ"},
            new Institute(){Name = "ГИ"},
            new Institute(){Name = "ИППС"},
            new Institute(){Name = "ИУБП"}
        };
        public List<Service> Services { get; set; } = new ()
        {
            new Service(){Name = "Discord"},
            new Service(){Name = "Zoom"},
            new Service(){Name = "WebinarSFU"}
        };
        #endregion

        private List<TopServiceItem> _TopServices = new ();
        public List<TopServiceItem>  TopServices { get => _TopServices; set => Set(ref _TopServices, value); }

        private int _SelectedIndexAddNewTeacherByInstitute = -1;
        public int SelectedIndexAddNewTeacherByInstitute { get => _SelectedIndexAddNewTeacherByInstitute; set => Set(ref _SelectedIndexAddNewTeacherByInstitute, value); }
        private int _SelectedIndexAddNewTeacherByService = -1;
        public int SelectedIndexAddNewTeacherByService { get => _SelectedIndexAddNewTeacherByService; set => Set(ref _SelectedIndexAddNewTeacherByService, value); }

        public Teacher NewTeacher { get; set; } = new Teacher();
        private void ExecuteGetTop3UsingServices()
        {
            TopServices = new List<TopServiceItem>(
                Teachers.GroupBy(p => p.Service!.Name)
                        .Select
                            (p => new TopServiceItem
                                {
                                    ServiceName = p.Key,
                                    CountOfUsing = p.Count()
                                }
                            )
                        .OrderByDescending(t => t.CountOfUsing)
                        .Take(3)
                        .ToList());
        }
        private void ExecuteAddNewTeacherInCollection()
        {
            if (!Teachers.Contains(NewTeacher))
            {
                Teachers.Add(NewTeacher);
                NewTeacher = null!;
                SelectedIndexAddNewTeacherByInstitute = -1;
                SelectedIndexAddNewTeacherByService = -1;
            }
        }

        public MainWindowViewModel()
        {
            Teachers.Add(new Teacher() { FullName = "Sergey", Institute = new Institute() { Name = "ГИ" }, Service = new Service() { Name = "Discord" } });

            #region Init Commands
            AddNewTeacherCommand = new RelayCommand(ExecuteAddNewTeacherInCollection, () => true);
            GetTopServicesCommand = new RelayCommand(ExecuteGetTop3UsingServices, () => Teachers.Count > 0);
            #endregion

        }

        private bool CanExecuteAddNewTeacherInCollection()
        {
            if (string.IsNullOrWhiteSpace(NewTeacher.FullName) || NewTeacher.Institute is null || NewTeacher.Service is null) return false;
            return true;
        }

        #region Commands
        public RelayCommand AddNewTeacherCommand { get;  }
        public RelayCommand GetTopServicesCommand { get;  }
        
        #endregion

    }


}
