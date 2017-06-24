using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace VDriveFiles
{
    public class VDriveHeader
    {
        public int Signature { get; set; }
        public int Version { get; set; }
        public int Type { get; set; }
        public short Unk1 { get; set; }
        public short OffsetCount { get; set; }
        public List<int> Offsets { get; set; }
        public VDriveHeader() { }
        public VDriveHeader(BinaryReader br) { LoadData(br); }
        public void LoadData(BinaryReader br)
        {
            Signature = br.ReadInt32();
            Version = br.ReadInt32();
            Type = br.ReadInt32();
            Unk1 = br.ReadInt16();
            OffsetCount = br.ReadInt16();
            Offsets = new List<int>(OffsetCount);
            for (int i = 0; i < OffsetCount; i++)
            {
                Offsets.Add(br.ReadInt32());
            }
        }
    }
}
