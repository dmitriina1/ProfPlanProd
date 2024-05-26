using ProfPlanProd.Commands;
using ProfPlanProd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace ProfPlanProd.ViewModels
{
    internal class AddTeacherWindowViewModel
    {
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Position { get; set; }
        public string AcademicDegree { get; set; }
        public string Post { get; set; }
        public string Workload { get; set; }
        public string WorkloadCount { get; set; }

        private RelayCommand _addTeacherCommand;
        public ICommand AddTeacherCommand
        {
            get { return _addTeacherCommand ?? (_addTeacherCommand = new RelayCommand(AddTeacher)); }
        }

        private void AddTeacher(object obj)
        {
            Teacher checkUser = TeachersManager.GetTeacherByName(Lastname, Firstname, Middlename);
            if (checkUser == null)
            {
                double? doubleValue;
                double? doubleValueCount;
                try
                {
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                    if (Workload!=null)
                        doubleValue = Convert.ToDouble(Workload);
                    else doubleValue = null;
                    if(WorkloadCount!=null)
                        doubleValueCount = Convert.ToDouble(WorkloadCount);
                    else doubleValueCount = null;
                    if (Lastname !=null && Firstname != null)
                    {
                        TeachersManager.AddTeacher(new Teacher() { LastName = Lastname, FirstName = Firstname, MiddleName = Middlename, Position = Position, AcademicDegree = AcademicDegree, Post = Post, Workload = doubleValue, WorkloadCount = doubleValueCount });
                        //ExcelModel.UpdateSharedTeachers();
                    }
                    else
                    {
                        MessageBox.Show("Ячейки Фамилия и Имя должны быть заполнены");
                    }

                }
                catch (FormatException)
                {
                    MessageBox.Show("В ячейку Ставка было вписано не число!");
                    doubleValue = null;
                    doubleValueCount = null;
                    Workload = null;
                    WorkloadCount = null;
                }
            }
            else
            {
                try
                {
                    if (checkUser != null)
                    {
                        checkUser.LastName = Lastname;
                        checkUser.FirstName = Firstname;
                        checkUser.MiddleName = Middlename;
                        checkUser.Position = Position;
                        checkUser.AcademicDegree = AcademicDegree;
                        checkUser.Post = Post;
                        checkUser.Workload = Workload.ToNullable<double>();
                        checkUser.WorkloadCount = WorkloadCount.ToNullable<double>();

                        TeachersManager.UpdateTeacher(checkUser, TeachersManager.GetTeacherIndex(checkUser));
                        MessageBox.Show("Данные пользователя обновлены.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        //ExcelModel.UpdateSharedTeachers();
                        checkUser = null;
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("В ячейку Ставка было вписано не число!");
                    Workload = null;
                    WorkloadCount = null;
                }
            }
            //ExcelModel.UpdateSharedTeachers();

        }
        public void SetTeacher(Teacher teacher)
        {
            Lastname = teacher?.LastName;
            Firstname = teacher?.FirstName;
            Middlename = teacher?.MiddleName;
            Position = teacher?.Position;
            AcademicDegree = teacher?.AcademicDegree;
            Post = teacher?.Post;
            Workload = teacher.Workload.ToNullable<double>().ToString();
            WorkloadCount = teacher.WorkloadCount.ToNullable<double>().ToString();
        }
    }
}
