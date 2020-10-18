using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace KyeSwapperTemplate
{
    public partial class Form1 : Form
    {
        /* | By Kye (Owner of Pro Swapper)
        * 
        * 
        * ====
        * Please look in help.txt (in the solution explorer) for more info
        * ====
        */
        public static string swappername = "Kye's Swapper Template";
        string swapfrom = "Swap From Item"; //Write what item it swaps from
        string swapto = "Swap To Item";//Write what item it swaps to
        bool showswaptime = true; //Shows how many ms (milliseconds) it took for the item to swap, by default its on true

        string path0 = (Properties.Settings.Default.Paks + @"\pakchunk0-WindowsClient.pak");
        string path3 = (Properties.Settings.Default.Paks + @"\pakchunk10_s2-WindowsClient.pak");

        byte[] search1 = new byte[]//Search
        {
            0
        };
        
        byte[] replace1 = new byte[]//Replace
        {
            0
        };

        long swap1offset = 0;
        
        private void Swap_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Stopwatch s = new Stopwatch();
            s.Start();


            //Swaps Swapper.Swap(string pakslocation, byte array to search, byte array to replace, long to start offset)
            Swapper.Swap(path3, search1, replace1, swap1offset);


            Log("Converted Item");
            label3.Text = "ON";
            label3.ForeColor = Color.Lime;
            s.Stop();
            if (showswaptime)
            {
                Log("Converted in " + s.ElapsedMilliseconds + "ms");
            }
        }

        private void Revert_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Stopwatch s = new Stopwatch();
            s.Start();


            //Swaps Swapper.Swap(string pakslocation, byte array to search, byte array to replace, long to start offset)
            //On revert swap the search and replace like below
            Swapper.Swap(path3, replace1, search1, swap1offset);



            Log("Reverted Item");
            label3.Text = "OFF";
            label3.ForeColor = Color.Red;
            s.Stop();
            if (showswaptime)
            {
                Log("Reverted in " + s.ElapsedMilliseconds + "ms");
            }
        }
        
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Swapper.CloseFN();
            this.Text = swappername + " | " + swapfrom + " - " + swapto;

            label3.Text = Properties.Settings.Default.item;
            switch (label3.Text)
            {
                case "ON":
                    label3.ForeColor = Color.Lime;
                    ConvertB.Enabled = false;
                    RevertB.Enabled = true;
                    break;

                case "OFF":
                    label3.ForeColor = Color.Red;
                    ConvertB.Enabled = true;
                    RevertB.Enabled = false;
                    break;
            }
        }
        void Log(string txt)
        {
           this.title.Text += "[+]" + txt + Environment.NewLine;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists(path0))
            {
                RevertB.Enabled = true;
                ConvertB.Enabled = false;
                this.Swap.RunWorkerAsync();
                title.Clear();
            }
            else
                MessageBox.Show("Choose your paks location");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists(path0))
            {
                ConvertB.Enabled = true;
                RevertB.Enabled = false;
                this.Revert.RunWorkerAsync();
                title.Clear();
            }
            else
                MessageBox.Show("Choose your paks location");
        }
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
            label3.ForeColor = Color.White;
            ConvertB.Enabled = true;
            RevertB.Enabled = true;
            MessageBox.Show("Config Reset! (Now you can either convert or revert for this item)");
            Swap.CancelAsync();
            Revert.CancelAsync();
            title.Text = "[+] Convert/Revert Cancelled";
        }
    }
}
//Made by Kye | Owner of Pro Swapper
