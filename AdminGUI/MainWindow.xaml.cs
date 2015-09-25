using AdminGUI.Facade;
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
using Types;

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

            foreach (int i in df.GetListOfCourseId())
            {
                List<string> courseInfo = df.GetCourseInfo(i);
                ListViewItem l = new ListViewItem();
                
            }
        }
    }
}
