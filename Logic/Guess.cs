namespace Logic
{
    using System;

    public class Guess
    {
        private const byte k_LengthOfSequence = 4;
        private const char k_BottomOfTheRangeChar = 'A';
        private const char k_TopOfTheRangeChar = 'H';
        private string m_Sequence;

        public static byte LengthOfSequence
        {
            get { return k_LengthOfSequence; }
        }

        public string Sequence
        {
            get { return m_Sequence; }
            set { m_Sequence = value; }
        }

        public static bool TryParse(string i_Str, out Guess o_Guess, out string o_InvalidStrMsg)
        {
            bool result;

            if (i_Str.Length != k_LengthOfSequence)
            {
                o_Guess = null;
                o_InvalidStrMsg = "This is an invalid size of string";
                result = false;
            }
            else if (aCharNotInTheValidRangeExists(i_Str))
            {
                o_Guess = null;
                o_InvalidStrMsg = "There is a character that is not in the valid range of characters";
                result = false;
            }
            else if (aCharAppearsMoreThanOneTime(i_Str))
            {
                o_Guess = null;
                o_InvalidStrMsg = "There is a character that appears more than one time";
                result = false;
            }
            else
            {
                o_Guess = new Guess();
                o_Guess.Sequence = i_Str;
                o_InvalidStrMsg = null;
                result = true;
            }

            return result;
        }

        public static bool AreEqual(Guess i_Guess1, Guess i_Guess2)
        {
            return i_Guess1.Sequence == i_Guess2.Sequence;
        }

        public static Guess BuildRandomGuess()
        {
            System.Text.StringBuilder randomSeq = new System.Text.StringBuilder(k_LengthOfSequence);
            Random rnd = new Random();
            char letter = (char)rnd.Next(k_BottomOfTheRangeChar, k_TopOfTheRangeChar);
            bool[] buckets = new bool[k_TopOfTheRangeChar - k_BottomOfTheRangeChar + 1];

            for (int i = 0; i < k_LengthOfSequence; i++)
            {
                while (buckets[convertAsciiValToBucketIndex(letter)])
                {
                    letter = (char)rnd.Next(k_BottomOfTheRangeChar, k_TopOfTheRangeChar);
                }

                buckets[convertAsciiValToBucketIndex(letter)] = true;
                randomSeq.Append(letter);
            }

            Guess randomGuess = new Guess();
            randomGuess.Sequence = randomSeq.ToString();

            return randomGuess;
        }

        private static bool aCharNotInTheValidRangeExists(string i_Str)
        {
            bool result = false;

            foreach (char ch in i_Str)
            {
                if (ch < k_BottomOfTheRangeChar || ch > k_TopOfTheRangeChar)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        private static bool aCharAppearsMoreThanOneTime(string i_Str)
        {
            uint bucketSize = convertAsciiValToBucketIndex(k_TopOfTheRangeChar) - convertAsciiValToBucketIndex(k_BottomOfTheRangeChar) + 1;
            uint[] bucket = new uint[bucketSize];
            uint startBuckIndex = convertAsciiValToBucketIndex(k_BottomOfTheRangeChar);
            bool result = false;

            foreach (char ch in i_Str)
            {
                bucket[convertAsciiValToBucketIndex(ch)]++;
            }

            foreach (uint value in bucket)
            {
                if (value > 1)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        private static uint convertAsciiValToBucketIndex(char i_Char)
        {
            return (uint)i_Char - (uint)k_BottomOfTheRangeChar;
        }
    }
}
