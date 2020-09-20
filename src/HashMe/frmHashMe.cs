using System;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;

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
    public partial class frmHashMe : Form
    {
        public frmHashMe()
        {
            InitializeComponent();
        }
            
        private void FrmHashMe_Load(object sender, EventArgs e)
        {
            this.DragEnter += new DragEventHandler(FileDragEnter);
            this.DragDrop += new DragEventHandler(FileDragDrop);
            MonoAdjustLabels();
        }

        private void MonoAdjustLabels()
        {
            bool runningOnMono = Type.GetType("Mono.Runtime") != null;
            if (runningOnMono)
            {
                const int adjustment = 4;
                lblMD5.Left = lblMD5.Location.X + adjustment;
                lblSHA1.Left = lblSHA1.Location.X + adjustment;
                lblSHA256.Left = lblSHA256.Location.X + adjustment;
            }
        }

        private void FileDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void FileDragDrop(object sender, DragEventArgs e)
        {
            string[] filePath = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (File.Exists(filePath[0]))
            {
                bgwHashing.RunWorkerAsync(filePath[0]);
            }
        }

        private void BgwHashing_DoWork(object sender, DoWorkEventArgs e)
        {
            string filePath = (string)e.Argument;
            var hashes = Hashing.GetHashes(filePath);
            e.Result = hashes;
        }

        private void BgwHashing_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string hashes = e.Result.ToString().TrimStart('(').TrimEnd(')');
            string[] hashArray = hashes.Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
            DisplayHashes(hashArray[0], hashArray[1], hashArray[2]);
        }

        private void DisplayHashes(string md5, string sha1, string sha256)
        {
            if (!string.IsNullOrEmpty(md5))
            {
                txtMD5.Text = md5.ToLower();
                txtMD5.SelectionStart = txtMD5.Text.Length;
            }
            if (!string.IsNullOrEmpty(sha1))
            {
                txtSHA1.Text = sha1.ToLower();
                txtSHA1.SelectionStart = txtSHA1.Text.Length;
            }
            if (!string.IsNullOrEmpty(sha256))
            {
                txtSHA256.Text = sha256.ToLower();
                txtSHA256.SelectionStart = txtSHA256.Text.Length;
            }
        }
    }
}
