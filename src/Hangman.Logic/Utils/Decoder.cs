namespace Hangman.Logic.Utils
{
    using System;

    public static class Decoder
    {
        internal static string Base64Decode(string base64EncodedData)
        {
                var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
                return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        internal static string[] DecodeEveryLine(string decodedText)
        {
            string[] encodedLines = decodedText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            string[] decodedLines = new string[encodedLines.Length];

            for (int i = 0; i < encodedLines.Length; i++)
            {
                decodedLines[i] = Decoder.Base64Decode(encodedLines[i]);
            }

            return decodedLines;
        }
    }
}