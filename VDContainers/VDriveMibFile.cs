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
                int i = 0;
                foreach (var item in Header.Offsets)
                {
                    br.BaseStream.Seek(item,SeekOrigin.Begin);
                    var tempEntry = new VDriveMibEntry(br);
                    Entries.Add(tempEntry);
                    tempEntry.InternalID = string.Format("{0}_({1})", tempEntry.Name, i);
                    i++;
                }
            }
        }
        public void UpdateOffsets()
        {
            int curr_offset = Header.Offsets[0];
            Header.Offsets = new List<int>();
            foreach (var item in Entries)
            {
                Header.Offsets.Add(curr_offset);
                curr_offset += item.DataSize + item.EntrySize;
            }
        }
        public void WriteFile(string FileName)
        {
            using (var bw = new BinaryWriter(File.OpenWrite(FileName)))
            {
                Header.WriteData(bw);

                foreach (var item in Entries.Zip(Header.Offsets,(x,y)=>new { x, y }))
                {
                    bw.BaseStream.Seek(item.y, SeekOrigin.Begin);
                    item.x.WriteData(bw);
                }
            }
        }
        
    }
}
