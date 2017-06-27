using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
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
        public string InternalID { get; set; }
        public static Dictionary<int, int> DXTMapping = new Dictionary<int, int>();
        static bool RunInit = false;
        static void InitMapping()
        {
            DXTMapping.Add(827611204, 8);
            DXTMapping.Add(861165636, 9);
            DXTMapping.Add(894720068, 10);
            RunInit = true;

        }

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
            Width = br.ReadUInt16();
            Height = br.ReadUInt16();
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
            List<byte> nameBytes = new List<byte>();
            StringBuilder builder = new StringBuilder();
            do
            {
                curr = br.ReadByte();
                    nameBytes.Add(curr);
                
            } while (curr!=0);
            Name= Encoding.GetEncoding("SHIFT-JIS").GetString(nameBytes.ToArray());
            Name = Name.Substring(0, Name.Length - 1);
           /// Name = builder.ToString();
            br.BaseStream.Seek(offset+EntrySize, SeekOrigin.Begin);
            data = br.ReadBytes(DataSize);


        }
        public void UpdateData(byte[] newData)
        {
            DataSize = newData.Length;
            SameAsDataSize = (short)DataSize;
            data = newData;

        }
        override public void WriteData(BinaryWriter bw)
        {
            var offset = bw.BaseStream.Position;
            base.WriteData(bw);
            bw.Write(EncodingType);
            bw.Write(Width);
            bw.Write(Height);
            bw.Write(Unk1);
            bw.Write(ImgType);
            bw.Write(MimmapLevels);
            bw.Write(Unk2);
            bw.Write(Unk3);
            bw.Write(Unk4);
            bw.Write(SameAsDataSize);
            bw.Write(Unk5);
            bw.Write(Unk6);
            bw.Write(Unk7);
            bw.Write(Encoding.GetEncoding("SHIFT-JIS").GetBytes(Name));
            var paddingStart = bw.BaseStream.Position;
            for (long i = paddingStart; i < offset + EntrySize; i++)
            {
                bw.Write((byte)0);
            }
            bw.BaseStream.Seek(offset + EntrySize, SeekOrigin.Begin);
            bw.Write(data, 0, DataSize);
            
        }
        public  DDSFile GetDDSFile()
        {
            var ddsFile= new DDSFile();
            ddsFile.Size = 124;
            ddsFile.Height = Height;
            ddsFile.Width = Width;
            ddsFile.MipMapCount = (uint)(MimmapLevels - 1);
            ddsFile.PixelFormat =DDSFile.EncodingValues[EncodingType-8];
            ddsFile.Pitch = 0;
            ddsFile.Depth = 0;
            if (MimmapLevels > 1)
                ddsFile.Caps = 8 | 0x400000;
            else
                ddsFile.Caps = 0;
            ddsFile.Caps |= 0x1000;
            ddsFile.data = data;
            return ddsFile;
        }
        public bool isDDS
        {
            get
            {
                return ImgType == 3;
            }
        }
        public void UpdateFromDDS(DDSFile file)
        {
            if (!RunInit)
                InitMapping();
            data = file.data;
            DataSize = file.data.Length;
            SameAsDataSize = (short)file.data.Length;
            Width = (ushort)file.Width;
            Height = (ushort)(file.Height);
            MimmapLevels = (byte)(file.MipMapCount + 1);
            EncodingType = DXTMapping[file.PixelFormat];
        }
    }
}
