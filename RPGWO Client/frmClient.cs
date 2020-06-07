using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RPGWO_Client.Network;

namespace RPGWO_Client
{
    public partial class frmClient : Form
    {
        // Networking
        public Network.Network Network { private set; get; }

        public frmLogin LoginForm { private set; get; }

        public frmClient()
        {
            InitializeComponent();
            LoginForm = new frmLogin(this);
        }

        private void FrmClient_Load(object sender, EventArgs e)
        {
            LoginForm.TopLevel = false;
            LoginForm.Parent = this;

            this.Network = new Network.Network("127.0.0.1", 4502);

            Network.OnConnect += Network_OnConnect;
            // Network.Connect();

            frmCreate frmMainMenu = new frmCreate();
            // frmMainMenu.TopLevel = false;
            // frmMainMenu.Parent = this;
            frmMainMenu.Show();
        }

        private void Network_OnConnect(object sender, EventArgs e)
        {
            Console.WriteLine("Connected to Server.");

            LoginForm.Invoke((MethodInvoker)delegate ()
            {
                LoginForm.Show();
            });
        }
    }
}
