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
using VDriveFiles;
namespace MIBExplorer
{
    public partial class Form1 : Form
    {
        VDriveMibFile currentMIB;
        BindingList<string> MIBFileNames;
        public Form1()
        {
            InitializeComponent();
            MIBFileNames = new BindingList<string>();
            textBox1.Text = ".";
            MIBFiles.DataSource = MIBFileNames;
            currentMIB = null;
        }



        private void DumpButton_Click(object sender, EventArgs e)
        {
            var str = MIBFileNames[MIBFiles.SelectedIndex];
            var dir = string.Format("{0}/{1}", textBox1.Text, str.Substring(0, str.Length - 4));
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            if (currentMIB != null)
            {
                foreach (var item in currentMIB.Entries)
                {
                    if (item.isDDS)
                    {
                        var ddsFile = item.GetDDSFile();
                        ddsFile.WriteData(string.Format("{0}/{1}.dds", dir, item.InternalID));
                    }
                }
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            var str = MIBFileNames[MIBFiles.SelectedIndex];
            var dir = string.Format("{0}/{1}", textBox1.Text, str.Substring(0, str.Length - 4));
            if (Directory.Exists(dir))
            {
                if (currentMIB != null)
                {
                    foreach (var item in currentMIB.Entries)
                    {
                        if (item.isDDS)
                        {
                            DDSFile dds = new DDSFile();
                            if (dds.ReadData(string.Format("{0}/{1}.dds", dir, item.InternalID)))
                            {
                                item.UpdateFromDDS(dds);
                            }
                        }
                    }
                    currentMIB.UpdateOffsets();
                    currentMIB.WriteFile(string.Format("{0}.mib", dir));
                }
            }


        }



        private void OpenDir_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDlg = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowserDlg.ShowDialog();//=textBox1.Text;
                if (result == DialogResult.OK)
                {
                    textBox1.Text = folderBrowserDlg.SelectedPath;
                }
            }
        }

        private void MIBFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MIBFiles.SelectedIndex >= 0)
            {
                var fileName = string.Format("{0}/{1}", textBox1.Text, MIBFileNames[MIBFiles.SelectedIndex]);
                currentMIB = new VDriveMibFile(fileName);
                DDSFiles.Items.Clear();
                foreach (var item in currentMIB.Entries)
                {
                    var tempLVI = new ListViewItem(item.Name);
                    tempLVI.SubItems.Add(item.EncodingType.ToString());
                    tempLVI.SubItems.Add(item.Width.ToString());
                    tempLVI.SubItems.Add(item.Height.ToString());
                    DDSFiles.Items.Add(tempLVI);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            MIBFileNames.Clear();
            if (Directory.Exists(textBox1.Text))
            {
                foreach (var item in Directory.EnumerateFiles(textBox1.Text, "*.mib"))
                {
                    FileInfo fi = new FileInfo(item);
                    MIBFileNames.Add(fi.Name);
                }

            }
            DDSFiles.Items.Clear();
            MIBFiles.SelectedIndex = -1;
        }
    }
}
