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
        public frmClient Client {get; private set; }
        public frmLogin(frmClient frmClient)
        {
            InitializeComponent();
            Client = frmClient;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            // First send client info2
            Client.Network.SendInfo2();

            // TODO :: Validate text fields before sending.
            if (!checkBoxNewUser.Checked)
            {
                Client.Network.SendLogin(textBoxUsername.Text, textBoxPassword.Text);
            } else
            {
                Client.Network.SendLogin(textBoxUsername.Text, textBoxPassword.Text, textBoxEmail.Text);
            }

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit(); // TODO :: Better handle exit. Inform server if need be.
        }
    }
}
