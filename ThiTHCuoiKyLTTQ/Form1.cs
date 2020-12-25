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

namespace ThiTHCuoiKyLTTQ
{
    public partial class Form1 : Form
    {
        string currentUrl = "";

        public string CurrentUrl { get => currentUrl; set => currentUrl = value; }

        public Form1()
        {
            InitializeComponent();
            webBrowser1.Url = new Uri(@"C:\");
            comboBox1.DataSource = Environment.GetLogicalDrives();

        }

        private void webBrowser1_LocationChanged(object sender, EventArgs e)
        {


        }

        private void detailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = false;

        }

        private void iconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = true;
            flowLayoutPanel1.Controls.Clear();
            string[] allfiles;
            string[] allFolder;
            try
            {
                allfiles = Directory.GetFiles(textBox1_url.Text);
                allFolder = Directory.GetDirectories(textBox1_url.Text);
            }
            catch (Exception)
            {

            }

            foreach (string filePath in allfiles)
            {
                FileItem fileItem = new FileItem(filePath);
                fileItem.FileItemClick += FileItem_FileItemClick;
                flowLayoutPanel1.Controls.Add(fileItem);
            }

            foreach (string folder in allFolder)
            {
                FileItem fileItem = new FileItem(folder);
                fileItem.FileItemClick += FileItem_FileItemClick;
                flowLayoutPanel1.Controls.Add(fileItem);
            }

        }

        private void FileItem_FileItemClick(string path)
        {

            try
            {
                webBrowser1.Url = new Uri(path);
            }
            catch (Exception)
            {

            }
            iconToolStripMenuItem_Click(null, null);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //webBrowser1.GoBack();
            webBrowser1.GoForward();

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string url = "";
            if (webBrowser1.Url != null)
            {
                url = webBrowser1.Url.AbsoluteUri;
                textBox1_url.Text = url.Replace("file:///", "");

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            webBrowser1.Url = new Uri(comboBox1.Text);
        }

        private void button3_add_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
            iconToolStripMenuItem_Click(null, null);
        }
    }
}
