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
using System.Diagnostics;

namespace ProMasterBoy_Swapper
{
    public partial class Form1 : Form
    {
        /* | By Kye (Owner of Pro Swapper)
        * Supports 3 replaces in pakchunk10_s2 and 1 CID replace (pakchunk0)
        * Edit the stuff below including bytes, offsets, etc
        * 
        * 
        * ====
        * Please look in help.txt (in the solution explorer) for more info
        * ====
        */
        string swappername = "Pro Swapper";
        string swapfrom = "Uplink"; //Write what item it swaps from
        string swapto = "Black Shield";//Write what item it swaps to
        string logtext = "[LOG]"; //What it says when you convert it where it says [LOG] Converted, you can make it something else like [+], but it's your preference.
        bool showswaptime = true; //Shows how many ms (milliseconds) it took for the item to swap, by default its on true
        /*
         * The offsets (e.g: swap1offset, swap2offset, etc) is where in the pak file it starts searching from. (dec in HxD)
         */


        //Leave unused bytes as 0
        //Swap 1
        public int swap1offset = 70000000;
        private static byte[] search1 = new byte[]//Search For
       {
        047, 071, 097, 109, 101, 047, 065, 099, 099, 101, 115, 115, 111, 114, 105, 101, 115, 047, 070, 079, 082, 084, 095, 066, 097, 099, 107, 112, 097, 099, 107, 115, 047, 077, 095, 077, 069, 068, 095, 084, 097, 099, 116, 105, 099, 097, 108, 066, 097, 100, 097, 115, 115, 095, 066, 097, 099, 107, 112, 097, 099, 107, 047, 077, 101, 115, 104, 101, 115, 047, 077, 095, 077, 069, 068, 095, 084, 097, 099, 116, 105, 099, 097, 108, 095, 066, 097, 100, 097, 115, 115, 046, 077, 095, 077, 069, 068, 095, 084, 097, 099, 116, 105, 099, 097, 108, 095, 066, 097, 100, 097, 115, 115
       };

        private static byte[] replace1 = new byte[]//Replace With
        {
          47, 71, 97, 109, 101, 47, 65, 99, 99, 101, 115, 115, 111, 114, 105, 101, 115, 47, 70, 79, 82, 84, 95, 66, 97, 99, 107, 112, 97, 99, 107, 115, 47, 77, 101, 115, 104, 47, 83, 75, 95, 83, 104, 105, 101, 108, 100, 95, 66, 108, 97, 99, 107, 107, 110, 105, 103, 104, 116, 46, 83, 75, 95, 83, 104, 105, 101, 108, 100, 95, 66, 108, 97, 99, 107, 107, 110, 105, 103, 104, 116, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
        };
        //



        //Swap 2
        public int swap2offset = 0;
        private static byte[] search2 = new byte[]//Search For
      {
        0
      };

        private static byte[] replace2 = new byte[]//Replace With
        {
          0
        };
        //




        //Swap 3
        public int swap3offset = 0;
        private static byte[] search3 = new byte[]//Search For
      {
        0
      };

        private static byte[] replace3 = new byte[]//Replace With
        {
          0
        };
        //

        //CID Swap (4) pakchunk0
        public int swap4offset = 400000000;
        private static byte[] search4 = new byte[]//Search For
     {
        66, 73, 68, 95, 48, 55, 53, 95, 84, 97, 99, 116, 105, 99, 97, 108, 66, 97, 100, 97, 115, 115, 46, 66, 73, 68, 95, 48, 55, 53, 95, 84, 97, 99, 116, 105, 99, 97, 108, 66, 97, 100, 97, 115, 115
     };

        private static byte[] replace4 = new byte[]//Replace With
        {
          66, 73, 68, 95, 48, 48, 52, 95, 66, 108, 97, 99, 107, 75, 110, 105, 103, 104, 116, 46, 66, 73, 68, 95, 48, 48, 52, 95, 66, 108, 97, 99, 107, 75, 110, 105, 103, 104, 116, 0, 0, 0, 0, 0, 0
        };

        // Edit up to here, see code below if you know what you're doing - Kye








































            //DO NOT TOUCH ANYTHING HERE BELOW UNLESS YOU KNOW WHAT YOU ARE DOING!


        public string path0 = (Properties.Settings.Default.PaksLocation + @"\pakchunk0-WindowsClient.pak");
        public string path3 = (Properties.Settings.Default.PaksLocation + @"\pakchunk10_s2-WindowsClient.pak");
        public Form1()
        {
            InitializeComponent();
            this.Swap.DoWork += new DoWorkEventHandler(this.ReplaceBytes);
            this.Revert.DoWork += new DoWorkEventHandler(this.RevertBytes);
        }

        public void ReplaceBytes(object sender, DoWorkEventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            Stopwatch s = new Stopwatch();
            s.Start();

            ReplaceBytes(path3, search1, replace1, swap1offset, "[1/4] Converted");
            ReplaceBytes(path3, search2, replace2, swap2offset, "[2/4] Converted");
            ReplaceBytes(path3, search3, replace3, swap3offset, "[3/4] Converted");
            ReplaceBytes(path0, search4, replace4, swap4offset, "[4/4] Converted");
            label3.Text = "ON";
            label3.ForeColor = System.Drawing.Color.Lime;
            s.Stop();
            int num2 = (int)s.Elapsed.TotalMilliseconds;
            if (showswaptime)
            {
                Log("Converted in " + num2 + "ms");
            }
        }

        public void RevertBytes(object sender, DoWorkEventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            Stopwatch s = new Stopwatch();
            s.Start();

            ReplaceBytes(path3, replace1, search1, swap1offset, "[1/4] Reverted");
            ReplaceBytes(path3, replace2, search2, swap2offset, "[2/4] Reverted");
            ReplaceBytes(path3, replace3, search3, swap3offset, "[3/4] Reverted");
            ReplaceBytes(path0, replace4, search4, swap4offset, "[4/4] Reverted");
            label3.Text = "OFF";
            label3.ForeColor = System.Drawing.Color.Red;
            s.Stop();
            int num2 = (int)s.Elapsed.TotalMilliseconds;
            if (showswaptime)
            {
                Log("Reverted in " + num2 + "ms");
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Process[] processesByName = Process.GetProcessesByName("FortniteClient-Win64-Shipping_EAC");
            for (int i = 0; i < processesByName.Length; i++)
            {
                processesByName[i].Kill();
            }
            processesByName = Process.GetProcessesByName("FortniteClient-Win64-Shipping");
            for (int i = 0; i < processesByName.Length; i++)
            {
                processesByName[i].Kill();
            }
            processesByName = Process.GetProcessesByName("FortniteClient-Win64-Shipping_EAC");
            for (int i = 0; i < processesByName.Length; i++)
            {
                processesByName[i].Kill();
            }
            processesByName = Process.GetProcessesByName("FortniteClient-Win64-Shipping_BE");
            for (int i = 0; i < processesByName.Length; i++)
            {
                processesByName[i].Kill();
            }
            processesByName = Process.GetProcessesByName("EpicGamesLauncher");
            for (int i = 0; i < processesByName.Length; i++)
            {
                processesByName[i].Kill();
            }
            processesByName = Process.GetProcessesByName("UnrealCEFSubProcess");
            for (int i = 0; i < processesByName.Length; i++)
            {
                processesByName[i].Kill();
            }
            processesByName = Process.GetProcessesByName("FortniteLauncher");
            for (int i = 0; i < processesByName.Length; i++)
            {
                processesByName[i].Kill();
            }
            processesByName = Process.GetProcessesByName("EasyAntiCheat");
            for (int i = 0; i < processesByName.Length; i++)
            {
                processesByName[i].Kill();
            }
            processesByName = Process.GetProcessesByName("umodel");
            for (int i = 0; i < processesByName.Length; i++)
            {
                processesByName[i].Kill();
            }
            this.Text = swappername + " | " + swapfrom + " - " + swapto;

            label3.Text = Properties.Settings.Default.item;
            if (label3.Text == "ON")
            {
                label3.ForeColor = System.Drawing.Color.Lime;
                ConvertB.Enabled = false;
                RevertB.Enabled = true;
            }
            if (label3.Text == "OFF")
            {
                label3.ForeColor = System.Drawing.Color.Red;
                ConvertB.Enabled = true;
                RevertB.Enabled = false;
            }
        }
        public void Log(string text)
        {
           this.title.Text = this.title.Text + logtext + " " + text + Environment.NewLine;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string path = Properties.Settings.Default.PaksLocation + @"\pakchunk10_s2-WindowsClient.pak";
            if (File.Exists(path))
            {
                Log("Starting");
                RevertB.Enabled = true;
                ConvertB.Enabled = false;
                this.Swap.RunWorkerAsync();
                title.Text = "";
            }else{
                MessageBox.Show("Choose Your Pak File Location!");
            }}
        private void button2_Click(object sender, EventArgs e)
        {
            string path = Properties.Settings.Default.PaksLocation + @"\pakchunk10_s2-WindowsClient.pak";
            if (File.Exists(path))
            {
                Log("Starting");
                ConvertB.Enabled = true;
                RevertB.Enabled = false;
                this.Revert.RunWorkerAsync();
                title.Text = "";
            }else{
                MessageBox.Show("Choose Your Pak File Location!");
            }}
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.item = label3.Text;
            Properties.Settings.Default.Save();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Settings Settings = new Settings();
            Settings.ShowDialog();
        }
        private void button1_Click_2(object sender, EventArgs e)
        {
            label3.Text = "???";
            label3.ForeColor = System.Drawing.Color.White;
            ConvertB.Enabled = true;
            RevertB.Enabled = true;
            MessageBox.Show("Config Reset! (Now you can either convert or revert for this item)");
            Swap.CancelAsync();
            Revert.CancelAsync();
            title.Text = "[LOG] Convert/Revert Cancelled";
        }
        public void ReplaceBytes(string path, byte[] search, byte[] replace, int startoffset, string log)
        {
            Stream stream09 = (Stream)File.OpenRead(path);
            foreach (long offset in researcher.FindPosition(stream09, 0, startoffset, search))
            {
                stream09.Close();
                BinaryWriter binaryWriter = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
                binaryWriter.Write(replace);
                binaryWriter.Close();
                Log(log);
            }}}}
//Made by Kye | Owner of Pro Swapper
