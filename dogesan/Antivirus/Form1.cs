using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Antivirus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        private int viruses = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            string[] search = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.*");
            progressBar1.Maximum = search.Length;
            foreach (string item in search)
            {
                try
                {
                    StreamReader stream = new StreamReader(item);
                    string read = stream.ReadToEnd();
                    string[] virus = new string[] { "SUBSCRIBE" , "LIKE" , "COMMENT" };
                    foreach (string st in virus)
                    {
                        if (Regex.IsMatch(read, st))
                        {
                            viruses += 1;
                            listBox1.Items.Add(item);
                            button3.Show();
                            label2.Text = "Detected : " + viruses.ToString();

                        }
                        progressBar1.Increment(1);
                    }
                }
                catch
                {
                    string read = item;
                    string[] virus = new string[] { "VIRUSES", "INFECTED", "HACKED" };
                    foreach (string st in virus)
                    {
                        if (Regex.IsMatch(read, st))
                        {
                            viruses += 1;
                            listBox1.Items.Add(item);
                            button3.Show();
                            label2.Text = "Detected : " + viruses.ToString();

                        }
                        progressBar1.Increment(1);

                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Hide();
            button3.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            label1.Text = "Selected Location : " + folderBrowserDialog1.SelectedPath;
            viruses = 0;
            progressBar1.Value = 0;
            listBox1.Items.Clear();
            button2.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string removex = listBox1.Text;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            File.Delete(this.listBox1.Text);
            listBox1.Items.Clear();
            MessageBox.Show("Selected Malware Successfully Removed!");

        }
    }
}
