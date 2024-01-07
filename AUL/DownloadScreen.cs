using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Newtonsoft.Json;
using System.IO;
using Ionic.Zip;

namespace AUL
{
    public partial class DownloadScreen : Form
    {
        public DownloadScreen()
        {
            InitializeComponent();
        }

        bool isSeletion = true;
        private readonly string[] reposAddr = { "Zeo666/AllTheRoles", "yukieiji/ExtremeRoles", "Dolly1016/Nebula", "ykundesu/SuperNewRoles", "eDonnes124/Town-Of-Us-R" };
        int idx = -1;
        HttpClient httpClient;

        public async void DownloadScreen_Load(object sender, EventArgs e)
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "AULauncher Updater");
            isSeletion = true;
            downloadButton.Text = "选择";
            label1.Text = "请选择模组";
            listBox1.Items.AddRange(new object[] { "AllTheRoles", "ExtremeRoles", "Nebula", "SuperNewRoles", "TownOfUs" });
        }

        private async Task TaskAsync()
        {
            idx = listBox1.SelectedIndex;

            string url = $"https://api.github.com/repos/{reposAddr[listBox1.SelectedIndex]}/tags?per_page=100&page=1";
            var response = await httpClient.GetAsync(url);
            string json = await response.Content.ReadAsStringAsync();
            List<ReleaseInfo> info = JsonConvert.DeserializeObject<List<ReleaseInfo>>(json);
            listBox1.Items.Clear();
            foreach (var f in info)
            {
                listBox1.Items.Add(f.name);
            }
            label1.Text = $"当前模组：{reposAddr[idx].Split("/")[1]}";
            isSeletion = false;
            listBox1.Enabled = true;
            downloadButton.Enabled = true;
        }

        private async Task DownloadAsync()
        {
            string url = $"https://api.github.com/repos/{reposAddr[idx]}/releases/tags/{listBox1.SelectedItem.ToString()}";
            var response = await httpClient.GetAsync(url);
            string json = await response.Content.ReadAsStringAsync();
            tagInfo info = JsonConvert.DeserializeObject<tagInfo>(json);
            url = "https://mirror.ghproxy.com/" + info.assets.FirstOrDefault((ass) => ass.browser_download_url.Contains(".zip")).browser_download_url;
            var repos = await httpClient.GetAsync(url);
            if (repos.StatusCode != HttpStatusCode.OK) return;
            var dllStream = await repos.Content.ReadAsStreamAsync();

            using var fileStream = File.Create("Download.zip");
            dllStream.CopyTo(fileStream);
            fileStream.Flush();
            /*
            label1.Text = $"正在解压...";


            if (Directory.Exists(".\\Extract\\"))
            {
                DirectoryInfo di = new DirectoryInfo(".\\Extract\\");
                di.Delete(true);
            }
            Directory.CreateDirectory(".\\Extract\\");
            //MessageBox.Show("\"" + System.Environment.CurrentDirectory + "\\Download.zip\"");
            //ZipFile.ExtractToDirectory("\"" + System.Environment.CurrentDirectory + "\\Download.zip\"", "\"" + folderBrowserDialog1.SelectedPath + "\"");
            new ZipFile("Download.zip").ExtractAll(".\\Extract\\");
            //File.Delete(".\\Download.zip");
            */
            MessageBox.Show("下载完成\n存放在目录中\n解压后拷贝至游戏文件夹", "提示");
            System.Diagnostics.Process.Start("Explorer.exe", System.Environment.CurrentDirectory + "\\Download.zip");
            this.Close();
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            if (isSeletion)
            {
                if (listBox1.SelectedIndex != -1)
                {
                    label1.Text = "正在获取...";
                    downloadButton.Enabled = false;
                    listBox1.Enabled = false;
                    TaskAsync();
                }
                else MessageBox.Show("请选择模组", "提示");
            }
            else
            {
                if (listBox1.SelectedIndex != -1)
                {
                    downloadButton.Enabled = false;
                    listBox1.Enabled = false;
                    label1.Text = $"正在下载：{reposAddr[idx].Split("/")[1]} {listBox1.SelectedItem.ToString()}";
                    DownloadAsync();
                }
                else MessageBox.Show("请选择版本", "提示");
            }
        }
    }
}

public class ReleaseInfo
{
    public string name;
    public string zipball_url;
    public string tarball_url;
    public string node_id;
}

public class tagInfo
{
    public assetInfo[] assets;
}

public class assetInfo
{
    public string browser_download_url;
}
