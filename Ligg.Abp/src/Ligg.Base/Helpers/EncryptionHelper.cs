using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Ligg.Base.Helpers
{
    public static class EncryptionHelper
    {
        public static string Key1 = _selfKey1;
        public static string Key2 = _selfKey2;
        private static string _selfKey1 = "mOtXb01/2Mp8kIOYD/hbAg==";
        private static string _selfKey2 = "wEdL50/eAJFSx+0thR2hhg==";

        private static readonly string
            TypeName = System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName;

        //#md5 
        public static String Md5Encrypt(String source)
        {
            char[] hashedDatachars;
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] hashedDataBytes = md5Hasher.ComputeHash(encoder.GetBytes(source));
            long arrayLength = (long)((4.0d / 3.0d) * hashedDataBytes.Length);
            if (arrayLength % 4 != 0)
            {
                arrayLength += 4 - arrayLength % 4;
            }

            hashedDatachars = new char[arrayLength];
            Convert.ToBase64CharArray(hashedDataBytes, 0, hashedDataBytes.Length, hashedDatachars, 0);
            String tmp = new String(hashedDatachars);
            return tmp;
        }


        //#RSA
        public static string RsaEncrypt(string source)
        {
            return RsaEncrypt(source, Key1);
        }

        public static string RsaEncrypt(string source, string key)
        {
            try
            {
                var csp = new CspParameters();
                csp.KeyContainerName = key;
                var rsaProvider = new RSACryptoServiceProvider(csp);
                byte[] encryptBytes = rsaProvider.Encrypt(ASCIIEncoding.ASCII.GetBytes(source), false);
                string str = "";
                foreach (byte b in encryptBytes)
                {
                    str = str + string.Format("{0:x2}", b);
                }

                return str;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("\n>> " + TypeName + ".RsaEncrypt Error: " + ex.Message);
            }
        }

        public static string RsaDecrypt(string source)
        {
            return RsaDecrypt(source, Key1);
        }

        public static string RsaDecrypt(string source, string key)
        {
            try
            {
                var csp = new CspParameters();
                csp.KeyContainerName = key;
                var rsaProvider = new RSACryptoServiceProvider(csp);
                int length = (source.Length / 2);
                byte[] decryptBytes = new byte[length];
                for (int index = 0; index < length; index++)
                {
                    string substring = source.Substring(index * 2, 2);
                    decryptBytes[index] = Convert.ToByte(substring, 16);
                }

                decryptBytes = rsaProvider.Decrypt(decryptBytes, false);
                return ASCIIEncoding.ASCII.GetString(decryptBytes);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("\n>> " + TypeName + ".RsaDecrypt Error: " + ex.Message);
            }
        }









    }
}

