﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StudyWPFProject.Models
{
    internal class Teacher
    {
        public string? FullName { get; set; }
        public Institute? Institute { get; set; }
        public Service? Service { get; set; }
        //public override bool Equals(object? obj)
        //{
        //    return obj is Teacher teacher && this.FullName == teacher.FullName;
        //}
        //public override int GetHashCode()
        //{
        //    return base.GetHashCode();
        //}
    }
}
