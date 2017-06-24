using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace VDriveFiles
{
  public  class VDriveMibFile
    {
        public VDriveHeader Header { get; set; }
        public List<VDriveMibEntry> Entries { get; set; }
        public VDriveMibFile(string fileName)
        {
            LoadFile(fileName);
        }
        public void LoadFile(string fileName)
        {
            using (var br = new BinaryReader(File.OpenRead(fileName)))
            {
                Header = new VDriveHeader(br);
                Entries = new List<VDriveMibEntry>();
                foreach (var item in Header.Offsets)
                {
                    br.BaseStream.Seek(item,SeekOrigin.Begin);
                    Entries.Add(new VDriveMibEntry(br));
                }
            }
        }
    }
}
