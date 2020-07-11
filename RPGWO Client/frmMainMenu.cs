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

            Client.Network.Handler.OnPlayerDelete += Handler_OnPlayerDelete;

            Client.Network.Handler.OnGameEnter += Handler_OnGameEnter;
        }


        private void Handler_OnPlayerDelete(object sender, bool e)
        {
            // Switch network state back
            Client.Network.NetworkState = NetworkState.MainMenu;

            if (e)
            {
                MessageBox.Show("Player deleted.", "Delete Player", MessageBoxButtons.OK);

                // Update player list
                Client.Network.SendPlayerListReq();
            }
            else
            {
                MessageBox.Show("Failed to delete player.", "Delete Player", MessageBoxButtons.OK);
            }

        }

        private void Handler_OnPlayerList(object sender, PlayerList playerList)
        {
            this.BeginInvoke((MethodInvoker)delegate () {
                // Clear listbox
                listBox1.Items.Clear();

                for (int i = 0; i < playerList.PlayerNames.Length; i++)
                {
                    listBox1.Items.Add(playerList.PlayerNames[i]);
                }
            });
        }

        private void Handler_OnClientList(object sender, ClientList clientList)
        {
            // Grab Packet
            Client.MainMenu.BeginInvoke((MethodInvoker)delegate () {
                toolStripStatusLabel1.Text = "Number of players logged on: " + clientList.Name;
            });
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            // Update State to show we are in character creation
            Client.Network.NetworkState = NetworkState.PlayerCreation;

            // Request Skill Definitions.
            Client.Network.SendSkillListReq();

            // Close Main Menu
            // Client.HideForm(Client.MainMenu);

            // Show Create
            Client.ShowForm(Client.CreateForm);
        }

        private void FrmMainMenu_VisibleChanged(object sender, EventArgs e)
        {
            Console.WriteLine();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
                return;

            DialogResult dialogResult = MessageBox.Show("Delete Player? " + listBox1.SelectedItem, "Confirm", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                Delete delete = new Delete()
                {
                    Name = listBox1.SelectedItem.ToString()
                };


                // Let network know we are deleting
                Client.Network.NetworkState = NetworkState.PlayerDelete;

                Client.Network.Send(delete);
            }
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            Client.Network.Send(new Logout());

            Client.Network.NetworkState = NetworkState.LoginScreen;

            Client.HideForm(this);

            Client.ShowForm(Client.LoginForm);
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
                return;

            Client.Network.SendEnter(listBox1.SelectedItem.ToString());
        }

        private void Handler_OnGameEnter(object sender, bool e)
        {
            if (e)
            {
                // Send CPU info
                Client.Network.SendText("@cpu RPGWO", 105);

                // Send Final Enter
                Client.Network.SendEnterFinal();

                // Close MainMenu
                Client.HideForm(this);
            }
            else
            {
                MessageBox.Show("Cannot enter world.", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
