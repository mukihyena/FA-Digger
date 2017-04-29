namespace FADownloader
{
    partial class CookiesTutorial
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
            this.lbl_CT = new System.Windows.Forms.Label();
            this.btn_CT_Next = new System.Windows.Forms.Button();
            this.btn_CT_Prev = new System.Windows.Forms.Button();
            this.align = new System.Windows.Forms.PictureBox();
            this.pb_CT_CR = new System.Windows.Forms.PictureBox();
            this.pb_CT_FF = new System.Windows.Forms.PictureBox();
            this.pb_Tut = new System.Windows.Forms.PictureBox();
            this.btn_CT_Close = new System.Windows.Forms.Button();
            this.lbl_ct_pagenum = new System.Windows.Forms.Label();
            this.lbl_ct_title = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.align)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_CT_CR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_CT_FF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Tut)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_CT
            // 
            this.lbl_CT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_CT.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.lbl_CT.Location = new System.Drawing.Point(12, 466);
            this.lbl_CT.Name = "lbl_CT";
            this.lbl_CT.Size = new System.Drawing.Size(920, 25);
            this.lbl_CT.TabIndex = 0;
            this.lbl_CT.Text = "Tutorial";
            this.lbl_CT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_CT_Next
            // 
            this.btn_CT_Next.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_CT_Next.Font = new System.Drawing.Font("Verdana", 6.75F);
            this.btn_CT_Next.ForeColor = System.Drawing.Color.Black;
            this.btn_CT_Next.Location = new System.Drawing.Point(776, 466);
            this.btn_CT_Next.Name = "btn_CT_Next";
            this.btn_CT_Next.Size = new System.Drawing.Size(75, 23);
            this.btn_CT_Next.TabIndex = 42;
            this.btn_CT_Next.Text = "Next";
            this.btn_CT_Next.UseVisualStyleBackColor = true;
            this.btn_CT_Next.Click += new System.EventHandler(this.btn_CT_Next_Click);
            // 
            // btn_CT_Prev
            // 
            this.btn_CT_Prev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_CT_Prev.Font = new System.Drawing.Font("Verdana", 6.75F);
            this.btn_CT_Prev.ForeColor = System.Drawing.Color.Black;
            this.btn_CT_Prev.Location = new System.Drawing.Point(695, 466);
            this.btn_CT_Prev.Name = "btn_CT_Prev";
            this.btn_CT_Prev.Size = new System.Drawing.Size(75, 23);
            this.btn_CT_Prev.TabIndex = 43;
            this.btn_CT_Prev.Text = "Previous";
            this.btn_CT_Prev.UseVisualStyleBackColor = true;
            this.btn_CT_Prev.Click += new System.EventHandler(this.btn_CT_Prev_Click);
            // 
            // align
            // 
            this.align.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.align.Location = new System.Drawing.Point(470, 260);
            this.align.Name = "align";
            this.align.Size = new System.Drawing.Size(10, 10);
            this.align.TabIndex = 47;
            this.align.TabStop = false;
            this.align.Visible = false;
            // 
            // pb_CT_CR
            // 
            this.pb_CT_CR.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pb_CT_CR.InitialImage = global::FADownloader.Properties.Resources.firefox;
            this.pb_CT_CR.Location = new System.Drawing.Point(486, 134);
            this.pb_CT_CR.Name = "pb_CT_CR";
            this.pb_CT_CR.Size = new System.Drawing.Size(256, 256);
            this.pb_CT_CR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_CT_CR.TabIndex = 46;
            this.pb_CT_CR.TabStop = false;
            this.pb_CT_CR.Click += new System.EventHandler(this.pb_CT_CR_Click);
            // 
            // pb_CT_FF
            // 
            this.pb_CT_FF.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pb_CT_FF.InitialImage = global::FADownloader.Properties.Resources.chrome;
            this.pb_CT_FF.Location = new System.Drawing.Point(208, 134);
            this.pb_CT_FF.Name = "pb_CT_FF";
            this.pb_CT_FF.Size = new System.Drawing.Size(256, 256);
            this.pb_CT_FF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_CT_FF.TabIndex = 45;
            this.pb_CT_FF.TabStop = false;
            this.pb_CT_FF.Click += new System.EventHandler(this.pb_CT_FF_Click);
            // 
            // pb_Tut
            // 
            this.pb_Tut.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pb_Tut.Location = new System.Drawing.Point(12, 12);
            this.pb_Tut.Name = "pb_Tut";
            this.pb_Tut.Size = new System.Drawing.Size(920, 448);
            this.pb_Tut.TabIndex = 44;
            this.pb_Tut.TabStop = false;
            // 
            // btn_CT_Close
            // 
            this.btn_CT_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_CT_Close.Font = new System.Drawing.Font("Verdana", 6.75F);
            this.btn_CT_Close.ForeColor = System.Drawing.Color.Black;
            this.btn_CT_Close.Location = new System.Drawing.Point(857, 466);
            this.btn_CT_Close.Name = "btn_CT_Close";
            this.btn_CT_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_CT_Close.TabIndex = 48;
            this.btn_CT_Close.Text = "Close";
            this.btn_CT_Close.UseVisualStyleBackColor = true;
            this.btn_CT_Close.Click += new System.EventHandler(this.btn_CT_Close_Click);
            // 
            // lbl_ct_pagenum
            // 
            this.lbl_ct_pagenum.AutoSize = true;
            this.lbl_ct_pagenum.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ct_pagenum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.lbl_ct_pagenum.Location = new System.Drawing.Point(12, 470);
            this.lbl_ct_pagenum.Name = "lbl_ct_pagenum";
            this.lbl_ct_pagenum.Size = new System.Drawing.Size(44, 16);
            this.lbl_ct_pagenum.TabIndex = 49;
            this.lbl_ct_pagenum.Text = "Page";
            // 
            // lbl_ct_title
            // 
            this.lbl_ct_title.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_ct_title.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ct_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.lbl_ct_title.Location = new System.Drawing.Point(12, 12);
            this.lbl_ct_title.Name = "lbl_ct_title";
            this.lbl_ct_title.Size = new System.Drawing.Size(920, 119);
            this.lbl_ct_title.TabIndex = 50;
            this.lbl_ct_title.Text = "-=HOW TO FIND YOUR LOGIN COOKIES=-\r\n\r\nPlease select your preferred browser.";
            this.lbl_ct_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CookiesTutorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(59)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(944, 501);
            this.Controls.Add(this.lbl_ct_title);
            this.Controls.Add(this.lbl_ct_pagenum);
            this.Controls.Add(this.btn_CT_Close);
            this.Controls.Add(this.align);
            this.Controls.Add(this.pb_CT_CR);
            this.Controls.Add(this.pb_CT_FF);
            this.Controls.Add(this.btn_CT_Prev);
            this.Controls.Add(this.btn_CT_Next);
            this.Controls.Add(this.lbl_CT);
            this.Controls.Add(this.pb_Tut);
            this.Font = new System.Drawing.Font("Verdana", 6.75F);
            this.MaximumSize = new System.Drawing.Size(960, 540);
            this.MinimumSize = new System.Drawing.Size(960, 540);
            this.Name = "CookiesTutorial";
            this.Text = "CookiesTutorial";
            this.Load += new System.EventHandler(this.CookiesTutorial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.align)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_CT_CR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_CT_FF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Tut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_CT;
        private System.Windows.Forms.Button btn_CT_Next;
        private System.Windows.Forms.Button btn_CT_Prev;
        private System.Windows.Forms.PictureBox pb_Tut;
        private System.Windows.Forms.PictureBox pb_CT_FF;
        private System.Windows.Forms.PictureBox pb_CT_CR;
        private System.Windows.Forms.PictureBox align;
        private System.Windows.Forms.Button btn_CT_Close;
        private System.Windows.Forms.Label lbl_ct_pagenum;
        private System.Windows.Forms.Label lbl_ct_title;
    }
}