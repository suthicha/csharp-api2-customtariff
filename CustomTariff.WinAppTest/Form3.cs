using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomTariff.WinAppTest
{
    public partial class Form3 : Form
    {
        public Form3()

        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var content = RemoveLineEndings(richTextBox1.Text);
            richTextBox2.Text = RemoveWhiteSpace(content);
        }

        private string RemoveLineEndings(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return value;
            }
            string lineSeparator = ((char)0x2028).ToString();
            string paragraphSeparator = ((char)0x2029).ToString();

            return value.Replace("\r\n", string.Empty).Replace("\n", string.Empty).Replace("\r", string.Empty).Replace(lineSeparator, string.Empty).Replace(paragraphSeparator, string.Empty);
        }

        private string RemoveWhiteSpace(string content)
        {
            return content.Replace(" ", "").Replace(" ", "").Replace(".", "");
        }

        private List<string> DeepTarrif(string content)
        {
            var lstTariff = new List<string>();

            while (content.Length > 0)
            {
                string padContent = "";
                string padText = content.Substring(0, 2);
                int delLength = 0;

                if (padText == "ex")
                {
                    padContent = content.Substring(0, 10);
                    delLength = 10;
                }
                else
                {
                    padContent = content.Substring(0, 8);
                    delLength = 8;
                }

                lstTariff.Add(padContent);
                content = content.Remove(0, delLength);
            }
            return lstTariff;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = DeepTarrif(richTextBox2.Text);
        }
    }
}