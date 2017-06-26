using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace VDriveFiles
{
   public class DDSFile
    {
        static public int[] EncodingValues = new int []{ 827611204, 861165636, 894720068 };
        public uint Size { get; set; }
        public uint Flags { get; set; }
        public uint Width { get; set; }
        public uint Height { get; set; }
        public uint Pitch { get; set; }
        public uint Depth { get; set; }
        public uint MipMapCount { get; set; }
        public int PixelFormat { get; set; }
        public uint Caps { get; set; }
        public byte[] data;
        public void WriteData(string FileName)
        {
            using (var bw = new BinaryWriter(File.OpenWrite(FileName)))
            {
                //Fuck having to figure out how to correctly write a DDS Header, hopefully I'm doing this correct enough that the files can be used
                bw.Write(new byte[] { 0x44, 0x44, 0x53, 0x20 });
                Flags = 0x81007;
                if (MipMapCount > 1)
                    Flags |= 0x2000;
                bw.Write(Size);
                bw.Write(Flags);
                bw.Write(Height);
                bw.Write(Width);

                bw.Write(Pitch);
                bw.Write(Depth);
                bw.Write(MipMapCount);
                for (int i = 0; i < 11; i++)
                {
                    bw.Write(0);
                }
                bw.Write(32);
                bw.Write(4);
                //this is just based on observation and guessing.

                bw.Write(PixelFormat);
                for (int i = 0; i < 5; i++)
                {
                    bw.Write(0);
                }
                bw.Write(Caps);
                for (int i = 0; i < 4; i++)
                {
                    bw.Write(0);
                }
                if (data != null)
                    bw.Write(data);
            }
        }
        public bool ReadData(string fileName)
        {
            using (var br = new BinaryReader(File.OpenRead(fileName)))
            {
                var magic=br.ReadInt32();//read magic
                if (magic == 0x20534444)
                {
                    Size = br.ReadUInt32();
                    Flags = br.ReadUInt32();
                    Height = br.ReadUInt32();

                    Width = br.ReadUInt32();
                    Pitch = br.ReadUInt32();
                    Depth = br.ReadUInt32();
                    MipMapCount = br.ReadUInt32();
                    for (int i = 0; i < 13; i++)
                    {
                        br.ReadUInt32();
                    }
                    PixelFormat = br.ReadInt32();
                    for (int i = 0; i < 5; i++)
                    {
                        br.ReadUInt32();
                    }
                    Caps = br.ReadUInt32();
                    for (int i = 0; i < 4; i++)
                    {
                        br.ReadUInt32();
                    }
                    int len = (int)br.BaseStream.Length - 128;
                    data = br.ReadBytes(len);
                    return true;
                }
            }
            return false;
        }

    }
}
