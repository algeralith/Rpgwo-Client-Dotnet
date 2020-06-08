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

        // Client Forms
        public frmLogin LoginForm { private set; get; }
        public frmCreate CreateForm { private set; get; }
        public frmMainMenu MainMenu { private set; get; }

        public frmClient()
        {

            InitializeComponent();
        }

        private void FrmClient_Load(object sender, EventArgs e)
        {
            this.Network = new Network.Network("127.0.0.1", 4502);

            InitalizeForms();

            InitalizeEvents();

            Network.Connect();
        }

        private void InitalizeForms()
        {
            LoginForm = new frmLogin(this);
            // For some reason, it seems like you need to try to access the handle to make sure its created.
            // See: https://stackoverflow.com/questions/808867/invoke-or-begininvoke-cannot-be-called-on-a-control-until-the-window-handle-has/809186
            // TODO :: Look into the proper way to do this.
            var handler = LoginForm.Handle;

            MainMenu = new frmMainMenu();
            handler = MainMenu.Handle;

            CreateForm = new frmCreate();
            handler = CreateForm.Handle;
        }

        private void InitalizeEvents()
        {
            Network.OnConnect += Network_OnConnect;
            Network.OnDisconnect += Network_OnDisconnect;
        }

        private void Network_OnConnect(object sender, EventArgs e)
        {
            Console.WriteLine("Connected to Server.");

            LoginForm.Invoke((MethodInvoker)delegate ()
            {
                LoginForm.ShowDialog();
            });
        }

        private void Network_OnDisconnect(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

    }
}
