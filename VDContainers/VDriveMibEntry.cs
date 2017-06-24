using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace VDriveFiles
{
    public class VDriveMibEntry : VDriveEntry
    {
        //Mostly a reference more than anything else
        public int EncodingType { get; set; }//I know that 8 is DXT1 and 10 is DXT5
        public ushort Width { get; set; }
        public ushort Height { get; set; }
        public short Unk1 { get; set; }//Usually 512
        public byte ImgType { get; set; }//I'm not quite sure on this could be something else
        public byte MimmapLevels { get; set; }
        //Have no fucking clue on the next three values
        public byte Unk2 { get; set; }
        public byte Unk3 { get; set; }
        public short Unk4 { get; set; }
        public short SameAsDataSize { get; set; }
        //The next three are some sort of flags
        public short Unk5 { get; set; }
        public short Unk6 { get; set; }
        public short Unk7 { get; set; }
        public string Name { get; set; }
        public byte[] data { get; set; }
        public VDriveMibEntry()
        {

        }
        public VDriveMibEntry(BinaryReader br)
        {
            LoadData(br);

        }
        override public void LoadData(BinaryReader br)
        {
            var offset = br.BaseStream.Position;
            base.LoadData(br);
            EncodingType = br.ReadInt32();
            Height = br.ReadUInt16();
            Width = br.ReadUInt16();
            Unk1 = br.ReadInt16();
            ImgType = br.ReadByte();
            MimmapLevels = br.ReadByte();
            Unk2 = br.ReadByte();
            Unk3 = br.ReadByte();
            Unk4 = br.ReadInt16();
            SameAsDataSize = br.ReadInt16();
            Unk5 = br.ReadInt16();
            Unk6 = br.ReadInt16();
            Unk7 = br.ReadInt16();
            byte curr = 0;
            StringBuilder builder = new StringBuilder();
            do
            {
                curr = br.ReadByte();
                builder.Append(Convert.ToChar(curr));
            } while (curr!=0);
            Name = builder.ToString();
            br.BaseStream.Seek(offset+EntrySize, SeekOrigin.Begin);
            data = br.ReadBytes(DataSize);


        }
    }
}
