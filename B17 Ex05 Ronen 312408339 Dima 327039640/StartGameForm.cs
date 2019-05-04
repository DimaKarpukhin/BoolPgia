namespace B17_Ex05_Ronen_312408339_Dima_327039640
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
   
    public class FormStartGame : Form
    {
        private const int k_MaxNumOfChances = 10;
        private static int s_NumberOfChances = 4;
        private Button m_ButtonNumberOfChances;
        private Button m_ButtonStart;
        private RunGameForm m_FormGame;

        public FormStartGame()
        {
            this.Text = "Bool Pgia";
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(260, 95);
            this.MaximizeBox = false;

            m_ButtonNumberOfChances = new Button();
            this.Controls.Add(m_ButtonNumberOfChances);
            m_ButtonNumberOfChances.Location = new Point(12, 12);
            m_ButtonNumberOfChances.Size = new Size(240, 23);
            m_ButtonNumberOfChances.TabIndex = 0;
            m_ButtonNumberOfChances.Text = string.Format("Number of chances: {0}", s_NumberOfChances);
            m_ButtonNumberOfChances.Click += new EventHandler(buttonNumberOfChances_Click);

            m_ButtonStart = new Button();
            this.Controls.Add(m_ButtonStart);
            m_ButtonStart.Location = new Point(174, 60);
            m_ButtonStart.Size = new Size(75, 23);
            m_ButtonStart.TabIndex = 1;
            m_ButtonStart.Text = "Start";
            m_ButtonStart.Click += new EventHandler(buttonStart_Click);
        }

        public int NumberOfChances
        {
            get { return s_NumberOfChances; }
            set { s_NumberOfChances = value; }
        }

        private void buttonNumberOfChances_Click(object sender, EventArgs e)
        {
            if (this.NumberOfChances < k_MaxNumOfChances)
            {
                NumberOfChances++;
                m_ButtonNumberOfChances.Text = string.Format("Number of chances: {0}", s_NumberOfChances);
            }
            else
            {
                m_ButtonNumberOfChances.Enabled = false;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        { 
            m_FormGame = new RunGameForm(this.NumberOfChances);
            m_FormGame.ShowDialog();
            this.Close();
        }
    }
}
