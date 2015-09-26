using AdminGUI.Facade;
using System.Collections.Generic;
using System.Windows;

namespace AdminGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DomainFacade df;

        public MainWindow()
        {
            InitializeComponent();

            df = new DomainFacade();

            foreach(int i in df.GetListOfCourseId())
            {
                List<string> courseInfo = df.GetCourseInfo(i);
                lstCourses.Items.Add(courseInfo);
            }
        }
    }
}
