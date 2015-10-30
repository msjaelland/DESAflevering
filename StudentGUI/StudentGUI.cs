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

<<<<<<< HEAD
=======
        NetworkFacade nf;
        int currentStudentId;

>>>>>>> 220aba9f00c268e5a4a8f72d108156dac4a78686
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

        private void signIn_Click(object sender, EventArgs e)
        {
            currentStudentId = nf.GetStudentIdByEmail(EmailTextBox.Text);
        }

        private void signUp_Click(object sender, EventArgs e)
        {

        }
    }
}
