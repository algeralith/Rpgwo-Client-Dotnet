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

        private bool _info2Sent = false;

        public frmLogin(frmClient frmClient)
        {
            Client = frmClient;
            InitializeComponent();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            Client.Network.Handler.LoginSuccess += Handler_LoginSuccess;
            Client.Network.Handler.LoginFailure += Handler_LoginFailure;
        }

        private void Handler_LoginSuccess(object sender, EventArgs e)
        {
            // Hide Login
            Client.HideForm(this);

            // Show MainMenu
            Client.ShowForm(Client.MainMenu);
            
            // TODO :: The following code is better suited elsewhere. Just putting it here for quick testing.
            // Request Skills
            Client.Network.SendSkillDefReq();

            // Request Player List
            Client.Network.SendPlayerListReq();
        }

        private void Handler_LoginFailure(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            // First send client info2 -- TODO :: Put this into networking. 
            if (_info2Sent == false)
            {
                Client.Network.SendInfo2();
                _info2Sent = true;
            }

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
