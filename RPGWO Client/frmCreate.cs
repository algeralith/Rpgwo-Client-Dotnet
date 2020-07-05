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
    public partial class frmCreate : Form
    {
        public frmClient Client { get; private set; }

        private int TotalAttributePoints = 0;
        private int TotalSkillPoints = 0;
        private int SpentAttributePoints = 0;
        private int SpentSkillPoints = 0;

        public frmCreate(frmClient frmClient)
        {
            Client = frmClient;
            InitializeComponent();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            Client.Network.Handler.OnSkillDef += Handler_OnSkillDef;
            Client.Network.Handler.OnCreateDef += Handler_OnCreateDef;
        }

        private int CalculateSpentAttributes()
        {
            int spentAttr = 0;

            this.Invoke((MethodInvoker)delegate ()
            {
                spentAttr = trackBarLife.Value + trackBarStr.Value + trackBarDex.Value + trackBarQui.Value + trackBarIntl.Value + trackBarWis.Value;
            });

            return spentAttr;
        }

        private void UpdateLabels()
        {
            SpentAttributePoints = CalculateSpentAttributes();

            this.Invoke((MethodInvoker)delegate ()
            {
                labelAttrPoints.Text = (TotalAttributePoints - SpentAttributePoints).ToString();
                labelSkillPoints.Text = TotalSkillPoints.ToString();

                // Life / Stam / Mana
                labelLife.Text = trackBarLife.Value.ToString();
                labelStamina.Text = (trackBarLife.Value * 2).ToString(); // Stamina is 2 times life.
                labelMana.Text = trackBarWis.Value.ToString(); // Mana is equal to wisdom.

                // Attributes
                labelStrength.Text = trackBarStr.Value.ToString();
                labelDexteriity.Text = trackBarDex.Value.ToString();
                labelQuickness.Text = trackBarQui.Value.ToString();
                labelIntelligence.Text = trackBarIntl.Value.ToString();
                labelWisdom.Text = trackBarWis.Value.ToString();

                // Skill Points
                labelSkillPoints.Text = (TotalSkillPoints - SpentSkillPoints).ToString();

            });
        }

        private void UpdateSkillCosts()
        {
            int skillCosts = 0;

            foreach (SkillEntry skillEntry in listBoxTrainedSkill.Items)
            {
                if (skillEntry.skillDef.SkillPoints > 100)
                    continue; // Default skill, no cost

                skillCosts += skillEntry.skillDef.SkillPoints;
            }

            foreach (SkillEntry skillEntry in listBoxSpec.Items)
            {
                if (skillEntry.skillDef.SkillPoints > 100)
                    skillCosts += (skillEntry.skillDef.SkillPoints - 100); // It was a default skill.
                else
                    skillCosts += skillEntry.skillDef.SkillPoints * 2;
            }

            SpentSkillPoints = skillCosts;
        }

        private void Handler_OnCreateDef(object sender, PacketEventArgs e)
        {
            if (Client.Network.NetworkState != NetworkState.PlayerCreation)
                return;

            CreateDef createDef = (CreateDef)e.Packet;

            TotalAttributePoints = createDef.Attributes;
            TotalSkillPoints = createDef.SkillPoints;

            UpdateLabels();
        }

        private void Handler_OnSkillDef(object sender, PacketEventArgs e)
        {
            if (Client.Network.NetworkState != NetworkState.PlayerCreation)
                return;

            SkillDef skillDef = (SkillDef)e.Packet;

            this.Invoke((MethodInvoker)delegate ()
            {
                if (skillDef.ClearList)
                {
                    listBoxUntrainedSkill.Items.Clear();
                    listBoxTrainedSkill.Items.Clear();
                    listBoxSpec.Items.Clear();
                }

                SkillEntry skillEntry = new SkillEntry(skillDef);

                if (skillDef.SkillPoints > 100) // Anything with a skill cost over 100 is considered pretrained by the server.
                    listBoxTrainedSkill.Items.Add(skillEntry);
                else
                    listBoxUntrainedSkill.Items.Add(skillEntry);
            });
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (Client.Network.NetworkState == NetworkState.PlayerCreation)
            {
                // Update Network to Main Menu
                Client.Network.NetworkState = NetworkState.MainMenu;
            }

            // Hide Player Creation
            Client.HideForm(this);

            // Show Main Menu
            Client.ShowForm(Client.MainMenu);
        }

        private void TrackBarLife_ValueChanged(object sender, EventArgs e)
        {
            VerifyTrackbar(trackBarLife);
        }

        private void TrackBarStr_ValueChanged(object sender, EventArgs e)
        {
            VerifyTrackbar(trackBarStr);
        }

        private void TrackBarDex_ValueChanged(object sender, EventArgs e)
        {
            VerifyTrackbar(trackBarDex);
        }

        private void TrackBarQui_ValueChanged(object sender, EventArgs e)
        {
            VerifyTrackbar(trackBarQui);
        }

        private void TrackBarIntl_ValueChanged(object sender, EventArgs e)
        {
            VerifyTrackbar(trackBarIntl);
        }

        private void TrackBarWis_ValueChanged(object sender, EventArgs e)
        {
            VerifyTrackbar(trackBarWis);
        }

        private void VerifyTrackbar(TrackBar trackbar)
        {
            int spentPoints = TotalAttributePoints - CalculateSpentAttributes();

            // Check to see if we are spending more than allowed.
            if (spentPoints < 0)
            {
                // Revert value
                trackbar.Value += spentPoints;
            }

            UpdateLabels();
        }
        
        private void ListBoxUntrainedSkill_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxUntrainedSkill.SelectedItem == null)
                return;

            SkillEntry skillEntry = (SkillEntry)listBoxUntrainedSkill.SelectedItem;
            SkillDef skillDef = skillEntry.skillDef;

            UpdateSkillDefLabel(skillDef);
        }

        private void ListBoxTrainedSkill_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxTrainedSkill.SelectedItem == null)
                return;

            SkillEntry skillEntry = (SkillEntry)listBoxTrainedSkill.SelectedItem;
            SkillDef skillDef = skillEntry.skillDef;

            UpdateSkillDefLabel(skillDef);
        }

        private void ListBoxSpec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxSpec.SelectedItem == null)
                return;

            SkillEntry skillEntry = (SkillEntry)listBoxSpec.SelectedItem;
            SkillDef skillDef = skillEntry.skillDef;

            UpdateSkillDefLabel(skillDef);
        }

        private void UpdateSkillDefLabel(SkillDef skillDef)
        {
            // Melee Defense :: Cost 10 :: (DEX + QUICK) / 3
            List<String> attr = new List<string>(5);

            if (skillDef.Strength > 0)
                attr.Add("STR");
            if (skillDef.Dexterity > 0)
                attr.Add("DEX");
            if (skillDef.Quickness > 0)
                attr.Add("QUICK");
            if (skillDef.Intelligence > 0)
                attr.Add("INTEL");
            if (skillDef.Wisdom > 0)
                attr.Add("WISDOM");

            String attributes = "(";

            for (int i = 0; i < attr.Count; i++)
            {
                if (i > 0)
                    attributes += " + ";

                attributes += attr[i];
            }

            attributes += ") / " + skillDef.Divisor.ToString();

            String skillDesc = skillDef.Name.Trim() + " :: Cost " + (skillDef.SkillPoints > 100 ? skillDef.SkillPoints - 100 : skillDef.SkillPoints) + " :: " + attributes;
            skillDesc += "\r\n";
            skillDesc += skillDef.Description.Substring(1, skillDef.Description.Length - 1);

            labelSkillDef.Text = skillDesc;
        }

        private void BtnTrainSkill_Click(object sender, EventArgs e)
        {
            if (listBoxUntrainedSkill.SelectedItem == null)
                return;

            SkillEntry skillEntry = (SkillEntry)listBoxUntrainedSkill.SelectedItem;
            SkillDef skillDef = skillEntry.skillDef;

            int availablePoints = (TotalSkillPoints - SpentSkillPoints);

            if (skillDef.SkillPoints > availablePoints)
            {
                // Not enough points available
                return;
            }

            listBoxUntrainedSkill.Items.RemoveAt(listBoxUntrainedSkill.SelectedIndex);
            listBoxTrainedSkill.Items.Add(skillEntry);

            // Update Skill Points
            UpdateSkillCosts();

            // Update Labels
            UpdateLabels();
        }

        private void BtnUntrainSkill_Click(object sender, EventArgs e)
        {
            if (listBoxTrainedSkill.SelectedItem == null)
                return;

            SkillEntry skillEntry = (SkillEntry)listBoxTrainedSkill.SelectedItem;
            SkillDef skillDef = skillEntry.skillDef;

            if (skillDef.SkillPoints > 100) // Check if default skill
            {
                // TODO :: Messagebox will always show in the center of the screen.
                // It would be nice to create a custom form to act as a message box, and use that instead.
                MessageBox.Show(this, "Sorry, this skill is trained by default and can NOT be untrained.", "No! No! NO!");
                return;
            }

            // Remove Skill
            listBoxTrainedSkill.Items.RemoveAt(listBoxTrainedSkill.SelectedIndex);

            // Add skill back to untrained
            listBoxUntrainedSkill.Items.Add(skillEntry);

            // Update Skill Points
            UpdateSkillCosts();

            // Update Labels
            UpdateLabels();
        }

        private void BtnSpecSkill_Click(object sender, EventArgs e)
        {
            if (listBoxTrainedSkill.SelectedItem == null)
                return;

            SkillEntry skillEntry = (SkillEntry)listBoxTrainedSkill.SelectedItem;
            SkillDef skillDef = skillEntry.skillDef;

            int availablePoints = (TotalSkillPoints - SpentSkillPoints);

            // If skill points is > 100, skill is default. Minus the 100.
            if ((skillDef.SkillPoints > 100 ? skillDef.SkillPoints - 100 : skillDef.SkillPoints) > availablePoints)
            {
                // Not enough points available
                return;
            }

            listBoxTrainedSkill.Items.RemoveAt(listBoxTrainedSkill.SelectedIndex);
            listBoxSpec.Items.Add(skillEntry);

            // Update Skill Points
            UpdateSkillCosts();

            // Update Labels
            UpdateLabels();
        }

        private void BtnUnSpecSkill_Click(object sender, EventArgs e)
        {
            if (listBoxSpec.SelectedItem == null)
                return;

            SkillEntry skillEntry = (SkillEntry)listBoxSpec.SelectedItem;
            SkillDef skillDef = skillEntry.skillDef;

            // Remove Skill
            listBoxSpec.Items.RemoveAt(listBoxSpec.SelectedIndex);

            // Add skill back to untrained
            listBoxTrainedSkill.Items.Add(skillEntry);

            // Update Skill Points
            UpdateSkillCosts();

            // Update Labels
            UpdateLabels();
        }

        private class SkillEntry : IComparable<SkillEntry>
        {
            public SkillDef skillDef;

            public SkillEntry(SkillDef skillDef)
            {
                this.skillDef = skillDef;
            }

            public override string ToString()
            {
                return skillDef.Name;
            }
        }
    }
}
