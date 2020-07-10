using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPGWO_Client.Gui
{
    public class SkillsView : UserControl
    {
        private Label labelNextLevel;
        private Label label51;
        private Label labelSpendable;
        private Label label49;
        private Label labelTotalExp;
        private Label labelLevel;
        private Label label46;
        private Label label45;
        private GroupBox groupBox2;
        private Button button28;
        private Button button29;
        private Button button30;
        private Button button31;
        private Label labelWisdom;
        private Label labelIntelligence;
        private Label labelQuickness;
        private Label labelDexterity;
        private Label label41;
        private Label label42;
        private Label label43;
        private Label label44;
        private Button button27;
        private Button button26;
        private Button button25;
        private Button button24;
        private Label labelStrength;
        private Label labelMana;
        private Label labelStamina;
        private Label labelLife;
        private Label label32;
        private Label label31;
        private Label label30;
        private Label label29;
        private Button button23;
        private Button button22;
        private GroupBox groupBox1;
        private Label label28;
        private Label label24;
        private Label label25;
        private Label label26;
        private Label label27;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label18;
        private Label label19;
        private Label label17;
        private Label label16;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label9;
        private VScrollBar vScrollBar1;
        private Panel panel1;

        public SkillsView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.labelNextLevel = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.labelSpendable = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.labelTotalExp = new System.Windows.Forms.Label();
            this.labelLevel = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button28 = new System.Windows.Forms.Button();
            this.button29 = new System.Windows.Forms.Button();
            this.button30 = new System.Windows.Forms.Button();
            this.button31 = new System.Windows.Forms.Button();
            this.labelWisdom = new System.Windows.Forms.Label();
            this.labelIntelligence = new System.Windows.Forms.Label();
            this.labelQuickness = new System.Windows.Forms.Label();
            this.labelDexterity = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.button27 = new System.Windows.Forms.Button();
            this.button26 = new System.Windows.Forms.Button();
            this.button25 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.labelStrength = new System.Windows.Forms.Label();
            this.labelMana = new System.Windows.Forms.Label();
            this.labelStamina = new System.Windows.Forms.Label();
            this.labelLife = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.button23 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelNextLevel
            // 
            this.labelNextLevel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelNextLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNextLevel.Location = new System.Drawing.Point(232, 10);
            this.labelNextLevel.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.labelNextLevel.Name = "labelNextLevel";
            this.labelNextLevel.Size = new System.Drawing.Size(72, 15);
            this.labelNextLevel.TabIndex = 40;
            this.labelNextLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label51
            // 
            this.label51.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label51.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.Location = new System.Drawing.Point(166, 10);
            this.label51.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(64, 15);
            this.label51.TabIndex = 39;
            this.label51.Text = "Next Level";
            // 
            // labelSpendable
            // 
            this.labelSpendable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSpendable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSpendable.Location = new System.Drawing.Point(232, 29);
            this.labelSpendable.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.labelSpendable.Name = "labelSpendable";
            this.labelSpendable.Size = new System.Drawing.Size(72, 15);
            this.labelSpendable.TabIndex = 38;
            this.labelSpendable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label49
            // 
            this.label49.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label49.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.Location = new System.Drawing.Point(166, 29);
            this.label49.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(64, 15);
            this.label49.TabIndex = 37;
            this.label49.Text = "Spendable";
            // 
            // labelTotalExp
            // 
            this.labelTotalExp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelTotalExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalExp.Location = new System.Drawing.Point(95, 29);
            this.labelTotalExp.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.labelTotalExp.Name = "labelTotalExp";
            this.labelTotalExp.Size = new System.Drawing.Size(65, 15);
            this.labelTotalExp.TabIndex = 36;
            this.labelTotalExp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelLevel
            // 
            this.labelLevel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLevel.Location = new System.Drawing.Point(95, 2);
            this.labelLevel.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Size = new System.Drawing.Size(65, 25);
            this.labelLevel.TabIndex = 35;
            this.labelLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label46
            // 
            this.label46.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(3, 2);
            this.label46.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(90, 25);
            this.label46.TabIndex = 34;
            this.label46.Text = "Level";
            // 
            // label45
            // 
            this.label45.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(3, 29);
            this.label45.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(90, 15);
            this.label45.TabIndex = 33;
            this.label45.Text = "Total Experience";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.button28);
            this.groupBox2.Controls.Add(this.button29);
            this.groupBox2.Controls.Add(this.button30);
            this.groupBox2.Controls.Add(this.button31);
            this.groupBox2.Controls.Add(this.labelWisdom);
            this.groupBox2.Controls.Add(this.labelIntelligence);
            this.groupBox2.Controls.Add(this.labelQuickness);
            this.groupBox2.Controls.Add(this.labelDexterity);
            this.groupBox2.Controls.Add(this.label41);
            this.groupBox2.Controls.Add(this.label42);
            this.groupBox2.Controls.Add(this.label43);
            this.groupBox2.Controls.Add(this.label44);
            this.groupBox2.Controls.Add(this.button27);
            this.groupBox2.Controls.Add(this.button26);
            this.groupBox2.Controls.Add(this.button25);
            this.groupBox2.Controls.Add(this.button24);
            this.groupBox2.Controls.Add(this.labelStrength);
            this.groupBox2.Controls.Add(this.labelMana);
            this.groupBox2.Controls.Add(this.labelStamina);
            this.groupBox2.Controls.Add(this.labelLife);
            this.groupBox2.Controls.Add(this.label32);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.label30);
            this.groupBox2.Controls.Add(this.label29);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 52);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(301, 97);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Attributes";
            // 
            // button28
            // 
            this.button28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button28.Location = new System.Drawing.Point(282, 66);
            this.button28.Name = "button28";
            this.button28.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.button28.Size = new System.Drawing.Size(17, 17);
            this.button28.TabIndex = 43;
            this.button28.Text = "⯅";
            this.button28.UseVisualStyleBackColor = true;
            // 
            // button29
            // 
            this.button29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button29.Location = new System.Drawing.Point(282, 50);
            this.button29.Name = "button29";
            this.button29.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.button29.Size = new System.Drawing.Size(17, 17);
            this.button29.TabIndex = 42;
            this.button29.Text = "⯅";
            this.button29.UseVisualStyleBackColor = true;
            // 
            // button30
            // 
            this.button30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button30.Location = new System.Drawing.Point(282, 34);
            this.button30.Name = "button30";
            this.button30.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.button30.Size = new System.Drawing.Size(17, 17);
            this.button30.TabIndex = 41;
            this.button30.Text = "⯅";
            this.button30.UseVisualStyleBackColor = true;
            // 
            // button31
            // 
            this.button31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button31.Location = new System.Drawing.Point(282, 19);
            this.button31.Name = "button31";
            this.button31.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.button31.Size = new System.Drawing.Size(17, 17);
            this.button31.TabIndex = 40;
            this.button31.Text = "⯅";
            this.button31.UseVisualStyleBackColor = true;
            // 
            // labelWisdom
            // 
            this.labelWisdom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelWisdom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWisdom.Location = new System.Drawing.Point(216, 66);
            this.labelWisdom.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.labelWisdom.Name = "labelWisdom";
            this.labelWisdom.Size = new System.Drawing.Size(62, 15);
            this.labelWisdom.TabIndex = 39;
            this.labelWisdom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelIntelligence
            // 
            this.labelIntelligence.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelIntelligence.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIntelligence.Location = new System.Drawing.Point(216, 51);
            this.labelIntelligence.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.labelIntelligence.Name = "labelIntelligence";
            this.labelIntelligence.Size = new System.Drawing.Size(62, 15);
            this.labelIntelligence.TabIndex = 38;
            this.labelIntelligence.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelQuickness
            // 
            this.labelQuickness.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelQuickness.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuickness.Location = new System.Drawing.Point(216, 36);
            this.labelQuickness.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.labelQuickness.Name = "labelQuickness";
            this.labelQuickness.Size = new System.Drawing.Size(62, 15);
            this.labelQuickness.TabIndex = 37;
            this.labelQuickness.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelDexterity
            // 
            this.labelDexterity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelDexterity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDexterity.Location = new System.Drawing.Point(216, 19);
            this.labelDexterity.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.labelDexterity.Name = "labelDexterity";
            this.labelDexterity.Size = new System.Drawing.Size(62, 15);
            this.labelDexterity.TabIndex = 36;
            this.labelDexterity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label41
            // 
            this.label41.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.Location = new System.Drawing.Point(142, 66);
            this.label41.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(68, 15);
            this.label41.TabIndex = 35;
            this.label41.Text = "Wisdom";
            // 
            // label42
            // 
            this.label42.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(142, 51);
            this.label42.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(68, 15);
            this.label42.TabIndex = 34;
            this.label42.Text = "Intelligence";
            // 
            // label43
            // 
            this.label43.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(142, 36);
            this.label43.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(68, 15);
            this.label43.TabIndex = 33;
            this.label43.Text = "Quickness";
            // 
            // label44
            // 
            this.label44.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.Location = new System.Drawing.Point(142, 21);
            this.label44.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(68, 15);
            this.label44.TabIndex = 32;
            this.label44.Text = "Dexterity";
            // 
            // button27
            // 
            this.button27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button27.Location = new System.Drawing.Point(122, 66);
            this.button27.Name = "button27";
            this.button27.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.button27.Size = new System.Drawing.Size(17, 17);
            this.button27.TabIndex = 31;
            this.button27.Text = "⯅";
            this.button27.UseVisualStyleBackColor = true;
            // 
            // button26
            // 
            this.button26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button26.Location = new System.Drawing.Point(122, 50);
            this.button26.Name = "button26";
            this.button26.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.button26.Size = new System.Drawing.Size(17, 17);
            this.button26.TabIndex = 30;
            this.button26.Text = "⯅";
            this.button26.UseVisualStyleBackColor = true;
            // 
            // button25
            // 
            this.button25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button25.Location = new System.Drawing.Point(122, 34);
            this.button25.Name = "button25";
            this.button25.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.button25.Size = new System.Drawing.Size(17, 17);
            this.button25.TabIndex = 29;
            this.button25.Text = "⯅";
            this.button25.UseVisualStyleBackColor = true;
            // 
            // button24
            // 
            this.button24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button24.Location = new System.Drawing.Point(122, 19);
            this.button24.Name = "button24";
            this.button24.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.button24.Size = new System.Drawing.Size(17, 17);
            this.button24.TabIndex = 28;
            this.button24.Text = "⯅";
            this.button24.UseVisualStyleBackColor = true;
            // 
            // labelStrength
            // 
            this.labelStrength.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelStrength.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStrength.Location = new System.Drawing.Point(58, 66);
            this.labelStrength.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.labelStrength.Name = "labelStrength";
            this.labelStrength.Size = new System.Drawing.Size(62, 15);
            this.labelStrength.TabIndex = 27;
            this.labelStrength.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelMana
            // 
            this.labelMana.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelMana.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMana.Location = new System.Drawing.Point(58, 51);
            this.labelMana.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.labelMana.Name = "labelMana";
            this.labelMana.Size = new System.Drawing.Size(62, 15);
            this.labelMana.TabIndex = 26;
            this.labelMana.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelStamina
            // 
            this.labelStamina.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelStamina.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStamina.Location = new System.Drawing.Point(58, 36);
            this.labelStamina.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.labelStamina.Name = "labelStamina";
            this.labelStamina.Size = new System.Drawing.Size(62, 15);
            this.labelStamina.TabIndex = 25;
            this.labelStamina.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelLife
            // 
            this.labelLife.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelLife.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLife.Location = new System.Drawing.Point(58, 21);
            this.labelLife.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.labelLife.Name = "labelLife";
            this.labelLife.Size = new System.Drawing.Size(62, 15);
            this.labelLife.TabIndex = 24;
            this.labelLife.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label32
            // 
            this.label32.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(6, 66);
            this.label32.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(52, 15);
            this.label32.TabIndex = 23;
            this.label32.Text = "Strength";
            // 
            // label31
            // 
            this.label31.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(6, 51);
            this.label31.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(52, 15);
            this.label31.TabIndex = 22;
            this.label31.Text = "Mana";
            // 
            // label30
            // 
            this.label30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(6, 36);
            this.label30.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(52, 15);
            this.label30.TabIndex = 21;
            this.label30.Text = "Stamina";
            // 
            // label29
            // 
            this.label29.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(6, 21);
            this.label29.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(52, 15);
            this.label29.TabIndex = 20;
            this.label29.Text = "Life";
            // 
            // button23
            // 
            this.button23.Location = new System.Drawing.Point(310, 214);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(49, 41);
            this.button23.TabIndex = 30;
            this.button23.Text = "Untrain";
            this.button23.UseVisualStyleBackColor = true;
            // 
            // button22
            // 
            this.button22.Location = new System.Drawing.Point(310, 165);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(49, 41);
            this.button22.TabIndex = 31;
            this.button22.Text = "Train";
            this.button22.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.vScrollBar1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 155);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 237);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Skills";
            // 
            // label28
            // 
            this.label28.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(200, 216);
            this.label28.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(66, 15);
            this.label28.TabIndex = 44;
            // 
            // label24
            // 
            this.label24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(200, 200);
            this.label24.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(66, 15);
            this.label24.TabIndex = 43;
            // 
            // label25
            // 
            this.label25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(200, 184);
            this.label25.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(66, 15);
            this.label25.TabIndex = 42;
            // 
            // label26
            // 
            this.label26.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(200, 168);
            this.label26.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(66, 15);
            this.label26.TabIndex = 41;
            // 
            // label27
            // 
            this.label27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(200, 152);
            this.label27.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(66, 15);
            this.label27.TabIndex = 40;
            // 
            // label20
            // 
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(200, 136);
            this.label20.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(66, 15);
            this.label20.TabIndex = 39;
            // 
            // label21
            // 
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(200, 120);
            this.label21.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(66, 15);
            this.label21.TabIndex = 38;
            // 
            // label22
            // 
            this.label22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(200, 104);
            this.label22.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(66, 15);
            this.label22.TabIndex = 37;
            // 
            // label23
            // 
            this.label23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(200, 88);
            this.label23.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(66, 15);
            this.label23.TabIndex = 36;
            // 
            // label18
            // 
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(200, 72);
            this.label18.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(66, 15);
            this.label18.TabIndex = 35;
            // 
            // label19
            // 
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(200, 53);
            this.label19.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(66, 15);
            this.label19.TabIndex = 34;
            // 
            // label17
            // 
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(200, 37);
            this.label17.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(66, 15);
            this.label17.TabIndex = 33;
            // 
            // label16
            // 
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(6, 216);
            this.label16.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(188, 15);
            this.label16.TabIndex = 32;
            // 
            // label15
            // 
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(6, 200);
            this.label15.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(188, 15);
            this.label15.TabIndex = 31;
            // 
            // label14
            // 
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(6, 184);
            this.label14.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(188, 15);
            this.label14.TabIndex = 30;
            // 
            // label13
            // 
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 168);
            this.label13.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(188, 15);
            this.label13.TabIndex = 29;
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 152);
            this.label12.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(188, 15);
            this.label12.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 136);
            this.label11.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(188, 15);
            this.label11.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 120);
            this.label10.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(188, 16);
            this.label10.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 104);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(188, 15);
            this.label8.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 88);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 15);
            this.label7.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 72);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(188, 15);
            this.label6.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 53);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 15);
            this.label5.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 37);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 15);
            this.label4.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(200, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 21);
            this.label9.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(188, 15);
            this.label9.TabIndex = 19;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Enabled = false;
            this.vScrollBar1.Location = new System.Drawing.Point(273, 20);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(25, 211);
            this.vScrollBar1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.labelNextLevel);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label51);
            this.panel1.Controls.Add(this.button22);
            this.panel1.Controls.Add(this.labelSpendable);
            this.panel1.Controls.Add(this.button23);
            this.panel1.Controls.Add(this.label49);
            this.panel1.Controls.Add(this.label45);
            this.panel1.Controls.Add(this.labelTotalExp);
            this.panel1.Controls.Add(this.label46);
            this.panel1.Controls.Add(this.labelLevel);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 393);
            this.panel1.TabIndex = 41;
            // 
            // SkillsView
            // 
            this.Controls.Add(this.panel1);
            this.Name = "SkillsView";
            this.Size = new System.Drawing.Size(360, 394);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
