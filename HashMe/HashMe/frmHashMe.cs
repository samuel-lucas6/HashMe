using System;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.ComponentModel;

//HashMe:  Retrieve MD5, SHA1, and SHA256 hashes for files on Windows.
//    Copyright(C) 2020 Samuel Lucas

//    Permission is hereby granted, free of charge, to any person obtaining 
//    a copy of this software and associated documentation files (the "Software"), 
//    to deal in the Software without restriction, including without limitation 
//    the rights to use, copy, modify, merge, publish, distribute, sublicense, 
//    and/or sell copies of the Software, and to permit persons to whom the 
//    Software is furnished to do so, subject to the following conditions:

//    The above copyright notice and this permission notice shall be included
//    in all copies or substantial portions of the Software.

//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS 
//    OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
//    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//    SOFTWARE.

namespace HashMe
{
    public partial class frmHashMe : Form
    {
        public frmHashMe()
        {
            InitializeComponent();
        }

        private void frmHashMe_Load(object sender, EventArgs e)
        {
            this.DragEnter += new DragEventHandler(fileDragEnter);
            this.DragDrop += new DragEventHandler(fileDragDrop);
        }

        private void fileDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void fileDragDrop(object sender, DragEventArgs e)
        {
            string[] filePath = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (File.Exists(filePath[0]))
            {
                bgwHashing.RunWorkerAsync(filePath[0]);
            }
        }

        private void bgwHashing_DoWork(object sender, DoWorkEventArgs e)
        {
            string filePath = (string)e.Argument;
            var hashes = getHashes(filePath);
            e.Result = hashes;
        }

        private void bgwHashing_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string hashes = e.Result.ToString();
            string[] splitHashes = hashes.Split(',');
            splitHashes[0] = splitHashes[0].TrimStart('(');
            splitHashes[2] = splitHashes[2].TrimEnd(')');
            displayHashes(splitHashes[0], splitHashes[1], splitHashes[2]);
        }

        private static (string, string, string) getHashes(string filePath)
        {
            string md5 = hashFile(filePath, new MD5CryptoServiceProvider());
            string sha1 = hashFile(filePath, new SHA1CryptoServiceProvider());
            string sha256 = hashFile(filePath, new SHA256CryptoServiceProvider());
            return (md5, sha1, sha256);
        }

        private static string hashFile(string filePath, HashAlgorithm hash)
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    byte[] hashBytes = hash.ComputeHash(fs);
                    string hashString = BitConverter.ToString(hashBytes).Replace("-", "");
                    return hashString;
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Error: IO exception.");
                return null;
            }
        }

        private void displayHashes(string md5, string sha1, string sha256)
        {
            if (!string.IsNullOrEmpty(md5))
            {
                txtMD5.Text = md5.ToLower();
            }
            if (!string.IsNullOrEmpty(sha1))
            {
                txtSHA1.Text = sha1.ToLower();
            }
            if (!string.IsNullOrEmpty(sha256))
            {
                txtSHA256.Text = sha256.ToLower();
            }
            txtMD5.SelectionStart = txtMD5.Text.Length;
        }
    }
}
