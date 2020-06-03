using System;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

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
                getHashes(filePath[0]);
            }
        }

        private void getHashes(string filePath)
        {
            string md5 = hashFile(filePath, new MD5CryptoServiceProvider());
            string sha1 = hashFile(filePath, new SHA1CryptoServiceProvider());
            string sha256 = hashFile(filePath, new SHA256CryptoServiceProvider());
            displayHashes(md5, sha1, sha256);
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
        }
    }
}
