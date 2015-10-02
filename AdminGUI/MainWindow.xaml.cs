using AdminGUI.Facade;
using System;
using System.Collections.Generic;
using System.Windows;

namespace AdminGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NetworkFacade nf;

        public MainWindow()
        {
            InitializeComponent();
            nf = new NetworkFacade();
            UpdateCoursesListView();
            UpdateTeacherComboBox();
            UpdateTeacherListView();
        }

        public void UpdateCoursesListView()
        {
            lstCourses.Items.Clear();
            foreach(int i in nf.GetListOfCourseId())
            {
                List<string> courseInfo = nf.GetCourseInfo(i);
                lstCourses.Items.Add(courseInfo);
            }
        }

        public void UpdateTeacherListView()
        {
            lstTeachers.Items.Clear();
            foreach(int i in nf.GetListOfTeacherId())
            {
                List<string> teacherInfo = nf.GetTeacherInfo(i);
                lstTeachers.Items.Add(teacherInfo);
            }
        }

        public void UpdateTeacherComboBox()
        {
            cmbTeacher.Items.Clear();
            foreach(int i in nf.GetListOfTeacherId())
            {
                List<string> teacherInfo = nf.GetTeacherInfo(i);
                cmbTeacher.Items.Add(teacherInfo[1] + " " + teacherInfo[2]);
            }
        }

        private void btnSaveCourse_Click(object sender, RoutedEventArgs e)
        {

            int i = cmbInstance.SelectedIndex + 1;

            try
            {
                nf.CreateCourse(txbName.Text, i, Int32.Parse(txbInstanceYear.Text), txbDescription.Text, Int32.Parse(txbEcts.Text));
                UpdateCoursesListView();
            }
            catch (FormatException)
            {
                MessageBox.Show("Some of the filled textfield doesn't match the required input. Please fill out form correctly.");
            }

        }

        private void buttonSaveTeacher_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                nf.CreateTeacher(txbTeacherName.Text, txbFamilyName.Text, txbEmail.Text);
                UpdateTeacherListView();
                UpdateTeacherComboBox();
            }
            catch (FormatException)
            {
                MessageBox.Show("Some of the filled textfield doesn't match the required input. Please fill out form correctly.");
            }
        }
    }
}
