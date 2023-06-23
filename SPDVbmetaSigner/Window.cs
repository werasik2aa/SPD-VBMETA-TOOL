using System;
using System.IO;
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
        }

        private void SignNowBtn_Click(object sender, EventArgs e)
        {
            int rsaleng = int.Parse(RSALEN.Text.Replace("RSA_", ""));
            int andrver = int.Parse(AndrverBOX.Text.Replace("Android_", ""));
            LOG(0, "<<<=======[" + DateTime.Now + "]=======>>>");
            if(!File.Exists("In\\vbmeta-sign.img"))
            {
                LOG(2, "File doesn't exist! ..\\In\\vbmeta-sign.img");
                return;
            }
            if (PartsI.Rows.Count == 0)
            {
                File.Copy("In\\vbmeta-sign.img", "Work\\vbmeta-bak.img", true);
                LOG(0, "Generating Vbmeta Public Key");
                KeyGenMeta(rsaleng);
                LOG(0, "Reading: In\\vbmeta-sign.img");
                readedfileHex = ReadFileInHex("In\\vbmeta-sign.img").Replace("\n", "").Replace("\r", "");

                foreach (var o in ReadAllPartitions()) PartsI.Rows.Add(false, o.Key, (File.Exists("In\\" + o + ".img") ? new FileInfo("In\\" + o + ".img").Length : 36700160));

                LOG(0, "Writing: Work\\vbmeta-original.txt");
                File.WriteAllText("Work\\vbmeta-original.txt", readedfileHex);
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

                    string rawData = readedfileHex.Substring(index, end - index).Replace(pattern, "00001000");
                    LOG(0, "Extracting: " + rawData.Length + " Lenght");
                    byte[] rawBytes = HexStringToBytes(rawData);
                    LOG(0, "Writing: " + rawBytes.Length + " Lenght | " + rowPartName);
                    File.WriteAllBytes("Work\\" + rowPartName.Trim() + ".avbpubkey", rawBytes);
                }
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
                    if(!File.Exists("In\\"+ rowPartName + ".img"))
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
            }
            LOG(0, "Generating Vbmeta Image");
            VbmetaCreate(rsaleng, rsaleng);
            LOG(0, "Padding Vbmeta Image");
            Android_PAD(andrver);

            LOG(0, "Finally copy Vbmeta-sign-img");
            if (File.Exists("Work\\vbmeta.img"))
                File.Copy("Work\\vbmeta.img", "Out\\vbmeta-sign.img", true);
            else
                LOG(2, "File Not generated. Error accured in =>VbmetaCreate(rsaleng, rsaleng); or ->Android_PAD(andrver);");
            File.Delete("Work\\vbmeta.img");
        }

        private void ClrBTN_Click(object sender, EventArgs e)
        {
            SignNowBtn.Text = "Extract Headers";
            LOG(0, "Clearing");
            Directory.Delete("Work", true);
            Directory.Delete("Out", true);
            Directory.CreateDirectory("Work");
            Directory.CreateDirectory("Out");
            PartsI.Rows.Clear();
            LOG(0, "All Clean!");
        }
    }
}
