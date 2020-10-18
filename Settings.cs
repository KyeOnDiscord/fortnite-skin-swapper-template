using System;
using System.Windows.Forms;
using System.IO;

namespace KyeSwapperTemplate
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            textBox1.Text = Properties.Settings.Default.Paks;
        }

        private void RevertB_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog choosepakfiles = new FolderBrowserDialog();
            choosepakfiles.RootFolder = Environment.SpecialFolder.MyComputer;
            choosepakfiles.Description = @"Please select your paks folder";
            choosepakfiles.ShowNewFolderButton = false;
            if (choosepakfiles.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Pak Files are now located at: " + choosepakfiles.SelectedPath);
                SavePaks(choosepakfiles.SelectedPath);
            }
        }
        private void SavePaks(string location)
        {
            textBox1.Text = location;
            Properties.Settings.Default.Paks = location;
            Properties.Settings.Default.Save();
        }
        
        private void FindPaksB_Click(object sender, EventArgs e)
        {
            try
            {
                string line;
                string path;
                string EpicDir = Swapper.GetEpicDir();
                if (EpicDir == "a")
                    MessageBox.Show("Please select your pak files manually!", Form1.swappername, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                StreamReader file = new StreamReader(EpicDir);
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Contains("\"InstallLocation\"") && line.Contains("Fortnite"))
                    {
                        path = line.Replace("\"InstallLocation\": \"", "").Replace(@"\\", @"\").Replace("Fortnite\",", @"Fortnite\FortniteGame\Content\Paks").Trim();
                        SavePaks(path);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e) => MessageBox.Show("This was made with a swapper template originally made by Kye (aka owner of Pro Swapper)", "Credits | Kye", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
