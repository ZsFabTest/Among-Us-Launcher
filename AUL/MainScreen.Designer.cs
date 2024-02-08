namespace AUL
{
    partial class MainScreen
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        private CheckBox reactorEnableChecker;
        private CheckBox crowdedModEnableChecker;
        private CheckBox submergedEnableChecker;
        private CheckBox mciEnableChecker;
        private ComboBox gamePathChoose;
        private Label reactorLab;
        private Label crowdedModLab;
        private Label submergedLab;
        private Button addButton;
        private Button refreshButton;
        private Button gameStartButton;
        private CheckBox consoleStatus;
        private Label modNameShower;
        private FolderBrowserDialog gameFolderSelection;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            reactorEnableChecker = new CheckBox();
            crowdedModEnableChecker = new CheckBox();
            submergedEnableChecker = new CheckBox();
            mciEnableChecker = new CheckBox();
            gamePathChoose = new ComboBox();
            reactorLab = new Label();
            crowdedModLab = new Label();
            submergedLab = new Label();
            addButton = new Button();
            refreshButton = new Button();
            gameStartButton = new Button();
            consoleStatus = new CheckBox();
            modNameShower = new Label();
            gameFolderSelection = new FolderBrowserDialog();
            downloadButton = new Button();
            CrowdedModInstaller = new Button();
            mciInstaller = new Button();
            reactorInstaller = new Button();
            openPath = new Button();
            refreshServers = new Button();
            SuspendLayout();
            // 
            // reactorEnableChecker
            // 
            reactorEnableChecker.AutoSize = true;
            reactorEnableChecker.Location = new Point(27, 39);
            reactorEnableChecker.Name = "reactorEnableChecker";
            reactorEnableChecker.Size = new Size(202, 35);
            reactorEnableChecker.TabIndex = 0;
            reactorEnableChecker.Text = "启用\"Reactor\"";
            reactorEnableChecker.UseVisualStyleBackColor = true;
            // 
            // crowdedModEnableChecker
            // 
            crowdedModEnableChecker.AutoSize = true;
            crowdedModEnableChecker.Location = new Point(27, 94);
            crowdedModEnableChecker.Name = "crowdedModEnableChecker";
            crowdedModEnableChecker.Size = new Size(270, 35);
            crowdedModEnableChecker.TabIndex = 1;
            crowdedModEnableChecker.Text = "启用\"CrowdedMod\"";
            crowdedModEnableChecker.UseVisualStyleBackColor = true;
            // 
            // submergedEnableChecker
            // 
            submergedEnableChecker.AutoSize = true;
            submergedEnableChecker.Location = new Point(27, 150);
            submergedEnableChecker.Name = "submergedEnableChecker";
            submergedEnableChecker.Size = new Size(247, 35);
            submergedEnableChecker.TabIndex = 2;
            submergedEnableChecker.Text = "启用\"Submerged\"";
            submergedEnableChecker.UseVisualStyleBackColor = true;
            // 
            // mciEnableChecker
            // 
            mciEnableChecker.AutoSize = true;
            mciEnableChecker.Location = new Point(27, 207);
            mciEnableChecker.Name = "mciEnableChecker";
            mciEnableChecker.Size = new Size(160, 35);
            mciEnableChecker.TabIndex = 3;
            mciEnableChecker.Text = "启用\"MCI\"";
            mciEnableChecker.UseVisualStyleBackColor = true;
            // 
            // gamePathChoose
            // 
            gamePathChoose.FormattingEnabled = true;
            gamePathChoose.Location = new Point(28, 394);
            gamePathChoose.Name = "gamePathChoose";
            gamePathChoose.Size = new Size(634, 39);
            gamePathChoose.TabIndex = 4;
            // 
            // reactorLab
            // 
            reactorLab.AutoSize = true;
            reactorLab.Location = new Point(330, 43);
            reactorLab.Name = "reactorLab";
            reactorLab.Size = new Size(0, 31);
            reactorLab.TabIndex = 5;
            // 
            // crowdedModLab
            // 
            crowdedModLab.AutoSize = true;
            crowdedModLab.Location = new Point(330, 98);
            crowdedModLab.Name = "crowdedModLab";
            crowdedModLab.Size = new Size(0, 31);
            crowdedModLab.TabIndex = 6;
            // 
            // submergedLab
            // 
            submergedLab.AutoSize = true;
            submergedLab.Location = new Point(330, 154);
            submergedLab.Name = "submergedLab";
            submergedLab.Size = new Size(0, 31);
            submergedLab.TabIndex = 7;
            // 
            // addButton
            // 
            addButton.Location = new Point(668, 394);
            addButton.Name = "addButton";
            addButton.Size = new Size(47, 39);
            addButton.TabIndex = 8;
            addButton.Text = "...";
            addButton.UseVisualStyleBackColor = true;
            // 
            // refreshButton
            // 
            refreshButton.Location = new Point(28, 439);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(74, 39);
            refreshButton.TabIndex = 9;
            refreshButton.Text = "刷新";
            refreshButton.UseVisualStyleBackColor = true;
            // 
            // gameStartButton
            // 
            gameStartButton.Location = new Point(623, 446);
            gameStartButton.Name = "gameStartButton";
            gameStartButton.Size = new Size(150, 46);
            gameStartButton.TabIndex = 10;
            gameStartButton.Text = "启动";
            gameStartButton.UseVisualStyleBackColor = true;
            // 
            // consoleStatus
            // 
            consoleStatus.AutoSize = true;
            consoleStatus.Location = new Point(607, 224);
            consoleStatus.Name = "consoleStatus";
            consoleStatus.Size = new Size(166, 35);
            consoleStatus.TabIndex = 11;
            consoleStatus.Text = "启用控制台";
            consoleStatus.UseVisualStyleBackColor = true;
            // 
            // modNameShower
            // 
            modNameShower.AutoSize = true;
            modNameShower.Location = new Point(128, 443);
            modNameShower.Name = "modNameShower";
            modNameShower.Size = new Size(0, 31);
            modNameShower.TabIndex = 12;
            // 
            // downloadButton
            // 
            downloadButton.Location = new Point(471, 439);
            downloadButton.Name = "downloadButton";
            downloadButton.Size = new Size(126, 39);
            downloadButton.TabIndex = 13;
            downloadButton.Text = "获取模组";
            downloadButton.UseVisualStyleBackColor = true;
            // 
            // CrowdedModInstaller
            // 
            CrowdedModInstaller.Location = new Point(28, 265);
            CrowdedModInstaller.Name = "CrowdedModInstaller";
            CrowdedModInstaller.Size = new Size(302, 46);
            CrowdedModInstaller.TabIndex = 14;
            CrowdedModInstaller.Text = "安装CrowdedMod(7.12s)";
            CrowdedModInstaller.UseVisualStyleBackColor = true;
            CrowdedModInstaller.Click += CrowdedModInstaller_Click;
            // 
            // mciInstaller
            // 
            mciInstaller.Location = new Point(28, 322);
            mciInstaller.Name = "mciInstaller";
            mciInstaller.Size = new Size(302, 46);
            mciInstaller.TabIndex = 15;
            mciInstaller.Text = "安装MCI(0.0.6)";
            mciInstaller.UseVisualStyleBackColor = true;
            // 
            // reactorInstaller
            // 
            reactorInstaller.Location = new Point(360, 265);
            reactorInstaller.Name = "reactorInstaller";
            reactorInstaller.Size = new Size(302, 46);
            reactorInstaller.TabIndex = 16;
            reactorInstaller.Text = "安装Reactor(2.2.0)";
            reactorInstaller.UseVisualStyleBackColor = true;
            reactorInstaller.Click += reactorInstaller_Click;
            // 
            // openPath
            // 
            openPath.Location = new Point(360, 322);
            openPath.Name = "openPath";
            openPath.Size = new Size(150, 46);
            openPath.TabIndex = 17;
            openPath.Text = "打开目录";
            openPath.UseVisualStyleBackColor = true;
            openPath.Click += openPath_Click;
            // 
            // refreshServers
            // 
            refreshServers.Location = new Point(512, 322);
            refreshServers.Name = "refreshServers";
            refreshServers.Size = new Size(150, 46);
            refreshServers.TabIndex = 18;
            refreshServers.Text = "更新私服";
            refreshServers.UseVisualStyleBackColor = true;
            refreshServers.Click += refreshServers_Click;
            // 
            // MainScreen
            // 
            ClientSize = new Size(785, 501);
            Controls.Add(refreshServers);
            Controls.Add(openPath);
            Controls.Add(reactorInstaller);
            Controls.Add(mciInstaller);
            Controls.Add(CrowdedModInstaller);
            Controls.Add(downloadButton);
            Controls.Add(modNameShower);
            Controls.Add(consoleStatus);
            Controls.Add(gameStartButton);
            Controls.Add(refreshButton);
            Controls.Add(addButton);
            Controls.Add(submergedLab);
            Controls.Add(crowdedModLab);
            Controls.Add(reactorLab);
            Controls.Add(gamePathChoose);
            Controls.Add(mciEnableChecker);
            Controls.Add(submergedEnableChecker);
            Controls.Add(crowdedModEnableChecker);
            Controls.Add(reactorEnableChecker);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainScreen";
            Text = "Among Us Launcher";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Button downloadButton;
        private Button CrowdedModInstaller;
        private Button mciInstaller;
        private Button reactorInstaller;
        private Button openPath;
        private Button refreshServers;








        /*
        private CheckBox reactorEnableChecker;
        private CheckBox crowdedModEnableChecker;
        private ComboBox gamePathChoose;
        private Button addButton;
        private FolderBrowserDialog gameFolderSelection;
        private Button refreshButton;
        private Button gameStartButton;
        private CheckBox consoleStatus;
        private CheckBox submergedEnableChecker;
        private CheckBox mciEnableChecker;
        private Label reactorLab;
        private Label crowdedModLab;
        private Label submergedLab;
        private Label modNameShower;
        */
    }
}