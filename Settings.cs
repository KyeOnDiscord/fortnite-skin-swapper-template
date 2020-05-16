using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ProMasterBoy_Swapper.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ProMasterBoy_Swapper
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            string pakfiles = "";
            pakfiles = Properties.Settings.Default.PaksLocation;
            textBox1.Text = pakfiles;
        }

        private void RevertB_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog choosepakfiles = new FolderBrowserDialog();
            choosepakfiles.RootFolder = Environment.SpecialFolder.MyComputer;
            choosepakfiles.Description = @"Please select your paks folder";
            choosepakfiles.ShowNewFolderButton = false;
            if (choosepakfiles.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string choosepakfiles2 = choosepakfiles.SelectedPath;
                string pakfiles = "New Pak Files Here";
                MessageBox.Show("Pak Files are now located at: " + choosepakfiles2);
                pakfiles = choosepakfiles2;
                textBox1.Text = pakfiles;
            }

        }

        private void Settings_Load(object sender, EventArgs e)
        {
            Properties.Settings.Default.PaksLocation = textBox1.Text;
            Properties.Settings.Default.Save();
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.PaksLocation = textBox1.Text;
            Properties.Settings.Default.Save();
        }


        private static string GetEpicDirectory() => Directory.Exists(@"C:\ProgramData\Epic") ? @"C:\ProgramData\Epic" : Directory.Exists(@"D:\ProgramData\Epic") ? @"D:\ProgramData\Epic" : Directory.Exists(@"E:\ProgramData\Epic") ? @"E:\ProgramData\Epic" : @"F:\ProgramData\Epic";
        private static bool DatFileExists() => File.Exists($@"{GetEpicDirectory()}\UnrealEngineLauncher\LauncherInstalled.dat");

        private void RevertB_Click_1(object sender, EventArgs e)
        {
            /*
            * 
            * 
            * This function require:
            * using AutoPathPaksFinder.Classes;
            * using AutoPathPaksFinder.Properties;
            * using Newtonsoft.Json;
            * using Newtonsoft.Json.Linq;
            * 
            * Create a settings called "pathpaks" (Using it line 51 of this Class).
            * Copy the Class called "Utilities" in AutoPath>Classes>Utilities.cs (Using it line 38 of this Class).     
            * 
            * Put these at the beginning of the files as I did : 
            * private static string GetEpicDirectory() => Directory.Exists(@"C:\ProgramData\Epic") ? @"C:\ProgramData\Epic" : Directory.Exists(@"D:\ProgramData\Epic") ? @"D:\ProgramData\Epic" : Directory.Exists(@"E:\ProgramData\Epic") ? @"E:\ProgramData\Epic" : @"F:\ProgramData\Epic";
            * private static bool DatFileExists() => File.Exists($@"{GetEpicDirectory()}\UnrealEngineLauncher\LauncherInstalled.dat");
            * 
            * 
            * Made by yanis#0001 <---- Credit tysm from yanis/whey! - Kye
            */
            if (DatFileExists())
            {
                string jsonData = File.ReadAllText($@"{GetEpicDirectory()}\UnrealEngineLauncher\LauncherInstalled.dat");
                if (Utilities.IsValidJson(jsonData))
                {
                    JToken FortnitePath = JsonConvert.DeserializeObject<JToken>(jsonData);
                    if (FortnitePath != null)
                    {
                        JArray installationListArray = FortnitePath["InstallationList"].Value<JArray>();
                        if (installationListArray != null)
                        {
                            foreach (JToken FortnitePathReal in installationListArray)
                            {
                                if (string.Equals(FortnitePathReal["AppName"].Value<string>(), "Fortnite"))
                                {
                                    string path = $@"{FortnitePathReal["InstallLocation"].Value<string>()}\FortniteGame\Content\Paks";
                                    Properties.Settings.Default.PaksLocation = path;
                                    Properties.Settings.Default.Save();
                                    textBox1.Text = Properties.Settings.Default.PaksLocation;
                                    Properties.Settings.Default.PaksLocation = textBox1.Text;
                                    Properties.Settings.Default.Save();
                                    MessageBox.Show("Pak Files are now saved at " + Properties.Settings.Default.PaksLocation, "Pro Swapper", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Could not find your pak files! Please select them manually!", "Pro Swapper", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Utilities.credits, "Credits");
        }
    }
}
