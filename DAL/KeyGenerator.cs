namespace DAL {
    using System.Security.Cryptography;
    using System.Text;

    public static class KeyGenerator {
        public const string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        public const int KeySize = 6;

        public static string GenerateUniqueKey() {
            char[] chars = Alphabet.ToCharArray();
            var data = new byte[1];
            var crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);

            data = new byte[KeySize];
            crypto.GetNonZeroBytes(data);
            var result = new StringBuilder(KeySize);

            foreach (byte b in data) {
                result.Append(chars[b%(chars.Length - 1)]);
            }

            return result.ToString();
        }
    }
}