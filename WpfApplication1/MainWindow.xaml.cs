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
using System.Windows.Navigation;
using System.Windows.Shapes;
using StudentGUI.Facade;
using Types;


namespace StudentGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NetworkFacade nf;
        
        int currentStudentId;
        int selectedCourseId;
        List<int> courseId;
        List<int> myCourses = new List<int>();
        List<int> courseIDsForStudent;
         

        public MainWindow()
        {
            InitializeComponent();
            nf = new NetworkFacade();
            UpdateCoursesListView();
        }

        #region Register_Done

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            nf.Register(NameTextBox.Text, FamilyNameTextBox.Text, EmailTextBox.Text);
            currentStudentId = nf.GetStudentIdByEmail(EmailTextBox.Text);
            CurrentUserLabel.Content = nf.GetStudentName(currentStudentId);
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
           currentStudentId = nf.GetStudentIdByEmail(EmailSignInTextBox.Text);
           CurrentUserLabel.Content = nf.GetStudentName(currentStudentId);
        }


        #endregion

        #region Courses
        /*
        Updates list of avaialable courses
        */
        public void UpdateCoursesListView()
        {
            AvaliableCourcesListView.Items.Clear();
            foreach (int i in nf.GetListOfCourseId())
            {
                List<string> courseInfo = nf.GetCourseInfo(i);
                AvaliableCourcesListView.Items.Add(courseInfo);
            }
        }
        /*
        Updates list of my courses
        */
        public void UpdateMyCoursesListView()
        {
            MyCoursesListView.Items.Clear();
            foreach (int i in nf.GetCourseIDsForStudent(currentStudentId))  
            {
                List<string> courseInfo = nf.GetCourseInfo(i);
                MyCoursesListView.Items.Add(courseInfo);
            }
            
        }

        /*
        Signs up a student for a course
        */
        private void SignUpCourseButton_Click(object sender, RoutedEventArgs e)
        {
            List<String> fetchedCourseID = (List<String>)AvaliableCourcesListView.SelectedItem; //get ID of selected course
            
            Console.WriteLine("Student with ID: " + currentStudentId + " signed up for course with ID: " + fetchedCourseID[0]);
            nf.SignUpForCourse(currentStudentId, Int32.Parse(fetchedCourseID[0])); 
            UpdateMyCoursesListView();
        }

        #endregion

        private void SignUpExamButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Implement much
        }

        private void UnregisterButton_Click(object sender, RoutedEventArgs e)
        {
            List<String> fetchedCourseID = (List<String>)MyCoursesListView.SelectedItem; //get ID of selected course

            Console.WriteLine("Student with ID: " + currentStudentId + " resigned from course with ID: " + fetchedCourseID[0]);
            nf.UnregisterFromCourse(currentStudentId, Int32.Parse(fetchedCourseID[0]));
            UpdateMyCoursesListView();
        }

        private void TabItem_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
           
        }

        private void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void TabItem_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void LoadMyExamsButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateMyCoursesListView();
        }
    }
}
