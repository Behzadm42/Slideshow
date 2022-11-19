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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = Application.StartupPath + ("\\1");
            showimage();
        }
        int cnt = 0;
        void showimage()
        {
            //  listBox1.Items.Clear();
            listBox1.DataSource = null;
            try
            {
                
                textBox1.Text = folderBrowserDialog1.SelectedPath;
                if (folderBrowserDialog1.SelectedPath.Length != 0)
                {
                    string[] file = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.jpg");
                                    listBox1.DataSource = file.ToArray();
                  //  listBox1.Items.AddRange(file.ToArray());
                    listBox1.SelectedIndex = 0;
                    listBox1_SelectedIndexChanged(null, null);
                }
                else
                    MessageBox.Show("ridi");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.Left = 10;
            try
            {
                cnt = listBox1.SelectedIndex;
                pictureBox1.ImageLocation = listBox1.Items[cnt].ToString();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString());
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            showimage();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timernext.Enabled == true ||timerback.Enabled==true)
            {
                pictureBox1.Left = 10;
                listBox1.SelectedIndex = cnt;
                timernext.Enabled = false;
                timerback.Enabled = false;
            }
            cnt++;
            if (cnt > listBox1.Items.Count-1)
                cnt = 0;
            
         //   listBox1.SelectedIndex= cnt ;
            timernext.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (timernext.Enabled == true || timerback.Enabled == true)
            {
                pictureBox1.Left = 10;
                listBox1.SelectedIndex = cnt;
                timernext.Enabled = false;
                timerback.Enabled = false;
            }
            cnt--;
            if (cnt <0)
                cnt = listBox1.Items.Count-1;
            //  pictureBox1.ImageLocation = listBox1.Items[cnt].ToString();
            timerback.Enabled = true;
            pictureBox1.Left = 790;
        }

        private void timernext_Tick(object sender, EventArgs e)
        {

            if (pictureBox1.Left < 790)
                pictureBox1.Left += 50;
            else
            {
                pictureBox1.Left=10;
                listBox1.SelectedIndex = cnt;
                timernext.Enabled = false;
            }
        }

        private void timerback_Tick(object sender, EventArgs e)
        {
           
            if (pictureBox1.Left > 0)
                pictureBox1.Left -=50;
            else
            {
                pictureBox1.Left = 10;
                listBox1.SelectedIndex = cnt;
                timerback.Enabled = false;
            }
        }
    }
}
