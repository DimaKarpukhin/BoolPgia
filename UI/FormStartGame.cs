namespace UI
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormStartGame : Form
    {
        private const int k_MaxNumOfChances = 10;
        private static int s_NumberOfChances = 4;
        private const int k_ClientLength = 260;
        private const int k_ClientHeight = 110;
        private const int k_ButtonLength = k_ClientLength / 3;
        private const int k_ButtonHeight = k_ClientHeight / 3;
        private const int k_MarginSize = k_ButtonHeight / 2;
        private Button m_ButtonNumberOfChances;
        private Button m_ButtonStart;
        private FormRunGame m_FormGame;

        public FormStartGame()
        {
            this.Text = "Bool Pgia";
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(k_ClientLength, k_ClientHeight);
            this.MaximizeBox = false;

            m_ButtonNumberOfChances = new Button();
            this.Controls.Add(m_ButtonNumberOfChances);
            m_ButtonNumberOfChances.Location = new Point(k_MarginSize, k_MarginSize);
            m_ButtonNumberOfChances.Size = new Size(k_ClientLength - (k_MarginSize * 2), k_ButtonHeight);
            m_ButtonNumberOfChances.TabIndex = 0;
            m_ButtonNumberOfChances.Text = string.Format("Number of chances: {0}", s_NumberOfChances);
            m_ButtonNumberOfChances.Click += new EventHandler(buttonNumberOfChances_Click);

            m_ButtonStart = new Button();
            this.Controls.Add(m_ButtonStart);
            m_ButtonStart.Location = new Point(k_ButtonLength, k_MarginSize + k_ButtonHeight + (k_MarginSize / 2));
            m_ButtonStart.Size = new Size(k_ButtonLength, k_ButtonHeight);
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
            m_FormGame = new FormRunGame(this.NumberOfChances);
            m_FormGame.ShowDialog();
            this.Close();
        }
    }
}
