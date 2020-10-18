using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
namespace KyeSwapperTemplate
{
    public class Swapper
    {
        public static void CloseFN()
        {
            Process[] processlist = Process.GetProcesses();
            foreach (Process theprocess in processlist)
            {
                if (theprocess.ProcessName.Contains("FortniteLauncher") | theprocess.ProcessName.Contains("EasyAntiCheat") | theprocess.ProcessName.Contains("FortniteClient") | theprocess.ProcessName.Contains("EpicGamesLauncher") | theprocess.ProcessName.Contains("UnrealCEFSubProcess") | theprocess.ProcessName.Equals("umodel") | theprocess.ProcessName.Equals("FModel"))
                {
                    theprocess.Kill();
                    if (theprocess.ProcessName.Equals("FortniteClient-Win64-Shipping"))
                    {
                        MessageBox.Show("Closed Fortnite (Fortnite needs to be closed)!", Form1.swappername, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }


        private static readonly string[] drives = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        public static string GetEpicDir()
        {
            foreach (string letter in drives)//Searches all drives for LauncherInstalled.dat
            {
                if (File.Exists(letter + @":\ProgramData\Epic\UnrealEngineLauncher\LauncherInstalled.dat"))
                    return letter + @":\ProgramData\Epic\UnrealEngineLauncher\LauncherInstalled.dat";
            }
            return "a";
        }


        public static void Swap(string path, byte[] search, byte[] replace, long startoffset)
        {
            CloseFN();
            Stream swap = File.OpenRead(path);
            foreach (long offset in FindPosition(swap, 0, startoffset, search))
            {
                swap.Close();
                BinaryWriter binaryWriter = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
                binaryWriter.Write(replace);
                binaryWriter.Close();
            }
        }

        static List<long> FindPosition(Stream stream, int searchPosition, long startIndex, byte[] searchPattern)
        {
            List<long> searchResults = new List<long>();

            stream.Position = startIndex;

            while (true)
            {
                if (stream.Position == 5000000000)
                {
                    return searchResults;
                }

                var latestbyte = stream.ReadByte();
                if (latestbyte == -1)
                {
                    break;
                }

                if (latestbyte == searchPattern[searchPosition])
                {
                    searchPosition++;
                    if (searchPosition == searchPattern.Length)
                    {
                        searchResults.Add(stream.Position - searchPattern.Length);
                        return searchResults;
                    }
                }
                else
                {
                    searchPosition = 0;
                }
            }

            return searchResults;
        }
    }
}
