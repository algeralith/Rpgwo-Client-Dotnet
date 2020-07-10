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
    public partial class Attributes : UserControl
    {
        public Attributes()
        {
            InitializeComponent();
        }

        public void SetLife(int min, int max)
        {
            labelLife.Text =  String.Format("{0}/{1}", min, max);
        }

        public void SetStamina(int min, int max)
        {
            labelStamina.Text = String.Format("{0}/{1}", min, max);
        }

        public void SetMana(int min, int max)
        {
            labelMana.Text = String.Format("{0}/{1}", min, max);
        }

        public void SetStrength(int value)
        {
            labelStrength.Text = String.Format("{0}", value);
        }

        public void SetDexterity(int value)
        {
            labelDexterity.Text = String.Format("{0}", value);
        }

        public void SetQuickness(int value)
        {
            labelQuickness.Text = String.Format("{0}", value);
        }

        public void SetIntelligence(int value)
        {
            labelIntelligence.Text = String.Format("{0}", value);
        }

        public void SetWisdom(int value)
        {
            labelWisdom.Text = String.Format("{0}", value);
        }
    }
}
