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

        frmLogin frmLogin = new frmLogin();

        public frmClient()
        {
            InitializeComponent();
        }

        private void FrmClient_Load(object sender, EventArgs e)
        {
            frmLogin.TopLevel = false;
            frmLogin.Parent = this;

            // RPGWO_Client.Network.Network.Connect();
            // 104.168.47.163
            // 127.0.0.1
            this.Network = new Network.Network("127.0.0.1", 4502);

            Network.OnConnect += Network_OnConnect;
            Network.Connect();
        }

        private void Network_OnConnect(object sender, EventArgs e)
        {
            Console.WriteLine("Connected to Server.");

            frmLogin.Invoke((MethodInvoker)delegate ()
            {
                frmLogin.Show();
            });
        }
    }
}
