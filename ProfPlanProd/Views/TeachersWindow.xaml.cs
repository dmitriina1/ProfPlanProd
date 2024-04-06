﻿using ProfPlanProd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ProfPlanProd.ViewModels;
using ProfPlanProd.Views;

namespace ProfPlanProd.Views
{
    /// <summary>
    /// Логика взаимодействия для TeachersWindow.xaml
    /// </summary>
    public partial class TeachersWindow : Window
    {
        public TeachersWindow()
        {
            InitializeComponent();
            this.Closing += TeachersWindow_Closing;
            TeachersWindowViewModel TeacherListWindow = new TeachersWindowViewModel();
            this.DataContext = TeacherListWindow;
        }
        private void UserListViewItem_DoubleClick(object sender, RoutedEventArgs e)
        {
            if (TeacherList.SelectedItem is Teacher selectedUser)
            {
                TeachersWindowViewModel mainViewModel = DataContext as TeachersWindowViewModel;
                mainViewModel.SelectedTeacher = selectedUser;

                AddTeacherWindowViewModel addUserViewModel = new AddTeacherWindowViewModel();
                addUserViewModel.SetTeacher(mainViewModel.SelectedTeacher);

                AddTeacherWindow addUserWin = new AddTeacherWindow();
                addUserWin.Owner = this;
                addUserWin.DataContext = addUserViewModel;
                addUserWin.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                addUserWin.ShowDialog();
            }
        }
        private void UserList_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Pressed)
            {
                TeachersWindowViewModel mainViewModel = DataContext as TeachersWindowViewModel;

                HitTestResult hitTestResult = VisualTreeHelper.HitTest(TeacherList, e.GetPosition(TeacherList));
             
                if (hitTestResult.VisualHit is FrameworkElement element && element.DataContext is Teacher selectedUser)
                {
                    mainViewModel.RemoveSelectedTeacher(selectedUser);
                }
            }
        }

        

        // Метод, который будет вызываться при закрытии окна
        private void TeachersWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Ваш метод, который нужно вызвать при закрытии окна
            ExcelModel.UpdateSharedTeachers();
        }
    }
}
