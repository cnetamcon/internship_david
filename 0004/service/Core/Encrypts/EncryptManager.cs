using Core.Interfaces.Encrypts;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Core.Encrypts
{
    public class EncryptManager : IEncryptManager
    {
        string _sold = "Uyr43!@vb9(6e_#";
        string _cryptographicAlgorithm = "SHA1";
        int _passwordIteration = 2;
        string _initVector = "YokYeh3#2!gN12R4";
        int _keySize = 256;

        public string Encrypt(string text, string pass)
        {
            if (string.IsNullOrEmpty(text))
                return "";

            byte[] initVector = Encoding.ASCII.GetBytes(_initVector);
            byte[] sold = Encoding.ASCII.GetBytes(_sold);
            byte[] origin = Encoding.UTF8.GetBytes(text);

            PasswordDeriveBytes derivPass = new PasswordDeriveBytes(pass, sold, _cryptographicAlgorithm, _passwordIteration);
            byte[] keyBytes = derivPass.GetBytes(_keySize / 8);
            RijndaelManaged crypt = new RijndaelManaged();
            crypt.Mode = CipherMode.CBC;

            byte[] cipherTextBytes = null;

            using (ICryptoTransform encryptor = crypt.CreateEncryptor(keyBytes, initVector))
            {
                using (MemoryStream memStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(origin, 0, origin.Length);
                        cryptoStream.FlushFinalBlock();
                        cipherTextBytes = memStream.ToArray();
                        memStream.Close();
                        cryptoStream.Close();
                    }
                }
            }

            crypt.Clear();
            return Convert.ToBase64String(cipherTextBytes);
        }

        public string Decrypt(string text, string pass)
        {
            if (string.IsNullOrEmpty(text))
                return "";

            byte[] initVector = Encoding.ASCII.GetBytes(_initVector);
            byte[] sold = Encoding.ASCII.GetBytes(_sold);
            byte[] origin = Convert.FromBase64String(text);

            PasswordDeriveBytes derivPass = new PasswordDeriveBytes(pass, sold, _cryptographicAlgorithm, _passwordIteration);
            byte[] keyBytes = derivPass.GetBytes(_keySize / 8);

            RijndaelManaged crypt = new RijndaelManaged();
            crypt.Mode = CipherMode.CBC;

            byte[] plainTextBytes = new byte[origin.Length];
            int byteCount = 0;

            using (ICryptoTransform decryptor = crypt.CreateDecryptor(keyBytes, initVector))
            {
                using (MemoryStream mSt = new MemoryStream(origin))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(mSt, decryptor, CryptoStreamMode.Read))
                    {
                        byteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                        mSt.Close();
                        cryptoStream.Close();
                    }
                }
            }

            crypt.Clear();
            return Encoding.UTF8.GetString(plainTextBytes, 0, byteCount);
        }
    }
}
