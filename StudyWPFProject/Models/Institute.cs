using StudyWPFProject.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPFProject.Models
{
    internal class Institute : ViewModel
    {
        private string _name;
        public string? Name { get => _name; set => Set(ref _name!, value); }
        public override string ToString() => Name!;
        //public override bool Equals(object? obj)
        //{
        //    return this.Name == ((Institute)obj!).Name;
        //}
        //public override int GetHashCode()
        //{
        //    return base.GetHashCode();
        //}
    }
}
