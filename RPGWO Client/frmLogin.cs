using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RPGWO_Client.Network.Packets;

namespace RPGWO_Client
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            // Create Login Packet
            Login login = new Login();

            login.Username = textBoxUsername.Text;
            login.Password = textBoxPassword.Text;
            login.Email = textBoxEmail.Text;
            login.NewUser = checkBoxNewUser.Checked;

            // Send Login request
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit(); // TODO :: Better handle exit. Inform server if need be.
        }
    }
}
