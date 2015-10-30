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

namespace StudentGUIWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void UnregisterCourseButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            StudentGUIWPF.DesRunningSampleDataSet desRunningSampleDataSet = ((StudentGUIWPF.DesRunningSampleDataSet)(this.FindResource("desRunningSampleDataSet")));
            // Load data into the table CourseSet. You can modify this code as needed.
            StudentGUIWPF.DesRunningSampleDataSetTableAdapters.CourseSetTableAdapter desRunningSampleDataSetCourseSetTableAdapter = new StudentGUIWPF.DesRunningSampleDataSetTableAdapters.CourseSetTableAdapter();
            desRunningSampleDataSetCourseSetTableAdapter.Fill(desRunningSampleDataSet.CourseSet);
            System.Windows.Data.CollectionViewSource courseSetViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("courseSetViewSource")));
            courseSetViewSource.View.MoveCurrentToFirst();
        }
    }
}
