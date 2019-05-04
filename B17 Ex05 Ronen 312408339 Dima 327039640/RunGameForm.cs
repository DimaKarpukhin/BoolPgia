namespace B17_Ex05_Ronen_312408339_Dima_327039640
{
    using System.Drawing;
    using System.Windows.Forms;
    using Logic;

    public class RunGameForm : Form
    {
        private const int k_ButtonSize = 40;
        private const int k_GessLeight = 4;
        private Button[] m_ButtonsInitialGuess = new Button [k_GessLeight];
        private Round[] m_Rounds;
        private Guess m_InitialGuess;
        private Guess m_CurrentUserGuess;
        private Score m_ScoreOfUserGuess;

        public RunGameForm(int i_NumOfRounds)
        {
            m_InitialGuess = Guess.BuildRandomGuess();
            this.Text = "Bool Pgia";
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size((k_ButtonSize * 7) - 10, (i_NumOfRounds * 44) + 66);
            this.MaximizeBox = false;

            m_Rounds = new Round[i_NumOfRounds];
            createInitialGuessButtons();
            initialAllRounds(i_NumOfRounds);     
        }

        public Button[] ButtonsInitialGuess
        {
            get { return m_ButtonsInitialGuess; }
        }

        public string ScoreStr
        {
            get { return m_ScoreOfUserGuess.ScoreStr; }
        }

        public string InitialGuessStr
        {
            get { return m_InitialGuess.Sequence; }
        }

        public string CurrentUserGuessStr
        {
            get { return m_CurrentUserGuess.Sequence; }
        }

        public void BuildScore()
        {
            m_ScoreOfUserGuess = new Score(m_CurrentUserGuess, m_InitialGuess);
        }

        public bool IsStopPlaying()
        {
            bool stopPlaying = true;
            int i = 0;

            while (stopPlaying && i < m_Rounds.Length)
            {
                stopPlaying = m_Rounds[i++].IsStopRound();
            }

            return stopPlaying;
        }

        public void DisableAllButtons()
        {
            foreach (Round round in m_Rounds)
            {
                round.DisableRoundButtons();
            }
        }

        public void CreateGuessFromString(string i_String)
        {
            string invalidMsg = null;
            Guess guess = null;
            if (Guess.TryParse(i_String, out guess, out invalidMsg))
            {
                m_CurrentUserGuess = guess;
            }
        }

        public string ButtonBackColorToString(Color i_BackColor)
        {
            string result = null;

            if (i_BackColor == Color.Purple)
            {
                result = "A";
            }
            else if (i_BackColor == Color.Red)
            {
                result = "B";
            }
            else if (i_BackColor == Color.Lime)
            {
                result = "C";
            }
            else if (i_BackColor == Color.Turquoise)
            {
                result = "D";
            }
            else if (i_BackColor == Color.Blue)
            {
                result = "E";
            }
            else if (i_BackColor == Color.Gold)
            {
                result = "F";
            }
            else if (i_BackColor == Color.Brown)
            {
                result = "G";
            }
            else if (i_BackColor == Color.White)
            {
                result = "H";
            }
            else if (i_BackColor == Color.Yellow)
            {
                result = "X";
            }
            else
            {
                result = "V";
            }

            return result;
        }

        public Color CharToButtonBackColor(char i_Char)
        {
            Color result = Color.Empty;

            if (i_Char == 'A')
            {
                result = Color.Purple;
            }
            else if (i_Char == 'B')
            {
                result = Color.Red;
            }
            else if (i_Char == 'C')
            {
                result = Color.Lime;
            }
            else if (i_Char == 'D')
            {
                result = Color.Turquoise;
            }
            else if (i_Char == 'E')
            {
                result = Color.Blue;
            }
            else if (i_Char == 'F')
            {
                result = Color.Gold;
            }
            else if (i_Char == 'G')
            {
                result = Color.Brown;
            }
            else if (i_Char == 'H')
            {
                result = Color.White;
            }
            else if (i_Char == 'X')
            {
                result = Color.Yellow;
            }
            else if (i_Char == 'V')
            {
                result = Color.Black;
            }

            return result;
        }

        private void initialAllRounds(int i_NumOfRounds)
        {
            for (int i = 0; i < i_NumOfRounds; i++)
            {
                m_Rounds[i] = new Round();
                m_Rounds[i].FormGame = this;
                m_Rounds[i].InitialRound(i);
            }
        }

        private void createInitialGuessButtons()
        {
            for (int i = 0; i < k_GessLeight; i++)
            {
                m_ButtonsInitialGuess[i] = new Button();
                this.Controls.Add(m_ButtonsInitialGuess[i]);
                m_ButtonsInitialGuess[i].Location = new Point((44 * i) + 4, 8);
                m_ButtonsInitialGuess[i].Size = new Size(k_ButtonSize, k_ButtonSize);
                m_ButtonsInitialGuess[i].BackColor = Color.Black;
                m_ButtonsInitialGuess[i].Enabled = false;
                m_ButtonsInitialGuess[i].UseVisualStyleBackColor = true;
            }
        }
    }
}