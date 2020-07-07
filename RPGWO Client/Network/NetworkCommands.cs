using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGWO_Client.Network.Packets;

namespace RPGWO_Client.Network
{
    public partial class Network
    {

        public void SendAck()
        {
            Send(new Ack(), SendReceiveMode.None); // No security for Ack / Nack.
        }

        public void SendNack()
        {
            Send(new Nack(), SendReceiveMode.None); // No security for Ack / Nack.
        }

        public void SendInfo2()
        {
            Info2 info2 = new Info2();

            Send(info2);
        }

        public void SendSkillDefReq()
        {
            ReqSkillDef reqSkillDef = new ReqSkillDef();

            Send(reqSkillDef);
        }

        public void SendSkillListReq()
        {
            ReqSkillList reqSkillList = new ReqSkillList();

            Send(reqSkillList);
        }

        public void SendPlayerListReq()
        {
            ReqPlayerList reqPlayerList = new ReqPlayerList();

            Send(reqPlayerList);
        }

        // Default Login
        public void SendLogin(String username, String password)
        {
            Login login = new Login();
            login.Username = username;
            login.Password = password;

            SendLogin(login);
        }

        // Create account and Login
        public void SendLogin(String username, String password, String email)
        {
            Login login = new Login();
            login.Username = username;
            login.Password = password;
            login.Email = email;
            login.NewUser = true;

            SendLogin(login);
        }

        private void SendLogin(Login login)
        {
            // First, verify that we are in the proper state.
            if (this.NetworkState != NetworkState.LoginScreen)
            {
                // TODO :: Err
                return;
            }

            Send(login);

            // Update NetworkState
            NetworkState = NetworkState.LoginSent;
        }
    }
}
