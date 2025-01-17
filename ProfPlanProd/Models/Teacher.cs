﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfPlanProd.Models
{
    internal class Teacher : INotifyPropertyChanged
    {
        private string _lastname;
        public string LastName
        {
            get { return _lastname; }
            set
            {
                if (_lastname != value)
                {
                    _lastname = value;
                    OnPropertyChanged(nameof(LastName));
                }
            }
        }
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }
        private string _middleName;
        public string MiddleName
        {
            get { return _middleName; }
            set
            {
                if (_middleName != value)
                {
                    _middleName = value;
                    OnPropertyChanged(nameof(MiddleName));
                }
            }
        }
        private string _position;
        public string Position
        {
            get { return _position; }
            set
            {
                if (_position != value)
                {
                    _position = value;
                    OnPropertyChanged(nameof(Position));
                }
            }
        }
        private string _academicDegree;
        public string AcademicDegree
        {
            get { return _academicDegree; }
            set
            {
                if (_academicDegree != value)
                {
                    _academicDegree = value;
                    OnPropertyChanged(nameof(AcademicDegree));
                }
            }
        }
        private string _post;
        public string Post
        {
            get { return _post; }
            set
            {
                if (_post != value)
                {
                    _post = value;
                    OnPropertyChanged(nameof(Post));
                }
            }
        }
        private double? _workload;
        public double? Workload
        {
            get { return _workload; }
            set
            {
                if (_workload != value)
                {
                    _workload = value;
                    OnPropertyChanged(nameof(Workload));
                }
            }
        }

        private double? _workloadCount;
        public double? WorkloadCount
        {
            get { return _workloadCount; }
            set
            {
                if (_workloadCount != value)
                {
                    _workloadCount = value;
                    OnPropertyChanged(nameof(WorkloadCount));
                }
            }
        }
        public Teacher() { }
        public Teacher(string lastName, string firstName, string middleName, string position, string academicDegree, string post, double? workload, double? workloadCount)
        {
            LastName=lastName;
            FirstName=firstName;
            MiddleName=middleName;
            Position=position;
            AcademicDegree=academicDegree;
            Post = post;
            Workload=workload;
            WorkloadCount = workloadCount;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
    }
}
