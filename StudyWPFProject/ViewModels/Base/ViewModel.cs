﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPFProject.ViewModels.Base
{
    internal abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string propName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string propName = null!)
        {
            if(Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propName);
            return true;
        }
        
    }
}
