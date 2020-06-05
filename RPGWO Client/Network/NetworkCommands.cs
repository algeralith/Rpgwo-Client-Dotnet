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
        public void RequestSkillDefs()
        {

        }

        public void SendInfo2()
        {
            Info2 info2 = new Info2();

            Send(info2);
        }

        // Default Login
        public void SendLogin(String username, String password)
        {
            Login login = new Login();
            login.Username = username;
            login.Password = password;

            Send(login);
        }

        // Create account and Login
        public void SendLogin(String username, String password, String email)
        {
            Login login = new Login();
            login.Username = username;
            login.Password = password;
            login.Email = email;
            login.NewUser = true;

            Send(login);
        }
    }
}
