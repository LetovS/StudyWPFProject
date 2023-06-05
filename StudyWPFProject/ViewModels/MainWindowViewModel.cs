﻿using StudyWPFProject.Infrastructure.Commands;
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
        private void GetTop3Services()
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
        private bool CanExecuteAddNewTeacherCommand(object arg)
        {
            if (string.IsNullOrEmpty(NewTeacher.FullName) || NewTeacher.Institute is null || NewTeacher.Service is null) return false;
            return true;
        }
        private void ExecuteAddNewTeacherCommand(object obj)
        {
            if (!Teachers.Contains(NewTeacher))
            {
                Teachers.Add(NewTeacher);
                NewTeacher = new Teacher();
                SelectedIndexAddNewTeacherByInstitute = -1;
                SelectedIndexAddNewTeacherByService = -1;
            }
        }

        //public RelayCommand GetTopServicesCommand { get; set => GetTop3Services(); }
        public ICommand GetTopServicesCommand { get; }
        private bool CanExecuteGetTopServicesCommand(object arg) => true;
        private void ExecuteGetTopServicesCommand(object obj) => GetTop3Services();
        #endregion

    }


}
