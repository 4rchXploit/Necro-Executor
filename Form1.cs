using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeAreDevs_API;

namespace ProjectLookingGLass
{
    public partial class Form1 : Form
    {
        ExploitAPI module = new ExploitAPI();

        public Form1()
        {
            InitializeComponent();
        }

        Point lastPoint;

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Functions.PopulateListBox(listBox1, "./Scripts", "*.txt");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.lua");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            module.LegacyLaunchExploit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            module.SendLuaScript(executorText.Text);
            module.SendLuaCScript(executorText.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            executorText.Clear();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            executorText.Text = File.ReadAllText($"./scripts/{listBox1.SelectedIndex}");
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                openFileDialog.Title = "Open";
                executorText.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(executorText.Text);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ScriptHub openform = new ScriptHub();
            openform.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Credits openform2 = new Credits();
            openform2.Show();
        }

        private void developer_login_Click(object sender, EventArgs e)
        {
            Login openForm_Login = new Login ();
            openForm_Login.Show();
        }
    }
}
