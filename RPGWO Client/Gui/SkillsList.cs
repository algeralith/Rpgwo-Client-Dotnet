using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RPGWO_Client.Network.Packets;

namespace RPGWO_Client.Gui
{
    public partial class SkillsList : UserControl
    {
        private const int _shownSkills = 13;

        private SortedDictionary<int, Skill> _skills;

        private Label[] _skillNames;
        private Label[] _skillValues;

        private static Color _specColor = Color.FromArgb(100, 100, 200);

        public SkillsList()
        {
            InitializeComponent();

            _skillNames = new Label[_shownSkills];
            _skillValues = new Label[_shownSkills];
            _skills = new SortedDictionary<int, Skill>();

            // Skill Labels
            _skillNames[0] = skillLabel1;
            _skillNames[1] = skillLabel2;
            _skillNames[2] = skillLabel3;
            _skillNames[3] = skillLabel4;
            _skillNames[4] = skillLabel5;
            _skillNames[5] = skillLabel6;
            _skillNames[6] = skillLabel7;
            _skillNames[7] = skillLabel8;
            _skillNames[8] = skillLabel9;
            _skillNames[9] = skillLabel10;
            _skillNames[10] = skillLabel11;
            _skillNames[11] = skillLabel12;
            _skillNames[12] = skillLabel13;

            // Skill Values
            _skillValues[0] = skillValue1;
            _skillValues[1] = skillValue2;
            _skillValues[2] = skillValue3;
            _skillValues[3] = skillValue4;
            _skillValues[4] = skillValue5;
            _skillValues[5] = skillValue6;
            _skillValues[6] = skillValue7;
            _skillValues[7] = skillValue8;
            _skillValues[8] = skillValue9;
            _skillValues[9] = skillValue10;
            _skillValues[10] = skillValue11;
            _skillValues[11] = skillValue12;
            _skillValues[12] = skillValue13;
        }

        public void AddSkil(Skill skill)
        {
            lock (_skills)
            {
                if (skill.ClearList)
                    _skills.Clear();

                if (!_skills.ContainsKey(skill.SkillID))
                {
                    _skills.Add(skill.SkillID, skill);
                }

                // Update Labels
                UpdateSkills();
            }
        }

        private void UpdateSkills()
        {
            // Check if Scroll bar needs to be Enabled / Disabled.
            if (_skills.Count > 13)
            {
                // Calculate scroll maximum value
                skillScrollBar.Maximum = (_skills.Count - 13);

                // Only reset scroll value if it was previously enabled.
                if (!skillScrollBar.Enabled)
                {
                    skillScrollBar.Value = 0;
                    skillScrollBar.Enabled = true;
                }
            }
            else
            {
                skillScrollBar.Maximum = 0;
                skillScrollBar.Value = 0;
                skillScrollBar.Enabled = false;
            }

            int[] skills = _skills.Keys.ToArray();
            for (int i = 0; i < Math.Min(_skills.Count, _shownSkills); i++)
            {
                int skillID = skills[i + skillScrollBar.Value];
                Skill skill = _skills[skillID];

                // Set color
                if (skill.Spec == 1)
                    _skillNames[i].ForeColor = _specColor;
                else
                    _skillNames[i].ForeColor = Color.Black;

                _skillNames[i].Text = skill.SkillName;
                _skillValues[i].Text = skill.Value.ToString();
            }
        }

        private void skillScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            UpdateSkills();
        }

    }
}
