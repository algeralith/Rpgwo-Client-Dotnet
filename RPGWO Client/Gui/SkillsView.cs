using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPGWO_Client.Gui
{
    public partial class SkillsView : UserControl
    {
        public SkillsView()
        {
            InitializeComponent();
        }

        public Attributes Attributes
        {
            get
            {
                return attributes1;
            }
        }

        //labelLevel.Text = e.Level.ToString();
        //labelNextLevel.Text = e.NextLevel.ToString();
        //labelSpendable.Text = e.EarnedExp.ToString();
        public void SetLevel(int value)
        {
            labelLevel.Text = String.Format("{0}", value);
        }

        public void SetNextLevel(int value)
        {
            labelNextLevel.Text = String.Format("{0}", value);
        }

        public void SetSpendable(int value)
        {
            labelSpendable.Text = String.Format("{0}", value);
        }

        public void SetTotalExperience(int value)
        {
            labelTotalExp.Text = String.Format("{0}", value);
        }

        public SkillsList SkillsList
        { 
            get
            {
                return skillsList1;
            }
        }

    }
}
