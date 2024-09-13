using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Net6HrPublicLibrary.PublicShared
{
    public class EncryptHr
    {
        public static string mtdEncryptPassword(string _text)
        {
            string input = "i" + _text + "u";
            string result = "";
            byte[] hashBytes = Encoding.UTF8.GetBytes(input);
#pragma warning disable SYSLIB0021 // Type or member is obsolete
            SHA1 sha1 = SHA1Managed.Create();
#pragma warning restore SYSLIB0021 // Type or member is obsolete
            byte[] cryptPassword = sha1.ComputeHash(hashBytes);
            result = BitConverter.ToString(cryptPassword).Replace("-", "");
            //result = System.Convert.ToBase64String(inputBytes);
            return result;
        }

        public static string mtdEncryptAttachment(string input)
        {
            string result = "";
            byte[] hashBytes = Encoding.UTF8.GetBytes(input);
#pragma warning disable SYSLIB0021 // Type or member is obsolete
            SHA1 sha1 = SHA1Managed.Create();
#pragma warning restore SYSLIB0021 // Type or member is obsolete
            byte[] cryptPassword = sha1.ComputeHash(hashBytes);
            result = BitConverter.ToString(cryptPassword).Replace("-", "");
            //result = System.Convert.ToBase64String(inputBytes);
            return result;
        }


        private const string initVector = "utmepesara072018"; // "pemgail9uzpgzl88";
        // This constant is used to determine the keysize of the encryption algorithm.
        private const int keysize = 256;

        //Encrypt
        public static string EncryptString(string plainText, string passPhrase)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
#pragma warning disable SYSLIB0022 // Type or member is obsolete
            RijndaelManaged symmetricKey = new RijndaelManaged();
#pragma warning restore SYSLIB0022 // Type or member is obsolete
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(cipherTextBytes);
        }
        public static string EncryptString4url(string plainText, string passPhrase)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
#pragma warning disable SYSLIB0022 // Type or member is obsolete
            RijndaelManaged symmetricKey = new RijndaelManaged();
#pragma warning restore SYSLIB0022 // Type or member is obsolete
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            string _return = Convert.ToBase64String(cipherTextBytes);
            _return = _return.Replace("+", "CAMPUR");
            _return = _return.Replace("/", "SLASH");
            _return = _return.Replace("'", "COATAS");
            _return = _return.Replace(",", "COBAWAH");
            _return = _return.Replace("@", "ALIAS");
            _return = _return.Replace("!", "SERUAN");
            _return = _return.Replace("&", "TANDAN");
            _return = _return.Replace("*", "STARB");
            _return = _return.Replace("#", "PAGAR");
            _return = _return.Replace("^", "LEKUK");
            return _return;
        }

        //Decrypt
        public static string DecryptString(string cipherText, string passPhrase)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
#pragma warning disable SYSLIB0022 // Type or member is obsolete
            RijndaelManaged symmetricKey = new RijndaelManaged();
#pragma warning restore SYSLIB0022 // Type or member is obsolete
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }
        public static string DecryptString4url(string _textEnc, string passPhrase)
        {
            if (_textEnc == null)
            {
                return null;
            }
            else
            {
                string cipherText = _textEnc.Replace("CAMPUR", "+");
                cipherText = cipherText.Replace("SLASH", "/");
                cipherText = cipherText.Replace("COATAS", "'");
                cipherText = cipherText.Replace("COBAWAH", ",");
                cipherText = cipherText.Replace("ALIAS", "@");
                cipherText = cipherText.Replace("SERUAN", "!");
                cipherText = cipherText.Replace("TANDAN", "&");
                cipherText = cipherText.Replace("STARB", "*");
                cipherText = cipherText.Replace("PAGAR", "#");
                cipherText = cipherText.Replace("LEKUK", "^");
                byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
                PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
                byte[] keyBytes = password.GetBytes(keysize / 8);
#pragma warning disable SYSLIB0022 // Type or member is obsolete
                RijndaelManaged symmetricKey = new RijndaelManaged();
#pragma warning restore SYSLIB0022 // Type or member is obsolete
                symmetricKey.Mode = CipherMode.CBC;
                ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
                MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
                CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
                byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                memoryStream.Close();
                cryptoStream.Close();
                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
            }
        }


    }
}
