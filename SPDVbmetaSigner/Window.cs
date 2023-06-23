using Microsoft.VisualBasic.Logging;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static SPDVbmetaSigner.CORE;
namespace SPDVbmetaSigner
{
    public partial class Window : Form
    {
        public Window()
        {
            InitializeComponent();
            LOGGBOX = TextLogBox;
            if (!Directory.Exists("Out")) Directory.CreateDirectory("Out");
            if (!Directory.Exists("In")) Directory.CreateDirectory("In");
            if (!Directory.Exists("Work")) Directory.CreateDirectory("Work");
            AndrverBOX.Items.Add("Android_8");
            AndrverBOX.Items.Add("Android_9");
            AndrverBOX.Items.Add("Android_10");
            AndrverBOX.Items.Add("Android_11");
            RSALEN.Items.Add("RSA_4096");
            RSALEN.Items.Add("RSA_2048");
            LOGGBOX.Text = "Spreadtrum Sign Tool (WINDOWS) VBMETA";
            LOG(0, "4PDA-MOONGAMER");
            LOG(1, "Default File Size: 36700160 for recovery.img and boot.img!");
            LOG(1, "Default RSA: RSA_4096 for most devices! RSA_2048 use it, if RSA_4096 doesn't works!");
            LOG(0, "This use modified avbtool.py");
            PGG = nProgressBar1;
        }

        private void SignNowBtn_Click(object sender, EventArgs e)
        {
            int rsaleng = int.Parse(RSALEN.Text.Replace("RSA_", ""));
            int andrver = int.Parse(AndrverBOX.Text.Replace("Android_", ""));
            if (!File.Exists("In\\vbmeta-sign.img"))
            {
                LOG(0, "<<<=======[" + DateTime.Now + "]=======>>>");
                LOG(2, "File doesn't exist! ..\\In\\vbmeta-sign.img");
                return;
            }
            Progress(5);
            if (PartsI.Rows.Count == 0)
            {
                File.Copy("In\\vbmeta-sign.img", "Work\\vbmeta-bak.img", true);
                LOG(0, "Generating Vbmeta Public Key");
                KeyGenMeta(rsaleng);
                Progress(10);
                LOG(0, "Reading: In\\vbmeta-sign.img");
                readedfileHex = ReadFileInHex("In\\vbmeta-sign.img").Replace("\n", "").Replace("\r", "");
                Progress(25);
                foreach (var o in ReadAllPartitions()) PartsI.Rows.Add(false, o, (File.Exists("In\\" + o + ".img") ? new FileInfo("In\\" + o + ".img").Length : 36700160));

                LOG(0, "Writing: Work\\vbmeta-original.txt");
                File.WriteAllText("Work\\vbmeta-original.txt", readedfileHex);
                Progress(30);
                for (int i = 0; i < PartsI.Rows.Count; i++)
                {
                    var a = PartsI.Rows[i];
                    var rowPartName = a.Cells[1].Value.ToString();
                    LOG(0, "=======[" + rowPartName + "]=======");
                    byte[] partitionname = Encoding.ASCII.GetBytes(rowPartName);
                    string pattern = BytesToHexString(partitionname) + "00001000";
                    LOG(0, "Header Searching Hex: " + pattern);

                    int end = 0;
                    int index = 0;
                    while (readedfileHex.Length > index + pattern.Length && readedfileHex.Length > end + 8)
                    {
                        if (!readedfileHex.Substring(index, pattern.Length).StartsWith(pattern))
                            end = index += 2;
                        else if (!readedfileHex.Substring(end, 8).StartsWith("00000000"))
                            end += 8;
                        else
                            break;
                    }
                    Progress(i * 10 + 30);
                    string rawData = readedfileHex.Substring(index, end - index).Replace(pattern, "00001000");
                    LOG(0, "Extracting: " + rawData.Length + " Lenght");
                    byte[] rawBytes = HexStringToBytes(rawData);
                    LOG(0, "Writing: " + rawBytes.Length + " Lenght | " + rowPartName);
                    int lastIndex = Array.FindLastIndex(rawBytes, b => b != 0);
                    Array.Resize(ref rawBytes, lastIndex + 1);
                    File.WriteAllBytes("Work\\" + rowPartName + ".avbpubkey", rawBytes);
                }
                Progress(100);
                SignNowBtn.Text = "Sign Checked Images";
                return;
            }
            for (int i = 0; i < PartsI.Rows.Count; i++)
            {
                var a = PartsI.Rows[i];
                var rowPartName = a.Cells[1].Value.ToString();
                if ((bool)a.Cells[0].Value)
                {
                    LOG(0, "=======[" + rowPartName + "]=======");
                    LOG(0, "Generating Empty Vbmeta Image");
                    GenerateEmptyMeta(rowPartName, rsaleng);
                    LOG(0, "Copying Image to Work");
                    if (!File.Exists("In\\" + rowPartName + ".img"))
                    {
                        LOG(2, "File [" + rowPartName + "] Doesn't EXIST!");
                        continue;
                    }
                    File.Copy("In\\" + rowPartName + ".img", "Work\\" + rowPartName + ".img", true);
                    LOG(0, "Signing Image");
                    SignImage(rowPartName, int.Parse(a.Cells[2].Value.ToString()));
                    LOG(0, "Adding Hash Footer of image");
                    AddHashFooter(rowPartName, rsaleng);
                    LOG(0, "Copying Images to Out");
                    File.Copy("Work\\" + rowPartName + ".img", "Out\\" + rowPartName + ".img", true);
                    vbmetacreate += " --chain_partition " + rowPartName + ":" + (i + 1) + ":Work\\vbmeta.avbpubkey";
                }
                else
                    vbmetacreate += " --chain_partition " + rowPartName + ":" + (i + 1) + ":Work\\" + rowPartName + ".avbpubkey";
                Progress(i / PartsI.Rows.Count * 100);
            }
            Progress(50);
            LOG(0, "Generating Vbmeta Image");
            VbmetaCreate(rsaleng, rsaleng);
            Progress(80);
            LOG(0, "Padding Vbmeta Image");
            Android_PAD(andrver);
            Progress(90);
            LOG(0, "Finally copy Vbmeta-sign-img");
            if (File.Exists("Work\\vbmeta.img"))
                File.Copy("Work\\vbmeta.img", "Out\\vbmeta-sign.img", true);
            else
                LOG(2, "File Not generated. Error accured in =>VbmetaCreate(rsaleng, rsaleng); or ->Android_PAD(andrver);");
            File.Delete("Work\\vbmeta.img");
            Progress(100);
            vbmetacreate = "";
        }

        private void ClrBTN_Click(object sender, EventArgs e)
        {
            SignNowBtn.Text = "Extract VBMETA";
            LOG(0, "Clearing");
            Directory.Delete("Work", true);
            Directory.Delete("Out", true);
            Directory.CreateDirectory("Work");
            Directory.CreateDirectory("Out");
            PartsI.Rows.Clear();
            LOG(0, "All Clean!");
            vbmetacreate = "";
        }

        private void UlockDevBTN_Click(object sender, EventArgs e)
        {
            var result = SyncRUN(FASTBOOTCmd, "devices").ToLower();
            if (result.ToLower().Contains("fastboot"))
            {
                LOG(0, "[Device] " + result);
                LOG(0, "[Test Unlock CMDS] flashing unlock");
                result = SyncRUN(FASTBOOTCmd, "flashing unlock");
                if (isErr(result)) LOG(0, "[TEST UNLOCK] Warning SecureBoot! Trying Another Method!");
                LOG(0, "[Test Unlock CMDS] oem unlock");
                result = SyncRUN(FASTBOOTCmd, "oem unlock");
                if (isErr(result)) LOG(0, "[TEST UNLOCK] Warning SecureBoot! Trying Another Method!");
                LOG(0, "[Test Unlock CMDS] oem unlock-go");
                result = SyncRUN(FASTBOOTCmd, "oem unlock-go");
                if (isErr(result)) LOG(0, "[TEST UNLOCK] Warning SecureBoot! Trying Another Method!");
                LOG(0, "[Test Unlock CMDS] flashing critical_unlock-go");
                result = SyncRUN(FASTBOOTCmd, "flashing critical_unlock");
                if (isErr(result)) LOG(0, "[TEST UNLOCK] Warning SecureBoot! Trying Another Method!");
                LOG(0, "[Test Unlock CMDS TestFile] flashing unlock_bootloader Tools\\Ulkey.bin");
                result = SyncRUN(FASTBOOTCmd, "flashing unlock_bootloader Tools\\Ulkey.bin");
                if (isErr(result)) LOG(0, "[TEST UNLOCK] Warning SecureBoot! Trying new Method!");
                LOG(0, "[Getting Identifier SN]");
                string[] lines = SyncRUN(FASTBOOTCmd, "oem get_identifier_token").Trim().Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                
                LOG(0, "[Identifier Token] " + lines[1]);
                LOG(0, "[Writing] TempSN Work\\SNORIG.avbpubkey");
                File.WriteAllText("Work\\SNORIG.avbpubkey", SNboxTXT.Text = lines[1]);

                LOG(0, "[Generation UlKey.bin] Started");
                GenSignatureBin(lines[1], 4096, "Out\\UlKey.bin");
                LOG(0, "[Unlocking] Out\\UlKey.bin");
                result = SyncRUN(FASTBOOTCmd, "flashing unlock_bootloader Out\\Ulkey.bin");
                if (!result.Contains("fail"))
                    LOG(0, "[Bootloader] FAILED WRONG SN OR KEY OR ALREADY UNLOCKED" + result);
                else
                    LOG(0, "[Bootloader] Unlock bootloader success");
            }
        }
        private bool isErr(string i)
        {
            i = i.ToLower();
            return (i.Contains("fail") || i.Contains("not implement") || i.Contains("not ") || i.Contains("error")) && (!i.Contains("success") || !i.Contains("unlocked") || !i.Contains("locked"));
        }

        private void GenULSignBTN_Click(object sender, EventArgs e)
        {
            if (SNboxTXT.Text.Length < 80 && !SNboxTXT.Text.Any(x => char.IsLetter(x)))
                GenSignatureBin(SNboxTXT.Text, 4096, "Out\\UlKey.bin");
            else
                LOG(2, "Must be *SN_ID <= 80* and only numbers");
        }

        private void LockDevBTN_Click(object sender, EventArgs e)
        {
            var result = SyncRUN(FASTBOOTCmd, "devices").ToLower();
            if (result.ToLower().Contains("fastboot"))
            {
                LOG(0, "[Device] " + result);
                LOG(0, "[Locking Bootloader]");
                SyncRUN(FASTBOOTCmd, "flashing lock_bootloader").ToLower();
                if (isErr(result)) 
                    LOG(0, "[TEST UNLOCK] Warning SecureBoot! Failed to lock bootloader or it's already locked!");
                else
                    LOG(0, "[Bootloader] Lock bootloader success");
            }
        }

        private void DBG_CheckedChanged(object sender, EventArgs e)
        {
            debug = DBG.Checked;
        }
    }
}
