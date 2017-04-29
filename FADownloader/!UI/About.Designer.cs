namespace FADownloader
{
    partial class aboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(aboutForm));
            this.btnClose = new System.Windows.Forms.Button();
            this.lblMukihyenaDescription = new System.Windows.Forms.Label();
            this.lblPervdragonDescription = new System.Windows.Forms.Label();
            this.lblFabioCredit = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.pbPervdragon = new System.Windows.Forms.PictureBox();
            this.pbMukihyena = new System.Windows.Forms.PictureBox();
            this.pbVariableMog = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbPervdragon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMukihyena)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVariableMog)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Location = new System.Drawing.Point(347, 330);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "get out my face";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // lblMukihyenaDescription
            // 
            this.lblMukihyenaDescription.AutoSize = true;
            this.lblMukihyenaDescription.ForeColor = System.Drawing.Color.White;
            this.lblMukihyenaDescription.Location = new System.Drawing.Point(270, 13);
            this.lblMukihyenaDescription.Name = "lblMukihyenaDescription";
            this.lblMukihyenaDescription.Size = new System.Drawing.Size(140, 78);
            this.lblMukihyenaDescription.TabIndex = 3;
            this.lblMukihyenaDescription.Text = "- conception/design\r\n- UI coding/design\r\n- HTML parser handling\r\n- login handling" +
    "\r\n- multithreading\r\n- wrote this janky description";
            // 
            // lblPervdragonDescription
            // 
            this.lblPervdragonDescription.AutoSize = true;
            this.lblPervdragonDescription.ForeColor = System.Drawing.Color.White;
            this.lblPervdragonDescription.Location = new System.Drawing.Point(270, 118);
            this.lblPervdragonDescription.Name = "lblPervdragonDescription";
            this.lblPervdragonDescription.Size = new System.Drawing.Size(167, 91);
            this.lblPervdragonDescription.TabIndex = 4;
            this.lblPervdragonDescription.Text = "- taught me how to not suck at c#\r\n- failed at that\r\n- cookies handling\r\n- downlo" +
    "ad handling\r\n- logger coding\r\n- various optimizations\r\n- fixed my fuckups and de" +
    "ad-ends";
            // 
            // lblFabioCredit
            // 
            this.lblFabioCredit.AutoSize = true;
            this.lblFabioCredit.ForeColor = System.Drawing.Color.White;
            this.lblFabioCredit.Location = new System.Drawing.Point(160, 327);
            this.lblFabioCredit.Name = "lblFabioCredit";
            this.lblFabioCredit.Size = new System.Drawing.Size(171, 26);
            this.lblFabioCredit.TabIndex = 5;
            this.lblFabioCredit.Text = "inspired by Fabio\'s FA Anti-Bawlete\r\nbatch downloader";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.ForeColor = System.Drawing.Color.White;
            this.lblInfo.Location = new System.Drawing.Point(12, 13);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(145, 156);
            this.lblInfo.TabIndex = 6;
            this.lblInfo.Text = resources.GetString("lblInfo.Text");
            // 
            // pbPervdragon
            // 
            this.pbPervdragon.ImageLocation = "http://a.facdn.net/1424255659/pervdragon.gif";
            this.pbPervdragon.Location = new System.Drawing.Point(163, 118);
            this.pbPervdragon.Name = "pbPervdragon";
            this.pbPervdragon.Size = new System.Drawing.Size(100, 100);
            this.pbPervdragon.TabIndex = 2;
            this.pbPervdragon.TabStop = false;
            this.pbPervdragon.Click += new System.EventHandler(this.pbPervdragon_Click);
            this.pbPervdragon.MouseHover += new System.EventHandler(this.pbPervdragon_MouseHover);
            // 
            // pbMukihyena
            // 
            this.pbMukihyena.ImageLocation = "http://a.facdn.net/1424255659/mukihyena.gif";
            this.pbMukihyena.Location = new System.Drawing.Point(163, 12);
            this.pbMukihyena.Name = "pbMukihyena";
            this.pbMukihyena.Size = new System.Drawing.Size(100, 100);
            this.pbMukihyena.TabIndex = 1;
            this.pbMukihyena.TabStop = false;
            this.pbMukihyena.Click += new System.EventHandler(this.pbMukihyena_Click);
            this.pbMukihyena.MouseHover += new System.EventHandler(this.pbMukihyena_MouseHover);
            // 
            // pbVariableMog
            // 
            this.pbVariableMog.ImageLocation = "http://a.facdn.net/1424255659/variablemog.gif";
            this.pbVariableMog.Location = new System.Drawing.Point(163, 224);
            this.pbVariableMog.Name = "pbVariableMog";
            this.pbVariableMog.Size = new System.Drawing.Size(100, 100);
            this.pbVariableMog.TabIndex = 7;
            this.pbVariableMog.TabStop = false;
            this.pbVariableMog.Click += new System.EventHandler(this.pbVariableMog_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(272, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 52);
            this.label1.TabIndex = 8;
            this.label1.Text = "- cookies handling code from his\r\nown program\r\n- insight on using login cookies\r\n" +
    "- misc assistance";
            // 
            // aboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(59)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(451, 363);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbVariableMog);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblFabioCredit);
            this.Controls.Add(this.lblPervdragonDescription);
            this.Controls.Add(this.lblMukihyenaDescription);
            this.Controls.Add(this.pbPervdragon);
            this.Controls.Add(this.pbMukihyena);
            this.Controls.Add(this.btnClose);
            this.Name = "aboutForm";
            this.Text = "About";
            this.Load += new System.EventHandler(this.aboutForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPervdragon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMukihyena)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVariableMog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pbMukihyena;
        private System.Windows.Forms.PictureBox pbPervdragon;
        private System.Windows.Forms.Label lblMukihyenaDescription;
        private System.Windows.Forms.Label lblPervdragonDescription;
        private System.Windows.Forms.Label lblFabioCredit;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.PictureBox pbVariableMog;
        private System.Windows.Forms.Label label1;
    }
}