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
using WpfApplication1.Facade;

namespace WpfApplication1
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
        public void UpdateCoursesListView()
        {
            courseId = nf.GetListOfCourseId();
            AvaliableCourcesListView.Items.Clear();
            foreach (int i in nf.GetListOfCourseId())
            {
                List<string> courseInfo = nf.GetCourseInfo(i);
                AvaliableCourcesListView.Items.Add(courseInfo);
            }
        }
        /*
        METODE DER SKAL OPDATERE MYCOURSELISTVIEW, SÅ DE COURSES SOM DEN PÅGÆLDENDE STUDENT ER SIGNET OP TIL BLIVER VIST I LISTEN 
        */
        public void UpdateMyCoursesListView()
        {
            /*LIGE PT LOOPER DEN KUN GENNEM EN LOKAL LISTE (MYCOURSES)
                **HENVISNING TIL DATABASEFACADE (HER HAR JEG UDDYBET LIDT) ;)
            */
            foreach (int i in myCourses)
            {
                 
                List<String> courseInfo = nf.GetCourseInfo(i);
                MyCoursesListView.Items.Add(courseInfo);
            }
        }

        /*
        METODE DER SIGNER EN STUDENT OP TIL ET COURSE
        */
        private void SignUpCourseButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = AvaliableCourcesListView.SelectedIndex;
            selectedCourseId = courseId[selectedIndex];
            //MIDLERTIDIG
            myCourses.Add(selectedCourseId);
            //
            UpdateMyCoursesListView();
            Console.WriteLine(currentStudentId + " + " + selectedCourseId);
            nf.SignUpForCourse(currentStudentId, selectedCourseId);
        }

        #endregion

        private void SignUpExamButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
