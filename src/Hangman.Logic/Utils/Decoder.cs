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
    }
}