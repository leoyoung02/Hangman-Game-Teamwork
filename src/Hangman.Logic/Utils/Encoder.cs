namespace Hangman.Logic.Utils
{
    using System;
    using System.Linq;

    public static class Encoder
    {
        internal static string GetEncodedFile(ScoreboardMemento memento)
        {
            string[] lines = memento.TopFiveRecords
             .Select(p => p.PlayerName + "=" + p.Score)
             .ToArray();

            string[] encodedLines = new string[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                encodedLines[i] = Base64Encode(lines[i]);
            }

            string encodedFile = Base64Encode(string.Join(Environment.NewLine, encodedLines));

            return encodedFile;
        }

        private static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}