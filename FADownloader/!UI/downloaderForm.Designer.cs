namespace FADownloader
{
    partial class downloaderForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(downloaderForm));
            this.lbOutput = new System.Windows.Forms.ListBox();
            this.gbLogin = new System.Windows.Forms.GroupBox();
            this.cbLogInOnLaunch = new System.Windows.Forms.CheckBox();
            this.cbShowPassword = new System.Windows.Forms.CheckBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.lblLoginInfo = new System.Windows.Forms.Label();
            this.cbAllFARatings = new System.Windows.Forms.CheckBox();
            this.lblRatings = new System.Windows.Forms.Label();
            this.cbAdult = new System.Windows.Forms.CheckBox();
            this.lblLoginStatus = new System.Windows.Forms.Label();
            this.cbMature = new System.Windows.Forms.CheckBox();
            this.cbGeneral = new System.Windows.Forms.CheckBox();
            this.gbFAConnectionStatus = new System.Windows.Forms.GroupBox();
            this.btnAttemptReconnection = new System.Windows.Forms.Button();
            this.lblFAConnectionStatus = new System.Windows.Forms.Label();
            this.lblArtistList = new System.Windows.Forms.Label();
            this.cbGallery = new System.Windows.Forms.CheckBox();
            this.cbScraps = new System.Windows.Forms.CheckBox();
            this.cbFavorites = new System.Windows.Forms.CheckBox();
            this.cbJournals = new System.Windows.Forms.CheckBox();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnSelectNone = new System.Windows.Forms.Button();
            this.gbArtistSettings = new System.Windows.Forms.GroupBox();
            this.cbStatusAutoUpdate = new System.Windows.Forms.CheckBox();
            this.lblArtistCount = new System.Windows.Forms.Label();
            this.btnGetArtistStatuses = new System.Windows.Forms.Button();
            this.lblArtistGalleryTypes = new System.Windows.Forms.Label();
            this.cbAllGalleryTypes = new System.Windows.Forms.CheckBox();
            this.dgvArtistList = new System.Windows.Forms.DataGridView();
            this.artistAvailable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.artistName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.artistDownloadGallery = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.artistDownloadScraps = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.artistDownloadFavorites = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.artistDownloadJournals = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnArtistApplyDownloads = new System.Windows.Forms.Button();
            this.btnImportWatchList = new System.Windows.Forms.Button();
            this.btnRemoveArtists = new System.Windows.Forms.Button();
            this.lblBigStatus = new System.Windows.Forms.Label();
            this.gbLoginCookies = new System.Windows.Forms.GroupBox();
            this.btn_CookieTut = new System.Windows.Forms.Button();
            this.btnVerifyCookies = new System.Windows.Forms.Button();
            this.lblCookieA = new System.Windows.Forms.Label();
            this.lblCookieB = new System.Windows.Forms.Label();
            this.tbCookieB = new System.Windows.Forms.TextBox();
            this.tbCookieA = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLoggingLevel = new System.Windows.Forms.Label();
            this.cbDownloads = new System.Windows.Forms.CheckBox();
            this.cbErrors = new System.Windows.Forms.CheckBox();
            this.cbStatus = new System.Windows.Forms.CheckBox();
            this.gbOutput = new System.Windows.Forms.GroupBox();
            this.lblDownloadingFile = new System.Windows.Forms.Label();
            this.lblDiggingArtist = new System.Windows.Forms.Label();
            this.lbDownloadProgress = new System.Windows.Forms.Label();
            this.lbParseProgress = new System.Windows.Forms.Label();
            this.cbAllLoggingLevels = new System.Windows.Forms.CheckBox();
            this.cbDebug = new System.Windows.Forms.CheckBox();
            this.btnClearOutput = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnCopyOutputToClipboard = new System.Windows.Forms.Button();
            this.gbImagePreview = new System.Windows.Forms.GroupBox();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.lblLiveInfo = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.nudHTMLDelay = new System.Windows.Forms.NumericUpDown();
            this.nudDownloadDelay = new System.Windows.Forms.NumericUpDown();
            this.lblHTMLDelay = new System.Windows.Forms.Label();
            this.lblDownloadDelay = new System.Windows.Forms.Label();
            this.btnDownload = new System.Windows.Forms.Button();
            this.cbOverwrite = new System.Windows.Forms.CheckBox();
            this.btnFolderSelect = new System.Windows.Forms.Button();
            this.gbDownloadOptions = new System.Windows.Forms.GroupBox();
            this.nudMaxDupes = new System.Windows.Forms.NumericUpDown();
            this.lblMaxDupes = new System.Windows.Forms.Label();
            this.cbDownloadMethod = new System.Windows.Forms.ComboBox();
            this.btnOpenDownloadDir = new System.Windows.Forms.Button();
            this.cbSubfolderBySubmissionType = new System.Windows.Forms.CheckBox();
            this.tbDownloadDirectory = new System.Windows.Forms.TextBox();
            this.lblDownloadDir = new System.Windows.Forms.Label();
            this.cbSubfolderByArtistName = new System.Windows.Forms.CheckBox();
            this.btnAbout = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cbFilterSubmissionTitle = new System.Windows.Forms.CheckBox();
            this.cbFilterKeywords = new System.Windows.Forms.CheckBox();
            this.cbFilterComments = new System.Windows.Forms.CheckBox();
            this.cbFilterDescription = new System.Windows.Forms.CheckBox();
            this.lbFilter = new System.Windows.Forms.ListBox();
            this.btnAddToFilter = new System.Windows.Forms.Button();
            this.cbFilterFileName = new System.Windows.Forms.CheckBox();
            this.btnRemoveFilteredWord = new System.Windows.Forms.Button();
            this.cbFilterAll = new System.Windows.Forms.CheckBox();
            this.gbMOTD = new System.Windows.Forms.GroupBox();
            this.lnklblLiveMOTDLink = new System.Windows.Forms.LinkLabel();
            this.lblLiveMOTD = new System.Windows.Forms.Label();
            this.dgvArtistListContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cbSTFU = new System.Windows.Forms.CheckBox();
            this.lblEnterVerification = new System.Windows.Forms.Label();
            this.gbCaptcha = new System.Windows.Forms.GroupBox();
            this.tbCaptcha = new System.Windows.Forms.TextBox();
            this.btnCaptchaSubmit = new System.Windows.Forms.Button();
            this.pbCaptcha = new System.Windows.Forms.PictureBox();
            this.lblCaptcha = new System.Windows.Forms.Label();
            this.tbAddToFilter = new System.Windows.Forms.TextBox();
            this.lblFilterThrough = new System.Windows.Forms.Label();
            this.gbFilterSettings = new System.Windows.Forms.GroupBox();
            this.wbLogin = new System.Windows.Forms.WebBrowser();
            this.gbLogin.SuspendLayout();
            this.gbFAConnectionStatus.SuspendLayout();
            this.gbArtistSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArtistList)).BeginInit();
            this.gbLoginCookies.SuspendLayout();
            this.gbOutput.SuspendLayout();
            this.gbImagePreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.gbInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHTMLDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDownloadDelay)).BeginInit();
            this.gbDownloadOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxDupes)).BeginInit();
            this.gbMOTD.SuspendLayout();
            this.gbCaptcha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaptcha)).BeginInit();
            this.gbFilterSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbOutput
            // 
            this.lbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbOutput.BackColor = System.Drawing.Color.Black;
            this.lbOutput.Font = new System.Drawing.Font("Franklin Gothic Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOutput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbOutput.FormattingEnabled = true;
            this.lbOutput.ItemHeight = 21;
            this.lbOutput.Location = new System.Drawing.Point(6, 19);
            this.lbOutput.Name = "lbOutput";
            this.lbOutput.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbOutput.Size = new System.Drawing.Size(403, 235);
            this.lbOutput.TabIndex = 1;
            this.toolTip.SetToolTip(this.lbOutput, "it\'s an output log, what do you think it is");
            // 
            // gbLogin
            // 
            this.gbLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbLogin.Controls.Add(this.cbLogInOnLaunch);
            this.gbLogin.Controls.Add(this.cbShowPassword);
            this.gbLogin.Controls.Add(this.btnLogin);
            this.gbLogin.Controls.Add(this.lblUsername);
            this.gbLogin.Controls.Add(this.lblPassword);
            this.gbLogin.Controls.Add(this.tbPassword);
            this.gbLogin.Controls.Add(this.tbUsername);
            this.gbLogin.Controls.Add(this.lblLoginInfo);
            this.gbLogin.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.gbLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.gbLogin.Location = new System.Drawing.Point(516, 12);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.Size = new System.Drawing.Size(446, 134);
            this.gbLogin.TabIndex = 3;
            this.gbLogin.TabStop = false;
            this.gbLogin.Text = "FurAffinity options";
            this.gbLogin.Visible = false;
            // 
            // cbLogInOnLaunch
            // 
            this.cbLogInOnLaunch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLogInOnLaunch.AutoSize = true;
            this.cbLogInOnLaunch.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLogInOnLaunch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.cbLogInOnLaunch.Location = new System.Drawing.Point(178, 60);
            this.cbLogInOnLaunch.Name = "cbLogInOnLaunch";
            this.cbLogInOnLaunch.Size = new System.Drawing.Size(105, 16);
            this.cbLogInOnLaunch.TabIndex = 40;
            this.cbLogInOnLaunch.Text = "Log in on launch";
            this.toolTip.SetToolTip(this.cbLogInOnLaunch, "Show your FurAffinity Password");
            this.cbLogInOnLaunch.UseVisualStyleBackColor = true;
            this.cbLogInOnLaunch.CheckedChanged += new System.EventHandler(this.cbLogInOnLaunch_CheckedChanged);
            // 
            // cbShowPassword
            // 
            this.cbShowPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbShowPassword.AutoSize = true;
            this.cbShowPassword.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbShowPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.cbShowPassword.Location = new System.Drawing.Point(178, 84);
            this.cbShowPassword.Name = "cbShowPassword";
            this.cbShowPassword.Size = new System.Drawing.Size(100, 16);
            this.cbShowPassword.TabIndex = 18;
            this.cbShowPassword.Text = "Show password";
            this.toolTip.SetToolTip(this.cbShowPassword, "Show your FurAffinity Password");
            this.cbShowPassword.UseVisualStyleBackColor = true;
            this.cbShowPassword.CheckedChanged += new System.EventHandler(this.cbShowPassword_CheckedChanged);
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.Black;
            this.btnLogin.Location = new System.Drawing.Point(72, 105);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(100, 23);
            this.btnLogin.TabIndex = 10;
            this.btnLogin.Text = "Log in";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.lblUsername.Location = new System.Drawing.Point(6, 60);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(60, 12);
            this.lblUsername.TabIndex = 6;
            this.lblUsername.Text = "Username:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.lblPassword.Location = new System.Drawing.Point(9, 82);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(57, 12);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Text = "Password:";
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.Location = new System.Drawing.Point(72, 81);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(100, 18);
            this.tbPassword.TabIndex = 8;
            this.toolTip.SetToolTip(this.tbPassword, "Enter your FurAffinity Password");
            this.tbPassword.TextChanged += new System.EventHandler(this.tbPassword_TextChanged);
            this.tbPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPassword_KeyPress);
            // 
            // tbUsername
            // 
            this.tbUsername.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUsername.Location = new System.Drawing.Point(72, 57);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(100, 18);
            this.tbUsername.TabIndex = 5;
            this.toolTip.SetToolTip(this.tbUsername, "Enter your FurAffinity Username");
            this.tbUsername.TextChanged += new System.EventHandler(this.tbUsername_TextChanged);
            this.tbUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbUsername_KeyPress);
            // 
            // lblLoginInfo
            // 
            this.lblLoginInfo.AutoSize = true;
            this.lblLoginInfo.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.lblLoginInfo.Location = new System.Drawing.Point(8, 16);
            this.lblLoginInfo.Name = "lblLoginInfo";
            this.lblLoginInfo.Size = new System.Drawing.Size(231, 24);
            this.lblLoginInfo.TabIndex = 4;
            this.lblLoginInfo.Text = "In order for you to download mature and adult\r\nsubmissions, you must log into Fur" +
    "Affinity.";
            // 
            // cbAllFARatings
            // 
            this.cbAllFARatings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAllFARatings.AutoSize = true;
            this.cbAllFARatings.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAllFARatings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.cbAllFARatings.Location = new System.Drawing.Point(333, 32);
            this.cbAllFARatings.Name = "cbAllFARatings";
            this.cbAllFARatings.Size = new System.Drawing.Size(38, 16);
            this.cbAllFARatings.TabIndex = 17;
            this.cbAllFARatings.Text = "All";
            this.toolTip.SetToolTip(this.cbAllFARatings, "Toggle all ratings");
            this.cbAllFARatings.UseVisualStyleBackColor = true;
            this.cbAllFARatings.CheckedChanged += new System.EventHandler(this.cbAllFARatings_CheckedChanged);
            // 
            // lblRatings
            // 
            this.lblRatings.AutoSize = true;
            this.lblRatings.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRatings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.lblRatings.Location = new System.Drawing.Point(331, 17);
            this.lblRatings.Name = "lblRatings";
            this.lblRatings.Size = new System.Drawing.Size(109, 12);
            this.lblRatings.TabIndex = 14;
            this.lblRatings.Text = "Ratings to download:";
            // 
            // cbAdult
            // 
            this.cbAdult.AutoSize = true;
            this.cbAdult.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAdult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.cbAdult.Location = new System.Drawing.Point(333, 98);
            this.cbAdult.Name = "cbAdult";
            this.cbAdult.Size = new System.Drawing.Size(51, 16);
            this.cbAdult.TabIndex = 13;
            this.cbAdult.Text = "Adult";
            this.toolTip.SetToolTip(this.cbAdult, "Download submissions rated adult");
            this.cbAdult.UseVisualStyleBackColor = true;
            this.cbAdult.CheckedChanged += new System.EventHandler(this.cbAdult_CheckedChanged);
            // 
            // lblLoginStatus
            // 
            this.lblLoginStatus.AutoSize = true;
            this.lblLoginStatus.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.lblLoginStatus.Location = new System.Drawing.Point(173, 110);
            this.lblLoginStatus.Name = "lblLoginStatus";
            this.lblLoginStatus.Size = new System.Drawing.Size(67, 12);
            this.lblLoginStatus.TabIndex = 9;
            this.lblLoginStatus.Text = "Login status";
            // 
            // cbMature
            // 
            this.cbMature.AutoSize = true;
            this.cbMature.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMature.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.cbMature.Location = new System.Drawing.Point(333, 76);
            this.cbMature.Name = "cbMature";
            this.cbMature.Size = new System.Drawing.Size(59, 16);
            this.cbMature.TabIndex = 12;
            this.cbMature.Text = "Mature";
            this.toolTip.SetToolTip(this.cbMature, "Download submissions rated mature");
            this.cbMature.UseVisualStyleBackColor = true;
            this.cbMature.CheckedChanged += new System.EventHandler(this.cbMature_CheckedChanged);
            // 
            // cbGeneral
            // 
            this.cbGeneral.AutoSize = true;
            this.cbGeneral.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGeneral.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.cbGeneral.Location = new System.Drawing.Point(333, 54);
            this.cbGeneral.Name = "cbGeneral";
            this.cbGeneral.Size = new System.Drawing.Size(63, 16);
            this.cbGeneral.TabIndex = 11;
            this.cbGeneral.Text = "General";
            this.toolTip.SetToolTip(this.cbGeneral, "Download submissions rated general");
            this.cbGeneral.UseVisualStyleBackColor = true;
            this.cbGeneral.CheckedChanged += new System.EventHandler(this.cbGeneral_CheckedChanged);
            // 
            // gbFAConnectionStatus
            // 
            this.gbFAConnectionStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFAConnectionStatus.Controls.Add(this.btnAttemptReconnection);
            this.gbFAConnectionStatus.Controls.Add(this.lblFAConnectionStatus);
            this.gbFAConnectionStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFAConnectionStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.gbFAConnectionStatus.Location = new System.Drawing.Point(516, 12);
            this.gbFAConnectionStatus.Name = "gbFAConnectionStatus";
            this.gbFAConnectionStatus.Size = new System.Drawing.Size(446, 134);
            this.gbFAConnectionStatus.TabIndex = 41;
            this.gbFAConnectionStatus.TabStop = false;
            this.gbFAConnectionStatus.Text = "FurAffinity connection status";
            // 
            // btnAttemptReconnection
            // 
            this.btnAttemptReconnection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAttemptReconnection.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttemptReconnection.ForeColor = System.Drawing.Color.Black;
            this.btnAttemptReconnection.Location = new System.Drawing.Point(162, 61);
            this.btnAttemptReconnection.Name = "btnAttemptReconnection";
            this.btnAttemptReconnection.Size = new System.Drawing.Size(121, 32);
            this.btnAttemptReconnection.TabIndex = 38;
            this.btnAttemptReconnection.Text = "Attempt Reconnection";
            this.btnAttemptReconnection.UseVisualStyleBackColor = true;
            this.btnAttemptReconnection.Click += new System.EventHandler(this.btnAttemptReconnection_Click);
            // 
            // lblFAConnectionStatus
            // 
            this.lblFAConnectionStatus.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFAConnectionStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.lblFAConnectionStatus.Location = new System.Drawing.Point(6, 18);
            this.lblFAConnectionStatus.Name = "lblFAConnectionStatus";
            this.lblFAConnectionStatus.Size = new System.Drawing.Size(434, 40);
            this.lblFAConnectionStatus.TabIndex = 39;
            this.lblFAConnectionStatus.Text = "lblFAConnectionStatus";
            this.lblFAConnectionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblArtistList
            // 
            this.lblArtistList.AutoSize = true;
            this.lblArtistList.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArtistList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.lblArtistList.Location = new System.Drawing.Point(6, 14);
            this.lblArtistList.Name = "lblArtistList";
            this.lblArtistList.Size = new System.Drawing.Size(144, 12);
            this.lblArtistList.TabIndex = 11;
            this.lblArtistList.Text = "Artist list to download from:";
            // 
            // cbGallery
            // 
            this.cbGallery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbGallery.AutoSize = true;
            this.cbGallery.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGallery.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.cbGallery.Location = new System.Drawing.Point(364, 244);
            this.cbGallery.Name = "cbGallery";
            this.cbGallery.Size = new System.Drawing.Size(60, 16);
            this.cbGallery.TabIndex = 12;
            this.cbGallery.Text = "Gallery";
            this.cbGallery.UseVisualStyleBackColor = true;
            // 
            // cbScraps
            // 
            this.cbScraps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbScraps.AutoSize = true;
            this.cbScraps.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbScraps.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.cbScraps.Location = new System.Drawing.Point(364, 266);
            this.cbScraps.Name = "cbScraps";
            this.cbScraps.Size = new System.Drawing.Size(59, 16);
            this.cbScraps.TabIndex = 13;
            this.cbScraps.Text = "Scraps";
            this.cbScraps.UseVisualStyleBackColor = true;
            // 
            // cbFavorites
            // 
            this.cbFavorites.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFavorites.AutoSize = true;
            this.cbFavorites.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFavorites.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.cbFavorites.Location = new System.Drawing.Point(364, 288);
            this.cbFavorites.Name = "cbFavorites";
            this.cbFavorites.Size = new System.Drawing.Size(71, 16);
            this.cbFavorites.TabIndex = 14;
            this.cbFavorites.Text = "Favorites";
            this.cbFavorites.UseVisualStyleBackColor = true;
            // 
            // cbJournals
            // 
            this.cbJournals.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbJournals.AutoSize = true;
            this.cbJournals.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbJournals.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.cbJournals.Location = new System.Drawing.Point(364, 310);
            this.cbJournals.Name = "cbJournals";
            this.cbJournals.Size = new System.Drawing.Size(66, 16);
            this.cbJournals.TabIndex = 15;
            this.cbJournals.Text = "Journals";
            this.cbJournals.UseVisualStyleBackColor = true;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectAll.ForeColor = System.Drawing.Color.Black;
            this.btnSelectAll.Location = new System.Drawing.Point(256, 19);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAll.TabIndex = 21;
            this.btnSelectAll.Text = "Select all";
            this.toolTip.SetToolTip(this.btnSelectAll, "Select all artists in artist list");
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnSelectNone
            // 
            this.btnSelectNone.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectNone.ForeColor = System.Drawing.Color.Black;
            this.btnSelectNone.Location = new System.Drawing.Point(175, 19);
            this.btnSelectNone.Name = "btnSelectNone";
            this.btnSelectNone.Size = new System.Drawing.Size(75, 23);
            this.btnSelectNone.TabIndex = 22;
            this.btnSelectNone.Text = "Select none";
            this.toolTip.SetToolTip(this.btnSelectNone, "Deselect all artists in artist list");
            this.btnSelectNone.UseVisualStyleBackColor = true;
            this.btnSelectNone.Click += new System.EventHandler(this.btnSelectNone_Click);
            // 
            // gbArtistSettings
            // 
            this.gbArtistSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbArtistSettings.Controls.Add(this.cbStatusAutoUpdate);
            this.gbArtistSettings.Controls.Add(this.lblArtistCount);
            this.gbArtistSettings.Controls.Add(this.btnGetArtistStatuses);
            this.gbArtistSettings.Controls.Add(this.lblArtistGalleryTypes);
            this.gbArtistSettings.Controls.Add(this.cbAllGalleryTypes);
            this.gbArtistSettings.Controls.Add(this.dgvArtistList);
            this.gbArtistSettings.Controls.Add(this.btnArtistApplyDownloads);
            this.gbArtistSettings.Controls.Add(this.btnImportWatchList);
            this.gbArtistSettings.Controls.Add(this.btnRemoveArtists);
            this.gbArtistSettings.Controls.Add(this.lblArtistList);
            this.gbArtistSettings.Controls.Add(this.btnSelectNone);
            this.gbArtistSettings.Controls.Add(this.cbGallery);
            this.gbArtistSettings.Controls.Add(this.btnSelectAll);
            this.gbArtistSettings.Controls.Add(this.cbScraps);
            this.gbArtistSettings.Controls.Add(this.cbFavorites);
            this.gbArtistSettings.Controls.Add(this.cbJournals);
            this.gbArtistSettings.Controls.Add(this.lblBigStatus);
            this.gbArtistSettings.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbArtistSettings.ForeColor = System.Drawing.Color.White;
            this.gbArtistSettings.Location = new System.Drawing.Point(12, 12);
            this.gbArtistSettings.Name = "gbArtistSettings";
            this.gbArtistSettings.Size = new System.Drawing.Size(498, 361);
            this.gbArtistSettings.TabIndex = 24;
            this.gbArtistSettings.TabStop = false;
            this.gbArtistSettings.Text = "Artist settings";
            // 
            // cbStatusAutoUpdate
            // 
            this.cbStatusAutoUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbStatusAutoUpdate.AutoSize = true;
            this.cbStatusAutoUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.cbStatusAutoUpdate.Location = new System.Drawing.Point(366, 149);
            this.cbStatusAutoUpdate.Name = "cbStatusAutoUpdate";
            this.cbStatusAutoUpdate.Size = new System.Drawing.Size(121, 16);
            this.cbStatusAutoUpdate.TabIndex = 41;
            this.cbStatusAutoUpdate.Text = "Status auto-update";
            this.toolTip.SetToolTip(this.cbStatusAutoUpdate, "Artist statuses will auto-update.\r\nMay be slow with larger lists.");
            this.cbStatusAutoUpdate.UseVisualStyleBackColor = true;
            this.cbStatusAutoUpdate.CheckedChanged += new System.EventHandler(this.cbStatusAutoUpdate_CheckedChanged);
            // 
            // lblArtistCount
            // 
            this.lblArtistCount.AutoSize = true;
            this.lblArtistCount.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArtistCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.lblArtistCount.Location = new System.Drawing.Point(6, 26);
            this.lblArtistCount.Name = "lblArtistCount";
            this.lblArtistCount.Size = new System.Drawing.Size(59, 12);
            this.lblArtistCount.TabIndex = 40;
            this.lblArtistCount.Text = "#### total";
            // 
            // btnGetArtistStatuses
            // 
            this.btnGetArtistStatuses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetArtistStatuses.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetArtistStatuses.ForeColor = System.Drawing.Color.Black;
            this.btnGetArtistStatuses.Location = new System.Drawing.Point(364, 120);
            this.btnGetArtistStatuses.Name = "btnGetArtistStatuses";
            this.btnGetArtistStatuses.Size = new System.Drawing.Size(128, 23);
            this.btnGetArtistStatuses.TabIndex = 38;
            this.btnGetArtistStatuses.Text = "Get Artist Statuses";
            this.btnGetArtistStatuses.UseVisualStyleBackColor = true;
            this.btnGetArtistStatuses.Click += new System.EventHandler(this.btnGetArtistStatuses_Click);
            // 
            // lblArtistGalleryTypes
            // 
            this.lblArtistGalleryTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblArtistGalleryTypes.AutoSize = true;
            this.lblArtistGalleryTypes.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArtistGalleryTypes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.lblArtistGalleryTypes.Location = new System.Drawing.Point(364, 207);
            this.lblArtistGalleryTypes.Name = "lblArtistGalleryTypes";
            this.lblArtistGalleryTypes.Size = new System.Drawing.Size(98, 12);
            this.lblArtistGalleryTypes.TabIndex = 36;
            this.lblArtistGalleryTypes.Text = "Submission types:";
            // 
            // cbAllGalleryTypes
            // 
            this.cbAllGalleryTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAllGalleryTypes.AutoSize = true;
            this.cbAllGalleryTypes.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAllGalleryTypes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.cbAllGalleryTypes.Location = new System.Drawing.Point(364, 222);
            this.cbAllGalleryTypes.Name = "cbAllGalleryTypes";
            this.cbAllGalleryTypes.Size = new System.Drawing.Size(38, 16);
            this.cbAllGalleryTypes.TabIndex = 35;
            this.cbAllGalleryTypes.Text = "All";
            this.toolTip.SetToolTip(this.cbAllGalleryTypes, "Toggle all submission types");
            this.cbAllGalleryTypes.UseVisualStyleBackColor = true;
            this.cbAllGalleryTypes.CheckedChanged += new System.EventHandler(this.cbAllGalleryTypes_CheckedChanged);
            // 
            // dgvArtistList
            // 
            this.dgvArtistList.AllowUserToAddRows = false;
            this.dgvArtistList.AllowUserToResizeColumns = false;
            this.dgvArtistList.AllowUserToResizeRows = false;
            this.dgvArtistList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvArtistList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvArtistList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(114)))), ((int)(((byte)(131)))));
            this.dgvArtistList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvArtistList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArtistList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.artistAvailable,
            this.artistName,
            this.artistDownloadGallery,
            this.artistDownloadScraps,
            this.artistDownloadFavorites,
            this.artistDownloadJournals});
            this.dgvArtistList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(114)))), ((int)(((byte)(131)))));
            this.dgvArtistList.Location = new System.Drawing.Point(9, 48);
            this.dgvArtistList.Name = "dgvArtistList";
            this.dgvArtistList.RowHeadersVisible = false;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.dgvArtistList.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvArtistList.Size = new System.Drawing.Size(349, 306);
            this.dgvArtistList.TabIndex = 34;
            this.dgvArtistList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArtistList_CellEndEdit);
            this.dgvArtistList.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvArtistList_EditingControlShowing);
            this.dgvArtistList.SelectionChanged += new System.EventHandler(this.dgvArtistList_SelectionChanged);
            this.dgvArtistList.Sorted += new System.EventHandler(this.dgvArtistList_Sorted);
            this.dgvArtistList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvArtistList_KeyDown);
            this.dgvArtistList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvArtistList_MouseClick);
            // 
            // artistAvailable
            // 
            this.artistAvailable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.artistAvailable.Frozen = true;
            this.artistAvailable.HeaderText = "";
            this.artistAvailable.MinimumWidth = 25;
            this.artistAvailable.Name = "artistAvailable";
            this.artistAvailable.ReadOnly = true;
            this.artistAvailable.Width = 25;
            // 
            // artistName
            // 
            this.artistName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.artistName.FillWeight = 70.25548F;
            this.artistName.HeaderText = "Artist";
            this.artistName.MinimumWidth = 75;
            this.artistName.Name = "artistName";
            // 
            // artistDownloadGallery
            // 
            this.artistDownloadGallery.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.artistDownloadGallery.FillWeight = 218.9781F;
            this.artistDownloadGallery.HeaderText = "Gallery";
            this.artistDownloadGallery.MinimumWidth = 50;
            this.artistDownloadGallery.Name = "artistDownloadGallery";
            this.artistDownloadGallery.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.artistDownloadGallery.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.artistDownloadGallery.Width = 66;
            // 
            // artistDownloadScraps
            // 
            this.artistDownloadScraps.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.artistDownloadScraps.FillWeight = 70.25548F;
            this.artistDownloadScraps.HeaderText = "Scraps";
            this.artistDownloadScraps.MinimumWidth = 50;
            this.artistDownloadScraps.Name = "artistDownloadScraps";
            this.artistDownloadScraps.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.artistDownloadScraps.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.artistDownloadScraps.Width = 65;
            // 
            // artistDownloadFavorites
            // 
            this.artistDownloadFavorites.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.artistDownloadFavorites.FillWeight = 70.25548F;
            this.artistDownloadFavorites.HeaderText = "Favorites";
            this.artistDownloadFavorites.MinimumWidth = 50;
            this.artistDownloadFavorites.Name = "artistDownloadFavorites";
            this.artistDownloadFavorites.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.artistDownloadFavorites.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.artistDownloadFavorites.Width = 77;
            // 
            // artistDownloadJournals
            // 
            this.artistDownloadJournals.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.artistDownloadJournals.FillWeight = 70.25548F;
            this.artistDownloadJournals.HeaderText = "Journals";
            this.artistDownloadJournals.MinimumWidth = 50;
            this.artistDownloadJournals.Name = "artistDownloadJournals";
            this.artistDownloadJournals.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.artistDownloadJournals.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.artistDownloadJournals.Width = 72;
            // 
            // btnArtistApplyDownloads
            // 
            this.btnArtistApplyDownloads.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnArtistApplyDownloads.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArtistApplyDownloads.ForeColor = System.Drawing.Color.Black;
            this.btnArtistApplyDownloads.Location = new System.Drawing.Point(364, 332);
            this.btnArtistApplyDownloads.Name = "btnArtistApplyDownloads";
            this.btnArtistApplyDownloads.Size = new System.Drawing.Size(128, 23);
            this.btnArtistApplyDownloads.TabIndex = 30;
            this.btnArtistApplyDownloads.Text = "Apply to selected";
            this.toolTip.SetToolTip(this.btnArtistApplyDownloads, "Apply checked submission types to selected artists in Artist List");
            this.btnArtistApplyDownloads.UseVisualStyleBackColor = true;
            this.btnArtistApplyDownloads.Click += new System.EventHandler(this.btnArtistApplyDownloads_Click);
            // 
            // btnImportWatchList
            // 
            this.btnImportWatchList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportWatchList.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportWatchList.ForeColor = System.Drawing.Color.Black;
            this.btnImportWatchList.Location = new System.Drawing.Point(364, 80);
            this.btnImportWatchList.Name = "btnImportWatchList";
            this.btnImportWatchList.Size = new System.Drawing.Size(128, 34);
            this.btnImportWatchList.TabIndex = 27;
            this.btnImportWatchList.Text = "Import all artists from your watch list";
            this.toolTip.SetToolTip(this.btnImportWatchList, "Import your FA watch list into the artist list");
            this.btnImportWatchList.UseVisualStyleBackColor = true;
            this.btnImportWatchList.Click += new System.EventHandler(this.btnImportWatchList_Click);
            // 
            // btnRemoveArtists
            // 
            this.btnRemoveArtists.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveArtists.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveArtists.ForeColor = System.Drawing.Color.Black;
            this.btnRemoveArtists.Location = new System.Drawing.Point(364, 51);
            this.btnRemoveArtists.Name = "btnRemoveArtists";
            this.btnRemoveArtists.Size = new System.Drawing.Size(128, 23);
            this.btnRemoveArtists.TabIndex = 25;
            this.btnRemoveArtists.Text = "Remove selected artists";
            this.toolTip.SetToolTip(this.btnRemoveArtists, "Remove currently selected artist from artist list");
            this.btnRemoveArtists.UseVisualStyleBackColor = true;
            this.btnRemoveArtists.Click += new System.EventHandler(this.btnRemoveArtists_Click);
            // 
            // lblBigStatus
            // 
            this.lblBigStatus.Font = new System.Drawing.Font("Verdana", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBigStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.lblBigStatus.Location = new System.Drawing.Point(9, 48);
            this.lblBigStatus.Name = "lblBigStatus";
            this.lblBigStatus.Size = new System.Drawing.Size(349, 306);
            this.lblBigStatus.TabIndex = 42;
            this.lblBigStatus.Text = "Big status";
            this.lblBigStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbLoginCookies
            // 
            this.gbLoginCookies.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbLoginCookies.Controls.Add(this.btn_CookieTut);
            this.gbLoginCookies.Controls.Add(this.btnVerifyCookies);
            this.gbLoginCookies.Controls.Add(this.lblLoginStatus);
            this.gbLoginCookies.Controls.Add(this.cbAllFARatings);
            this.gbLoginCookies.Controls.Add(this.lblRatings);
            this.gbLoginCookies.Controls.Add(this.cbGeneral);
            this.gbLoginCookies.Controls.Add(this.lblCookieA);
            this.gbLoginCookies.Controls.Add(this.cbAdult);
            this.gbLoginCookies.Controls.Add(this.lblCookieB);
            this.gbLoginCookies.Controls.Add(this.cbMature);
            this.gbLoginCookies.Controls.Add(this.tbCookieB);
            this.gbLoginCookies.Controls.Add(this.tbCookieA);
            this.gbLoginCookies.Controls.Add(this.label3);
            this.gbLoginCookies.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.gbLoginCookies.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.gbLoginCookies.Location = new System.Drawing.Point(516, 12);
            this.gbLoginCookies.Name = "gbLoginCookies";
            this.gbLoginCookies.Size = new System.Drawing.Size(446, 134);
            this.gbLoginCookies.TabIndex = 41;
            this.gbLoginCookies.TabStop = false;
            this.gbLoginCookies.Text = "FurAffinity options";
            // 
            // btn_CookieTut
            // 
            this.btn_CookieTut.Font = new System.Drawing.Font("Verdana", 6.75F);
            this.btn_CookieTut.ForeColor = System.Drawing.Color.Black;
            this.btn_CookieTut.Location = new System.Drawing.Point(225, 57);
            this.btn_CookieTut.Name = "btn_CookieTut";
            this.btn_CookieTut.Size = new System.Drawing.Size(102, 43);
            this.btn_CookieTut.TabIndex = 41;
            this.btn_CookieTut.Text = "How do I find my\r\nlogin cookies?";
            this.btn_CookieTut.UseVisualStyleBackColor = true;
            this.btn_CookieTut.Click += new System.EventHandler(this.btn_CookieTut_Click);
            // 
            // btnVerifyCookies
            // 
            this.btnVerifyCookies.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerifyCookies.ForeColor = System.Drawing.Color.Black;
            this.btnVerifyCookies.Location = new System.Drawing.Point(67, 105);
            this.btnVerifyCookies.Name = "btnVerifyCookies";
            this.btnVerifyCookies.Size = new System.Drawing.Size(100, 23);
            this.btnVerifyCookies.TabIndex = 10;
            this.btnVerifyCookies.Text = "Verifiy Cookies";
            this.btnVerifyCookies.UseVisualStyleBackColor = true;
            this.btnVerifyCookies.Click += new System.EventHandler(this.btnVerifyCookies_Click);
            // 
            // lblCookieA
            // 
            this.lblCookieA.AutoSize = true;
            this.lblCookieA.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCookieA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.lblCookieA.Location = new System.Drawing.Point(6, 60);
            this.lblCookieA.Name = "lblCookieA";
            this.lblCookieA.Size = new System.Drawing.Size(55, 12);
            this.lblCookieA.TabIndex = 6;
            this.lblCookieA.Text = "Cookie A:";
            // 
            // lblCookieB
            // 
            this.lblCookieB.AutoSize = true;
            this.lblCookieB.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCookieB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.lblCookieB.Location = new System.Drawing.Point(6, 81);
            this.lblCookieB.Name = "lblCookieB";
            this.lblCookieB.Size = new System.Drawing.Size(54, 12);
            this.lblCookieB.TabIndex = 7;
            this.lblCookieB.Text = "Cookie B:";
            // 
            // tbCookieB
            // 
            this.tbCookieB.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCookieB.Location = new System.Drawing.Point(67, 82);
            this.tbCookieB.Name = "tbCookieB";
            this.tbCookieB.Size = new System.Drawing.Size(155, 18);
            this.tbCookieB.TabIndex = 8;
            this.toolTip.SetToolTip(this.tbCookieB, "Enter your FurAffinity Password");
            // 
            // tbCookieA
            // 
            this.tbCookieA.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCookieA.Location = new System.Drawing.Point(67, 57);
            this.tbCookieA.Name = "tbCookieA";
            this.tbCookieA.Size = new System.Drawing.Size(155, 18);
            this.tbCookieA.TabIndex = 5;
            this.toolTip.SetToolTip(this.tbCookieA, "Enter your FurAffinity Username");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.label3.Location = new System.Drawing.Point(8, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(300, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "In order for you to download mature and adult submissions,\r\nyou must set your Fur" +
    "Affinity login cookies.";
            // 
            // lblLoggingLevel
            // 
            this.lblLoggingLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLoggingLevel.AutoSize = true;
            this.lblLoggingLevel.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoggingLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.lblLoggingLevel.Location = new System.Drawing.Point(415, 19);
            this.lblLoggingLevel.Name = "lblLoggingLevel";
            this.lblLoggingLevel.Size = new System.Drawing.Size(75, 12);
            this.lblLoggingLevel.TabIndex = 26;
            this.lblLoggingLevel.Text = "Logging level:";
            // 
            // cbDownloads
            // 
            this.cbDownloads.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDownloads.AutoSize = true;
            this.cbDownloads.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDownloads.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.cbDownloads.Location = new System.Drawing.Point(415, 57);
            this.cbDownloads.Name = "cbDownloads";
            this.cbDownloads.Size = new System.Drawing.Size(78, 16);
            this.cbDownloads.TabIndex = 27;
            this.cbDownloads.Text = "Downloads";
            this.toolTip.SetToolTip(this.cbDownloads, "Toggle download logging");
            this.cbDownloads.UseVisualStyleBackColor = true;
            this.cbDownloads.CheckedChanged += new System.EventHandler(this.cbDownloads_CheckedChanged);
            // 
            // cbErrors
            // 
            this.cbErrors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbErrors.AutoSize = true;
            this.cbErrors.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbErrors.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.cbErrors.Location = new System.Drawing.Point(415, 79);
            this.cbErrors.Name = "cbErrors";
            this.cbErrors.Size = new System.Drawing.Size(55, 16);
            this.cbErrors.TabIndex = 28;
            this.cbErrors.Text = "Errors";
            this.toolTip.SetToolTip(this.cbErrors, "Toggle error logging");
            this.cbErrors.UseVisualStyleBackColor = true;
            this.cbErrors.CheckedChanged += new System.EventHandler(this.cbErrors_CheckedChanged);
            // 
            // cbStatus
            // 
            this.cbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbStatus.AutoSize = true;
            this.cbStatus.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.cbStatus.Location = new System.Drawing.Point(415, 101);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(57, 16);
            this.cbStatus.TabIndex = 29;
            this.cbStatus.Text = "Status";
            this.toolTip.SetToolTip(this.cbStatus, "Toggle status logging");
            this.cbStatus.UseVisualStyleBackColor = true;
            this.cbStatus.CheckedChanged += new System.EventHandler(this.cbStatus_CheckedChanged);
            // 
            // gbOutput
            // 
            this.gbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOutput.Controls.Add(this.lblDownloadingFile);
            this.gbOutput.Controls.Add(this.lblDiggingArtist);
            this.gbOutput.Controls.Add(this.lbDownloadProgress);
            this.gbOutput.Controls.Add(this.lbParseProgress);
            this.gbOutput.Controls.Add(this.cbAllLoggingLevels);
            this.gbOutput.Controls.Add(this.cbDebug);
            this.gbOutput.Controls.Add(this.btnClearOutput);
            this.gbOutput.Controls.Add(this.lblStatus);
            this.gbOutput.Controls.Add(this.btnCopyOutputToClipboard);
            this.gbOutput.Controls.Add(this.cbStatus);
            this.gbOutput.Controls.Add(this.cbErrors);
            this.gbOutput.Controls.Add(this.lblLoggingLevel);
            this.gbOutput.Controls.Add(this.cbDownloads);
            this.gbOutput.Controls.Add(this.lbOutput);
            this.gbOutput.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbOutput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.gbOutput.Location = new System.Drawing.Point(12, 379);
            this.gbOutput.Name = "gbOutput";
            this.gbOutput.Size = new System.Drawing.Size(498, 285);
            this.gbOutput.TabIndex = 30;
            this.gbOutput.TabStop = false;
            this.gbOutput.Text = "Output log";
            // 
            // lblDownloadingFile
            // 
            this.lblDownloadingFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDownloadingFile.AutoSize = true;
            this.lblDownloadingFile.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDownloadingFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.lblDownloadingFile.Location = new System.Drawing.Point(237, 269);
            this.lblDownloadingFile.Name = "lblDownloadingFile";
            this.lblDownloadingFile.Size = new System.Drawing.Size(90, 12);
            this.lblDownloadingFile.TabIndex = 40;
            this.lblDownloadingFile.Text = "Downloading file:";
            // 
            // lblDiggingArtist
            // 
            this.lblDiggingArtist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiggingArtist.AutoSize = true;
            this.lblDiggingArtist.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiggingArtist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.lblDiggingArtist.Location = new System.Drawing.Point(237, 257);
            this.lblDiggingArtist.Name = "lblDiggingArtist";
            this.lblDiggingArtist.Size = new System.Drawing.Size(77, 12);
            this.lblDiggingArtist.TabIndex = 39;
            this.lblDiggingArtist.Text = "Digging artist:";
            // 
            // lbDownloadProgress
            // 
            this.lbDownloadProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDownloadProgress.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDownloadProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.lbDownloadProgress.Location = new System.Drawing.Point(333, 269);
            this.lbDownloadProgress.Name = "lbDownloadProgress";
            this.lbDownloadProgress.Size = new System.Drawing.Size(76, 12);
            this.lbDownloadProgress.TabIndex = 38;
            this.lbDownloadProgress.Text = "#### of ####";
            this.lbDownloadProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbParseProgress
            // 
            this.lbParseProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbParseProgress.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbParseProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.lbParseProgress.Location = new System.Drawing.Point(333, 257);
            this.lbParseProgress.Name = "lbParseProgress";
            this.lbParseProgress.Size = new System.Drawing.Size(76, 12);
            this.lbParseProgress.TabIndex = 37;
            this.lbParseProgress.Text = "#### of ####";
            this.lbParseProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbAllLoggingLevels
            // 
            this.cbAllLoggingLevels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAllLoggingLevels.AutoSize = true;
            this.cbAllLoggingLevels.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAllLoggingLevels.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.cbAllLoggingLevels.Location = new System.Drawing.Point(415, 35);
            this.cbAllLoggingLevels.Name = "cbAllLoggingLevels";
            this.cbAllLoggingLevels.Size = new System.Drawing.Size(38, 16);
            this.cbAllLoggingLevels.TabIndex = 36;
            this.cbAllLoggingLevels.Text = "All";
            this.toolTip.SetToolTip(this.cbAllLoggingLevels, "Toggle all logging levels\r\n\r\n!!! CAUTION !!!\r\nDebug logging may cause crashes.");
            this.cbAllLoggingLevels.UseVisualStyleBackColor = true;
            this.cbAllLoggingLevels.CheckedChanged += new System.EventHandler(this.cbAllLoggingLevels_CheckedChanged);
            // 
            // cbDebug
            // 
            this.cbDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDebug.AutoSize = true;
            this.cbDebug.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDebug.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.cbDebug.Location = new System.Drawing.Point(415, 123);
            this.cbDebug.Name = "cbDebug";
            this.cbDebug.Size = new System.Drawing.Size(62, 16);
            this.cbDebug.TabIndex = 35;
            this.cbDebug.Text = "DEBUG";
            this.toolTip.SetToolTip(this.cbDebug, "Toggle debug logging\r\n\r\n!! CAUTION !!\r\nMay help narrow down issues.\r\nIronically, " +
        "may also cause crashes.");
            this.cbDebug.UseVisualStyleBackColor = true;
            this.cbDebug.CheckedChanged += new System.EventHandler(this.cbDebug_CheckedChanged);
            // 
            // btnClearOutput
            // 
            this.btnClearOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearOutput.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearOutput.ForeColor = System.Drawing.Color.Black;
            this.btnClearOutput.Location = new System.Drawing.Point(415, 191);
            this.btnClearOutput.Name = "btnClearOutput";
            this.btnClearOutput.Size = new System.Drawing.Size(77, 23);
            this.btnClearOutput.TabIndex = 34;
            this.btnClearOutput.Text = "Clear output";
            this.btnClearOutput.UseVisualStyleBackColor = true;
            this.btnClearOutput.Click += new System.EventHandler(this.btnClearOutput_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.lblStatus.Location = new System.Drawing.Point(7, 259);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(38, 12);
            this.lblStatus.TabIndex = 32;
            this.lblStatus.Text = "Status";
            // 
            // btnCopyOutputToClipboard
            // 
            this.btnCopyOutputToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyOutputToClipboard.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyOutputToClipboard.ForeColor = System.Drawing.Color.Black;
            this.btnCopyOutputToClipboard.Location = new System.Drawing.Point(415, 220);
            this.btnCopyOutputToClipboard.Name = "btnCopyOutputToClipboard";
            this.btnCopyOutputToClipboard.Size = new System.Drawing.Size(77, 34);
            this.btnCopyOutputToClipboard.TabIndex = 31;
            this.btnCopyOutputToClipboard.Text = "Copy log to clipboard";
            this.btnCopyOutputToClipboard.UseVisualStyleBackColor = true;
            this.btnCopyOutputToClipboard.Click += new System.EventHandler(this.btnCopyOutputToClipboard_Click);
            // 
            // gbImagePreview
            // 
            this.gbImagePreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gbImagePreview.Controls.Add(this.pbPreview);
            this.gbImagePreview.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbImagePreview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.gbImagePreview.Location = new System.Drawing.Point(749, 379);
            this.gbImagePreview.Name = "gbImagePreview";
            this.gbImagePreview.Size = new System.Drawing.Size(213, 223);
            this.gbImagePreview.TabIndex = 31;
            this.gbImagePreview.TabStop = false;
            this.gbImagePreview.Text = "Image preview";
            // 
            // pbPreview
            // 
            this.pbPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPreview.ImageLocation = "test";
            this.pbPreview.Location = new System.Drawing.Point(6, 16);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(201, 201);
            this.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPreview.TabIndex = 0;
            this.pbPreview.TabStop = false;
            this.pbPreview.Click += new System.EventHandler(this.pbPreview_Click);
            this.pbPreview.MouseEnter += new System.EventHandler(this.pbPreview_MouseEnter);
            // 
            // gbInfo
            // 
            this.gbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbInfo.Controls.Add(this.lblLiveInfo);
            this.gbInfo.Controls.Add(this.lblVersion);
            this.gbInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.gbInfo.Location = new System.Drawing.Point(815, 152);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(147, 221);
            this.gbInfo.TabIndex = 32;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Info";
            // 
            // lblLiveInfo
            // 
            this.lblLiveInfo.AutoSize = true;
            this.lblLiveInfo.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLiveInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.lblLiveInfo.Location = new System.Drawing.Point(6, 49);
            this.lblLiveInfo.Name = "lblLiveInfo";
            this.lblLiveInfo.Size = new System.Drawing.Size(46, 12);
            this.lblLiveInfo.TabIndex = 3;
            this.lblLiveInfo.Text = "LiveInfo";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.lblVersion.Location = new System.Drawing.Point(6, 16);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(95, 24);
            this.lblVersion.TabIndex = 0;
            this.lblVersion.Text = "Version:\r\nbeta alpha delta 1";
            // 
            // nudHTMLDelay
            // 
            this.nudHTMLDelay.DecimalPlaces = 2;
            this.nudHTMLDelay.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudHTMLDelay.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.nudHTMLDelay.Location = new System.Drawing.Point(6, 33);
            this.nudHTMLDelay.Name = "nudHTMLDelay";
            this.nudHTMLDelay.Size = new System.Drawing.Size(215, 18);
            this.nudHTMLDelay.TabIndex = 11;
            this.toolTip.SetToolTip(this.nudHTMLDelay, "Delay between HTML requests. Use this if you don\'t want to bog down FA");
            this.nudHTMLDelay.ValueChanged += new System.EventHandler(this.nudHTMLDelay_ValueChanged);
            // 
            // nudDownloadDelay
            // 
            this.nudDownloadDelay.DecimalPlaces = 2;
            this.nudDownloadDelay.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDownloadDelay.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.nudDownloadDelay.Location = new System.Drawing.Point(6, 69);
            this.nudDownloadDelay.Name = "nudDownloadDelay";
            this.nudDownloadDelay.Size = new System.Drawing.Size(215, 18);
            this.nudDownloadDelay.TabIndex = 12;
            this.toolTip.SetToolTip(this.nudDownloadDelay, "Delay between downloads. Use this if you don\'t want to bog down FA");
            this.nudDownloadDelay.ValueChanged += new System.EventHandler(this.nudDownloadDelay_ValueChanged);
            // 
            // lblHTMLDelay
            // 
            this.lblHTMLDelay.AutoSize = true;
            this.lblHTMLDelay.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHTMLDelay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.lblHTMLDelay.Location = new System.Drawing.Point(6, 18);
            this.lblHTMLDelay.Name = "lblHTMLDelay";
            this.lblHTMLDelay.Size = new System.Drawing.Size(192, 12);
            this.lblHTMLDelay.TabIndex = 13;
            this.lblHTMLDelay.Text = "Delay between page loads (seconds):";
            // 
            // lblDownloadDelay
            // 
            this.lblDownloadDelay.AutoSize = true;
            this.lblDownloadDelay.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDownloadDelay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.lblDownloadDelay.Location = new System.Drawing.Point(6, 54);
            this.lblDownloadDelay.Name = "lblDownloadDelay";
            this.lblDownloadDelay.Size = new System.Drawing.Size(193, 12);
            this.lblDownloadDelay.TabIndex = 14;
            this.lblDownloadDelay.Text = "Delay between downloads  (seconds):";
            // 
            // btnDownload
            // 
            this.btnDownload.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownload.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnDownload.Location = new System.Drawing.Point(6, 245);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(215, 34);
            this.btnDownload.TabIndex = 33;
            this.btnDownload.Text = "DOWNLOAD";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            this.btnDownload.MouseEnter += new System.EventHandler(this.btnDownload_MouseEnter);
            this.btnDownload.MouseLeave += new System.EventHandler(this.btnDownload_MouseLeave);
            // 
            // cbOverwrite
            // 
            this.cbOverwrite.AutoSize = true;
            this.cbOverwrite.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOverwrite.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.cbOverwrite.Location = new System.Drawing.Point(6, 173);
            this.cbOverwrite.Name = "cbOverwrite";
            this.cbOverwrite.Size = new System.Drawing.Size(197, 16);
            this.cbOverwrite.TabIndex = 34;
            this.cbOverwrite.Text = "Overwrite local files (takes longer)";
            this.toolTip.SetToolTip(this.cbOverwrite, "Overwrite files if they already exist");
            this.cbOverwrite.UseVisualStyleBackColor = true;
            this.cbOverwrite.CheckedChanged += new System.EventHandler(this.cbOverwrite_CheckedChanged);
            // 
            // btnFolderSelect
            // 
            this.btnFolderSelect.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFolderSelect.ForeColor = System.Drawing.Color.Black;
            this.btnFolderSelect.Location = new System.Drawing.Point(153, 104);
            this.btnFolderSelect.Name = "btnFolderSelect";
            this.btnFolderSelect.Size = new System.Drawing.Size(22, 19);
            this.btnFolderSelect.TabIndex = 35;
            this.btnFolderSelect.Text = "...";
            this.toolTip.SetToolTip(this.btnFolderSelect, "Open folder selection");
            this.btnFolderSelect.UseVisualStyleBackColor = true;
            this.btnFolderSelect.Click += new System.EventHandler(this.btnFolderSelect_Click);
            // 
            // gbDownloadOptions
            // 
            this.gbDownloadOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDownloadOptions.Controls.Add(this.nudMaxDupes);
            this.gbDownloadOptions.Controls.Add(this.lblMaxDupes);
            this.gbDownloadOptions.Controls.Add(this.cbDownloadMethod);
            this.gbDownloadOptions.Controls.Add(this.btnOpenDownloadDir);
            this.gbDownloadOptions.Controls.Add(this.nudDownloadDelay);
            this.gbDownloadOptions.Controls.Add(this.lblHTMLDelay);
            this.gbDownloadOptions.Controls.Add(this.nudHTMLDelay);
            this.gbDownloadOptions.Controls.Add(this.lblDownloadDelay);
            this.gbDownloadOptions.Controls.Add(this.cbSubfolderBySubmissionType);
            this.gbDownloadOptions.Controls.Add(this.btnDownload);
            this.gbDownloadOptions.Controls.Add(this.tbDownloadDirectory);
            this.gbDownloadOptions.Controls.Add(this.lblDownloadDir);
            this.gbDownloadOptions.Controls.Add(this.btnFolderSelect);
            this.gbDownloadOptions.Controls.Add(this.cbSubfolderByArtistName);
            this.gbDownloadOptions.Controls.Add(this.cbOverwrite);
            this.gbDownloadOptions.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDownloadOptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.gbDownloadOptions.Location = new System.Drawing.Point(516, 379);
            this.gbDownloadOptions.Name = "gbDownloadOptions";
            this.gbDownloadOptions.Size = new System.Drawing.Size(227, 285);
            this.gbDownloadOptions.TabIndex = 36;
            this.gbDownloadOptions.TabStop = false;
            this.gbDownloadOptions.Text = "Download options";
            // 
            // nudMaxDupes
            // 
            this.nudMaxDupes.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMaxDupes.Location = new System.Drawing.Point(180, 195);
            this.nudMaxDupes.Name = "nudMaxDupes";
            this.nudMaxDupes.Size = new System.Drawing.Size(41, 18);
            this.nudMaxDupes.TabIndex = 43;
            this.toolTip.SetToolTip(this.nudMaxDupes, "If you hit an existing submission file, skip the current gallery and move on.\r\nJo" +
        "urnals not supported.\r\n\r\nNOTE:\r\nIf you change your subfolder options, this limit" +
        " will be overlooekd.");
            // 
            // lblMaxDupes
            // 
            this.lblMaxDupes.AutoSize = true;
            this.lblMaxDupes.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxDupes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.lblMaxDupes.Location = new System.Drawing.Point(6, 197);
            this.lblMaxDupes.Name = "lblMaxDupes";
            this.lblMaxDupes.Size = new System.Drawing.Size(168, 12);
            this.lblMaxDupes.TabIndex = 42;
            this.lblMaxDupes.Text = "Max duplicates hit to skip artist:";
            // 
            // cbDownloadMethod
            // 
            this.cbDownloadMethod.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDownloadMethod.FormattingEnabled = true;
            this.cbDownloadMethod.Location = new System.Drawing.Point(6, 219);
            this.cbDownloadMethod.Name = "cbDownloadMethod";
            this.cbDownloadMethod.Size = new System.Drawing.Size(215, 20);
            this.cbDownloadMethod.TabIndex = 40;
            this.cbDownloadMethod.Text = "Select download method";
            this.toolTip.SetToolTip(this.cbDownloadMethod, resources.GetString("cbDownloadMethod.ToolTip"));
            this.cbDownloadMethod.SelectedIndexChanged += new System.EventHandler(this.cbDownloadMethod_SelectedIndexChanged);
            // 
            // btnOpenDownloadDir
            // 
            this.btnOpenDownloadDir.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenDownloadDir.ForeColor = System.Drawing.Color.Black;
            this.btnOpenDownloadDir.Location = new System.Drawing.Point(181, 105);
            this.btnOpenDownloadDir.Name = "btnOpenDownloadDir";
            this.btnOpenDownloadDir.Size = new System.Drawing.Size(40, 18);
            this.btnOpenDownloadDir.TabIndex = 39;
            this.btnOpenDownloadDir.Text = "Open";
            this.toolTip.SetToolTip(this.btnOpenDownloadDir, "Open your download directory");
            this.btnOpenDownloadDir.UseVisualStyleBackColor = true;
            this.btnOpenDownloadDir.Click += new System.EventHandler(this.btnOpenDownloadDir_Click);
            // 
            // cbSubfolderBySubmissionType
            // 
            this.cbSubfolderBySubmissionType.AutoSize = true;
            this.cbSubfolderBySubmissionType.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSubfolderBySubmissionType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.cbSubfolderBySubmissionType.Location = new System.Drawing.Point(6, 151);
            this.cbSubfolderBySubmissionType.Name = "cbSubfolderBySubmissionType";
            this.cbSubfolderBySubmissionType.Size = new System.Drawing.Size(177, 16);
            this.cbSubfolderBySubmissionType.TabIndex = 38;
            this.cbSubfolderBySubmissionType.Text = "Subfolders by submission type";
            this.toolTip.SetToolTip(this.cbSubfolderBySubmissionType, "Create subfolders for submission type (gallery, scraps, favorites, journals)\r\n\r\nD" +
        "ownloading after changing this option will reorganize your files.");
            this.cbSubfolderBySubmissionType.UseVisualStyleBackColor = true;
            this.cbSubfolderBySubmissionType.CheckedChanged += new System.EventHandler(this.cbSubfolderBySubmissionType_CheckedChanged);
            // 
            // tbDownloadDirectory
            // 
            this.tbDownloadDirectory.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDownloadDirectory.Location = new System.Drawing.Point(6, 105);
            this.tbDownloadDirectory.Name = "tbDownloadDirectory";
            this.tbDownloadDirectory.Size = new System.Drawing.Size(141, 18);
            this.tbDownloadDirectory.TabIndex = 37;
            this.toolTip.SetToolTip(this.tbDownloadDirectory, "Directory where your downloaded files will be stored");
            this.tbDownloadDirectory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbDownloadDirectory_KeyDown);
            // 
            // lblDownloadDir
            // 
            this.lblDownloadDir.AutoSize = true;
            this.lblDownloadDir.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDownloadDir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.lblDownloadDir.Location = new System.Drawing.Point(6, 90);
            this.lblDownloadDir.Name = "lblDownloadDir";
            this.lblDownloadDir.Size = new System.Drawing.Size(105, 12);
            this.lblDownloadDir.TabIndex = 36;
            this.lblDownloadDir.Text = "Download directory:";
            // 
            // cbSubfolderByArtistName
            // 
            this.cbSubfolderByArtistName.AutoSize = true;
            this.cbSubfolderByArtistName.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSubfolderByArtistName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.cbSubfolderByArtistName.Location = new System.Drawing.Point(6, 129);
            this.cbSubfolderByArtistName.Name = "cbSubfolderByArtistName";
            this.cbSubfolderByArtistName.Size = new System.Drawing.Size(152, 16);
            this.cbSubfolderByArtistName.TabIndex = 35;
            this.cbSubfolderByArtistName.Text = "Subfolders by artist name";
            this.toolTip.SetToolTip(this.cbSubfolderByArtistName, "Create subfolders for each artist.\r\n\r\nDownloading after changing this option will" +
        " reorganize your files.");
            this.cbSubfolderByArtistName.UseVisualStyleBackColor = true;
            this.cbSubfolderByArtistName.CheckedChanged += new System.EventHandler(this.cbSubfolderByArtistName_CheckedChanged);
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbout.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbout.ForeColor = System.Drawing.Color.Black;
            this.btnAbout.Location = new System.Drawing.Point(749, 639);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(211, 25);
            this.btnAbout.TabIndex = 38;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // toolTip
            // 
            this.toolTip.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // cbFilterSubmissionTitle
            // 
            this.cbFilterSubmissionTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFilterSubmissionTitle.AutoSize = true;
            this.cbFilterSubmissionTitle.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterSubmissionTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.cbFilterSubmissionTitle.Location = new System.Drawing.Point(144, 151);
            this.cbFilterSubmissionTitle.Name = "cbFilterSubmissionTitle";
            this.cbFilterSubmissionTitle.Size = new System.Drawing.Size(105, 16);
            this.cbFilterSubmissionTitle.TabIndex = 32;
            this.cbFilterSubmissionTitle.Text = "Submission title";
            this.toolTip.SetToolTip(this.cbFilterSubmissionTitle, "Apply filter to the title of submission");
            this.cbFilterSubmissionTitle.UseVisualStyleBackColor = true;
            this.cbFilterSubmissionTitle.CheckedChanged += new System.EventHandler(this.cbFilterSubmissionTitle_CheckedChanged);
            // 
            // cbFilterKeywords
            // 
            this.cbFilterKeywords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFilterKeywords.AutoSize = true;
            this.cbFilterKeywords.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterKeywords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.cbFilterKeywords.Location = new System.Drawing.Point(144, 107);
            this.cbFilterKeywords.Name = "cbFilterKeywords";
            this.cbFilterKeywords.Size = new System.Drawing.Size(72, 16);
            this.cbFilterKeywords.TabIndex = 28;
            this.cbFilterKeywords.Text = "Keywords";
            this.toolTip.SetToolTip(this.cbFilterKeywords, "Apply filter to keywords on parsed page");
            this.cbFilterKeywords.UseVisualStyleBackColor = true;
            // 
            // cbFilterComments
            // 
            this.cbFilterComments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFilterComments.AutoSize = true;
            this.cbFilterComments.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterComments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.cbFilterComments.Location = new System.Drawing.Point(144, 195);
            this.cbFilterComments.Name = "cbFilterComments";
            this.cbFilterComments.Size = new System.Drawing.Size(78, 16);
            this.cbFilterComments.TabIndex = 31;
            this.cbFilterComments.Text = "Comments";
            this.toolTip.SetToolTip(this.cbFilterComments, "Apply filter to comments in parsed page");
            this.cbFilterComments.UseVisualStyleBackColor = true;
            this.cbFilterComments.CheckedChanged += new System.EventHandler(this.cbFilterComments_CheckedChanged);
            // 
            // cbFilterDescription
            // 
            this.cbFilterDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFilterDescription.AutoSize = true;
            this.cbFilterDescription.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.cbFilterDescription.Location = new System.Drawing.Point(144, 129);
            this.cbFilterDescription.Name = "cbFilterDescription";
            this.cbFilterDescription.Size = new System.Drawing.Size(82, 16);
            this.cbFilterDescription.TabIndex = 30;
            this.cbFilterDescription.Text = "Description";
            this.toolTip.SetToolTip(this.cbFilterDescription, "Apply filter to description on parsed page");
            this.cbFilterDescription.UseVisualStyleBackColor = true;
            this.cbFilterDescription.CheckedChanged += new System.EventHandler(this.cbFilterDescription_CheckedChanged);
            // 
            // lbFilter
            // 
            this.lbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbFilter.BackColor = System.Drawing.Color.White;
            this.lbFilter.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFilter.FormattingEnabled = true;
            this.lbFilter.ItemHeight = 12;
            this.lbFilter.Location = new System.Drawing.Point(6, 18);
            this.lbFilter.Name = "lbFilter";
            this.lbFilter.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbFilter.Size = new System.Drawing.Size(132, 196);
            this.lbFilter.TabIndex = 27;
            this.toolTip.SetToolTip(this.lbFilter, "List of words to filter while parsing FA");
            this.lbFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbFilter_KeyDown);
            // 
            // btnAddToFilter
            // 
            this.btnAddToFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddToFilter.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddToFilter.ForeColor = System.Drawing.Color.Black;
            this.btnAddToFilter.Location = new System.Drawing.Point(144, 44);
            this.btnAddToFilter.Name = "btnAddToFilter";
            this.btnAddToFilter.Size = new System.Drawing.Size(63, 23);
            this.btnAddToFilter.TabIndex = 29;
            this.btnAddToFilter.Text = "Add entry";
            this.toolTip.SetToolTip(this.btnAddToFilter, "Add entered text into filter list");
            this.btnAddToFilter.UseVisualStyleBackColor = true;
            this.btnAddToFilter.Click += new System.EventHandler(this.btnAddToFilter_Click);
            // 
            // cbFilterFileName
            // 
            this.cbFilterFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFilterFileName.AutoSize = true;
            this.cbFilterFileName.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterFileName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.cbFilterFileName.Location = new System.Drawing.Point(144, 173);
            this.cbFilterFileName.Name = "cbFilterFileName";
            this.cbFilterFileName.Size = new System.Drawing.Size(72, 16);
            this.cbFilterFileName.TabIndex = 33;
            this.cbFilterFileName.Text = "File name";
            this.toolTip.SetToolTip(this.cbFilterFileName, "Apply filter to the file name");
            this.cbFilterFileName.UseVisualStyleBackColor = true;
            this.cbFilterFileName.CheckedChanged += new System.EventHandler(this.cbFilterFileName_CheckedChanged);
            // 
            // btnRemoveFilteredWord
            // 
            this.btnRemoveFilteredWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveFilteredWord.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveFilteredWord.ForeColor = System.Drawing.Color.Black;
            this.btnRemoveFilteredWord.Location = new System.Drawing.Point(213, 44);
            this.btnRemoveFilteredWord.Name = "btnRemoveFilteredWord";
            this.btnRemoveFilteredWord.Size = new System.Drawing.Size(74, 23);
            this.btnRemoveFilteredWord.TabIndex = 34;
            this.btnRemoveFilteredWord.Text = "Remove selected";
            this.toolTip.SetToolTip(this.btnRemoveFilteredWord, "Remove the selected filter list entry");
            this.btnRemoveFilteredWord.UseVisualStyleBackColor = true;
            this.btnRemoveFilteredWord.Click += new System.EventHandler(this.btnRemoveFilteredWord_Click);
            // 
            // cbFilterAll
            // 
            this.cbFilterAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFilterAll.AutoSize = true;
            this.cbFilterAll.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.cbFilterAll.Location = new System.Drawing.Point(144, 85);
            this.cbFilterAll.Name = "cbFilterAll";
            this.cbFilterAll.Size = new System.Drawing.Size(38, 16);
            this.cbFilterAll.TabIndex = 35;
            this.cbFilterAll.Text = "All";
            this.toolTip.SetToolTip(this.cbFilterAll, "Apply filter to all areas of the parsed page");
            this.cbFilterAll.UseVisualStyleBackColor = true;
            this.cbFilterAll.CheckedChanged += new System.EventHandler(this.cbFilterAll_CheckedChanged);
            // 
            // gbMOTD
            // 
            this.gbMOTD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMOTD.Controls.Add(this.lnklblLiveMOTDLink);
            this.gbMOTD.Controls.Add(this.lblLiveMOTD);
            this.gbMOTD.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMOTD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.gbMOTD.Location = new System.Drawing.Point(12, 670);
            this.gbMOTD.Name = "gbMOTD";
            this.gbMOTD.Size = new System.Drawing.Size(950, 60);
            this.gbMOTD.TabIndex = 39;
            this.gbMOTD.TabStop = false;
            this.gbMOTD.Text = "Message of the day";
            // 
            // lnklblLiveMOTDLink
            // 
            this.lnklblLiveMOTDLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lnklblLiveMOTDLink.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.lnklblLiveMOTDLink.Location = new System.Drawing.Point(6, 41);
            this.lnklblLiveMOTDLink.Name = "lnklblLiveMOTDLink";
            this.lnklblLiveMOTDLink.Size = new System.Drawing.Size(938, 14);
            this.lnklblLiveMOTDLink.TabIndex = 1;
            this.lnklblLiveMOTDLink.TabStop = true;
            this.lnklblLiveMOTDLink.Text = "linkLabel1";
            this.lnklblLiveMOTDLink.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lnklblLiveMOTDLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblLiveMOTDLink_LinkClicked);
            // 
            // lblLiveMOTD
            // 
            this.lblLiveMOTD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLiveMOTD.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLiveMOTD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.lblLiveMOTD.Location = new System.Drawing.Point(6, 14);
            this.lblLiveMOTD.Name = "lblLiveMOTD";
            this.lblLiveMOTD.Size = new System.Drawing.Size(938, 41);
            this.lblLiveMOTD.TabIndex = 0;
            this.lblLiveMOTD.Text = "Message Of\r\nThe DAY\r\n!!!\r\n";
            this.lblLiveMOTD.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dgvArtistListContextMenu
            // 
            this.dgvArtistListContextMenu.Name = "dgvArtistListContextMenu";
            this.dgvArtistListContextMenu.Size = new System.Drawing.Size(61, 4);
            this.dgvArtistListContextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.dgvArtistListContextMenu_ItemClicked);
            // 
            // cbSTFU
            // 
            this.cbSTFU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSTFU.AutoSize = true;
            this.cbSTFU.Location = new System.Drawing.Point(749, 616);
            this.cbSTFU.Name = "cbSTFU";
            this.cbSTFU.Size = new System.Drawing.Size(126, 17);
            this.cbSTFU.TabIndex = 40;
            this.cbSTFU.Text = "omg shut the fuck up";
            this.cbSTFU.UseVisualStyleBackColor = true;
            // 
            // lblEnterVerification
            // 
            this.lblEnterVerification.Location = new System.Drawing.Point(0, 0);
            this.lblEnterVerification.Name = "lblEnterVerification";
            this.lblEnterVerification.Size = new System.Drawing.Size(100, 23);
            this.lblEnterVerification.TabIndex = 0;
            // 
            // gbCaptcha
            // 
            this.gbCaptcha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCaptcha.Controls.Add(this.tbCaptcha);
            this.gbCaptcha.Controls.Add(this.btnCaptchaSubmit);
            this.gbCaptcha.Controls.Add(this.pbCaptcha);
            this.gbCaptcha.Controls.Add(this.lblCaptcha);
            this.gbCaptcha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCaptcha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.gbCaptcha.Location = new System.Drawing.Point(516, 12);
            this.gbCaptcha.Name = "gbCaptcha";
            this.gbCaptcha.Size = new System.Drawing.Size(446, 134);
            this.gbCaptcha.TabIndex = 42;
            this.gbCaptcha.TabStop = false;
            this.gbCaptcha.Text = "Verification";
            this.gbCaptcha.Visible = false;
            // 
            // tbCaptcha
            // 
            this.tbCaptcha.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCaptcha.Location = new System.Drawing.Point(225, 65);
            this.tbCaptcha.Name = "tbCaptcha";
            this.tbCaptcha.Size = new System.Drawing.Size(100, 18);
            this.tbCaptcha.TabIndex = 42;
            this.tbCaptcha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCaptcha_KeyPress);
            // 
            // btnCaptchaSubmit
            // 
            this.btnCaptchaSubmit.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCaptchaSubmit.ForeColor = System.Drawing.Color.Black;
            this.btnCaptchaSubmit.Location = new System.Drawing.Point(225, 89);
            this.btnCaptchaSubmit.Name = "btnCaptchaSubmit";
            this.btnCaptchaSubmit.Size = new System.Drawing.Size(100, 23);
            this.btnCaptchaSubmit.TabIndex = 41;
            this.btnCaptchaSubmit.Text = "Submit captcha";
            this.btnCaptchaSubmit.UseVisualStyleBackColor = true;
            this.btnCaptchaSubmit.Click += new System.EventHandler(this.btnCaptchaSubmit_Click);
            // 
            // pbCaptcha
            // 
            this.pbCaptcha.Location = new System.Drawing.Point(99, 52);
            this.pbCaptcha.Name = "pbCaptcha";
            this.pbCaptcha.Size = new System.Drawing.Size(120, 60);
            this.pbCaptcha.TabIndex = 40;
            this.pbCaptcha.TabStop = false;
            // 
            // lblCaptcha
            // 
            this.lblCaptcha.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptcha.ForeColor = System.Drawing.Color.Orange;
            this.lblCaptcha.Location = new System.Drawing.Point(6, 17);
            this.lblCaptcha.Name = "lblCaptcha";
            this.lblCaptcha.Size = new System.Drawing.Size(434, 19);
            this.lblCaptcha.TabIndex = 39;
            this.lblCaptcha.Text = "Please enter verification to log in:";
            this.lblCaptcha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbAddToFilter
            // 
            this.tbAddToFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAddToFilter.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAddToFilter.Location = new System.Drawing.Point(144, 18);
            this.tbAddToFilter.Name = "tbAddToFilter";
            this.tbAddToFilter.Size = new System.Drawing.Size(143, 18);
            this.tbAddToFilter.TabIndex = 26;
            this.tbAddToFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbAddToFilter_KeyPress);
            // 
            // lblFilterThrough
            // 
            this.lblFilterThrough.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFilterThrough.AutoSize = true;
            this.lblFilterThrough.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterThrough.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.lblFilterThrough.Location = new System.Drawing.Point(144, 70);
            this.lblFilterThrough.Name = "lblFilterThrough";
            this.lblFilterThrough.Size = new System.Drawing.Size(77, 12);
            this.lblFilterThrough.TabIndex = 36;
            this.lblFilterThrough.Text = "Apply filter to:";
            // 
            // gbFilterSettings
            // 
            this.gbFilterSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFilterSettings.Controls.Add(this.lblFilterThrough);
            this.gbFilterSettings.Controls.Add(this.cbFilterAll);
            this.gbFilterSettings.Controls.Add(this.btnRemoveFilteredWord);
            this.gbFilterSettings.Controls.Add(this.tbAddToFilter);
            this.gbFilterSettings.Controls.Add(this.cbFilterFileName);
            this.gbFilterSettings.Controls.Add(this.btnAddToFilter);
            this.gbFilterSettings.Controls.Add(this.lbFilter);
            this.gbFilterSettings.Controls.Add(this.cbFilterDescription);
            this.gbFilterSettings.Controls.Add(this.cbFilterComments);
            this.gbFilterSettings.Controls.Add(this.cbFilterKeywords);
            this.gbFilterSettings.Controls.Add(this.cbFilterSubmissionTitle);
            this.gbFilterSettings.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilterSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.gbFilterSettings.Location = new System.Drawing.Point(516, 152);
            this.gbFilterSettings.Name = "gbFilterSettings";
            this.gbFilterSettings.Size = new System.Drawing.Size(293, 221);
            this.gbFilterSettings.TabIndex = 25;
            this.gbFilterSettings.TabStop = false;
            this.gbFilterSettings.Text = "Filter settings";
            // 
            // wbLogin
            // 
            this.wbLogin.Location = new System.Drawing.Point(516, 152);
            this.wbLogin.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbLogin.Name = "wbLogin";
            this.wbLogin.ScriptErrorsSuppressed = true;
            this.wbLogin.Size = new System.Drawing.Size(293, 221);
            this.wbLogin.TabIndex = 1;
            this.wbLogin.Visible = false;
            // 
            // downloaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(59)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(972, 740);
            this.Controls.Add(this.wbLogin);
            this.Controls.Add(this.cbSTFU);
            this.Controls.Add(this.gbMOTD);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.gbDownloadOptions);
            this.Controls.Add(this.gbInfo);
            this.Controls.Add(this.gbImagePreview);
            this.Controls.Add(this.gbOutput);
            this.Controls.Add(this.gbFilterSettings);
            this.Controls.Add(this.gbArtistSettings);
            this.Controls.Add(this.gbFAConnectionStatus);
            this.Controls.Add(this.gbLoginCookies);
            this.Controls.Add(this.gbLogin);
            this.Controls.Add(this.gbCaptcha);
            this.ForeColor = System.Drawing.Color.White;
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(945, 740);
            this.Name = "downloaderForm";
            this.Text = "FurAffinity Digger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.downloaderForm_FormClosing);
            this.Load += new System.EventHandler(this.downloaderForm_Load);
            this.Shown += new System.EventHandler(this.downloaderForm_Shown);
            this.gbLogin.ResumeLayout(false);
            this.gbLogin.PerformLayout();
            this.gbFAConnectionStatus.ResumeLayout(false);
            this.gbArtistSettings.ResumeLayout(false);
            this.gbArtistSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArtistList)).EndInit();
            this.gbLoginCookies.ResumeLayout(false);
            this.gbLoginCookies.PerformLayout();
            this.gbOutput.ResumeLayout(false);
            this.gbOutput.PerformLayout();
            this.gbImagePreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHTMLDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDownloadDelay)).EndInit();
            this.gbDownloadOptions.ResumeLayout(false);
            this.gbDownloadOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxDupes)).EndInit();
            this.gbMOTD.ResumeLayout(false);
            this.gbCaptcha.ResumeLayout(false);
            this.gbCaptcha.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaptcha)).EndInit();
            this.gbFilterSettings.ResumeLayout(false);
            this.gbFilterSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox gbLogin;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblLoginStatus;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label lblLoginInfo;
        private System.Windows.Forms.Label lblArtistList;
        private System.Windows.Forms.CheckBox cbGallery;
        private System.Windows.Forms.CheckBox cbScraps;
        private System.Windows.Forms.CheckBox cbFavorites;
        private System.Windows.Forms.CheckBox cbJournals;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnSelectNone;
        private System.Windows.Forms.GroupBox gbArtistSettings;
        private System.Windows.Forms.Button btnImportWatchList;
        private System.Windows.Forms.Button btnRemoveArtists;
        private System.Windows.Forms.Label lblDownloadDelay;
        private System.Windows.Forms.Label lblHTMLDelay;
        private System.Windows.Forms.NumericUpDown nudDownloadDelay;
        private System.Windows.Forms.NumericUpDown nudHTMLDelay;
        private System.Windows.Forms.Button btnArtistApplyDownloads;
        private System.Windows.Forms.Label lblLoggingLevel;
        private System.Windows.Forms.CheckBox cbDownloads;
        private System.Windows.Forms.CheckBox cbErrors;
        private System.Windows.Forms.CheckBox cbStatus;
        private System.Windows.Forms.GroupBox gbOutput;
        private System.Windows.Forms.Button btnCopyOutputToClipboard;
        private System.Windows.Forms.GroupBox gbImagePreview;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Label lblRatings;
        private System.Windows.Forms.CheckBox cbAdult;
        private System.Windows.Forms.CheckBox cbMature;
        private System.Windows.Forms.CheckBox cbGeneral;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.CheckBox cbOverwrite;
        private System.Windows.Forms.Button btnFolderSelect;
        private System.Windows.Forms.GroupBox gbDownloadOptions;
        private System.Windows.Forms.CheckBox cbSubfolderBySubmissionType;
        private System.Windows.Forms.Label lblDownloadDir;
        private System.Windows.Forms.CheckBox cbSubfolderByArtistName;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.PictureBox pbPreview;
        public System.Windows.Forms.ListBox lbOutput;
        public System.Windows.Forms.TextBox tbDownloadDirectory;
        private System.Windows.Forms.DataGridView dgvArtistList;
        private System.Windows.Forms.Button btnClearOutput;
        private System.Windows.Forms.CheckBox cbDebug;
        private System.Windows.Forms.CheckBox cbAllFARatings;
        private System.Windows.Forms.CheckBox cbAllLoggingLevels;
        private System.Windows.Forms.Label lblArtistGalleryTypes;
        private System.Windows.Forms.CheckBox cbAllGalleryTypes;
        private System.Windows.Forms.Button btnOpenDownloadDir;
        private System.Windows.Forms.WebBrowser wbLogin;
        private System.Windows.Forms.CheckBox cbShowPassword;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnGetArtistStatuses;
        private System.Windows.Forms.Label lblFAConnectionStatus;
        private System.Windows.Forms.Button btnAttemptReconnection;
        private System.Windows.Forms.CheckBox cbLogInOnLaunch;
        private System.Windows.Forms.ComboBox cbDownloadMethod;
        private System.Windows.Forms.Label lblLiveInfo;
        private System.Windows.Forms.GroupBox gbMOTD;
        private System.Windows.Forms.Label lblLiveMOTD;
        private System.Windows.Forms.LinkLabel lnklblLiveMOTDLink;
        private System.Windows.Forms.ContextMenuStrip dgvArtistListContextMenu;
        private System.Windows.Forms.CheckBox cbSTFU;
        public System.Windows.Forms.Label lbParseProgress;
        public System.Windows.Forms.Label lbDownloadProgress;
        private System.Windows.Forms.GroupBox gbFAConnectionStatus;
        private System.Windows.Forms.Label lblEnterVerification;
        private System.Windows.Forms.GroupBox gbCaptcha;
        private System.Windows.Forms.Label lblCaptcha;
        private System.Windows.Forms.TextBox tbCaptcha;
        private System.Windows.Forms.PictureBox pbCaptcha;
        private System.Windows.Forms.Button btnCaptchaSubmit;
        private System.Windows.Forms.Label lblArtistCount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn artistDownloadJournals;
        private System.Windows.Forms.DataGridViewCheckBoxColumn artistDownloadFavorites;
        private System.Windows.Forms.DataGridViewCheckBoxColumn artistDownloadScraps;
        private System.Windows.Forms.DataGridViewCheckBoxColumn artistDownloadGallery;
        private System.Windows.Forms.DataGridViewTextBoxColumn artistName;
        private System.Windows.Forms.DataGridViewTextBoxColumn artistAvailable;
        private System.Windows.Forms.NumericUpDown nudMaxDupes;
        private System.Windows.Forms.Label lblMaxDupes;
        private System.Windows.Forms.CheckBox cbStatusAutoUpdate;
        public System.Windows.Forms.Label lblDownloadingFile;
        public System.Windows.Forms.Label lblDiggingArtist;
        private System.Windows.Forms.Label lblBigStatus;
        private System.Windows.Forms.GroupBox gbFilterSettings;
        private System.Windows.Forms.Label lblFilterThrough;
        private System.Windows.Forms.CheckBox cbFilterAll;
        private System.Windows.Forms.Button btnRemoveFilteredWord;
        private System.Windows.Forms.TextBox tbAddToFilter;
        private System.Windows.Forms.CheckBox cbFilterFileName;
        private System.Windows.Forms.Button btnAddToFilter;
        private System.Windows.Forms.ListBox lbFilter;
        private System.Windows.Forms.CheckBox cbFilterDescription;
        private System.Windows.Forms.CheckBox cbFilterComments;
        private System.Windows.Forms.CheckBox cbFilterKeywords;
        private System.Windows.Forms.CheckBox cbFilterSubmissionTitle;
        private System.Windows.Forms.GroupBox gbLoginCookies;
        private System.Windows.Forms.Button btnVerifyCookies;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCookieA;
        private System.Windows.Forms.Label lblCookieB;
        private System.Windows.Forms.TextBox tbCookieB;
        private System.Windows.Forms.TextBox tbCookieA;
        private System.Windows.Forms.Button btn_CookieTut;
    }
}

