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

using VDriveFiles;
namespace MSBExplorer
{
    public partial class Form1 : Form
    {
        BindingList<string> MSBFileNames;
        VDriveMSBFile currentMSB;
        public Form1()
        {
            InitializeComponent();
            MSBFileNames = new BindingList<string>();
            textBox1.Text = ".";
            MSBFiles.DataSource = MSBFileNames;
        }

        private void MSBFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MSBFiles.SelectedIndex >= 0)
            {
                var fileName = string.Format("{0}/{1}", textBox1.Text, MSBFileNames[MSBFiles.SelectedIndex]);
                currentMSB = new VDriveMSBFile(fileName);
                meshInfo.Items.Clear();
                int i = 0;
                foreach (var item in currentMSB.Header.Offsets)
                {
                    var tempLVI = new ListViewItem(item.ToString());
                    tempLVI.SubItems.Add(currentMSB.Meshes[i].Type.ToString());
                    tempLVI.SubItems.Add(currentMSB.Meshes[i].Count.ToString());
                    meshInfo.Items.Add(tempLVI);
                    i++;
                }

            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            MSBFileNames.Clear();
            if (Directory.Exists(textBox1.Text))
            {
                foreach (var item in Directory.EnumerateFiles(textBox1.Text, "*.msb"))
                {
                    FileInfo fi = new FileInfo(item);
                    MSBFileNames.Add(fi.Name);
                }

            }
            meshInfo.Items.Clear();
            MSBFiles.SelectedIndex = -1;

        }

        private void meshInfo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
