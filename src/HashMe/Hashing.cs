using System;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Windows.Forms;

/*  HashMe:  Retrieve MD5, SHA1, and SHA256 hashes for files.
    Copyright(C) 2020 Samuel Lucas

    Permission is hereby granted, free of charge, to any person obtaining 
    a copy of this software and associated documentation files (the "Software"), 
    to deal in the Software without restriction, including without limitation 
    the rights to use, copy, modify, merge, publish, distribute, sublicense, 
    and/or sell copies of the Software, and to permit persons to whom the 
    Software is furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included
    in all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS 
    OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    SOFTWARE. 
*/

namespace HashMe
{
    public static class Hashing
    {
        public static (string, string, string) GetHashes(string filePath)
        {
            string md5 = HashFile(filePath, new MD5CryptoServiceProvider());
            string sha1 = HashFile(filePath, new SHA1CryptoServiceProvider());
            string sha256 = HashFile(filePath, new SHA256CryptoServiceProvider());
            return (md5, sha1, sha256);
        }

        private static string HashFile(string filePath, HashAlgorithm hashAlgorithm)
        {
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    byte[] hashBytes = hashAlgorithm.ComputeHash(fileStream);
                    hashAlgorithm.Dispose();
                    string hashString = BitConverter.ToString(hashBytes).Replace("-", "");
                    return hashString;
                }
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException || ex is ArgumentException || ex is SecurityException || ex is NotSupportedException)
            {
                MessageBox.Show($"Error: {ex.GetType()}");
                return null;    
            }
        }
    }
}
