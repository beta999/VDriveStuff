using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace VDriveFiles
{
    public class VDriveEntry
    {
        public int offset { get; set; }
        public int Magic { get; set; }
        public int DataSize { get; set; }
        public int EntrySize { get; set; }
        public short Type { get; set; }
        public short Count { get; set; }

        public VDriveEntry()
        {
            
        }
        virtual public void LoadData(BinaryReader br)
        {
            Magic = br.ReadInt32();
            DataSize = br.ReadInt32();
            EntrySize = br.ReadInt32();
            Type = br.ReadInt16();
            Count = br.ReadInt16();
        }
        virtual public void WriteData(BinaryWriter bw)
        {
            bw.Write(Magic);
            bw.Write(DataSize);
            bw.Write(EntrySize);
            bw.Write(Type);
            bw.Write(Count);
        }
        public VDriveEntry(BinaryReader br)
        {

            LoadData(br);
        }
    }
}
