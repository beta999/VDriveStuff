using System;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Linq;
using System.Collections.Generic;
using VDriveFiles;

namespace MIBUtil
{
    class Program
    {
        static void dump(string fileName)
        {
            VDriveMibFile file = new VDriveMibFile(fileName);
            int i = 0;
            string dir = fileName.Substring(0, fileName.Length - 4);
            Directory.CreateDirectory(dir);
            using (var mapping = new StreamWriter(dir + "\\mapping.txt"))
            {
                foreach (var item in file.Entries)
                {
                    FileInfo finfo = new FileInfo(fileName);
                    //This should work otherwise I need to figure out a better method of figuring out if it uses a GXT file
                    if (item.ImgType == 0)
                    {
                        //Just going to output raw GXT data for now
                        File.WriteAllBytes(string.Format("{0}/tex{1}.GXT", dir, i), item.data);
                        mapping.WriteLine("{0}={1}", file.Header.Offsets[i]+item.EntrySize, string.Format("{0}/tex{1}.GXT", dir, i));
                        /*
                        GXT gxt = new GXT();
                        gxt.Open(new MemoryStream(item.data));
                        gxt.GetBitmap().Save(string.Format("{0}/{0}/{1}.png", dir, i), System.Drawing.Imaging.ImageFormat.Png);
                        */
                    }
                    else if (item.ImgType == 3)
                    {
                        mapping.WriteLine("{0}={1}", file.Header.Offsets[i] + item.EntrySize, string.Format("{0}\\tex{1}.dds", dir, i));

                        DDSHeader ddsHeader = new DDSHeader();
                        ddsHeader.Size = 124;
                        ddsHeader.Height = item.Height;
                        ddsHeader.Width = item.Width;
                        ddsHeader.MipMapCount = item.MimmapLevels;
                        ddsHeader.PixelFormat = item.EncodingType;
                        ddsHeader.Pitch = 0;
                        ddsHeader.Depth = 0;
                        if (item.MimmapLevels > 1)
                            ddsHeader.Caps = 8 | 0x400000;
                        else
                            ddsHeader.Caps = 0;
                        ddsHeader.Caps |= 0x1000;
                        using (var bw = new BinaryWriter(File.OpenWrite(string.Format("{0}\\tex{1}.dds", dir, i))))
                        {
                            byte[] dat = { 0x44, 0x44, 0x53, 0x20 };
                            bw.Write(dat);
                            ddsHeader.WriteData(bw);
                            bw.Write(item.data, 0, item.DataSize);
                        }

                    }
                    i++;

                }
            }

        }
        static void Update(string fileName)
        {
            string dir = fileName.Substring(0, fileName.Length - 4);
            if(Directory.Exists(dir))
            {

                VDriveHeader header = new VDriveHeader();
                var mappings = File.ReadAllLines(dir + "/mapping.txt");
                using (var bw = new BinaryWriter(File.OpenWrite(fileName)))
                {
                    foreach (var item in mappings.Select(x => x.Split('=')))
                    {
                        int off = int.Parse(item[0]);
                        string filename = item[1];
                        var dat = File.ReadAllBytes(filename);
                        bw.BaseStream.Seek(off, SeekOrigin.Begin);

                        if (filename.Contains("GXT"))
                        {
                            bw.Write(dat);
                        }
                        else if(filename.Contains("dds"))
                        {
                            bw.Write(dat,128,dat.Length-128);

                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Dump the file first");
            }
        }
        static void OutputHelp()
        {
            //Console.WriteLine("Put this in you fuckhead before shipping");
            Console.WriteLine("usage: \n MIBUtil -d filename to dump\n MIBUtil -U filename to update from dump");
        }
        static void Main(string[] args)
        {
            if (args.Length > 1)
            {
                if (args[0] == "-d")
                {
                    dump(args[1]);
                }
                if (args[0] == "-u")
                {
                    Update(args[1]);
                }

            }
            else
            {
                OutputHelp();
            }

        }
    }
}
