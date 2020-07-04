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
using RPGWO_Client.Network.Packets;

namespace RPGWO_Client
{
    public partial class frmMainMenu : Form
    {
        public frmClient Client { get; private set; }

        public frmMainMenu(frmClient frmClient)
        {
            Client = frmClient;
            InitializeComponent();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            Client.Network.Handler.OnClientList += Handler_OnClientList;

            Client.Network.Handler.OnPlayerList += Handler_OnPlayerList;
        }

        private void Handler_OnPlayerList(object sender, PacketEventArgs e)
        {
            // Grab Packet
            PlayerList playerList = (PlayerList)e.Packet;

            this.BeginInvoke((MethodInvoker)delegate () {
                // Clear listbox
                listBox1.Items.Clear();

                for (int i = 0; i < playerList.PlayerNames.Length; i++)
                {
                    listBox1.Items.Add(playerList.PlayerNames[i]);
                }
            });
        }

        private void Handler_OnClientList(object sender, PacketEventArgs e)
        {
            // Grab Packet
            ClientList clientList = (ClientList)e.Packet;

            this.Invoke((MethodInvoker)delegate () {
                toolStripStatusLabel1.Text = "Number of players logged on: " + clientList.Name;
            });
        }
    }
}
