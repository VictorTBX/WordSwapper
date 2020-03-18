using LottoCap.Models;

namespace LottoCap
{
    public class WordSwapper : IWordSwapper
    {
        public WordSwapperModelResponse TransformWords(WordSwapperModelRequest modelResponse)
        {
            return new WordSwapperModelResponse
            {
                TotalMoves = CalculateChanges(modelResponse.Source, modelResponse.Destiny)
            };
        }

        private int CalculateChanges(string source, string destiny)
        {
            if (source.Equals(destiny))
                return 0;

            if (source.Contains(destiny))
                return source.Length - destiny.Length;

            if (destiny.Contains(source))
                return destiny.Length - source.Length;

            if (source.Length == destiny.Length)
                return VerifyWordsSameLenght(source, destiny);

            return VerifyWordsDifferentLength(source, destiny);
        }

        private int VerifyWordsDifferentLength(string source, string destiny)
        {
            string bigger, smaller;

            if (source.Length > destiny.Length)
            {
                bigger = source;
                smaller = destiny;
            }
            else
            {
                bigger = destiny;
                smaller = source;
            }

            var substringResult = string.Empty;

            for (int i = smaller.Length - 1; i > 0; i--)
            {
                substringResult = TryToFindSubstring(smaller, bigger, i);

                if (substringResult.Length > 0)
                    break;
            }

            var indexOfSubstringBigger = bigger.IndexOf(substringResult);
            var infexOfSubstringSmaller = smaller.IndexOf(substringResult);

            if (indexOfSubstringBigger == 0)
                return VerifyNumberChanges(smaller.Substring(substringResult.Length), bigger.Substring(substringResult.Length));
            else
                return VerifyNumberChanges(smaller.Substring(substringResult.Length + infexOfSubstringSmaller), bigger.Substring(substringResult.Length + indexOfSubstringBigger)) + indexOfSubstringBigger;
        }

        private int VerifyNumberChanges(string smaller, string bigger)
        {
            var numberChanges = 0;
            var biggerChanged = false;

            while (smaller.Length > 0)
            {
                if (!bigger.Contains(smaller[0]))
                {
                    smaller = smaller.Remove(0, 1);
                    numberChanges++;
                    continue;
                }

                if (bigger[0] != smaller[0])
                {
                    numberChanges++;
                }

                bigger = bigger.Remove(0, 1);
                smaller = smaller.Remove(0, 1);
                biggerChanged = true;
            }

            if (!biggerChanged)
                return bigger.Length;

            return numberChanges + bigger.Length - numberChanges;
        }

        private string TryToFindSubstring(string smaller, string bigger, int substringLength)
        {
            for (int j = 0; j < smaller.Length - substringLength + 1; j++)
            {
                var substringResult = smaller.Substring(j, substringLength);

                if (bigger.Contains(substringResult))
                {
                    return substringResult;
                }
            }

            return string.Empty;
        }

        private int VerifyWordsSameLenght(string source, string destiny)
        {
            var samePositionLetters = 0;

            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] == destiny[i])
                    samePositionLetters++;
            }

            return source.Length - samePositionLetters;
        }
    }
}
