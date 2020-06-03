namespace HashMe
{
    partial class frmHashMe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHashMe));
            this.txtMD5 = new System.Windows.Forms.TextBox();
            this.lblMD5 = new System.Windows.Forms.Label();
            this.lblSHA1 = new System.Windows.Forms.Label();
            this.txtSHA1 = new System.Windows.Forms.TextBox();
            this.lblSHA256 = new System.Windows.Forms.Label();
            this.txtSHA256 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtMD5
            // 
            this.txtMD5.BackColor = System.Drawing.Color.White;
            this.txtMD5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMD5.Location = new System.Drawing.Point(12, 31);
            this.txtMD5.Name = "txtMD5";
            this.txtMD5.ReadOnly = true;
            this.txtMD5.Size = new System.Drawing.Size(467, 26);
            this.txtMD5.TabIndex = 0;
            // 
            // lblMD5
            // 
            this.lblMD5.AutoSize = true;
            this.lblMD5.Location = new System.Drawing.Point(8, 9);
            this.lblMD5.Name = "lblMD5";
            this.lblMD5.Size = new System.Drawing.Size(40, 19);
            this.lblMD5.TabIndex = 1;
            this.lblMD5.Text = "MD5";
            // 
            // lblSHA1
            // 
            this.lblSHA1.AutoSize = true;
            this.lblSHA1.Location = new System.Drawing.Point(8, 70);
            this.lblSHA1.Name = "lblSHA1";
            this.lblSHA1.Size = new System.Drawing.Size(43, 19);
            this.lblSHA1.TabIndex = 3;
            this.lblSHA1.Text = "SHA1";
            // 
            // txtSHA1
            // 
            this.txtSHA1.BackColor = System.Drawing.Color.White;
            this.txtSHA1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSHA1.Location = new System.Drawing.Point(12, 92);
            this.txtSHA1.Name = "txtSHA1";
            this.txtSHA1.ReadOnly = true;
            this.txtSHA1.Size = new System.Drawing.Size(467, 26);
            this.txtSHA1.TabIndex = 2;
            // 
            // lblSHA256
            // 
            this.lblSHA256.AutoSize = true;
            this.lblSHA256.Location = new System.Drawing.Point(8, 133);
            this.lblSHA256.Name = "lblSHA256";
            this.lblSHA256.Size = new System.Drawing.Size(59, 19);
            this.lblSHA256.TabIndex = 5;
            this.lblSHA256.Text = "SHA256";
            // 
            // txtSHA256
            // 
            this.txtSHA256.BackColor = System.Drawing.Color.White;
            this.txtSHA256.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSHA256.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSHA256.Location = new System.Drawing.Point(12, 155);
            this.txtSHA256.Name = "txtSHA256";
            this.txtSHA256.ReadOnly = true;
            this.txtSHA256.Size = new System.Drawing.Size(467, 26);
            this.txtSHA256.TabIndex = 4;
            // 
            // frmHashMe
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(491, 196);
            this.Controls.Add(this.lblSHA256);
            this.Controls.Add(this.txtSHA256);
            this.Controls.Add(this.lblSHA1);
            this.Controls.Add(this.txtSHA1);
            this.Controls.Add(this.lblMD5);
            this.Controls.Add(this.txtMD5);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmHashMe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HashMe";
            this.Load += new System.EventHandler(this.frmHashMe_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMD5;
        private System.Windows.Forms.Label lblMD5;
        private System.Windows.Forms.Label lblSHA1;
        private System.Windows.Forms.TextBox txtSHA1;
        private System.Windows.Forms.Label lblSHA256;
        private System.Windows.Forms.TextBox txtSHA256;
    }
}

