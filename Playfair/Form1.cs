using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Linq;

namespace Playfair
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Inputkey.TextChanged += new EventHandler(onInputKeyChange);
            this.Encrypt.Click += new EventHandler(encrypt);
            this.Decrypt.Click += new EventHandler(decrypt);
            this.radioButton5x5.CheckedChanged += new EventHandler(onInputKeyChange);
            this.radioButton6x6.CheckedChanged += new EventHandler(onInputKeyChange);
        }

        Char[,] keyTable = new char[5, 5];
        Char[,] keyTable6 = new char[6, 6];
        private void onInputKeyChange(object sender, EventArgs e)
        {
            if (radioButton5x5.Checked)
            {
                char[] alphabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ".ToCharArray();
                String key = new String(this.Inputkey.Text.Distinct().ToArray());
                Regex rgx = new Regex("[^A-Z]");
                key = rgx.Replace(key, "");
                this.Inputkey.Text = key;

                //Tu dong dua con tro ve cuoi dong
                this.Inputkey.SelectionStart = this.Inputkey.Text.Length == 0 ? 0 : this.Inputkey.Text.Length;
                this.Inputkey.SelectionLength = 0;

                for (int i = 0; i < key.Length; i++)
                {
                    for (int j = 0; j < alphabet.Length; j++)
                    {
                        if (alphabet[j] == key[i])
                        {
                            alphabet[j] = ' ';
                        }
                        if ((key[i] == 'J') && (alphabet[j] == 'I'))
                        {
                            alphabet[j] = ' ';
                        }
                    }
                }
                var keyString = key + new string(alphabet);
                keyString = Regex.Replace(keyString, @"\s+", "");
                var keyShow = "";
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        var index = i * 5 + j;
                        keyTable[i, j] = keyString[index];
                        if ((keyString[index] == 'I') || (keyString[index] == 'J'))
                        {
                            keyShow += "I" + "     ";
                        }
                        else keyShow += keyString[index] + "    ";
                    }
                    keyShow += "\r\n";
                }
                this.Outputkey.Text = keyShow;
            }
            if (radioButton6x6.Checked)
            {
                char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();

                String key = new String(this.Inputkey.Text.Distinct().ToArray());
                Regex rgx = new Regex("[^A-Z0-9]");
                key = rgx.Replace(key, "");
                this.Inputkey.Text = key;

                //Tu dong dua con tro ve cuoi dong
                this.Inputkey.SelectionStart = this.Inputkey.Text.Length == 0 ? 0 : this.Inputkey.Text.Length;
                this.Inputkey.SelectionLength = 0;

                for (int i = 0; i < key.Length; i++)
                {
                    for (int j = 0; j < alphabet.Length; j++)
                    {
                        if (alphabet[j] == key[i])
                        {
                            alphabet[j] = ' ';
                        }
                        if ((key[i] == 'J') && (alphabet[j] == 'I'))
                        {
                            alphabet[j] = ' ';
                        }
                    }
                }
                var keyString = key + new string(alphabet);
                keyString = Regex.Replace(keyString, @"\s+", "");
                var keyShow = "";
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        var index = i * 6 + j;
                        keyTable6[i, j] = keyString[index];
                        if ((keyString[index] == 'I') || (keyString[index] == 'J'))
                        {
                            keyShow += "I" + "  ";
                        }
                        else keyShow += keyString[index] + "  ";
                    }
                    keyShow += "\r\n";
                }
                this.Outputkey.Text = keyShow;


            }
        }
        private void encrypt(object sender, EventArgs e)
        {
            if (radioButton5x5.Checked)
            {
                Regex rgx = new Regex("[^A-Z]");
                String message = rgx.Replace(this.Input.Text, "");
                rgx = new Regex("[J]");
                message = rgx.Replace(message, "I");
                if (message.Length % 2 != 0)
                {
                    message += 'X';
                }
                String keyString = "";
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        keyString += keyTable[i, j];
                    }
                }
                String result = "";
                for (int i = 0; i < message.Length - 1; i += 2)
                {
                    int indexA = keyString.IndexOf(message[i]);
                    int indexB = keyString.IndexOf(message[i + 1]);
                    int yA = indexA / 5;
                    int xA = indexA - 5 * yA;
                    int yB = indexB / 5;
                    int xB = indexB - 5 * yB;
                    if (xA == xB)
                    {
                        // Cung mot cot, thay the bang ki tu ben duoi.
                        result += keyTable[(yA + 1) % 5, xA].ToString() + keyTable[(yB + 1) % 5, xB].ToString();
                    }
                    else if (yA == yB)
                    {
                        // Cung mot hang, thay the bang ki tu ben phai.
                        result += keyTable[yA, (xA + 1) % 5].ToString() + keyTable[yB, (xB + 1) % 5].ToString();
                    }
                    else
                    {
                        // Tao thanh hinh chu nhat, thay the bang 2 goc con lai.
                        result += keyTable[yA, xB].ToString() + keyTable[yB, xA].ToString();
                    }
                    result += " ";
                }
                this.Output.Text = result;
            }
            if (radioButton6x6.Checked)
            {
                Regex rgx6 = new Regex("[^A-Z0-9]");
                String message6 = rgx6.Replace(this.Input.Text, "");
                rgx6 = new Regex("[J]");
                message6 = rgx6.Replace(message6, "I");
                if (message6.Length % 2 != 0)
                {
                    message6 += 'X';
                }
                String keyString6 = "";
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        keyString6 += keyTable6[i, j];
                    }
                }
                String result6 = "";
                for (int i = 0; i < message6.Length - 1; i += 2)
                {
                    int indexA = keyString6.IndexOf(message6[i]);
                    int indexB = keyString6.IndexOf(message6[i + 1]);
                    int yA = indexA / 6;
                    int xA = indexA - 6 * yA;
                    int yB = indexB / 6;
                    int xB = indexB - 6 * yB;
                    if (xA == xB)
                    {
                        // Cung mot cot, thay the bang ki tu ben duoi.
                        result6 += keyTable6[(yA + 1) % 6, xA].ToString() + keyTable6[(yB + 1) % 6, xB].ToString();
                    }
                    else if (yA == yB)
                    {
                        // Cung mot hang, thay the bang ki tu ben phai.
                        result6 += keyTable6[yA, (xA + 1) % 6].ToString() + keyTable6[yB, (xB + 1) % 6].ToString();
                    }
                    else
                    {
                        // Tao thanh hinh chu nhat, thay the bang 2 goc con lai.
                        result6 += keyTable6[yA, xB].ToString() + keyTable6[yB, xA].ToString();
                    }
                    result6 += " ";
                }
                this.Output.Text = result6;
            }


        }
        private void decrypt(object sender, EventArgs e)
        {
            if (radioButton5x5.Checked)
            {
                Regex rgx = new Regex("[^A-Z]");
                String message = rgx.Replace(this.Input.Text, "");
                rgx = new Regex("[J]");
                message = rgx.Replace(message, "I");
                if (message.Length % 2 != 0)
                {
                    message += 'X';
                }
                String keyString = "";
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        keyString += keyTable[i, j];
                    }
                }
                String result = "";
                for (int i = 0; i < message.Length - 1; i += 2)
                {
                    int indexA = keyString.IndexOf(message[i]);
                    int indexB = keyString.IndexOf(message[i + 1]);
                    int yA = indexA / 5;
                    int xA = indexA - 5 * yA;
                    int yB = indexB / 5;
                    int xB = indexB - 5 * yB;
                    if (xA == xB)
                    {
                        // Cung mot cot, thay the bang ki tu ben tren.
                        if (yA == 0) yA = 5;
                        if (yB == 0) yB = 5;
                        result += keyTable[(yA - 1) % 5, xA].ToString() + keyTable[(yB - 1) % 5, xB].ToString();
                    }
                    else if (yA == yB)
                    {
                        // Cung mot hang, thay the bang ki tu ben trai.
                        if (xA == 0) xA = 5;
                        if (xB == 0) xB = 5;
                        result += keyTable[yA, (xA - 1) % 5].ToString() + keyTable[yB, (xB - 1) % 5].ToString();
                    }
                    else
                    {
                        // Tao thanh hinh chu nhat, thay the bang 2 goc con lai.
                        result += keyTable[yA, xB].ToString() + keyTable[yB, xA].ToString();
                    }
                }
                this.Output.Text = result;
            }
            if (radioButton6x6.Checked)
            {
                Regex rgx6 = new Regex("[^A-Z0-9]");
                String message6 = rgx6.Replace(this.Input.Text, "");
                rgx6 = new Regex("[J]");
                message6 = rgx6.Replace(message6, "I");
                if (message6.Length % 2 != 0)
                {
                    message6 += 'X';
                }
                String keyString6 = "";
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        keyString6 += keyTable6[i, j];
                    }
                }
                String result6 = "";
                for (int i = 0; i < message6.Length - 1; i += 2)
                {
                    int indexA = keyString6.IndexOf(message6[i]);
                    int indexB = keyString6.IndexOf(message6[i + 1]);
                    int yA = indexA / 6;
                    int xA = indexA - 6 * yA;
                    int yB = indexB / 6;
                    int xB = indexB - 6 * yB;
                    if (xA == xB)
                    {
                        // Cung mot cot, thay the bang ki tu ben tren.
                        if (yA == 0) yA = 6;
                        if (yB == 0) yB = 6;
                        result6 += keyTable6[(yA - 1) % 6, xA].ToString() + keyTable6[(yB - 1) % 6, xB].ToString();
                    }
                    else if (yA == yB)
                    {
                        // Cung mot hang, thay the bang ki tu ben trai.
                        if (xA == 0) xA = 6;
                        if (xB == 0) xB = 6;
                        result6 += keyTable6[yA, (xA - 1) % 6].ToString() + keyTable6[yB, (xB - 1) % 6].ToString();
                    }
                    else
                    {
                        // Tao thanh hinh chu nhat, thay the bang 2 goc con lai.
                        result6 += keyTable6[yA, xB].ToString() + keyTable6[yB, xA].ToString();
                    }
                }
                this.Output.Text = result6;
            }
        }
        private void Inputkey_TextChanged(object sender, EventArgs e)
        {

        }
    }
}