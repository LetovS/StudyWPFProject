using StudyWPFProject.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPFProject.Models
{
    internal class Service : ViewModel
    {
        
        private string _name;
        public string? Name { get => _name; set => Set(ref _name!, value); }
        public override string ToString() => Name!;
        //TODO При выборе в главном представлении чего либо выскакивает исключение 
        public override bool Equals(object? obj)
        {
            return this.Name == ((Service)obj!).Name;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
