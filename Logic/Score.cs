namespace Logic
{
    using System.Text;

    public class Score
    {
        private const char k_AcceptChar = 'V';
        private const char k_RejectChar = 'X';
        private string m_ScoreStr;

        public Score(Guess i_UserGuess, Guess i_InitialSequence)
        {
            m_ScoreStr = buildScore(i_UserGuess, i_InitialSequence);
        }

        public string ScoreStr
        {
            get { return m_ScoreStr; }
            set { m_ScoreStr = value; }
        }

        private static string buildScore(Guess i_UserGuess, Guess i_InitialSequence)
        {
            StringBuilder resLeftPart = new StringBuilder(i_UserGuess.Sequence.Length);
            StringBuilder resRightPart = new StringBuilder(i_UserGuess.Sequence.Length);

            for (int i = 0; i < i_UserGuess.Sequence.Length; i++)
            {
                for (int j = 0; j < i_InitialSequence.Sequence.Length; j++)
                {
                    if (i_UserGuess.Sequence.ToCharArray()[i] == i_InitialSequence.Sequence.ToCharArray()[j])
                    {
                        if (i == j)
                        {
                            resLeftPart.Append(k_AcceptChar);
                        }
                        else
                        {
                            resRightPart.Append(k_RejectChar);
                        }

                        break;
                    }
                }
            }

            resLeftPart.Append(resRightPart.ToString());

            return resLeftPart.ToString();
        }
    }
}