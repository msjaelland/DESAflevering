using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service;
using Service.Services;
using StudentGUI.Facade;

namespace StudentGUI
{
    public partial class StudentGUI : Form
    {

        NetworkFacade nf;
        int currentStudentId;

        public StudentGUI()
        {
            InitializeComponent();
            nf = new NetworkFacade();

        }


        private void Register_Click(object sender, EventArgs e)
        {
            nf.Register(RegisterFirstName.Text.ToString(), RegisterFamilyName.Text.ToString(), RegisterEmail.Text.ToString());
        }


        private void LoadExams()
        {
            foreach (var entry in nf.getAvailableExams())
            {
                TreeNode courseNode = ExamTreeView.Nodes.Add(entry.Key);
                courseNode.Nodes.Add(entry.Value.ToString());
            }

        }

        private void LoadCourses()
        {
            //List<string> fetchedCourseId = (List<string>)lstCourses.SelectedItem;
            //lstViewStudents.Items.Clear();

            //foreach (int i in nf.GetStudentIdsForCourse(Int32.Parse(fetchedCourseId[0])))
            //{
            //    List<string> studentInfo = nf.GetStudentInfo(i);
            //    lstViewStudents.Items.Add(studentInfo);
            //    Console.WriteLine(studentInfo);

            //lstCourses.Items.Clear();
            //foreach (int i in nf.GetListOfCourseId())
            //{
            //    List<string> courseInfo = nf.GetCourseInfo(i);
            //    lstCourses.Items.Add(courseInfo);
            //}

            
        }

        private void signIn_Click(object sender, EventArgs e)
        {
            currentStudentId = nf.GetStudentIdByEmail(EmailTextBox.Text);
        }

        private void signUp_Click(object sender, EventArgs e)
        {

        }

        private void AvailableCoursesTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void splitContainer3_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer3_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
