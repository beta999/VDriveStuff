using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ConsoleApplication2
{
   public class DDSHeader
    {
      public uint Size { get; set; }
        public uint Flags { get; set; }
        public uint Height { get; set; }
        public uint Width { get; set; }
        public uint Pitch { get; set; }
        public uint Depth { get; set; }
        public uint MipMapCount { get; set; }
        public int PixelFormat { get; set; }
        public uint Caps { get; set; }
        public void WriteData(BinaryWriter bw)
        {
            //Fuck having to figure out how to correctly write a DDS Header, hopefully I'm doing this correct enough that the files can be used
            Flags = 0x81007;
            if (MipMapCount > 1)
                Flags |= 0x2000;
            bw.Write(Size);
            bw.Write(Flags);
            bw.Write(Width);
            bw.Write(Height);
            bw.Write(Pitch);
            bw.Write(Depth);
            bw.Write(MipMapCount-1);
            for (int i = 0; i < 11; i++)
            {
                bw.Write(0);
            }
            bw.Write(32);
            bw.Write(4);
            //this is just based on observation and guessig.
            if(PixelFormat==8)
            {
                byte[] dat = { 0x44, 0x58, 0x54, 0x31 };
                bw.Write(dat);
            }
            else if(PixelFormat == 10)
            {
                byte[] dat = { 0x44, 0x58, 0x54, 0x35 };
                bw.Write(dat);
            }
            else if (PixelFormat == 9)
            {
                byte[] dat = { 0x44, 0x58, 0x54, 0x33 };
                bw.Write(dat);
            }
            for (int i = 0; i < 5; i++)
            {
                bw.Write(0);
            }
            bw.Write(Caps);
            for (int i = 0; i < 4; i++)
            {
                bw.Write(0);
            }
        }
    }
}
