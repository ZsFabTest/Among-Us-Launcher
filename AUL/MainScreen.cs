using SharpConfig;
using System.Diagnostics;
using System.Drawing.Text;
using System.IO;
using System.Text;

namespace AUL
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        private readonly string[] AllModList = { "AllTheRoles", "Nebula", "SuperNewRoles", "ExtremeRoles", "LasMonjas", "TheOtherRoles", "TownOfHost", "TONX", "TownOfUs", "TOHE", "TOHEXI" };
        private readonly string[] ReactorRequestedModList = { "AllTheRoles", "LasMonjas", "TownOfUs" };

        private bool isLoading = false;
        private string mciName = null;
        private int modtype = -1;

        private bool isGameFolder(string path)
        {
            if (!Directory.Exists(path)) return false;
            DirectoryInfo root = new DirectoryInfo(path);
            DirectoryInfo[] files = root.GetDirectories();
            return files.Any((f) => f.Name == "Among Us_Data");
        }

        private void initGameStatus(object sender, EventArgs e)
        {
            if (gamePathChoose.SelectedIndex == -1) return;
            consoleStatus.Enabled = true;
            refreshButton.Enabled = true;
            gameStartButton.Enabled = true;
            reactorEnableChecker.Enabled = true;
            crowdedModEnableChecker.Enabled = true;
            submergedEnableChecker.Enabled = true;
            mciEnableChecker.Enabled = true;
            isLoading = true;
            string path = gamePathChoose.SelectedItem.ToString();
            if (!isGameFolder(path))
            {
                MessageBox.Show(this, "该文件夹无效", "提示");
                gamePathChoose.Items.RemoveAt(gamePathChoose.SelectedIndex);
                gamePathChoose.SelectedIndex = -1;
                refreshGamePathesList();
                isLoading = false;
                return;
            }
            path += "\\BepInEx\\plugins\\";
            DirectoryInfo root = new DirectoryInfo(path);
            FileInfo[] files = root.GetFiles();
            reactorEnableChecker.Enabled = false;
            reactorEnableChecker.Checked = false;
            crowdedModEnableChecker.Enabled = false;
            crowdedModEnableChecker.Checked = false;
            submergedEnableChecker.Checked = false;
            submergedEnableChecker.Enabled = false;
            mciEnableChecker.Enabled = false;
            mciEnableChecker.Checked = false;
            modtype = -1;
            reactorLab.Text = "";
            crowdedModLab.Text = "";
            submergedLab.Text = "";
            foreach (var f in files)
            {
                if (f.Name == "Reactor.dll")
                {
                    reactorEnableChecker.Enabled = true;
                    reactorEnableChecker.Checked = true;
                }
                else if (f.Name == "Reactor.dll.disabled")
                {
                    reactorEnableChecker.Enabled = true;
                    reactorEnableChecker.Checked = false;
                }
                else if (f.Name == "CrowdedMod.dll")
                {
                    crowdedModEnableChecker.Enabled = true;
                    crowdedModEnableChecker.Checked = true;
                }
                else if (f.Name == "CrowdedMod.dll.disabled")
                {
                    crowdedModEnableChecker.Enabled = true;
                    crowdedModEnableChecker.Checked = false;
                }
                else if (f.Name == "Submerged.dll")
                {
                    submergedEnableChecker.Enabled = true;
                    submergedEnableChecker.Checked = true;
                }
                else if (f.Name == "Submerged.dll.disabled")
                {
                    submergedEnableChecker.Enabled = true;
                    submergedEnableChecker.Checked = false;
                }
                else if (f.Name.Contains("MCI") || f.Name.Contains("mci"))
                {
                    mciName = f.Name.Replace(".disabled", "");
                    mciEnableChecker.Enabled = true;
                    if (!f.Name.Contains(".disabled"))
                    {
                        mciEnableChecker.Checked = true;
                    }
                    else mciEnableChecker.Checked = false;
                }
                else
                {
                    for (int i = 0; i < AllModList.Count(); i++)
                    {
                        if (f.Name.Contains(AllModList[i]))
                        {
                            modtype = i;
                        }
                    }
                }
            }
            crowdedModEnableChecker.Enabled = reactorEnableChecker.Checked & crowdedModEnableChecker.Enabled;
            submergedEnableChecker.Enabled = reactorEnableChecker.Checked & submergedEnableChecker.Enabled;

            if (!reactorEnableChecker.Checked)
            {
                crowdedModLab.Text = "不能在没有Reactor的情况下启用";
                submergedLab.Text = crowdedModLab.Text;
            }

            if (modtype != -1 && ReactorRequestedModList.Contains(AllModList[modtype]))
            {
                enabledDll("Reactor.dll");
                reactorEnableChecker.Enabled = false;
                reactorLab.Text = "该模组必须在Reactor下运行";
            }

            if (modtype != -1)
            {
                modNameShower.Text = AllModList[modtype];
            }
            else modNameShower.Text = "Unknow";

            consoleStatus.Checked = isConsoleEnabled();
            isLoading = false;
        }

        private void addGamePath(string path)
        {
            if (!isGameFolder(path))
            {
                MessageBox.Show(this, "非游戏文件夹", "提示");
                return;
            }
            gamePathChoose.Items.Add(path);
            refreshGamePathesList();
        }

        private void refreshGamePathesList()
        {
            FileStream fs = File.Create("GamePathes.ini");
            fs.Close();
            using (fs = new FileStream("GamePathes.ini", FileMode.Append, FileAccess.Write))
            {
                foreach (var item in gamePathChoose.Items)
                {
                    byte[] data = System.Text.Encoding.Default.GetBytes(item.ToString() + "\n");
                    fs.Position = fs.Length;
                    fs.Write(data, 0, data.Length);
                }
                fs.Flush();
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            gameFolderSelection.SelectedPath = "";
            if (gameFolderSelection.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(gameFolderSelection.SelectedPath))
                {
                    MessageBox.Show(this, "文件夹路径不能为空", "提示");
                    return;
                }
                addGamePath(gameFolderSelection.SelectedPath);
            }

            if (gamePathChoose.Items.Count == 1) gamePathChoose.SelectedIndex = 0;
        }

        private void initGamePathes()
        {
            if (!File.Exists("GamePathes.ini"))
            {
                FileStream fs = File.Create("GamePathes.ini");
                fs.Close();
            }
            using (StreamReader sr = new StreamReader("GamePathes.ini"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    line.Replace(@"[/n/r]", "");
                    if (!string.IsNullOrEmpty(line)) gamePathChoose.Items.Add(line);
                }
            }
            if (gamePathChoose.Items.Count > 0)
            {
                gamePathChoose.SelectedIndex = 0;
            }
            else disableAll();
        }

        private void disableAll()
        {
            consoleStatus.Enabled = false;
            refreshButton.Enabled = false;
            gameStartButton.Enabled = false;
            reactorEnableChecker.Enabled = false;
            crowdedModEnableChecker.Enabled = false;
            submergedEnableChecker.Enabled = false;
            mciEnableChecker.Enabled = false;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Process.Start(gamePathChoose.SelectedItem.ToString() + "\\Among Us.exe");
        }

        private bool isConsoleEnabled()
        {
            if (gamePathChoose.SelectedIndex == -1) return false;
            string cfgfile = gamePathChoose.SelectedItem.ToString() + "\\BepInEx\\config\\BepInEx.cfg";
            Configuration config = Configuration.LoadFromFile(cfgfile);

            foreach (Section item in config)
            {
                if (item.Name == "Logging.Console")
                {
                    return item["Enabled"].BoolValue;
                }
            }

            return false;
        }

        private void setConsoleEnabled(bool enabled)
        {
            if (gamePathChoose.SelectedIndex == -1) return;
            string cfgfile = gamePathChoose.SelectedItem.ToString() + "\\BepInEx\\config\\BepInEx.cfg";
            Configuration config = Configuration.LoadFromFile(cfgfile);

            foreach (Section item in config)
            {
                if (item.Name == "Logging.Console")
                {
                    item["Enabled"].BoolValue = enabled;
                }
            }

            config.SaveToFile(cfgfile, Encoding.ASCII);
        }

        private void console_Click(object sender, EventArgs e)
        {
            setConsoleEnabled(consoleStatus.Checked);
        }

        private void disabledDll(string dllName)
        {
            string path = gamePathChoose.SelectedItem.ToString() + "\\BepInEx\\plugins";
            if (!File.Exists(path + "\\" + dllName)) return;
            if (File.Exists(path + "\\" + dllName + ".disabled")) return;
            File.Move(path + "\\" + dllName, path + "\\" + dllName + ".disabled");
            refreshButton.PerformClick();
        }

        private void enabledDll(string dllName)
        {
            string path = gamePathChoose.SelectedItem.ToString() + "\\BepInEx\\plugins";
            if (!File.Exists(path + "\\" + dllName)) return;
            if (File.Exists(path + "\\" + dllName.Replace(".disabled", ""))) return;
            File.Move(path + "\\" + dllName, path + "\\" + dllName.Replace(".disabled", ""));
            refreshButton.PerformClick();
        }

        private void reactorEnabled_Click(object sender, EventArgs e)
        {
            if (isLoading) return;
            if (reactorEnableChecker.Checked == true) enabledDll("Reactor.dll.disabled");
            else disabledDll("Reactor.dll");
        }

        private void crowdedModEnabled_Click(object sender, EventArgs e)
        {
            if (isLoading) return;
            if (crowdedModEnableChecker.Checked == true) enabledDll("CrowdedMod.dll.disabled");
            else disabledDll("CrowdedMod.dll");
        }

        private void submergedModEnabled_Click(object sender, EventArgs e)
        {
            if (isLoading) return;
            if (submergedEnableChecker.Checked == true) enabledDll("Submerged.dll.disabled");
            else disabledDll("Submerged.dll");
        }

        private void mciModEnabled_Click(object sender, EventArgs e)
        {
            if (isLoading) return;
            if (mciEnableChecker.Checked == true) enabledDll(mciName + ".disabled");
            else disabledDll(mciName);
        }

        private DownloadScreen ds;

        private async void downloadButton_Click(object sender, EventArgs e)
        {
            ds = new DownloadScreen();
            ds.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            addButton.Click += new EventHandler(addButton_Click);
            gamePathChoose.SelectedValueChanged += new EventHandler(initGameStatus);
            refreshButton.Click += new EventHandler(initGameStatus);
            gameStartButton.Click += new EventHandler(startButton_Click);
            consoleStatus.CheckedChanged += new EventHandler(console_Click);
            reactorEnableChecker.CheckedChanged += new EventHandler(reactorEnabled_Click);
            crowdedModEnableChecker.CheckedChanged += new EventHandler(crowdedModEnabled_Click);
            submergedEnableChecker.CheckedChanged += new EventHandler(submergedModEnabled_Click);
            mciEnableChecker.CheckedChanged += new EventHandler(mciModEnabled_Click);
            downloadButton.Click += new EventHandler(downloadButton_Click);
            initGamePathes();

            //downloadButton.Enabled = false;
        }
    }
}