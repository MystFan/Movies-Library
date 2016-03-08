namespace MoviesLibrary.Common
{
    using System;
    using System.Text;

    public class IdentifierProvider
    {
        private string salt = "MoviesLibrary";

        public IdentifierProvider(string salt = "MoviesLibrary")
        {
            this.salt = salt;
        }

        public int DecodeId(string urlId)
        {
            if (urlId.Length != 20)
            {
                return -1;
            }

            var base64EncodedBytes = Convert.FromBase64String(urlId);
            var bytesAsString = Encoding.UTF8.GetString(base64EncodedBytes);
            bytesAsString = bytesAsString.Replace(this.salt, string.Empty);
            return int.Parse(bytesAsString);
        }

        public string EncodeId(int id)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(id + this.salt);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}
