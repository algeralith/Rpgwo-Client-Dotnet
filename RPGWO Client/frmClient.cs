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
    public partial class frmClient : Form
    {
        // Networking
        public Network.Network Network { private set; get; }

        // Client Forms
        public frmLogin LoginForm { private set; get; }
        public frmCreate CreateForm { private set; get; }
        public frmMainMenu MainMenu { private set; get; }
        public frmTextMsg TextMessage { private set; get; }

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
            LoginForm.Owner = this;

            MainMenu = new frmMainMenu(this);
            handler = MainMenu.Handle;
            MainMenu.Owner = this;

            CreateForm = new frmCreate(this);
            handler = CreateForm.Handle;
            CreateForm.Owner = MainMenu;

            TextMessage = new frmTextMsg();
            handler = TextMessage.Handle;
            TextMessage.Owner = this;
        }

        private void InitalizeEvents()
        {
            // Network Connection Events.
            Network.OnConnect += Network_OnConnect;
            Network.OnDisconnect += Network_OnDisconnect;

            // Enter Final.
            Network.Handler.OnGameEnterFinal += Handler_OnGameEnterFinal;

            // Packet Events.
            Network.Handler.OnText += Handler_OnText;
            Network.Handler.OnWorldState += Handler_OnWorldState;
            Network.Handler.OnAttributes += Handler_OnAttributes;
            Network.Handler.OnPlayerStats += Handler_OnPlayerStats;
        }

        private void Handler_OnAttributes(object sender, Attributes e)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                labelStrength.Text = e.Strength.ToString();
                labelDexterity.Text = e.Dexterity.ToString();
                labelQuickness.Text = e.Quickness.ToString();
                labelIntelligence.Text = e.Intelligence.ToString();
                labelWisdom.Text = e.Wisdom.ToString();
            });
        }

        private void Handler_OnPlayerStats(object sender, PlayerStats e)
        {
            this.Invoke((MethodInvoker)delegate () {
                // Life / Stam / Mana
                labelLife.Text = String.Format("{0}/{1}", e.Life, e.MaxLife);
                labelStamina.Text = String.Format("{0}/{1}", e.Stamina, e.MaxStamina);
                labelMana.Text = String.Format("{0}/{1}", e.Mana, e.MaxMana);

                picLife.Maximum = Convert.ToInt32(e.MaxLife);
                picLife.Value = Convert.ToInt32(e.Life);

                picStamina.Maximum = Convert.ToInt32(e.MaxStamina);
                picStamina.Value = Convert.ToInt32(e.Stamina);

                picMana.Maximum = Convert.ToInt32(e.MaxMana);
                picMana.Value = Convert.ToInt32(e.Mana);

                // Level / Total Exp / Next Level / Spendable
                labelLevel.Text = e.Level.ToString();
                labelNextLevel.Text = e.NextLevel.ToString();
                labelSpendable.Text = e.EarnedExp.ToString();

                // TODO ::: Vitae, Vitae Xp, and Poison
            });
        }

        private void Handler_OnWorldState(object sender, WorldState e)
        {
            labelWorld.Invoke((MethodInvoker)delegate () {
                labelWorld.Text = String.Format("{0}:{1} {2} {3}, {4}", e.Hour, e.Minute, (Utils.Month)e.Month, e.Day, e.Year);
            });
        }

        // Final Ack / Nack before game load complete.
        private void Handler_OnGameEnterFinal(object sender, bool e)
        {
            if (e)
            {
                // Client is completely in game. Update network status.
                Network.NetworkState = NetworkState.InGame;
            }
            else
            {
                // TODO :: Consider how to properly do this. Mickey just pops up an error and then
                // Brings up the exit confirmation.
                MessageBox.Show("Cannot enter world.\r\nWorld may be stopped.\r\n.Your player may be dead.", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Handler_OnText(object sender, Text e)
        {
            richTextAll.Invoke((MethodInvoker)delegate () {
                richTextAll.Text += ("\r\n" + e.TextContent);
            });
        }

        private void Network_OnConnect(object sender, EventArgs e)
        {
            Console.WriteLine("Connected to Server.");

            ShowForm(LoginForm);
        }

        private void Network_OnDisconnect(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ShowForm(Form form)
        {
            // Forms do not center to owner, calculate center.
            Point centerPoint = new Point(form.Owner.Left + form.Owner.Width / 2 - form.Width / 2, form.Owner.Top + form.Owner.Height / 2 - form.Height / 2);

            if (form.InvokeRequired)
            {
                form.BeginInvoke((MethodInvoker)delegate () {
                    form.Owner.Enabled = false;
                    form.Location = centerPoint;
                    form.Show(this);
                });

            } else
            {
                form.Owner.Enabled = false;
                form.Location = centerPoint;
                form.Show();
            }
        }

        public void HideForm(Form form)
        {
            if (form.InvokeRequired)
            {
                form.BeginInvoke((MethodInvoker)delegate () {
                    form.Owner.Enabled = true;
                    form.Hide();
                });
            }
            else
            {
                form.Owner.Enabled = true;
                form.Hide();
            }
        }
    }
}
