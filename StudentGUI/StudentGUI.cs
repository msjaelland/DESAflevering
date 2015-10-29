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


namespace StudentGUI
{
    public partial class StudentGUI : Form
    {
        ChannelFactory<IStudentService> channelFactory = new ChannelFactory<IStudentService>("StudentServiceEndpoint");
        IStudentService proxy;

        public StudentGUI()
        {
            proxy = channelFactory.CreateChannel();
            InitializeComponent();
        }

      
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Register_Click(object sender, EventArgs e)
        {
            proxy.Register(RegisterFirstName.Text.ToString(), RegisterFamilyName.Text.ToString(), RegisterEmail.Text.ToString());
        }
    }
}
