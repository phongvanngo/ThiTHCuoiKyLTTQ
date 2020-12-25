using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ThiTHCuoiKyLTTQ
{
    public delegate void FileItemHandler(string path);
    public partial class FileItem : UserControl
    {
        public event FileItemHandler FileItemClick;

        string fileName = "";
        public FileItem(string path)
        {
            InitializeComponent();
            fileName = path;
            label1.Text = Path.GetFileName(path);
            try
            {
                Icon appIcon = Icon.ExtractAssociatedIcon(path);
                // Check if icon is null or not
                if (appIcon != null)
                {
                    // Save the icon or do something else with it..
                    pictureBox1.Image = appIcon.ToBitmap();
                }

            }
            catch (Exception)
            {

            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            FileItemClick(fileName);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FileItemClick(fileName);
        }
    }
}
