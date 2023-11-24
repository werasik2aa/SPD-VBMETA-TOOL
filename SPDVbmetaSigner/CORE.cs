using HuaweiUnlocker.UI;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SPDVbmetaSigner
{
    public static class CORE
    {
        public static TextBox LOGGBOX;
        public static string newline = Environment.NewLine;
        public static string readedfileHex;
        public static bool debug = false;
        public static Process CurProcess;
        public static string command = "Tools\\pythonIT";
        public static string AvbCmd = "Tools\\avbtool.py ";
        public static string SSLCmd = "Tools\\bin\\openssl ";
        public static string FASTBOOTCmd = "Tools\\fastboot ";
        public static string vbmetacreate;
        public static NProgressBar PGG;
        public static byte[] HexFileRead(string path, UInt32 Offset, int count)
        {
            BinaryReader reader = new BinaryReader(new FileStream(path, FileMode.Open));
            reader.BaseStream.Position = Offset;
            byte[] a = reader.ReadBytes(count);
            reader.Close();
            reader.Dispose();
            return a;
        }

        public static string ReadFileInHex(string path = "In\\1.img")
        {
            return BitConverter.ToString(ReadFileInBytes(path)).Replace("-", "");
        }
        public static byte[] ReadFileInBytes(string path = "In\\1.img")
        {
            return File.ReadAllBytes(path);
        }
        public static byte[] HexStringToBytes(string strInput)
        {
            try
            {
                int startIndex = 0;
                byte[] buffer = new byte[strInput.Length];
                for (int i = 0; strInput.Length > (startIndex + 1); i++)
                {
                    buffer[i] = Convert.ToByte(Convert.ToInt64(strInput.Substring(startIndex, 2), 0x10));
                    startIndex += 2;
                }
                return buffer;
            }
            catch (Exception)
            {
                LOG(2, "Hex String To Byte Array Conversion Error!");
            }
            return null;
        }
        public static string BytesToHexString(byte[] byteInput)
        {
            try
            {
                string str3 = "";
                foreach (byte num in byteInput) str3 = str3 + Conversion.Hex(num).PadLeft(2, '0');
                return str3;
            }
            catch (Exception e)
            { LOG(2, e.Message); }
            return "";
        }
        public static void LOG(int i, string o, object a = null, string sepa = " ")
        {
            string d;
            switch (i)
            {
                default:
                    d = "";
                    break;
                case 0:
                    d = "[INFO] ";
                    break;
                case 1:
                    d = "[WARNING] ";
                    break;
                case 2:
                    d = "[ERROR] ";
                    break;
            }
            o = Language.Get(o) != null ? Language.Get(o) : o;
            if (a != null)
                a = Language.Get(a.ToString()) != null ? Language.Get(a.ToString()) : a;
            LOGGBOX.AppendText(newline + d + o + sepa + a);
        }
        public static string HexDump(byte[] bytes, int bytesPerLine = 16)
        {
            if (bytes == null) return "<null>";
            int bytesLength = bytes.Length;

            char[] HexChars = "0123456789ABCDEF".ToCharArray();

            int firstHexColumn =
                  8                   // 8 characters for the address
                + 3;                  // 3 spaces

            int firstCharColumn = firstHexColumn
                + bytesPerLine * 3       // - 2 digit for the hexadecimal value and 1 space
                + (bytesPerLine - 1) / 8 // - 1 extra space every 8 characters from the 9th
                + 2;                  // 2 spaces 

            int lineLength = firstCharColumn
                + bytesPerLine           // - characters to show the ascii value
                + Environment.NewLine.Length; // Carriage return and line feed (should normally be 2)

            char[] line = (new String(' ', lineLength - Environment.NewLine.Length) + Environment.NewLine).ToCharArray();
            int expectedLines = (bytesLength + bytesPerLine - 1) / bytesPerLine;
            StringBuilder result = new StringBuilder(expectedLines * lineLength);

            for (int i = 0; i < bytesLength; i += bytesPerLine)
            {
                line[0] = HexChars[(i >> 28) & 0xF];
                line[1] = HexChars[(i >> 24) & 0xF];
                line[2] = HexChars[(i >> 20) & 0xF];
                line[3] = HexChars[(i >> 16) & 0xF];
                line[4] = HexChars[(i >> 12) & 0xF];
                line[5] = HexChars[(i >> 8) & 0xF];
                line[6] = HexChars[(i >> 4) & 0xF];
                line[7] = HexChars[(i >> 0) & 0xF];

                int hexColumn = firstHexColumn;
                int charColumn = firstCharColumn;

                for (int j = 0; j < bytesPerLine; j++)
                {
                    if (j > 0 && (j & 7) == 0) hexColumn++;
                    if (i + j >= bytesLength)
                    {
                        line[hexColumn] = ' ';
                        line[hexColumn + 1] = ' ';
                        line[charColumn] = ' ';
                    }
                    else
                    {
                        byte b = bytes[i + j];
                        line[hexColumn] = HexChars[(b >> 4) & 0xF];
                        line[hexColumn + 1] = HexChars[b & 0xF];
                        line[charColumn] = (b < 32 ? '·' : (char)b);
                    }
                    hexColumn += 3;
                    charColumn++;
                }
                result.Append(line);
            }
            return result.ToString();
        }
        public static void Progress(int perc)
        {
            PGG.Value = perc;
        }
        public static string SyncRUN(string command, string subcommand)
        {
            Process p = CurProcess = new Process();
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.FileName = command;
            p.StartInfo.Arguments = subcommand;
            p.Start();
            p.WaitForExit();
            string output = p.StandardOutput.ReadToEnd() + p.StandardError.ReadToEnd();
            if (debug)
                LOG(1, output);
            p.Close();
            p.Dispose();
            return output;
        }
        public static void AddHashFooter(string img, int RsaLength = 4096)
        {
            string subcommand = AvbCmd + "add_hash_footer --image Work\\" + img + ".img --partition_size 36700160 --partition_name " + img + " --hash_algorithm sha256 --algorithm SHA256_RSA" + RsaLength + " --key Tools\\rsa" + RsaLength + "_vbmeta.pem";
            SyncRUN(command, subcommand);
        }
        public static void SignImage(string img, int partition_size = 36700160)
        {
            string subcommand = AvbCmd + "append_vbmeta_image --image Work\\" + img + ".img --partition_size " + partition_size + " --vbmeta_image vbmeta_" + img + ".img";
            SyncRUN(command, subcommand);
        }
        public static List<string> ReadAllPartitions()
        {
            List<string> a = new List<string>();
            int end = 0;
            int index = 0;
            string pattern = "00001000";
            while (readedfileHex.Length > end + pattern.Length)
            {
                if (!readedfileHex.Substring(index, pattern.Length).StartsWith(pattern))
                    end = index++;
                else if (!readedfileHex.Substring(end, 8).StartsWith("00000000"))
                    end++;
                else
                {
                    if (index - pattern.Length - 16 > 0)
                    {
                        string rawhex = readedfileHex.Substring(index - pattern.Length - 20, 34).Trim('0');
                        string text = Encoding.ASCII.GetString(HexStringToBytes(rawhex));
                        text = Regex.Replace(text, "(?i)[^А-ЯЁA-Z_]", string.Empty);
                        if (text.Length >= 3 && !string.IsNullOrWhiteSpace(text) && !string.IsNullOrEmpty(text) && !text.Contains("AVB"))
                        {
                            a.Add(text);
                            LOG(0, "[HEX]: " + rawhex + " [" + text.Trim() + "]");
                        }
                    }
                    index++;
                }
            }
            return a;
        }
        public static void KeyGenMeta(int rsalen = 4096)
        {
            string subcommand = AvbCmd + "extract_public_key --key Tools\\rsa" + rsalen + "_vbmeta.pem --output Work\\vbmeta.avbpubkey";
            SyncRUN(command, subcommand);
        }
        public static void VbmetaCreate(int av, int rsalen = 4096)
        {
            int padd = 12288;
            switch (av)
            {
                case 8:
                    padd = 12288;
                    break;
                case 9:
                    padd = 16384;
                    break;
                case 10:
                    padd = 20480;
                    break;
                case 11:
                    padd = 20480;
                    break;
            }

            SyncRUN(command, AvbCmd + "make_vbmeta_image --output Work\\vbmeta_unchecksummed.img --key Tools\\rsa" + rsalen + "_vbmeta.pem --algorithm SHA256_RSA" + rsalen + " --padding_size " + padd + " --rollback_index 0 --flags 2" + vbmetacreate);
            FileStream fileStream = File.Open("Work\\vbmeta_unchecksummed.img", FileMode.Open);
            fileStream.SetLength(12288);
            fileStream.Close();
            fileStream.Dispose();
        }
        public static void Android_PAD(int av = 8)
        {
            av = av == 11? 10 : av;
            SyncRUN(command, "Tools\\vbmeta_pad" + av + ".py");
        }
        public static void GenerateEmptyMeta(string img, int RsaLength = 4096)
        {
            string subcommand = AvbCmd + "make_vbmeta_image --output Work\\vbmeta_" + img + ".img --key Tools\\rsa" + RsaLength + "_vbmeta.pem --algorithm SHA256_RSA" + RsaLength + " --padding_size " + RsaLength + " --rollback_index 1";
            SyncRUN(command, subcommand);
        }
        public static IEnumerable<String> SplitInParts(this String s, Int32 partLength)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s));
            if (partLength <= 0)
                throw new ArgumentException("Part length has to be positive.", nameof(partLength));

            for (var i = 0; i < s.Length; i += partLength)
                yield return s.Substring(i, Math.Min(partLength, s.Length - i));
        }
        public static void GenSignatureBin(string id, int RsaLength, string OutPath)
        {
            var bytes = new byte[id.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
                bytes[i] = Convert.ToByte(id.Substring(i * 2, 2), 16);
            id = Encoding.ASCII.GetString(bytes);
            LOG(0, "[DecryptHex]: " + id);
            LOG(0, "[Writing]: Work\\SNHEX.avbpubkey");
            File.WriteAllText("Work\\SNHEX.avbpubkey", id);
            var o = File.Open("Work\\SNHEX.avbpubkey", FileMode.Open);
            o.SetLength(80-id.Length);
            o.Close();
            o.Dispose();
            LOG(0, "[Writed]: Work\\SNHEX.avbpubkey");
            LOG(0, "[RSA Generate] UnlockSig: " + OutPath);
            SyncRUN(SSLCmd, "dgst -sha256 -out "+ OutPath + " -sign Tools\\rsa" + RsaLength + "_vbmeta.pem Work\\SNHEX.avbpubkey");
        }
    }
}
